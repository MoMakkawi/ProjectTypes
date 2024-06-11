using Microsoft.EntityFrameworkCore;

using ProjectTypes.API.Contracts;
using ProjectTypes.API.Data;
using ProjectTypes.API.Models;

namespace ProjectTypes.API.Repositories;

internal class ProjectTypeRepository(ProjectTypesContext dbContext) : IProjectTypeRepository
{
    protected ProjectTypesContext _dbContext { get; set; } = dbContext;

    public async Task<ProjectType> CreateAsync(ProjectType projectType)
    {
        _dbContext.ProjectType.Add(projectType);
        await _dbContext.SaveChangesAsync();

        return projectType;
    }

    public async Task<int> DeleteAsync(int projectTypeId)
        => await _dbContext.ProjectType
                .Where(model => model.Id == projectTypeId)
                .ExecuteDeleteAsync();

    public async Task<List<ProjectType>> GetAllAsync()
        => await _dbContext.ProjectType.AsNoTracking().ToListAsync();

    public async Task<ProjectType?> GetByIdAsync(int projectTypeId)
        => await _dbContext.ProjectType.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == projectTypeId);

    public async Task<int> UpdateAsync(int projectTypeId, ProjectType projectType)
        => await _dbContext.ProjectType
                .Where(model => model.Id == projectTypeId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Name, projectType.Name)
                    );
}
