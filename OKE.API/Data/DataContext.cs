using Microsoft.EntityFrameworkCore;

using OKE.Api.Models;
using OKE.API.Models;

namespace OKE.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationSlot> ReservationSlots { get; set; }
    }
}