using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreWebApi.Data;
using EfCoreWebApi.Data.Entities;

namespace EfCoreWebApi.DAOs;

public class ProjectDao : IProjectDao
{
    private readonly AppDbContext _context;

    public ProjectDao(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<Project?> GetByTitelAsync(string titel)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Titel.ToLower() == titel.ToLower());
    }

    public async Task<Project> CreateAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task UpdateAsync(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
    }
}
