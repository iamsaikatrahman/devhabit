using System.Dynamic;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading;
using DevHabit.Api.Database;
using DevHabit.Api.DTOs.Users;
using DevHabit.Api.Entities;
using DevHabit.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Controllers;
[Authorize]
[ApiController]
[Route("users")]
internal sealed class UserController(ApplicationDbContext dbContext, UserContext userContext) : Controller
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(string id, CancellationToken cancellationToken)
    {
        string? userId = await userContext.GetUserIdAsync();
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Unauthorized();
        }

        if (id != userId)
        {
            return Forbid();
        }

        UserDto? user = await dbContext.Users
            .Where(x => x.Id == id)
            .Select(UserQueries.ProjectToDto())
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
    
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        string? userId = await userContext.GetUserIdAsync();
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Unauthorized(); 
        }

        UserDto? user = await dbContext.Users
            .Where(x => x.Id == userId)
            .Select(UserQueries.ProjectToDto())
            .FirstOrDefaultAsync();

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    
}
