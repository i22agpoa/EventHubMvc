using EventHubMvc.Models;
using EventHubMvc.Repositories;

namespace EventHubMvc.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;

        public OrganizerService(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<List<Organizer>> GetAllOrganizersAsync()
        {
            return await _organizerRepository.GetAllAsync();
        }

        public async Task<Organizer?> GetOrganizerByIdAsync(int id)
        {
            return await _organizerRepository.GetByIdAsync(id);
        }

        public async Task CreateOrganizerAsync(Organizer organizer)
        {
            await _organizerRepository.AddAsync(organizer);
        }

        public async Task UpdateOrganizerAsync(Organizer organizer)
        {
            await _organizerRepository.UpdateAsync(organizer);
        }

        public async Task DeleteOrganizerAsync(int id)
        {
            await _organizerRepository.DeleteAsync(id);
        }

        public async Task<bool> OrganizerExistsAsync(int id)
        {
            return await _organizerRepository.ExistsAsync(id);
        }
    }
}