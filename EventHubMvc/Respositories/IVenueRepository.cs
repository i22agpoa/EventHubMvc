using EventHubMvc.Models;

namespace EventHubMvc.Repositories
{
    public interface IVenueRepository
    {
        Task<List<Venue>> GetAllAsync();
        Task<Venue?> GetByIdAsync(int id);
        Task AddAsync(Venue venue);
        Task UpdateAsync(Venue venue);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}