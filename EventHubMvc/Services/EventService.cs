using EventHubMvc.Models;
using EventHubMvc.Repositories;

namespace EventHubMvc.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int id)
        {
            return await _eventRepository.GetByIdAsync(id);
        }

        public async Task<List<Event>> SearchEventsAsync(string? searchTerm)
        {
            return await _eventRepository.SearchAsync(searchTerm);
        }

        public async Task CreateEventAsync(Event eventItem)
        {
            await _eventRepository.AddAsync(eventItem);
        }

        public async Task UpdateEventAsync(Event eventItem)
        {
            await _eventRepository.UpdateAsync(eventItem);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _eventRepository.DeleteAsync(id);
        }

        public async Task<bool> EventExistsAsync(int id)
        {
            return await _eventRepository.ExistsAsync(id);
        }
    }
}