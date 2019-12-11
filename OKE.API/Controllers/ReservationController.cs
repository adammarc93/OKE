using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetReservations()
        {
            var reservation = _context.Reservations.ToList();

            return Ok(reservation);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(x => x.Id == id);

            return Ok(reservation);
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return Ok(reservation);
        }

        [HttpPut("{id}")]
        public IActionResult EditReservation(int id, [FromBody] Reservation reservation)
        {
            var data = _context.Reservations.Find(id);

            if(data == null)
            {
                return NoContent();
            }

            data.UserName = reservation.UserName;
            data.UserLastName = reservation.UserLastName;
            data.ReservationSlotId = reservation.ReservationSlotId;
            _context.Reservations.Update(data);
            _context.SaveChanges();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var data = _context.Reservations.Find(id);

            if(data == null)
            {
                return NoContent();
            }

            _context.Reservations.Remove(data);
            _context.SaveChanges();

            return Ok(data);
        }
    }
}