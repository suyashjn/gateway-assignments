using System.Collections.Generic;
using ConsoleApp.Models;

namespace ConsoleApp.Repository
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee {Id = 1, Name = "Suyash Jain 1", Department = "IT", City = "Mandsaur", Salary = 65000},
                new Employee {Id = 2, Name = "Suyash Jain 2", Department = "Management", City = "Indore", Salary = 46000},
                new Employee {Id = 3, Name = "Suyash Jain 3", Department = "HR", City = "Mumbai", Salary = 46000},
                new Employee {Id = 4, Name = "Suyash Jain 4", Department = "Admin", City = "Delhi", Salary = 37800}
            };
            return employees;
        }
    }
}