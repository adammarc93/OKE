using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetReservationSlots()
        {
            var reservationSlot = _context.ReservationSlots.ToList();

            return Ok(reservationSlot);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservationSlot(int id)
        {
            var reservationSlot = _context.ReservationSlots.FirstOrDefault(x => x.Id == id);

            return Ok(reservationSlot);
        }

        [HttpPost]
        public IActionResult AddReservationSlot([FromBody] ReservationSlot reservationSlot)
        {
            _context.ReservationSlots.Add(reservationSlot);
            _context.SaveChanges();

            return Ok(reservationSlot);
        }

        [HttpPut("{id}")]
        public IActionResult EditReservationSlot(int id, [FromBody] ReservationSlot reservationSlot)
        {
            var data = _context.ReservationSlots.Find(id);

            if(data == null)
            {
                return NoContent();
            }

            data.ConferenceRoomName = reservationSlot.ConferenceRoomName;
            data.ConferenceRoomNumber = reservationSlot.ConferenceRoomNumber;
            data.Time = reservationSlot.Time;
            _context.ReservationSlots.Update(data);
            _context.SaveChanges();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservationSlot(int id)
        {
            var data = _context.ReservationSlots.Find(id);

            if(data == null)
            {
                return NoContent();
            }

            _context.ReservationSlots.Remove(data);
            _context.SaveChanges();

            return Ok(data);
        }
    }
}