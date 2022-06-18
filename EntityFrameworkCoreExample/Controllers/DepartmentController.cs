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

        [HttpPost] 
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


        public async Task<IActionResult> Update(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Department department)
        {
            var departmentService = new DepartmentService();
            await departmentService.UpdateAsync(department);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var departmentService = new DepartmentService();
            await departmentService.DeleteAsync(id);

            return RedirectToAction("Index");
        }


    }
}
