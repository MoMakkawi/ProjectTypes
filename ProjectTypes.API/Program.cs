using Microsoft.EntityFrameworkCore;

using ProjectTypes.API.Contracts;
using ProjectTypes.API.Data;
using ProjectTypes.API.Endpoints;
using ProjectTypes.API.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjectTypesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectTypesContext") ?? throw new InvalidOperationException("Connection string 'ProjectTypesContext' not found.")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProjectTypeRepository, ProjectTypeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProjectTypeEndpoints();

app.Run();

