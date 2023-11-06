using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.NewFolder;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {


        private readonly ApplicationContext context;

        public AccountController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = context.Users.FirstOrDefault(u => u.Email == model.Email);

                if (existingUser != null)
                {
                    TempData["alreadyExit"] = "Email Already Exists";
                    return View(model);
                }
                var User = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Phone = model.Phone,

                };
                context.Users.Add(User);
                context.SaveChanges();
                TempData["message"] = "User Added";
                return RedirectToAction("Login");
            }
            return View(model);

        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = context.Users.Where(e => e.Email == model.Email).FirstOrDefault();
                if (user != null)
                {
                    bool isCredentialTrue = (user.Password == model.Password);
                    if (isCredentialTrue)
                    {
                        HttpContext.Session.SetString("Email", model.Email);
                        TempData["SessionId"] = HttpContext.Session.Id;
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        TempData["loginErrorMessages"] = "Invalid Password";
                        return View(model);

                    }
                }
                else
                {
                    TempData["loginErrorMessages"] = "User Not Found";
                    return View(model);


                }

            }
            else
            {

                TempData["loginErrorMessages"] = "Please Fill Valid Details";
                return View(model);
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Login");
        }
    }
}
