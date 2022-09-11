using HotelManagementSystem.Data;
using HotelManagementSystem.Data.Guests;
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
    [Route("Guest")]
    public class GuestController : Controller
    {
        private static HttpClient _Guest = new HttpClient();

        public GuestController()
        {
            if (_Guest.BaseAddress == null)
                _Guest.BaseAddress = new Uri("https://localhost:44342/Guest/");
        }

        public ActionResult Index()
        {
            return View("Landing");
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View("Create", new Guest());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateGuest(Guest Guest)
        {
            var serialize = JsonConvert.SerializeObject(Guest);
            var content = new StringContent(serialize, Encoding.UTF8, "application/json");


            var myGuest = await _Guest.PostAsync("Create", content);
            if (myGuest.IsSuccessStatusCode)
                ViewBag.SuccessMsg = "Guest Created Successfully";
            else
                ViewBag.ErrorMsg = JsonConvert.DeserializeObject<errors>(myGuest.Content.ReadAsStringAsync().Result).Error;
            return View("Create");
        }


        [HttpGet("Update")]
        public IActionResult Update()
        {
            return View("Update");
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateGuest(Guest Guest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(Guest), Encoding.UTF8, "application/json");
            var myGuest = await _Guest.PutAsync("Update/" + TempData["number"], content);
            if (myGuest.IsSuccessStatusCode)
                ViewBag.SuccessMsg = "Guest Updated Successfully...";
            else
                ViewBag.ErrorMsg = "Guest Update UnSuccessful...";
            return View("Update");
        }

        [HttpGet("UpdateCheck")]
        [HttpPost("UpdateCheck")]
        public async Task<IActionResult> UpdateCheck(int number)
        {
            var myGuest = await _Guest.GetAsync("View/" + number);
            if (myGuest.IsSuccessStatusCode)
            {
                TempData["number"] = number;
                var msg = JsonConvert.DeserializeObject<Guest>(myGuest.Content.ReadAsStringAsync().Result);
                GuestModel model = new GuestModel { Number = number, Guest = msg };
                ViewBag.SuccessMsg = "Guest Found...";
                return View("Update", model);
            }
            if (myGuest.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Guest Not Found...";
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
            var myGuest = await _Guest.GetAsync("View/" + number);
            if (myGuest.IsSuccessStatusCode)
            {
                var msg = JsonConvert.DeserializeObject<Guest>(myGuest.Content.ReadAsStringAsync().Result);
                ViewBag.SuccessMsg = "Guest Found...";
                return View("View", msg);
            }
            if (myGuest.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Guest Not Found...";
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
            var myGuest = await _Guest.GetAsync("View");
            if (myGuest.IsSuccessStatusCode)
            {
                var msg = JsonConvert.DeserializeObject<List<Guest>>(myGuest.Content.ReadAsStringAsync().Result);
                ViewBag.SuccessMsg = "Guest Found...";
                return View("ViewAll", msg);
            }
            if (myGuest.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Guest Not Found...";
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
            var myGuest = await _Guest.DeleteAsync("Delete/" + number);
            if (myGuest.IsSuccessStatusCode)
            {

                ViewBag.SuccessMsg = "Guest Deleted...";
                return View("Delete");
            }
            if (myGuest.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Guest Not Found...";
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
