using EventHubMvc.Data;
using EventHubMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHubMvc.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly ApplicationDbContext _context;

        public VenueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Venue>> GetAllAsync()
        {
            return await _context.Venues.ToListAsync();
        }

        public async Task<Venue?> GetByIdAsync(int id)
        {
            return await _context.Venues.FirstOrDefaultAsync(v => v.VenueId == id);
        }

        public async Task AddAsync(Venue venue)
        {
            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Venue venue)
        {
            _context.Venues.Update(venue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var venue = await _context.Venues.FindAsync(id);

            if (venue != null)
            {
                _context.Venues.Remove(venue);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Venues.AnyAsync(v => v.VenueId == id);
        }
    }
}