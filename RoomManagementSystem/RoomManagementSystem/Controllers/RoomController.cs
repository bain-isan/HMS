using RoomManagementSystem.Models;
using RoomManagementSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RoomManagementSystem.Controllers
{

    [ApiController]
    [Route("Room")]
    public class RoomController : ControllerBase
    {
        private IRoomRepository _repo;

        public RoomController(IRoomRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return new JsonResult(new {info = "API Successfully Running..."});
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult<Room> AddRoom([FromBody] OperationOnRoom Room)
        {
            if (ModelState.IsValid)
            {
                var unique = _repo.UniqueCheck(Room);
                if (_repo.IsUnique(unique))
                {
                    var newRoom = _repo.AddRoom(Room);
                    if (newRoom != null)
                        return Created("Room", newRoom);

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
        [Route("Update/{number}")]
        public ActionResult<Room> UpdateRoom([FromBody] OperationOnRoom Room, int number)
        {
            if (ModelState.IsValid)
            {

                var newRoom = _repo.UpdateRoom(Room, number);
                if (newRoom != null)
                    return Ok(newRoom);
                return BadRequest(new { error = "User Not Exists..." });

            }
            return BadRequest(new { error = "Other Issue Occures..." });
        }

        [HttpGet]
        [Route("View/{number?}")]
        public ActionResult<Room> ViewRoom(int? number)
        {

            if (number == null)
            {
                List<Room> Rooms = _repo.GetAllRooms();
                if (Rooms != null)
                    return Ok(Rooms);
            }

            var Room = _repo.GetRoomByNumber(number);
            if (Room != null)
                return Ok(Room);

            return NotFound(new { error = "No Rooms..." });
        }

        [HttpDelete]
        [Route(("Delete/{number}"))]
        public ActionResult<Room> DeleteRoom(int number)
        {
            if (ModelState.IsValid)
            {

                var Room = _repo.DeleteRoom(number);
                if(Room != null)
                    return Ok(new {data = "Successfully Deleted..."});
                return NotFound(new {error = "No Room with Room Number: " + number});
            }
            return BadRequest();
        }
    }
}
