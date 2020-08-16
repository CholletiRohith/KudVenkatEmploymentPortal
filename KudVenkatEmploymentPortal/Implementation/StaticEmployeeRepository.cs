using KudVenkatEmploymentPortal.Interfaces;
using KudVenkatEmploymentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkatEmploymentPortal.Implementation
{
    public class StaticEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;
        public StaticEmployeeRepository()
        {
            employees = new List<Employee>
            {
                new Employee{ ID = 1, Name= "Rohith",Dept = Dept.IT},
                new Employee{ ID = 2, Name= "Manik",Dept = Dept.HR},
                new Employee{ ID = 3, Name= "Deepak",Dept = Dept.None},
                new Employee{ ID = 4, Name= "Niha",Dept = Dept.Payroll},


            };
        }
        public Employee CreateEmployee(Employee newEmployee)
        {
           newEmployee.ID = employees.Max(emp => emp.ID) + 1;
            employees.Add(newEmployee);
            return newEmployee;

        }

        public Employee DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(int Id)
        {
            Employee getEmp = employees.Where(emp => emp.ID == Id).FirstOrDefault();
            return getEmp;
        }

        public Employee UpdateEmployee(Employee updateEmployee)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IEmployeeRepository.GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
