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
public class CategoriesController(ICategoryService categoryService, IMapper mapper, IOptions<ApiSettings> apiSettings) : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetAllCategories()
    {
        var result = categoryService.Get().Select(mapper.Map<CategoryDto>).ToList();

        result.ForEach(category => category.ImageUrl = category.ImageUrl.ToUrl(apiSettings.Value.BaseUrl));

        return new ValueTask<IActionResult>(Ok(result));
    }
}