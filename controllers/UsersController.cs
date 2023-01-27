using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("login")]
        public ActionResult<string> UserLogin(ToVerifyUser user)
        {
            if (user is null)
            {
                return BadRequest(new {message = "User is null."});
            }

            var dbUser = context.Users?.FirstOrDefault(p => p.User == user.User);

            if (dbUser == null)
            {
                return NotFound(new {message = "User doesn't exists."});
            }

            if (!BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password)) {
                return Unauthorized(new {message = "Incorrect Password."});
            }

            return TokenService.GenerateToken(dbUser);
        }

        [HttpPost]
        public ActionResult UserRegister([FromBody] Users user)
        {
            if (user is null)
            {
                return BadRequest(new {message ="User is null."});
            }

            var dbUser = context.Users?.FirstOrDefault(p => p.User == user.User);

            if (dbUser != null)
            {
                return BadRequest(new {message ="User already exists."});
            }

            user.UserPhoto = "./";
            user.UserLevel = 1;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            context.Users?.Add(user);
            context.SaveChanges();

            return Created("Account created Successful.", new { id = user.Id, user = user.User });
        }
    }
}
