using System.ComponentModel.DataAnnotations;

namespace EventHubMvc.Models
{
    public class Organizer
    {
        public int OrganizerId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; }
    }
}