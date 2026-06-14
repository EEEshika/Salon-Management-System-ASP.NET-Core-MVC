using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using SalonApp.AuthFilters;

namespace SalonApp.Controllers
{
    [Logged]
    public class AppointmentController : Controller
    {
        AppointmentService appointmentService;
        StaffService staffService;
        ServiceService serviceService;
        CustomerService customerService;

        public AppointmentController(AppointmentService appointmentService, StaffService staffService, ServiceService serviceService, CustomerService customerService)
        {
            this.appointmentService = appointmentService;
            this.staffService = staffService;
            this.serviceService = serviceService;
            this.customerService = customerService;
        }

        [AdminAccess]
        [HttpGet]
        public IActionResult Index()
        {
            var data = appointmentService.Get();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Staffs = staffService.Get();
            ViewBag.Services = serviceService.Get();

            return View(new AppointmentDTO());
        }

        [HttpPost]
        public IActionResult Create(AppointmentDTO data)
        {
            var role = HttpContext.Session.GetInt32("Role");
            if (role == 3)
            {
                int userId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

                var customer = customerService.GetByUserId(userId);

                data.CustomerId = customer.Id;
            }

            if (ModelState.IsValid)
            {
                var res = appointmentService.Create(data);

                if (res)
                {
                    TempData["Msg"] = "Appointment Added Successfully";
                    TempData["Class"] = "alert-success";

                    return RedirectToAction("History", "Customer");
                }

                TempData["Msg"] = "Appointment Add Failed";
                TempData["Class"] = "alert-danger";
            }

            ViewBag.Staffs = staffService.Get();
            ViewBag.Services = serviceService.Get();

            return View(data);
        }

        [AdminAccess]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = appointmentService.Get(id);

            if (data == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Staffs = staffService.Get();
            ViewBag.Services = serviceService.Get();

            return View(data);
        }

        [AdminAccess]
        [HttpPost]
        public IActionResult Update(AppointmentDTO data)
        {
            if (ModelState.IsValid)
            {
                var res = appointmentService.Update(data);

                if (res)
                {
                    TempData["Msg"] = "Appointment Updated Successfully";
                    TempData["Class"] = "alert-success";

                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Appointment Update Failed";
                TempData["Class"] = "alert-danger";
            }

            ViewBag.Staffs = staffService.Get();
            ViewBag.Services = serviceService.Get();

            return View(data);
        }

        [AdminAccess]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var res = appointmentService.Delete(id);

            if (res)
            {
                TempData["Msg"] = "Appointment Deleted Successfully";
                TempData["Class"] = "alert-success";
            }
            else
            {
                TempData["Msg"] = "Appointment Delete Failed";
                TempData["Class"] = "alert-danger";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult CustomerAppointments(int id)
        {
            var data = appointmentService.GetByCustomerId(id);

            return View(data);
        }
    }
}