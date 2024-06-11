using ProjectTypes.API.Models;

namespace ProjectTypes.API.Contracts;

internal interface IProjectTypeRepository
{
    Task<ProjectType> CreateAsync(ProjectType projectType);
    Task<int> DeleteAsync(int projectTypeId);
    Task<List<ProjectType>> GetAllAsync();
    Task<ProjectType?> GetByIdAsync(int projectTypeId);
    Task<int> UpdateAsync(int projectTypeId, ProjectType projectType);
}
