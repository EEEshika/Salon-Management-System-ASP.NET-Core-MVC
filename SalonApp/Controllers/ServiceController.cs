using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using SalonApp.AuthFilters;

namespace SalonApp.Controllers
{
    [Logged]
    public class ServiceController : Controller
    {
        ServiceService ss;

        public ServiceController(ServiceService ss)
        {
            this.ss = ss;
        }

        
        [AdminAccess]
        [HttpGet]
        public IActionResult Index()
        {
            var data = ss.Get();
            return View(data);
        }

        [AdminAccess]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [AdminAccess]
        [HttpPost]
        public IActionResult Create(ServiceDTO data)
        {
            if (ModelState.IsValid)
            {
                var res = ss.Create(data);

                if (res)
                {
                    TempData["Msg"] = "Service Added Successfully";
                    TempData["Class"] = "alert-success";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Service Add Failed";
                TempData["Class"] = "alert-danger";
            }

            return View(data);
        }

        [AdminAccess]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = ss.Get(id);

            if (data == null)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }

        [AdminAccess]
        [HttpPost]
        public IActionResult Update(ServiceDTO data)
        {
            if (ModelState.IsValid)
            {
                var res = ss.Update(data);

                if (res)
                {
                    TempData["Msg"] = "Service Updated Successfully";
                    TempData["Class"] = "alert-success";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Service Update Failed";
                TempData["Class"] = "alert-danger";
            }

            return View(data);
        }

        [AdminAccess]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var res = ss.Delete(id);

            if (res)
            {
                TempData["Msg"] = "Service Deleted Successfully";
                TempData["Class"] = "alert-success";
            }
            else
            {
                TempData["Msg"] = "Service Delete Failed";
                TempData["Class"] = "alert-danger";
            }

            return RedirectToAction("Index");
        }
    }
}