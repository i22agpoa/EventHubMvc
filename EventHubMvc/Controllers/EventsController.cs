using EventHubMvc.Data;
using EventHubMvc.Models;
using EventHubMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventHubMvc.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ApplicationDbContext _context;

        public EventsController(IEventService eventService, ApplicationDbContext context)
        {
            _eventService = eventService;
            _context = context;
        }

        // GET: Events
        [AllowAnonymous]
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var events = await _eventService.SearchEventsAsync(searchTerm);
            ViewData["CurrentFilter"] = searchTerm;
            return View(events);
        }

        // GET: Events/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _eventService.GetEventByIdAsync(id.Value);

            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        // GET: Events/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            LoadSelectLists();
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("EventId,Title,Description,Date,Price,CategoryId,VenueId,OrganizerId")] Event eventItem)
        {
            if (ModelState.IsValid)
            {
                await _eventService.CreateEventAsync(eventItem);
                return RedirectToAction(nameof(Index));
            }

            LoadSelectLists(eventItem);
            return View(eventItem);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _eventService.GetEventByIdAsync(id.Value);

            if (eventItem == null)
            {
                return NotFound();
            }

            LoadSelectLists(eventItem);
            return View(eventItem);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Title,Description,Date,Price,CategoryId,VenueId,OrganizerId")] Event eventItem)
        {
            if (id != eventItem.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _eventService.UpdateEventAsync(eventItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _eventService.EventExistsAsync(eventItem.EventId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            LoadSelectLists(eventItem);
            return View(eventItem);
        }

        // GET: Events/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _eventService.GetEventByIdAsync(id.Value);

            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private void LoadSelectLists(Event? eventItem = null)
        {
            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "CategoryId",
                "Name",
                eventItem?.CategoryId
            );

            ViewData["OrganizerId"] = new SelectList(
                _context.Organizers,
                "OrganizerId",
                "Email",
                eventItem?.OrganizerId
            );

            ViewData["VenueId"] = new SelectList(
                _context.Venues,
                "VenueId",
                "Address",
                eventItem?.VenueId
            );
        }
    }
}