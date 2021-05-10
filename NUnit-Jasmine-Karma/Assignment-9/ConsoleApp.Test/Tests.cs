using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;
using ConsoleApp.Repository;
using Moq;
using NUnit.Framework;
using Is = ConsoleApp.Test.CustomConstraints.Is;

namespace ConsoleApp.Test
{
    internal class Tests
    {
        private EmployeeRepository _employeeRepository;

        [SetUp]
        public void Setup()
        {
            // Creation of Mock object
            var employeeRepositoryMock = new Mock<EmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.GetEmployees()).Returns(
                new List<Employee>
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
                });
            _employeeRepository = employeeRepositoryMock.Object;
        }

        // Test Cases for custom constraints

        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Spaces_Positive()
        {
            // Act
            var value = " Suyash Jain ";

            // Assert
            Assert.That("Suyash Jain", Is.RemoveFirstAndLastCharacter(value));
        }

        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Both_Characters_Positive()
        {
            // Act
            var value = "Suyash Jain";

            // Assert
            Assert.That("uyash Jai", Is.RemoveFirstAndLastCharacter(value));
        }

        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_First_Character_Negative()
        {
            // Act
            var value = "Suyash Jain";

            // Assert
            Assert.AreNotEqual("Suyash Jai", Is.RemoveFirstAndLastCharacter(value));
        }

        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Last_Character_Negative()
        {
            // Act
            var value = "Suyash Jain";

            // Assert
            Assert.AreNotEqual("uyash Jain", Is.RemoveFirstAndLastCharacter(value));
        }

        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Both_Characters_Negative()
        {
            // Act
            var value = "Suyash Jain";

            // Assert
            Assert.AreNotEqual("Suyash Jain", Is.RemoveFirstAndLastCharacter(value));
        }

        // Test cases using Mock

        [Test]
        public void Employee_Count_Test_Positive()
        {
            //Assert 
            Assert.True(_employeeRepository.GetEmployees().Count == 5);
        }

        [Test]
        public void Employee_Count_Test__Negative()
        {
            //Assert 
            Assert.False(_employeeRepository.GetEmployees().Count == 3);
        }

        [Test]
        public void Employee_Department_By_id()
        {
            // Arrange
            var result = _employeeRepository.GetEmployees().FirstOrDefault(x => x.Id == 2);
            //Assert 
            Assert.AreEqual("HR", result.Department);
        }

        [Test]
        public void Employee_Name_By_Id_Test()
        {
            // Arrange
            var result = _employeeRepository.GetEmployees().FirstOrDefault(x => x.Id == 4);
            //Assert 
            Assert.AreEqual("Suyash Jain 4", result.Name);
        }

        [Test]
        public void Employee_Salary_By_Id_Test()
        {
            // Arrange
            var result = _employeeRepository.GetEmployees().FirstOrDefault(x => x.Id == 1);
            //Assert 
            Assert.AreEqual(47890, result.Salary);
        }
    }
}