using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using SalonApp.AuthFilters;

namespace SalonApp.Controllers
{
    [Logged]
    public class StaffController : Controller
    {
        StaffService staffService;
        AppointmentService appointmentService;
        ServiceService serviceService;


        public StaffController(StaffService staffService, AppointmentService appointmentService, ServiceService serviceService)
        {
            this.staffService = staffService;
            this.appointmentService = appointmentService;
            this.serviceService = serviceService;
        }


        [AdminAccess]
        [HttpGet]
        public IActionResult Index()
        {
            var data = staffService.Get();
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
        public IActionResult Create(StaffDTO data)
        {
            if (ModelState.IsValid)
            {
                var res = staffService.Create(data);

                if (res)
                {
                    TempData["Msg"] = "Staff Added Successfully";
                    TempData["Class"] = "alert-success";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Staff Add Failed";
                TempData["Class"] = "alert-danger";
            }

            return View(data);
        }


        [AdminAccess]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = staffService.Get(id);

            if (data == null)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }

        [AdminAccess]
        [HttpPost]
        public IActionResult Update(StaffDTO data)
        {
            if (ModelState.IsValid)
            {
                var res = staffService.Update(data);

                if (res)
                {
                    TempData["Msg"] = "Staff Updated Successfully";
                    TempData["Class"] = "alert-success";

                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Staff Update Failed";
                TempData["Class"] = "alert-danger";
            }

            return View(data);
        }



        [AdminAccess]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var res = staffService.Delete(id);

            if (res)
            {
                TempData["Msg"] = "Staff Deleted Successfully";
                TempData["Class"] = "alert-success";
            }
            else
            {
                TempData["Msg"] = "Staff Delete Failed";
                TempData["Class"] = "alert-danger";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult MyAppointments()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var staffs = staffService.GetAllByUserId((int)userId!);

            List<int> staffIds = new List<int>();

            foreach (var item in staffs)
            {
                staffIds.Add(item.Id);
            }

            var data = appointmentService.GetByStaffIds(staffIds);

            return View(data);
        }


        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var res = appointmentService.UpdateStatus(id, status);

            if (res)
            {
                TempData["Msg"] = "Status Updated Successfully";
                TempData["Class"] = "alert-success";
            }
            else
            {
                TempData["Msg"] = "Status Update Failed";
                TempData["Class"] = "alert-danger";
            }

            return RedirectToAction("MyAppointments");
        }


        [HttpGet]
        public IActionResult Services()
        {
            var data = serviceService.Get();
            return View(data);
        }
    }
}