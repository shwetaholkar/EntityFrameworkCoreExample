using EntityFrameworkCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            using var employeeContext = new EmployeeContext();
            var data = employeeContext.Employees.Include("Department").Include("Job").ToList();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            using var employeeContext=new EmployeeContext();    
            employeeContext.Employees.Add(employee);
            employeeContext.SaveChanges();

            return RedirectToAction("Create");
        }
    }
}
