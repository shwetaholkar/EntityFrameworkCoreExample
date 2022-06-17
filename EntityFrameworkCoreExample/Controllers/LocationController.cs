using EntityFrameworkCoreExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreExample.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            using var employeeContext=new EmployeeContext();
            var data=employeeContext.Locations.ToList();
            return View(data);
        }     
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLocation(Location location)
        {
            using var employeeContext = new EmployeeContext();
            employeeContext.Locations.Add(location);
            employeeContext.SaveChanges(); //don't forget
            return RedirectToAction("Create");
        }
    }
}
