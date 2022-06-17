using EntityFrameworkCoreExample.Models;
using EntityFrameworkCoreExample.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Controllers
{
    public class DepartmentController : Controller
    {
        //public IActionResult Index()
        //{

        //    using var employeeContext=new EmployeeContext();
        //    var data = employeeContext.Departments.Include("Location").ToList();
        //    return View(data);
        //}

        public async Task<IActionResult> IndexAsync()
        {
            var departmentService = new DepartmentService();
            var departments = await departmentService.GetAllAsync();

            return View(departments);
        }

        public async Task<IActionResult> DatailsAsync(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // when we want to use post method , must include HttpPost
        public async Task<IActionResult> Create(Department department)
        {
            var departmentService = new DepartmentService();
            await departmentService.CreateAsync(department);

            return RedirectToAction("Create");
        }



        //[HttpPost]
        //public IActionResult CreateDepartment(Department department)
        //{
        //    using var employeeContext=new EmployeeContext();
        //    employeeContext.Departments.Add(department);
        //    employeeContext.SaveChanges();
        //    return RedirectToAction("Create");
        //}



    }
}
