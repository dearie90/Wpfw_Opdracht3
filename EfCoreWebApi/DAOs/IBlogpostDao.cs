using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreWebApi.Data.Entities;

namespace EfCoreWebApi.DAOs;

public interface IBlogpostDao
{
    Task<IEnumerable<Blogpost>> GetAllAsync();
    Task<Blogpost?> GetByIdAsync(int id);
    Task<Blogpost?> GetByTitelAsync(string titel);
    Task<Blogpost> CreateAsync(Blogpost blogpost);
    Task UpdateAsync(Blogpost blogpost);
    Task DeleteAsync(Blogpost blogpost);
}
