using KudVenkatEmploymentPortal.Interfaces;
using KudVenkatEmploymentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkatEmploymentPortal.Implementation
{
    public class DBEmployeeRepository : IEmployeeRepository
    {
        public DBEmployeeRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        private AppDbContext AppDbContext { get; }

        public Employee CreateEmployee(Employee employee)
        {
            AppDbContext.Employees.Add(employee);
            SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee delEmployee = AppDbContext.Employees.Find(id);
            AppDbContext.Remove(delEmployee);
            SaveChanges();
            return delEmployee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return AppDbContext.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return AppDbContext.Employees.Find(Id);
        }

        public Employee UpdateEmployee(Employee updateEmployee)
        {
            var employee = AppDbContext.Employees.Update(updateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            SaveChanges();
            return updateEmployee;
        }

        public void SaveChanges()
        {
            AppDbContext.SaveChanges();
        }
    }
}
