using EventHubMvc.Models;

namespace EventHubMvc.Services
{
    public interface IOrganizerService
    {
        Task<List<Organizer>> GetAllOrganizersAsync();
        Task<Organizer?> GetOrganizerByIdAsync(int id);
        Task CreateOrganizerAsync(Organizer organizer);
        Task UpdateOrganizerAsync(Organizer organizer);
        Task DeleteOrganizerAsync(int id);
        Task<bool> OrganizerExistsAsync(int id);
    }
}