using AirBnB.Api.Models.Dtos;
using AirBnB.Api.Settings;
using AirBnB.Application.Locations;
using AirBnB.Domain.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AirBnB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController(ILocationService locationService, IMapper mapper, IOptions<ApiSettings> apiSettings) : ControllerBase
{
    [HttpGet("{categoryId}:guid")]
    public ValueTask<IActionResult> GetLocationsByCategoryId([FromRoute]Guid categoryId)
    {
        var result = locationService.GetByCategoryId(categoryId, true).Select(mapper.Map<LocationDto>).ToList();

        result.ForEach(location => location.ImageUrl = location.ImageUrl.ToUrl(apiSettings.Value.BaseUrl));

        return new(Ok(result));
    }

    [HttpGet]
    public ValueTask<IActionResult> GetLocations()
    {
        var result = locationService.Get().Select(mapper.Map<LocationDto>).ToList();

        result.ForEach(location => location.ImageUrl = location.ImageUrl.ToUrl(apiSettings.Value.BaseUrl));

        return new(Ok(result));
    }
}