using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogAPI.context;
using MyBlogAPI.services;
using MyBlogAPI.Models;

namespace MyBlogApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : Controller
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [EnableCors]
    [HttpPost("login")]
    public async Task<ActionResult<string>> UserLogin(ToLoginUser? user)
    {
        if (user is null)
        {
            return BadRequest(new {message = "User is null."});
        }

        var dbUser = await _context.Users!.FirstOrDefaultAsync(p => p.User == user.User);

        if (dbUser is null)
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
    public async Task<ActionResult> UserRegister(Users? user)
    {
        if (user is null)
        {
            return BadRequest(new {message = "User is null."});
        }

        var dbUser = await _context.Users!.FirstOrDefaultAsync(p => p.User == user.User ||
                                                            p.UserEmail == user.UserEmail);

        if (dbUser != null && dbUser.User == user.User)
        {
            return BadRequest(new {error = "user-already-exist", message = "User already exists."});
        }

        if (dbUser != null && dbUser.UserEmail == user.UserEmail)
        {
            return BadRequest(new {error = "email-already-exist", message = "Email already exists."});
        }

        user.UserLevel = 1;
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.CreatedAt = DateTime.Now;
        user.UpdatedAt = DateTime.Now;

        await _context.Users!.AddAsync(user);
        await _context.SaveChangesAsync();

        return Created("/account-created", new { id = user.Id, user = user.User });
    }
}
