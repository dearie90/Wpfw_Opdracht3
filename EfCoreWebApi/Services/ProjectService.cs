using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreWebApi.DAOs;
using EfCoreWebApi.DTOs;
using EfCoreWebApi.Data.Entities;

namespace EfCoreWebApi.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectDao _projectDao;

    // DAO class dependency injection via constructor
    public ProjectService(IProjectDao projectDao)
    {
        _projectDao = projectDao;
    }

    // GET alle projecten, geeft een lijst met project DTO's
    public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        var entities = await _projectDao.GetAllAsync();
        
        // Handmatige mapping naar DTO's
        return entities.Select(e => new ProjectDto
        {
            Id = e.Id,
            Titel = e.Titel,
            Beschrijving = e.Beschrijving,
            Categorie = e.Categorie,
            GitHubUrl = e.GitHubUrl,
            Datum = e.Datum
        }).ToList();
    }

    // 2. GET project by id, geeft een Dto of null als deze niet bestaat
    public async Task<ProjectDto?> GetProjectByIdAsync(int id)
    {
        var entity = await _projectDao.GetByIdAsync(id);
        if (entity == null) return null;

        return new ProjectDto
        {
            Id = entity.Id,
            Titel = entity.Titel,
            Beschrijving = entity.Beschrijving,
            Categorie = entity.Categorie,
            GitHubUrl = entity.GitHubUrl,
            Datum = entity.Datum
        };
    }

    // POST project, returned dto die nieuwe record + ID terug geeft aan de controller
    public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto)
    {
        // Check of een project met dezelfde titel al bestaat
        var existing = await _projectDao.GetByTitelAsync(projectDto.Titel);
        if (existing != null)
        {
            // Als de post al bestaat gooien we een gecontroleerde exception die de controller veranderd voor error 400
            throw new InvalidOperationException($"Een project met de titel '{projectDto.Titel}' bestaat al.");
        }

        // Mapping van DTO naar database-entity
        var newEntity = new Project
        {
            Titel = projectDto.Titel,
            Beschrijving = projectDto.Beschrijving,
            Categorie = projectDto.Categorie,
            GitHubUrl = projectDto.GitHubUrl,
            Datum = DateTime.Now 
        };

        var createdEntity = await _projectDao.CreateAsync(newEntity);

        // Geeft DTO inclusief nieuwe ID aan controller
        return new ProjectDto
        {
            Id = createdEntity.Id,
            Titel = createdEntity.Titel,
            Beschrijving = createdEntity.Beschrijving,
            Categorie = createdEntity.Categorie,
            GitHubUrl = createdEntity.GitHubUrl,
            Datum = createdEntity.Datum
        };
    }

    // UPDATE project
    public async Task<bool> UpdateProjectAsync(int id, ProjectDto projectDto)
    {
        // Check of project al bestaat
        var entity = await _projectDao.GetByIdAsync(id);
        if (entity == null)
        {
            return false; // Id bestaat niet, controller stuurt 404 terug
        }

        // verander veranderbare velden
        entity.Titel = projectDto.Titel;
        entity.Beschrijving = projectDto.Beschrijving;
        entity.Categorie = projectDto.Categorie;
        entity.GitHubUrl = projectDto.GitHubUrl;

        // update in database
        await _projectDao.UpdateAsync(entity);
        return true; // Succes, controller stuurt 204 terug
    }

    // DELETE project
    public async Task<bool> DeleteProjectAsync(int id)
    {
        // Check of project al bestaat
        var entity = await _projectDao.GetByIdAsync(id);
        if (entity == null)
        {
            return false; // Id bestaat niet, controller stuurt 404 terug
        }

        // delete in database
        await _projectDao.DeleteAsync(entity);
        return true; // Succes, controller stuurt 204 terug
    }
}
