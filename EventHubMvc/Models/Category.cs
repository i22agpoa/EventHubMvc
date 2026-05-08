using System.ComponentModel.DataAnnotations;

namespace EventHubMvc.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; }
    }
}