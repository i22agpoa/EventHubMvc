using EventHubMvc.Models;

namespace EventHubMvc.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task<List<Event>> SearchEventsAsync(string? searchTerm);
        Task CreateEventAsync(Event eventItem);
        Task UpdateEventAsync(Event eventItem);
        Task DeleteEventAsync(int id);
        Task<bool> EventExistsAsync(int id);
    }
}