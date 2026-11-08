using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreWebApi.Data;
using EfCoreWebApi.Data.Entities;

namespace EfCoreWebApi.DAOs;

public class BlogpostDao : IBlogpostDao
{
    private readonly AppDbContext _context;

    public BlogpostDao(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Blogpost>> GetAllAsync()
    {
        return await _context.Blogposts.ToListAsync();
    }

    public async Task<Blogpost?> GetByIdAsync(int id)
    {
        return await _context.Blogposts.FindAsync(id);
    }

    public async Task<Blogpost?> GetByTitelAsync(string titel)
    {
        return await _context.Blogposts.FirstOrDefaultAsync(b => b.Titel.ToLower() == titel.ToLower());
    }

    public async Task<Blogpost> CreateAsync(Blogpost blogpost)
    {
        await _context.Blogposts.AddAsync(blogpost);
        await _context.SaveChangesAsync();
        return blogpost;
    }

    public async Task UpdateAsync(Blogpost blogpost)
    {
        _context.Blogposts.Update(blogpost);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Blogpost blogpost)
    {
        _context.Blogposts.Remove(blogpost);
        await _context.SaveChangesAsync();
    }
}
