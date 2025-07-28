using System.Linq.Expressions;
using DevHabit.Api.Entities;

namespace DevHabit.Api.DTOs.Users;

internal static class UserQueries
{
    public static Expression<Func<User, UserDto>> ProjectToDto()
    {
        return x => new()
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            CreatedAtUtc = x.CreatedAtUtc,
            UpdatedAtUtc = x.UpdatedAtUtc
        };
    }
}
