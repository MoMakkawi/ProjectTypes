using Microsoft.AspNetCore.Mvc;
using ProjectTypes.UI.Models;
using ProjectTypes.UI.Services;

namespace ProjectTypes.UI.Controllers
{
    public class ProjectTypesController(ProjectTypeService projectTypeService) : Controller
    {
        protected ProjectTypeService _projectTypeService { get; set; } = projectTypeService;


        // GET: ProjectTypes
        public async Task<IActionResult> Index() => View(await _projectTypeService.GetAllProjectTypesAsync());

        // GET: ProjectTypes/Details/5
        public async Task<IActionResult> Details(int? id)
            => id is null
                ? NotFound()
                : await _projectTypeService.GetProjectTypeByIdAsync(id.Value)
                is ProjectType projectType
                    ? View(projectType)
                    : NotFound();

        // GET: ProjectTypes/Create
        public IActionResult Create() => View();

        // POST: ProjectTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProjectType projectType)
        {
            if (!ModelState.IsValid) return View(projectType);

            await _projectTypeService.CreateProjectTypeAsync(projectType);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProjectTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            return await _projectTypeService.GetProjectTypeByIdAsync(id.Value)
                is ProjectType projectType
                ? View(projectType)
                : NotFound();
        }

        // POST: ProjectTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProjectType projectType)
        {
            if (id != projectType.Id) return NotFound();

            if (!ModelState.IsValid) return View(projectType);

            var isUpdated = await _projectTypeService.UpdateProjectTypeAsync(id, projectType);
            return isUpdated ? RedirectToAction(nameof(Index)) : NotFound();

        }

        // GET: ProjectTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
            => id is null
                ? NotFound()
                : await _projectTypeService.GetProjectTypeByIdAsync(id.Value)
                    is ProjectType projectType
                    ? View(projectType)
                    : NotFound();

        // POST: ProjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDeleted = await _projectTypeService.DeleteProjectTypeAsync(id);
            return isDeleted ? RedirectToAction(nameof(Index)) : NotFound();
        }
    }
}
