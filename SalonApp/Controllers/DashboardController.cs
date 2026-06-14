using Microsoft.AspNetCore.Mvc;
using SalonApp.AuthFilters;

namespace SalonApp.Controllers
{
    [Logged]
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Admin()
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }

            return RedirectToAction("Login", "Auth");
        }


        [HttpGet]
        public IActionResult Staff()
        {
            if (HttpContext.Session.GetInt32("Role") == 2)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }

            return RedirectToAction("Login", "Auth");
        }


        [HttpGet]
        public IActionResult Customer()
        {
            if (HttpContext.Session.GetInt32("Role") == 3)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }

            return RedirectToAction("Login", "Auth");
        }
    }
}