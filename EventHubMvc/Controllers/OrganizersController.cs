using EventHubMvc.Models;
using EventHubMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventHubMvc.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly IOrganizerService _organizerService;

        public OrganizersController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        // GET: Organizers
        public async Task<IActionResult> Index()
        {
            return View(await _organizerService.GetAllOrganizersAsync());
        }

        // GET: Organizers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _organizerService.GetOrganizerByIdAsync(id.Value);

            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // GET: Organizers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizerId,Name,Email")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                await _organizerService.CreateOrganizerAsync(organizer);
                return RedirectToAction(nameof(Index));
            }

            return View(organizer);
        }

        // GET: Organizers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _organizerService.GetOrganizerByIdAsync(id.Value);

            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // POST: Organizers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizerId,Name,Email")] Organizer organizer)
        {
            if (id != organizer.OrganizerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _organizerService.UpdateOrganizerAsync(organizer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _organizerService.OrganizerExistsAsync(organizer.OrganizerId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(organizer);
        }

        // GET: Organizers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _organizerService.GetOrganizerByIdAsync(id.Value);

            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // POST: Organizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _organizerService.DeleteOrganizerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}