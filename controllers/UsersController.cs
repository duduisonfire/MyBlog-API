using Microsoft.AspNetCore.Mvc;
using MyBlogAPI.context;
using MyBlogAPI.Models;

namespace MyBlog_API.controllers
{
    [ApiController]
    [Route("api/users")]
    public class Aluno : Controller
    {
        private readonly AppDbContext _context;

        public Aluno(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<string> UserRegister(Users user)
        {
            if (user is null)
            {
                return BadRequest("User is null.");
            }

            var dbUser = _context.Users?.FirstOrDefault(p => p.User == user.User);

            if (dbUser != null)
            {
                return BadRequest("User already exists.");
            }

            user.UserPhoto = "./";
            user.UserLevel = 1;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            _context.Users?.Add(user);
            _context.SaveChanges();

            return Created("Account created Successful.", new {id = user.Id, user = user.User});
        }
    }
}
