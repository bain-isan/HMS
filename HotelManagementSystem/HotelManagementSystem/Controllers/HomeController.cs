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

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public async Task<string> Index()
        //{


        //        var myRoom = JsonSerializer.Serialize(new Room
        //        {
        //            RoomFloor = 1,
        //            RoomType = "Bed",
        //            RoomNumber = 126,
        //            MaxPersonAllowed = 3,
        //            Price = 7000
        //        });
        //        var sc = new StringContent(myRoom, Encoding.UTF8, "application/json");
        //        var put = await room.PutAsync("Update/" + 126, sc);

        //        await room.DeleteAsync("Delete/" + 125);

        //        HttpResponseMessage msg = await room.GetAsync("View");
        //        //HttpResponseMessage msg1 = await room.PostAsync("Create", sc);
        //        if (msg.IsSuccessStatusCode)
        //        {

        //            return (msg.Content.ReadAsStringAsync().Result);
        //        }

        //        return null;
        //    }

        //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //    public IActionResult Error()
        //    {
        //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
        //}
    }
}
