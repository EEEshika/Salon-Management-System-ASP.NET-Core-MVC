using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using SalonApp.AuthFilters;

namespace SalonApp.Controllers
{
    [Logged]
    public class PaymentController : Controller
    {
        PaymentService paymentService;
        AppointmentService appointmentService;

        public PaymentController(PaymentService paymentService,AppointmentService appointmentService)
        {
            this.paymentService = paymentService;
            this.appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Create(int appointmentId)
        {
            var appointment = appointmentService.Get(appointmentId);

            PaymentDTO data = new PaymentDTO();

            data.AppointmentId = appointmentId;

            return View(data);
        }

        [HttpPost]
        public IActionResult Create(PaymentDTO data)
        {
            if (ModelState.IsValid)
            {
                var res = paymentService.Create(data);

                if (res)
                {
                    TempData["Msg"] = "Payment Added Successfully";
                    TempData["Class"] = "alert-success";

                    return RedirectToAction("History", "Customer");
                }

                TempData["Msg"] = "Payment Failed";
                TempData["Class"] = "alert-danger";
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult History(int appointmentId)
        {
            var data = paymentService.GetByAppointmentId(appointmentId);

            return View(data);
        }
    }
}