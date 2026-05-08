using System.ComponentModel.DataAnnotations;

namespace EventHubMvc.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}