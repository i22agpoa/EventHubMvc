using EventHubMvc.Models;

namespace EventHubMvc.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
        Task<List<Event>> SearchAsync(string? searchTerm);
        Task AddAsync(Event eventItem);
        Task UpdateAsync(Event eventItem);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}