using AirBnB.Application.Locations;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetAllCategories()
    {
        return new(Ok(categoryService.Get()));
    }
}