using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfCoreWebApi.Services;
using EfCoreWebApi.DTOs;
using System.Linq;

namespace EfCoreWebApi.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    // GET alle projecten
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllProjectsAsync();

        if (!projects.Any()) return NotFound("No projects found.");
        return Ok(projects);
    }

    // GET individueel project
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null) return NotFound($"Project with ID {id} was not found.");
        
        return Ok(project);
    }

    // POST nieuw project
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectDto projectDto)
    {
        var createdProject = await _projectService.CreateProjectAsync(projectDto);
        return Ok(createdProject);
    }

    // UPDATE bestaand project
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProjectDto projectDto)
    {
        var updated = await _projectService.UpdateProjectAsync(id, projectDto);
        if (!updated) return NotFound($"Project with ID {id} was not found to update.");
        
        return NoContent();
    }

    // DELETE bestaand project
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _projectService.DeleteProjectAsync(id);
        if (!deleted) return NotFound($"Project with ID {id} was not found to delete.");
        
        return NoContent();
    }
}
