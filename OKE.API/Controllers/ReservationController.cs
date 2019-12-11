using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OKE.Api.Data;
using OKE.Api.Models;
using OKE.API.Models;

namespace Trinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private DataContext _context;

        public ReservationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservation = await _context.Reservations.ToListAsync();

            return Ok(reservation);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditReservation(int id, [FromBody] Reservation reservation)
        {
            var data = await _context.Reservations.FindAsync(id);

            if(data == null)
            {
                return NoContent();
            }

            data.UserName = reservation.UserName;
            data.UserLastName = reservation.UserLastName;
            data.ReservationSlotId = reservation.ReservationSlotId;
            _context.Reservations.Update(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var data = await _context.Reservations.FindAsync(id);

            if(data == null)
            {
                return NoContent();
            }

            _context.Reservations.Remove(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }
    }
}