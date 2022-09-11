using HotelManagementSystem.Data.Rooms;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static HttpClient room = new HttpClient();
        private static HttpClient inventory = new HttpClient();
        private static HttpClient guest = new HttpClient();
        private static HttpClient reserve = new HttpClient();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            room.BaseAddress = new Uri("https://localhost:44308/Room/");
            inventory.BaseAddress = new Uri("https://localhost:44321/Inventory/");
            guest.BaseAddress = new Uri("https://localhost:44342/Guest/");
            reserve.BaseAddress = new Uri("https://localhost:44335/Reservation/");
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
