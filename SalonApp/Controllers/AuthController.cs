using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace SalonApp.Controllers
{
    public class AuthController : Controller
    {

        UserService us;

        public AuthController(UserService us)
        {
            this.us = us;
        }

        [HttpGet]
        public IActionResult Login()     //Login page
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO data)
        {
            if (ModelState.IsValid)
            {
                data.Password = GetMd5(data.Password);

                var user = us.Login(data);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetInt32("Role", user.Type);

                    if (user.Type == 1)
                    {
                        return RedirectToAction("Admin", "Dashboard");
                    }
                    else if (user.Type == 2)
                    {
                        return RedirectToAction("Staff", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("Customer", "Dashboard");
                    }
                }

                TempData["Msg"] = "Username and Password Invalid";
            }

            return View(data);
        }
        string GetMd5(string input)   ///MD5 hashing for password security
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        [HttpGet]
         public IActionResult Register()    //Register page
        {
            return View();
        }




        [HttpPost]
        public IActionResult Register(RegisterDTO data)
        {
            if (ModelState.IsValid)
            {
                if (data.Password != data.ConfPassword)
                {
                    TempData["Msg"] = "Password and Confirm Password does not match";
                    return View(data);
                }

                data.Password = GetMd5(data.Password);

                us.Register(data);

                return RedirectToAction("Login");
            }

            return View(data);
        }


    }
}
