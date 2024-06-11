using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using ProjectTypes.UI.Models;
using ProjectTypes.UI.Services;

namespace ProjectTypes.UI.Controllers;

public class HomeController(ILogger<HomeController> logger, ProjectTypeService projectTypeService) : Controller
{
    protected ProjectTypeService _projectTypeService { get; set; } = projectTypeService;
    private readonly ILogger<HomeController> _logger = logger;

    // GET: ProjectTypes
    public async Task<IActionResult> Index() => View(await _projectTypeService.GetAllProjectTypesAsync());

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
