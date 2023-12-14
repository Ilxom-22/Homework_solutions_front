using AirBnB.Api.Models.Dtos;
using AirBnB.Application.Locations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetAllCategories()
    {
        return new ValueTask<IActionResult>
        (
            Ok(categoryService
                .Get()
                .Select(mapper.Map<CategoryDto>))
        );
    }
}