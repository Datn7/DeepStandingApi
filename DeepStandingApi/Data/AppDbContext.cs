using DeepStandingApi.Models;
using Microsoft.EntityFrameworkCore;
using static CSharpBasicsApi.Controllers.BasicsController;

namespace DeepStandingApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();           // for step 2
        public DbSet<Student> Students => Set<Student>();         // for step 3
        public DbSet<Course> Courses => Set<Course>();            // for step 3

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Global filters (added in step 5)
            modelBuilder.Entity<BaseEntity>().HasDiscriminator<string>("_discriminator"); // keeps EF happy for filter inheritance
            modelBuilder.Entity<Book>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Author>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Student>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Course>().HasQueryFilter(x => !x.IsDeleted);

            // Many-to-many (step 3)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCourses"));

            // Seeding (step 7)
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Mark Twain", CreatedAt = DateTime.UtcNow },
                new Author { Id = 2, Name = "Jane Austen", CreatedAt = DateTime.UtcNow }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Tom Sawyer", AuthorId = 1, PublishedDate = new DateTime(1876, 1, 1), CreatedAt = DateTime.UtcNow },
                new Book { Id = 2, Title = "Pride and Prejudice", AuthorId = 2, PublishedDate = new DateTime(1813, 1, 1), CreatedAt = DateTime.UtcNow }
            );

            base.OnModelCreating(modelBuilder);
        }

        // Audit (step 6)
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var utcNow = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = utcNow;
                        entry.Entity.UpdatedAt = utcNow;
                        break;
                    case EntityState.Modified:
                        entry.Property(p => p.CreatedAt).IsModified = false; // never change CreatedAt
                        entry.Entity.UpdatedAt = utcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
