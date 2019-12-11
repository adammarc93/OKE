using System;

namespace OKE.Api.Models
{
    public class ReservationSlot
    {
        public int Id { get; set; }

        public int ConferenceRoomNumber { get; set; }

        public string ConferenceRoomName { get; set; }

        public DateTime StartTime {get; set; }

        public DateTime EndTime {get; set; }
    }
}