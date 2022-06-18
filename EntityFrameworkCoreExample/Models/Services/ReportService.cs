using EntityFrameworkCoreExample.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Models.Services
{
    public class ReportService
    {

        public List<EmployeeDeptWise> EmployeeDeptWise()
        {
            using var employeeContext = new EmployeeContext();

            var data = (from employee in employeeContext.Employees.ToList()
                        join dept in employeeContext.Departments.ToList()
                        on employee.DepartmentRefId equals dept.Id
                        group employee by dept into g
                        select new EmployeeDeptWise
                        {
                            DeptName = g.Key.Name,
                            Employees = g.ToList(),

                        }).ToList();

            return data;

        }

        public List<EmployeeJobWise> EmployeeJobWise()
        {
            using var employeeContext = new EmployeeContext();

            var data = (from employee in employeeContext.Employees.ToList()
                        join job in employeeContext.Jobs.ToList()
                        on employee.JobId equals job.Id
                        group employee by job into g
                        select new EmployeeJobWise
                        {
                            JobName = g.Key.Name,
                            Employees = g.ToList(),

                        }).ToList();

            return data;

        }

        public List<Employee> EmployeeSalaryRange()
        {
            using var employeeContext = new EmployeeContext();
           
            var data = employeeContext.Employees.Where(x => x.Salary < 10000 || x.Salary > 20000).Include("Department").Include("Job").ToList();

            return data;
        }

        public List<Employee> EmployeeAverageSalary()
        {
            using var employeeContext = new EmployeeContext();

            var avgSalary = employeeContext.Employees.Average(x => x.Salary);
            var empSalary = (from emp in employeeContext.Employees
                             where emp.Salary < avgSalary
                             select emp).ToList();

            return empSalary;
        }
    }
}
