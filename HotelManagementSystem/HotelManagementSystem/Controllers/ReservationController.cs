using HotelManagementSystem.Data;
using HotelManagementSystem.Data.Reservations;
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
    [Route("Reservation")]
    public class ReservationController : Controller
    {
        private static HttpClient _Reservation = new HttpClient();

        public ReservationController()
        {
            if (_Reservation.BaseAddress == null)
                _Reservation.BaseAddress = new Uri("https://localhost:44335/Reservation/");
        }

        public ActionResult Index()
        {
            return View("Landing");
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View("Create", new CreateReservation());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateReservation(CreateReservation Reservation)
        {
            var serialize = JsonConvert.SerializeObject(Reservation);
            var content = new StringContent(serialize, Encoding.UTF8, "application/json");


            var myReservation = await _Reservation.PostAsync("Create", content);
            if (myReservation.IsSuccessStatusCode)
                ViewBag.SuccessMsg = "Reservation Created Successfully";
            else
                ViewBag.ErrorMsg = JsonConvert.DeserializeObject<errors>(myReservation.Content.ReadAsStringAsync().Result).Error;
            return View("Create");
        }


        [HttpGet("Update")]
        public IActionResult Update()
        {
            return View("Update");
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateReservation(OperationOnReservation Reservation)
        {
            var content = new StringContent(JsonConvert.SerializeObject(Reservation), Encoding.UTF8, "application/json");
            var myReservation = await _Reservation.PutAsync("Update/" + TempData["number"], content);
            if (myReservation.IsSuccessStatusCode)
                ViewBag.SuccessMsg = "Reservation Updated Successfully...";
            else
                ViewBag.ErrorMsg = "Reservation Update UnSuccessful...";
            return View("Update");
        }

        [HttpGet("UpdateCheck")]
        [HttpPost("UpdateCheck")]
        public async Task<IActionResult> UpdateCheck(int number)
        {
            var myReservation = await _Reservation.GetAsync("View/" + number);
            if (myReservation.IsSuccessStatusCode)
            {
                TempData["number"] = number;
                var msg = JsonConvert.DeserializeObject < OperationOnReservation>(myReservation.Content.ReadAsStringAsync().Result);
                ReservationModel model = new ReservationModel { Number = number, Reservation = msg };
                ViewBag.SuccessMsg = "Reservation Found...";
                return View("Update", model);
            }
            if (myReservation.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Reservation Not Found...";
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
            var myReservation = await _Reservation.GetAsync("View/" + number);
            if (myReservation.IsSuccessStatusCode)
            {
                var msg = JsonConvert.DeserializeObject<OperationOnReservation>(myReservation.Content.ReadAsStringAsync().Result);
                ViewBag.SuccessMsg = "Reservation Found...";
                return View("View", msg);
            }
            if (myReservation.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Reservation Not Found...";
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
            var myReservation = await _Reservation.GetAsync("View");
            if (myReservation.IsSuccessStatusCode)
            {
                var msg = JsonConvert.DeserializeObject<List<OperationOnReservation>>(myReservation.Content.ReadAsStringAsync().Result);
                ViewBag.SuccessMsg = "Reservation Found...";
                return View("ViewAll", msg);
            }
            if (myReservation.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Reservation Not Found...";
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
            var myReservation = await _Reservation.DeleteAsync("Delete/" + number);
            if (myReservation.IsSuccessStatusCode)
            {

                ViewBag.SuccessMsg = "Reservation Deleted...";
                return View("Delete");
            }
            if (myReservation.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewBag.ErrorMsg = "Reservation Not Found...";
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
