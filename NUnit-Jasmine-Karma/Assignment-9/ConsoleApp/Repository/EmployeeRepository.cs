using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp.Repository
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1, Name = "Suyash Jain 1", Department = "IT",
                Address = "Mandsaur", Phone = "9999999991", Salary = 47890
            },
            new Employee
            {
                Id = 2, Name = "Suyash Jain 2", Department = "HR",
                Address = "Mumbai", Phone = "9999999992", Salary = 34000
            },
            new Employee
            {
                Id = 3, Name = "Suyash Jain 3", Department = "Infra",
                Address = "Pune", Phone = "9999999993", Salary = 34000
            },
            new Employee
            {
                Id = 4, Name = "Suyash Jain 4", Department = "Admin",
                Address = "Indore", Phone = "9999999994", Salary = 57000
            },
            new Employee
            {
                Id = 5, Name = "Suyash Jain 5", Department = "Legal",
                Address = "Delhi", Phone = "9999999995", Salary = 38000
            }
        };

        public virtual List<Employee> GetEmployees()
        {
            return _employees;
        }

        public virtual Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }
    }
}