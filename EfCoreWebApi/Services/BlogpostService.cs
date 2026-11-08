using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreWebApi.DTOs;

namespace EfCoreWebApi.Services;

public class BlogpostService : IBlogpostService
{
    // GET alle blogposts
    public Task<IEnumerable<BlogpostDto>> GetAllBlogpostsAsync()
    {
        throw new NotImplementedException();
    }

    // GET individuele blogpost
    public Task<BlogpostDto?> GetBlogpostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    // POST nieuwe blogpost
    public Task<BlogpostDto> CreateBlogpostAsync(BlogpostDto blogpostDto)
    {
        throw new NotImplementedException();
    }

    // UPDATE bestaande blogpost
    public Task<bool> UpdateBlogpostAsync(int id, BlogpostDto blogpostDto)
    {
        throw new NotImplementedException();
    }

    // DELETE bestaande blogpost
    public Task<bool> DeleteBlogpostAsync(int id)
    {
        throw new NotImplementedException();
    }
}
