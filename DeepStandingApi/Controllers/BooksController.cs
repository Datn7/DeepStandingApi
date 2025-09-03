using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeepStandingApi.Data;
using DeepStandingApi.Models;

namespace DeepStandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(AppDbContext db) : ControllerBase
    {
        // GET /api/books?search=&sort=title|date&dir=asc|desc&page=1&pageSize=10&authorId=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get(
            [FromQuery] string? search, [FromQuery] string? sort = "date", [FromQuery] string? dir = "desc",
            [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] int? authorId = null)
        {
            IQueryable<Book> q = db.Books.Include(b => b.Author);

            if (!string.IsNullOrWhiteSpace(search))
                q = q.Where(b => b.Title.Contains(search));

            if (authorId is not null)
                q = q.Where(b => b.AuthorId == authorId);

            q = (sort?.ToLowerInvariant()) switch
            {
                "title" => (dir == "asc" ? q.OrderBy(b => b.Title) : q.OrderByDescending(b => b.Title)),
                _ => (dir == "asc" ? q.OrderBy(b => b.PublishedDate) : q.OrderByDescending(b => b.PublishedDate))
            };

            var total = await q.CountAsync();
            var items = await q.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            Response.Headers["X-Total-Count"] = total.ToString();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetOne(int id)
        {
            var book = await db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            db.Books.Add(book);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOne), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Book input)
        {
            if (id != input.Id) return BadRequest();

            var existing = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (existing is null) return NotFound();

            existing.Title = input.Title;
            existing.PublishedDate = input.PublishedDate;
            existing.AuthorId = input.AuthorId;

            await db.SaveChangesAsync();
            return NoContent();
        }

        // Soft delete (step 5)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book is null) return NotFound();

            book.IsDeleted = true;
            await db.SaveChangesAsync();
            return NoContent();
        }

        // Restore (step 5)
        [HttpPost("{id:int}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var book = await db.Books.IgnoreQueryFilters().FirstOrDefaultAsync(b => b.Id == id);
            if (book is null) return NotFound();

            book.IsDeleted = false;
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
