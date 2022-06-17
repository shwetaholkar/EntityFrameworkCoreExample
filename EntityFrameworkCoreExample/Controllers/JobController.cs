using EntityFrameworkCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            using var employeeContext = new EmployeeContext();
            var data = employeeContext.Jobs.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateJob(Job job)
        {
            using var employeeContext = new EmployeeContext();
            employeeContext.Jobs.Add(job);
            employeeContext.SaveChanges();

            return RedirectToAction("Create");
        }
    }
}




