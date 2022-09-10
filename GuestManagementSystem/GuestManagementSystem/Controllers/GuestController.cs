using GuestManagementSystem.Models;
using GuestManagementSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuestManagementSystem.Controllers
{

    [ApiController]
    [Route("Guest")]
    public class GuestController : ControllerBase
    {
        private IGuestRepository _repo;

        public GuestController(IGuestRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return new JsonResult(new {info = "API Successfully Running..."});
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult<Guest> AddGuest([FromBody] OperationOnGuest guest)
        {
            if (ModelState.IsValid)
            {
                var unique = _repo.UniqueCheck(guest);
                if (_repo.IsUnique(unique))
                {
                    var newGuest = _repo.AddGuest(guest);
                    if (newGuest != null)
                        return Created("Guest", newGuest);

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
        [Route("Update/{code}")]
        public ActionResult<Guest> UpdateGuest([FromBody] OperationOnGuest guest, int code)
        {
            if (ModelState.IsValid)
            {

                var newGuest = _repo.UpdateGuest(guest, code);
                if (newGuest != null)
                    return Ok(newGuest);
                return BadRequest(new { error = "User Not Exists..." });

            }
            return BadRequest(new { error = "Other Issue Occures..." });
        }

        [HttpGet]
        [Route("View/{id?}")]
        public ActionResult<Guest> ViewGuest(int? id)
        {

            if (id == null)
            {
                List<Guest> guests = _repo.GetAllGuests();
                if (guests != null)
                    return Ok(guests);
            }

            var guest = _repo.GetGuestById(id);
            if (guest != null)
                return Ok(guest);

            return NotFound(new { error = "No Guests..." });
        }

        [HttpDelete]
        [Route(("Delete/{code}"))]
        public ActionResult<Guest> DeleteGuest(int code)
        {
            if (ModelState.IsValid)
            {

                var guest = _repo.DeleteGuest(code);
                if(guest != null)
                    return Ok(new {data = "Successfully Deleted..."});
                return NotFound(new {error = "No Guest with Code: " + code});
            }
            return BadRequest();
        }
    }
}
