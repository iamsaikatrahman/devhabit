using System.Dynamic;
using System.Linq.Dynamic.Core;
using System.Threading;
using DevHabit.Api.Database;
using DevHabit.Api.DTOs.Users;
using DevHabit.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Controllers;
[ApiController]
[Route("users")]
internal sealed class UserController(ApplicationDbContext dbContext) : Controller
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(string id, CancellationToken cancellationToken)
    {
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

    
}
