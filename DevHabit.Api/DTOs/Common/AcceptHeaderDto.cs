using System.Net.Http.Headers;
using DevHabit.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevHabit.Api.DTOs.Common;

public record AcceptHeaderDto
{
    [FromHeader(Name = "Accept")]
    public string? Accept { get; init; }
    public bool IncludeLinks =>
        MediaTypeHeaderValue.TryParse(Accept, out MediaTypeHeaderValue? mediaType) &&
        mediaType?.MediaType?.Contains(CustomMediaTypeNames.Application.HateoasSubType, StringComparison.OrdinalIgnoreCase) == true;
}
