using EntityFrameworkCoreExample.Models;
using EntityFrameworkCoreExample.Models.Services;
using EntityFrameworkCoreExample.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Controllers
{

    public class ReportsController : Controller
    {

        //Display Employee information deptwise
        public IActionResult EmployeeDeptWise()
        {
            //using var employeeContext = new EmployeeContext();

            //var data = (from employee in employeeContext.Employees.ToList()
            //           join dept in employeeContext.Departments.ToList()
            //           on employee.DepartmentRefId equals dept.Id
            //           group employee by dept into g
            //           select new EmployeeDeptWise
            //           {
            //              DeptName= g.Key.Name,
            //              Employees=g.ToList(),

            //           }).ToList();

            //return View(data);

            // another way--------------
            // using var employeeContext = new EmployeeContext();
            // var data = employeeContext.Departments.Include("Employees").ToList();  // here Employees is object which are created in department table
            // return View(data);

            //--------------------------------------------------------------
            //using service class

            var reportService = new ReportService();
            var employees =  reportService.EmployeeDeptWise();

            return View(employees);
        }


        // Display Employee information jobwise
        public IActionResult EmployeeJobWise()
        {
            //using var employeeContext = new EmployeeContext();

            //var data = (from employee in employeeContext.Employees.ToList()
            //            join job in employeeContext.Jobs.ToList()
            //            on employee.JobId equals job.Id
            //            group employee by job into g
            //            select new EmployeeJobWise
            //            {
            //                JobName = g.Key.Name,
            //                Employees = g.ToList(),

            //            }).ToList();

            //return View(data);

            //--------------------------------------------------------------
            //using service class

            var reportService = new ReportService();
            var employees = reportService.EmployeeJobWise();

            return View(employees);
        }


        // Display Employees Who have salary, not in 10000 20000
        public IActionResult EmployeeSalaryRange()
        {
            //using var employeeContext = new EmployeeContext();
            ////var data = employeeContext.Employees.Include("Department").Include("Job").ToList();

            //var data =employeeContext.Employees.Where(x =>x.Salary < 10000 || x.Salary > 20000).Include("Department").Include("Job").ToList();

            //return View(data);

            //--------------------------------------------------------------
            //using service class

            var reportService = new ReportService();
            var employees = reportService.EmployeeSalaryRange();

            return View(employees);
        }


        // Display The employee who has a salary below the average salary
        public IActionResult EmployeeAverageSalary()
        {
            //using var employeeContext = new EmployeeContext();

            //var avgSalary=employeeContext.Employees.Average(x => x.Salary);
            //var empSalary = (from emp in employeeContext.Employees
            //                where emp.Salary < avgSalary
            //                select emp).ToList();

            //return View(empSalary);

            //--------------------------------------------------------------
            //using service class

            var reportService = new ReportService();
            var employees = reportService.EmployeeAverageSalary();

            return View(employees);
        }
    }
}
