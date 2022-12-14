using HotelManagementSystem.Data;
using HotelManagementSystem.Data.Rooms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Route("Room")]
    public class RoomController : Controller
    {
        private static HttpClient _room = new HttpClient();

        public RoomController()
        {
            if (_room.BaseAddress == null)
                _room.BaseAddress = new Uri("https://localhost:44308/Room/");
        }

        public ActionResult Index()
        {
            return View("Landing");
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View("Create", new Room());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateRoom(Room room)
        {
            var serialize = JsonConvert.SerializeObject(room);
            var content = new StringContent(serialize, Encoding.UTF8, "application/json");


            var myRoom = await _room.PostAsync("Create", content);
            if (myRoom.IsSuccessStatusCode)
                ViewBag.SuccessMsg = "Room Created Successfully";
            else
                ViewBag.ErrorMsg = JsonConvert.DeserializeObject<errors>(myRoom.Content.ReadAsStringAsync().Result).Error;
            return View("Create");
        }


        [HttpGet("Update")]
        public IActionResult Update()
        {
            return View("Update");
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateRoom(Room room)
        {
            var content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
            var myRoom = await _room.PutAsync("Update/" + TempData["number"], content);
            if (myRoom.IsSuccessStatusCode)
                ViewBag.SuccessMsg = "Room Updated Successfully...";
            else
                ViewBag.ErrorMsg = "Room Update UnSuccessful...";
            return View("Update");
        }

        [HttpGet("UpdateCheck")]
        [HttpPost("UpdateCheck")]
        public async Task<IActionResult> UpdateCheck(int number)
        {
            var myRoom = await _room.GetAsync("View/" + number);
            if (myRoom.IsSuccessStatusCode)
            {
                TempData["number"] = number;
                var msg = JsonConvert.DeserializeObject<Room>(myRoom.Content.ReadAsStringAsync().Result);
                RoomModel model = new RoomModel { Number = number, Room = msg };
                ViewBag.SuccessMsg = "Room Found...";
                return View("Update", model);
            }
            if (myRoom.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Room Not Found...";
                return View("Update");
            }
            else
            {
                ViewBag.ErrorMsg = "Some Other Error...";
                return View("Update");
            }
        }

        [HttpGet("View")]
        public IActionResult ViewOne(int number)
        {
            return View("View");
        }


        [HttpPost("View")]
        public async Task<IActionResult> View(int number)
        {
            var myRoom = await _room.GetAsync("View/" + number);
            if (myRoom.IsSuccessStatusCode)
            {
                var msg = JsonConvert.DeserializeObject<Room>(myRoom.Content.ReadAsStringAsync().Result);
                ViewBag.SuccessMsg = "Room Found...";
                return View("View", msg);
            }
            if (myRoom.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Room Not Found...";
                return View("View");
            }
            else
            {
                ViewBag.ErrorMsg = "Some Other Error...";
                return View("View");
            }
        }

        [HttpGet("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var myRoom = await _room.GetAsync("View");
            if (myRoom.IsSuccessStatusCode)
            {
                var msg = JsonConvert.DeserializeObject<List<Room>>(myRoom.Content.ReadAsStringAsync().Result);
                ViewBag.SuccessMsg = "Room Found...";
                return View("ViewAll", msg);
            }
            if (myRoom.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Room Not Found...";
                return View("ViewAll");
            }
            else
            {
                ViewBag.ErrorMsg = "Some Other Error...";
                return View("ViewAll");
            }
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int number)
        {
            var myRoom = await _room.DeleteAsync("Delete/" + number);
            if (myRoom.IsSuccessStatusCode)
            {
                
                ViewBag.SuccessMsg = "Room Deleted...";
                return View("Delete");
            }
            if (myRoom.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Room Not Found...";
                return View("Delete");
            }
            else
            {
                ViewBag.ErrorMsg = "Some Other Error...";
                return View("Delete");
            }
        }
    }
}
