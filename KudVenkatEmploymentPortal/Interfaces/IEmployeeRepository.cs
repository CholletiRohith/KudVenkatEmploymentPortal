using KudVenkatEmploymentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkatEmploymentPortal.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployees();

        Employee UpdateEmployee(Employee updateEmployee);

        Employee DeleteEmployee(int id);

        Employee CreateEmployee(Employee employee);
    }
}
