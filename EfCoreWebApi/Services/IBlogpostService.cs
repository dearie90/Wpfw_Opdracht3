using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreWebApi.DTOs;

namespace EfCoreWebApi.Services;

public interface IBlogpostService
{
    // GET alle blogposts
    Task<IEnumerable<BlogpostDto>> GetAllBlogpostsAsync();

    // GET individuele blogpost
    Task<BlogpostDto?> GetBlogpostByIdAsync(int id);

    // POST nieuwe blogpost
    Task<BlogpostDto> CreateBlogpostAsync(BlogpostDto blogpostDto);

    // UPDATE bestaande blogpost
    Task<bool> UpdateBlogpostAsync(int id, BlogpostDto blogpostDto);

    // DELETE bestaande blogpost
    Task<bool> DeleteBlogpostAsync(int id);
}
