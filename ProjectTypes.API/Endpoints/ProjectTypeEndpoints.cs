using Microsoft.AspNetCore.Http.HttpResults;
using ProjectTypes.API.Models;
using ProjectTypes.API.Contracts;
namespace ProjectTypes.API.Endpoints;

public static class ProjectTypeEndpoints
{
    public static void MapProjectTypeEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ProjectType").WithTags(nameof(ProjectType));

        group.MapGet("/", async (IProjectTypeRepository projectTypeRepository) 
            => await projectTypeRepository.GetAllAsync())
        .WithName("GetAllProjectTypes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ProjectType>, NotFound>> (int id, IProjectTypeRepository projectTypeRepository) =>
        {
            return await projectTypeRepository.GetByIdAsync(id)
                is ProjectType model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProjectTypeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, ProjectType projectType, IProjectTypeRepository projectTypeRepository) =>
        {
            var affected = await projectTypeRepository.UpdateAsync(id, projectType);
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProjectType")
        .WithOpenApi();

        group.MapPost("/", async (ProjectType projectType, IProjectTypeRepository projectTypeRepository) =>
        {
            projectType = await projectTypeRepository.CreateAsync(projectType);
            return TypedResults.Created($"/api/ProjectType/{projectType.Id}", projectType);
        })
        .WithName("CreateProjectType")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, IProjectTypeRepository projectTypeRepository) =>
        {
            var affected = await projectTypeRepository.DeleteAsync(id);
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProjectType")
        .WithOpenApi();
    }
}
