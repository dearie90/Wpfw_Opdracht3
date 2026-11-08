using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreWebApi.Data.Entities;

namespace EfCoreWebApi.DAOs;

public interface IProjectDao
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project?> GetByTitelAsync(string titel);
    Task<Project> CreateAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(Project project);
}
