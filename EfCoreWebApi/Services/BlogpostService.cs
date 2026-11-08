using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreWebApi.DAOs;
using EfCoreWebApi.DTOs;
using EfCoreWebApi.Data.Entities;

namespace EfCoreWebApi.Services;

public class BlogpostService : IBlogpostService
{
    private readonly IBlogpostDao _blogpostDao;

    // DAO class dependency injection via constructor
    public BlogpostService(IBlogpostDao blogpostDao)
    {
        _blogpostDao = blogpostDao;
    }

    // GET alle blogposts, geeft een lijst met blogpost DTO's
    public async Task<IEnumerable<BlogpostDto>> GetAllBlogpostsAsync()
    {
        var entities = await _blogpostDao.GetAllAsync();
        
        // Handmatige mapping naar DTO's
        return entities.Select(e => new BlogpostDto
        {
            Id = e.Id,
            Titel = e.Titel,
            Inhoud = e.Inhoud,
            Publicatiedatum = e.Publicatiedatum
        }).ToList();
    }

    // 2. GET blogpost by id, geeft een Dto of null als deze niet bestaat
    public async Task<BlogpostDto?> GetBlogpostByIdAsync(int id)
    {
        var entity = await _blogpostDao.GetByIdAsync(id);
        if (entity == null) return null;

        return new BlogpostDto
        {
            Id = entity.Id,
            Titel = entity.Titel,
            Inhoud = entity.Inhoud,
            Publicatiedatum = entity.Publicatiedatum
        };
    }

    // POST blogpost, returned dto die nieuwe record + ID terug geeft aan de controller
    public async Task<BlogpostDto> CreateBlogpostAsync(BlogpostDto blogpostDto)
    {
        // Check of een blogpost met dezelfde titel al bestaat
        var existing = await _blogpostDao.GetByTitelAsync(blogpostDto.Titel);
        if (existing != null)
        {
            // Als de post al bestaat gooien we een gecontroleerde exception die de controller veranderd voor error 400
            throw new InvalidOperationException($"Een blogpost met de titel '{blogpostDto.Titel}' bestaat al.");
        }

        // Mapping van DTO naar database-entity
        var newEntity = new Blogpost
        {
            Titel = blogpostDto.Titel,
            Inhoud = blogpostDto.Inhoud,
            Publicatiedatum = DateTime.Now 
        };

        var createdEntity = await _blogpostDao.CreateAsync(newEntity);

        // Geeft DTO inclusief nieuwe ID aan controller
        return new BlogpostDto
        {
            Id = createdEntity.Id,
            Titel = createdEntity.Titel,
            Inhoud = createdEntity.Inhoud,
            Publicatiedatum = createdEntity.Publicatiedatum
        };
    }

    // UPDATE blogpost
    public async Task<bool> UpdateBlogpostAsync(int id, BlogpostDto blogpostDto)
    {
        // Check of blogpost al bestaat
        var entity = await _blogpostDao.GetByIdAsync(id);
        if (entity == null)
        {
            return false; // Id bestaat niet, controller stuurt 404 terug
        }

        // verander veranderbare velden
        entity.Titel = blogpostDto.Titel;
        entity.Inhoud = blogpostDto.Inhoud;

        // update in database
        await _blogpostDao.UpdateAsync(entity);
        return true; // Succes, controller stuurt 204 terug
    }

    // DELETE blogpost
    public async Task<bool> DeleteBlogpostAsync(int id)
    {
        // Check of blogpost al bestaat
        var entity = await _blogpostDao.GetByIdAsync(id);
        if (entity == null)
        {
            return false; // Id bestaat niet, controller stuurt 404 terug
        }

        // delete in database
        await _blogpostDao.DeleteAsync(entity);
        return true; // Succes, controller stuurt 204 terug
    }
}
