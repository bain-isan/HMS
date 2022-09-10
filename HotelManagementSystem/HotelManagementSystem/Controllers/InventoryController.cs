using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
