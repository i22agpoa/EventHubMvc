using System.ComponentModel.DataAnnotations;

namespace EventHubMvc.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }

        public int NumberOfTickets { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }

        public int AttendeeId { get; set; }
        public Attendee? Attendee { get; set; }
    }
}