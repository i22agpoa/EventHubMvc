using System.ComponentModel.DataAnnotations;

namespace EventHubMvc.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }

        [Required]
        [StringLength(120)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public ICollection<Reservation>? Reservations { get; set; }
    }
}