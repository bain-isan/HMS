using ReservationManagementSystem.Models;
using ReservationManagementSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ReservationManagementSystem.Data;

namespace ReservationManagementSystem.Controllers
{

    [ApiController]
    [Route("Reservation")]
    public class ReservationController : ControllerBase
    {
        private IReservationRepository _repo;

        public ReservationController(IReservationRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return new JsonResult(new {info = "API Successfully Running..."});
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult<Reservation> AddReservation([FromBody] OperationOnReservation Reservation)
        {
            if (ModelState.IsValid)
            {
                var unique = _repo.UniqueCheck(Reservation);
                if (_repo.IsUnique(unique))
                {
                    var newReservation = _repo.AddReservation(Reservation);
                    if (newReservation != null)
                        return Created("Reservation", newReservation);

                    return BadRequest(new { error = "Addition Failed..." });
                }
                else
                {
                    return Conflict(new { error = _repo.UniqueCheckMsg(unique) });
                }
            }

            return BadRequest(new { error = "Some Error Occures" });
        }

        [HttpPut]
        [Route("Update/{id}")]
        public ActionResult<Reservation> UpdateReservation([FromBody] OperationOnReservation Reservation, int id)
        {
            if (ModelState.IsValid)
            {

                var newReservation = _repo.UpdateReservation(Reservation, id);
                if (newReservation != null)
                    return Ok(newReservation);
                return BadRequest(new { error = "User Not Exists..." });

            }
            return BadRequest(new { error = "Other Issue Occures..." });
        }

        [HttpGet]
        [Route("View/{id?}")]
        public ActionResult<Reservation> ViewReservation(int? id)
        {

            if (id == null)
            {
                List<Reservation> Reservations = _repo.GetAllReservations();
                if (Reservations != null)
                    return Ok(Reservations);
            }

            var Reservation = _repo.GetReservationById(id);
            if (Reservation != null)
                return Ok(Reservation);

            return NotFound(new { error = "No Reservations..." });
        }

        [HttpGet]
        [Route("EmptyRooms")]
        public ActionResult<Reservation> EmptyRooms()
        {
            var emptyRooms = _repo.SearchEmptyRoom();
            if(emptyRooms.Count > 0)
            {
                return Ok(emptyRooms);
            }
            return Ok("No Rooms Available...");
        }
        
    }
}
