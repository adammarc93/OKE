namespace OKE.API.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int ReservationSlotId { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }
    }
}