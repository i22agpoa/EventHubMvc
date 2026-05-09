using EventHubMvc.Models;

namespace EventHubMvc.Services
{
    public interface IVenueService
    {
        Task<List<Venue>> GetAllVenuesAsync();
        Task<Venue?> GetVenueByIdAsync(int id);
        Task CreateVenueAsync(Venue venue);
        Task UpdateVenueAsync(Venue venue);
        Task DeleteVenueAsync(int id);
        Task<bool> VenueExistsAsync(int id);
    }
}