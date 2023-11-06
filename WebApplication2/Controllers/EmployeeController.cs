using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.NewFolder;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            TempData["message"] = "Employee Loaded";
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    Email = model.Email,
                    Country = model.Country

                };
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["message"] = "Employee Added";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var emp = context.Employees.SingleOrDefault(emp => emp.Id == id);
                var result = new Employee
                {
                    Name = emp.Name,
                    Gender = emp.Gender,
                    Email = emp.Email,
                    Country = emp.Country
                };
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var emp = context.Employees.SingleOrDefault(emp => emp.Id == id);
                context.Employees.Remove(emp);
                context.SaveChanges();
                TempData["message"] = "Employee Deleted";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult EditProceed(Employee model)
        {
            try
            {
                var result = new Employee
                {
                    Id = model.Id,
                    Name = model.Name,
                    Gender = model.Gender,
                    Email = model.Email,
                    Country = model.Country
                };
                context.Employees.Update(result);
                context.SaveChanges();
                TempData["message"] = "Employee Edited";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

    }
}
