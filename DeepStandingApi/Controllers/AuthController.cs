using DeepStandingApi.Data;
using DeepStandingApi.Dtos;
using DeepStandingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DeepStandingApi.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly AppDbContext _context;
            private readonly IConfiguration _config;

            public AuthController(AppDbContext context, IConfiguration config)
            {
                _context = context;
                _config = config;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDto dto)
            {
                if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                    return BadRequest("Email already in use.");

                using var hmac = new HMACSHA512();
                var user = new UserModel
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    PasswordSalt = hmac.Key,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password))
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { user.Id, user.Username, user.Email });
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto dto)
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
                if (user == null) return Unauthorized("Invalid email or password");

                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                if (!computedHash.SequenceEqual(user.PasswordHash))
                    return Unauthorized("Invalid email or password");

                var token = CreateToken(user);
                return Ok(new { token });
            }

            private string CreateToken(UserModel user)
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(_config["Jwt:ExpiresInMinutes"])),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }

