using EventHubMvc.Models;
using EventHubMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventHubMvc.Controllers
{
    public class VenuesController : Controller
    {
        private readonly IVenueService _venueService;

        public VenuesController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        // GET: Venues
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _venueService.GetAllVenuesAsync());
        }

        // GET: Venues/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _venueService.GetVenueByIdAsync(id.Value);

            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // GET: Venues/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("VenueId,Name,City,Address,Capacity")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                await _venueService.CreateVenueAsync(venue);
                return RedirectToAction(nameof(Index));
            }

            return View(venue);
        }

        // GET: Venues/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _venueService.GetVenueByIdAsync(id.Value);

            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // POST: Venues/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("VenueId,Name,City,Address,Capacity")] Venue venue)
        {
            if (id != venue.VenueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _venueService.UpdateVenueAsync(venue);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _venueService.VenueExistsAsync(venue.VenueId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(venue);
        }

        // GET: Venues/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _venueService.GetVenueByIdAsync(id.Value);

            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _venueService.DeleteVenueAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}