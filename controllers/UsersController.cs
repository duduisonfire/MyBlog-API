using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog_API.models;
using MyBlogAPI.context;
using MyBlogAPI.services;

namespace MyBlog_API.controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly AppDbContext context;

        public UserController(AppDbContext context)
        {
            this.context = context;
        }

        [EnableCors]
        [HttpPost("login")]
        public async Task<ActionResult<string>> UserLogin(ToLoginUser user)
        {
            if (user is null)
            {
                return BadRequest(new {message = "User is null."});
            }

            var dbUser = await context.Users!.FirstOrDefaultAsync(p => p.User == user.User);

            if (dbUser == null)
            {
                return NotFound(new {message = "User doesn't exists."});
            }

            if (!BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password)) {
                return Unauthorized(new {message = "Incorrect Password."});
            }

            return TokenService.GenerateToken(dbUser);
        }

        [EnableCors]
        [HttpPost("register")]
        public async Task<ActionResult> UserRegister([FromBody] Users user)
        {
            if (user is null)
            {
                return BadRequest(new {message = "User is null."});
            }

            var dbUser = await context.Users!.FirstOrDefaultAsync(p => p.User == user.User);

            if (dbUser != null)
            {
                return BadRequest(new {message = "User already exists."});
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await context.Users!.AddAsync(user);
            await context.SaveChangesAsync();

            return Created("Account created Successful.", new { id = user.Id, user = user.User });
        }
    }
}
