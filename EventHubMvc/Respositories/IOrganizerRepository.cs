using EventHubMvc.Models;

namespace EventHubMvc.Repositories
{
    public interface IOrganizerRepository
    {
        Task<List<Organizer>> GetAllAsync();
        Task<Organizer?> GetByIdAsync(int id);
        Task AddAsync(Organizer organizer);
        Task UpdateAsync(Organizer organizer);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}