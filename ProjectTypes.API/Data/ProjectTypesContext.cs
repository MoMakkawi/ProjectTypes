using Microsoft.EntityFrameworkCore;

using ProjectTypes.API.Models;

namespace ProjectTypes.API.Data;

public class ProjectTypesContext(DbContextOptions<ProjectTypesContext> options) : DbContext(options)
{
    public DbSet<ProjectType> ProjectType { get; set; } = default!;
}
