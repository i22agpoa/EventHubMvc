using System.ComponentModel.DataAnnotations;

namespace EventHubMvc.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int VenueId { get; set; }
        public Venue? Venue { get; set; }

        public int OrganizerId { get; set; }
        public Organizer? Organizer { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}