using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreWebApi.DTOs;

namespace EfCoreWebApi.Services;

public interface IProjectService
{
    // GET alle Projects
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    // GET individuele Project
    Task<ProjectDto?> GetProjectByIdAsync(int id);
    // POST nieuwe Project
    Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);
    // UPDATE bestaande Project
    Task<bool> UpdateProjectAsync(int id, ProjectDto projectDto);
    // DELETE bestaande Project
    Task<bool> DeleteProjectAsync(int id);
}
