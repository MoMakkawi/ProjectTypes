namespace ProjectTypes.UI.Services;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectTypes.UI.Models;

public class ProjectTypeService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    private static readonly string apiURL = "https://localhost:9999/api";
    public async Task<List<ProjectType>> GetAllProjectTypesAsync()
        => await _httpClient.GetFromJsonAsync<List<ProjectType>>($"{apiURL}/ProjectType") ?? [];

    public async Task<ProjectType?> GetProjectTypeByIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<ProjectType>($"{apiURL}/ProjectType/{id}");

    public async Task<ProjectType?> CreateProjectTypeAsync(ProjectType projectType)
    {
        var response = await _httpClient.PostAsJsonAsync($"{apiURL}/ProjectType", projectType);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ProjectType>();
    }

    public async Task<bool> UpdateProjectTypeAsync(int id, ProjectType projectType)
    {
        var response = await _httpClient.PutAsJsonAsync($"{apiURL}/ProjectType/{id}", projectType);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProjectTypeAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{apiURL}/ProjectType/{id}");
        return response.IsSuccessStatusCode;
    }
}
