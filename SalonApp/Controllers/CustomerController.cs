using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using SalonApp.AuthFilters;
using System;

namespace SalonApp.Controllers
{

    [Logged]
    public class CustomerController : Controller
    {
        CustomerService customerService;
        AppointmentService appointmentService;
        ServiceService serviceService;

        public CustomerController
        (CustomerService customerService,AppointmentService appointmentService,ServiceService serviceService)
        {
            this.customerService = customerService;
            this.appointmentService = appointmentService;
            this.serviceService = serviceService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Services()
        {
            var data = serviceService.Get();

            return View(data);
        }

        [HttpGet]
        public IActionResult History()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

            var customer = customerService.GetByUserId(userId);

            var data = appointmentService.GetByCustomerId(customer.Id);

            return View(data);
        }
    }
}