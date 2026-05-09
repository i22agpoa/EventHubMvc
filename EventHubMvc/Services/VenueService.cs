using EventHubMvc.Models;
using EventHubMvc.Repositories;

namespace EventHubMvc.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository _venueRepository;

        public VenueService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public async Task<List<Venue>> GetAllVenuesAsync()
        {
            return await _venueRepository.GetAllAsync();
        }

        public async Task<Venue?> GetVenueByIdAsync(int id)
        {
            return await _venueRepository.GetByIdAsync(id);
        }

        public async Task CreateVenueAsync(Venue venue)
        {
            await _venueRepository.AddAsync(venue);
        }

        public async Task UpdateVenueAsync(Venue venue)
        {
            await _venueRepository.UpdateAsync(venue);
        }

        public async Task DeleteVenueAsync(int id)
        {
            await _venueRepository.DeleteAsync(id);
        }

        public async Task<bool> VenueExistsAsync(int id)
        {
            return await _venueRepository.ExistsAsync(id);
        }
    }
}