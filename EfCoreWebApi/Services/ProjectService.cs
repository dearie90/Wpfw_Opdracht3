using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreWebApi.DTOs;

namespace EfCoreWebApi.Services;

public class ProjectService : IProjectService
{
    // GET alle Projects
    public Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        throw new NotImplementedException();
    }

    // GET individuele Project
    public Task<ProjectDto?> GetProjectByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    // POST nieuwe Project
    public Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto)
    {
        throw new NotImplementedException();
    }

    // UPDATE bestaande Project
    public Task<bool> UpdateProjectAsync(int id, ProjectDto projectDto)
    {
        throw new NotImplementedException();
    }

    // DELETE bestaande Project
    public Task<bool> DeleteProjectAsync(int id)
    {
        throw new NotImplementedException();
    }
}
