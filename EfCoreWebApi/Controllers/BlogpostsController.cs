using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfCoreWebApi.Services;
using EfCoreWebApi.DTOs;

namespace EfCoreWebApi.Controllers;

[ApiController]
[Route("api/blogposts")]
public class BlogpostsController : ControllerBase
{
    private readonly IBlogpostService _blogpostService;

    public BlogpostsController(IBlogpostService blogpostService)
    {
        _blogpostService = blogpostService;
    }

    // GET alle blogposts
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogposts = await _blogpostService.GetAllBlogpostsAsync();

        if (!blogposts.Any()) return NotFound("No blogposts found.");
        return Ok(blogposts);
    }

    // GET individuele blogpost
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var blogpost = await _blogpostService.GetBlogpostByIdAsync(id);
        if (blogpost == null) return NotFound($"Blogpost with ID {id} was not found.");
        
        return Ok(blogpost);
    }

    // POST nieuwe blogpost
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BlogpostDto blogpostDto)
    {
        var createdBlogpost = await _blogpostService.CreateBlogpostAsync(blogpostDto);
        return Ok(createdBlogpost);
    }

    // UPDATE bestaande blogpost
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] BlogpostDto blogpostDto)
    {
        var updated = await _blogpostService.UpdateBlogpostAsync(id, blogpostDto);
        if (!updated) return NotFound($"Blogpost with ID {id} was not found to update.");
        
        return NoContent();
    }

    // DELETE bestaande blogpost
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _blogpostService.DeleteBlogpostAsync(id);
        if (!deleted) return NotFound($"Blogpost with ID {id} was not found to delete.");
        
        return NoContent();
    }
}
