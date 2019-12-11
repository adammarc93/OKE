using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OKE.Api.Data;
using OKE.Api.Models;

namespace Trinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationSlotController : ControllerBase
    {
        private DataContext _context;

        public ReservationSlotController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservationSlots()
        {
            var reservationSlot = await _context.ReservationSlots.ToListAsync();

            return Ok(reservationSlot);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationSlot(int id)
        {
            var reservationSlot = await _context.ReservationSlots.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(reservationSlot);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservationSlot([FromBody] ReservationSlot reservationSlot)
        {
            _context.ReservationSlots.Add(reservationSlot);
            await _context.SaveChangesAsync();

            return Ok(reservationSlot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditReservationSlot(int id, [FromBody] ReservationSlot reservationSlot)
        {
            var data = await _context.ReservationSlots.FindAsync(id);

            if(data == null)
            {
                return NoContent();
            }

            data.ConferenceRoomName = reservationSlot.ConferenceRoomName;
            data.ConferenceRoomNumber = reservationSlot.ConferenceRoomNumber;
            data.Time = reservationSlot.Time;
            _context.ReservationSlots.Update(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationSlot(int id)
        {
            var data = await _context.ReservationSlots.FindAsync(id);

            if(data == null)
            {
                return NoContent();
            }

            _context.ReservationSlots.Remove(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }
    }
}