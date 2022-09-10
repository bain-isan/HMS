using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Controllers
{

    [ApiController]
    [Route("Inventory")]
    public class InventoryController : ControllerBase
    {
        private IInventoryRepository _repo;

        public InventoryController(IInventoryRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return new JsonResult(new {info = "API Successfully Running..."});
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult<Inventory> AddInventory([FromBody] OperationOnInventory Inventory)
        {
            if (ModelState.IsValid)
            {
                var unique = _repo.UniqueCheck(Inventory);
                if (_repo.IsUnique(unique))
                {
                    var newInventory = _repo.AddInventory(Inventory);
                    if (newInventory != null)
                        return Created("Inventory", newInventory);

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
        public ActionResult<Inventory> UpdateInventory([FromBody] OperationOnInventory Inventory, int code)
        {
            if (ModelState.IsValid)
            {
                var unique = _repo.RoomCheck(Inventory);
                if (_repo.IsUnique(unique))
                {
                    var newInventory = _repo.UpdateInventory(Inventory, code);
                    if (newInventory != null)
                        return Ok(newInventory);
                    return BadRequest(new { error = "User Not Exists..." });
                }
                else
                {
                    return Conflict(new { error = _repo.UniqueCheckMsg(unique) });
                }
                    

            }
            return BadRequest(new { error = "Other Issue Occures..." });
        }

        [HttpGet]
        [Route("View/{number?}")]
        public ActionResult<Inventory> ViewInventory(int? code)
        {

            if (code == null)
            {
                List<Inventory> Inventorys = _repo.GetAllInventorys();
                if (Inventorys != null)
                    return Ok(Inventorys);
            }

            var Inventory = _repo.GetInventoryByNumber(code);
            if (Inventory != null)
                return Ok(Inventory);

            return NotFound(new { error = "No Inventorys..." });
        }

        [HttpDelete]
        [Route(("Delete/{number}"))]
        public ActionResult<Inventory> DeleteInventory(int code)
        {
            if (ModelState.IsValid)
            {

                var Inventory = _repo.DeleteInventory(code);
                if(Inventory != null)
                    return Ok(new {data = "Successfully Deleted..."});
                return NotFound(new {error = "No Inventory with Inventory Code: " + code });
            }
            return BadRequest();
        }
    }
}
