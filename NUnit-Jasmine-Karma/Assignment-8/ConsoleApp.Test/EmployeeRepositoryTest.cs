using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ConsoleApp.Models;
using ConsoleApp.Repository;
using ConsoleApp.Test.CustomAttribute;
using ConsoleApp.Test.Utilities;
using NUnit.Framework;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            //Arrange
            _employeeRepository = new EmployeeRepository();
        }

        private EmployeeRepository _employeeRepository;

        //---------- Fluent Assertion --------------

        // Test for Exactly one record having name Suyash Jain
        [Test]
        public void GetEmployees_Test_NameIsSuyash1()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(4)
                .And.Exactly(1).Property("Name").EqualTo("Suyash Jain 1"));
        }

        // Test for Exactly one record having name Suyash Jain and having salary 65000
        [Test]
        public void GetEmployees_Test_NameIsSuyash1AndSalaryIs65000()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(4)
                .And.Exactly(1).Property("Name").EqualTo("Suyash Jain 1")
                .And.Property("Salary").EqualTo(65000));
        }

        // Test for Exactly 2 record having Salary 46000 and having exactly one record having city Mumbai
        [Test]
        public void GetEmployees_Test_SalaryIs46000AndCityIsMumbai()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(4)
                .And.Exactly(2).Property("Salary").EqualTo(46000)
                .And.Exactly(1).Property("City").EqualTo("Mumbai"));
        }

        // Test for Exactly 2 record having Salary 46000 and having exactly one record having city Mumbai and Department HR
        [Test]
        public void GetEmployees_Test_SalaryIs46000AndCityIsMumbaiAndDepartmentIsHR()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(4)
                .And.Exactly(2).Property("Salary").EqualTo(46000)
                .And.Exactly(1).Property("City").EqualTo("Mumbai")
                .And.Exactly(1).Property("Department").EqualTo("HR"));
        }

        // Test for Exactly 3 record having Salary less than 50000
        [Test]
        public void GetEmployees_Test_SalaryLessEqualTo50000()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(4)
                .And.Exactly(3).Property("Salary").LessThanOrEqualTo(50000));
        }


        //--------------- Sequential Execution ------------

        [TestOrder(2)]
        public void Test1_AddEmployee()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees();
            result.Add(new Employee {Id = 5, Name = "Suyash Jain 5", Department = "IT", City = "Pune", Salary = 46000});

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(5)
                .And.Exactly(4).Property("Salary").LessThanOrEqualTo(46000));
        }

        [TestOrder(1)]
        public void Test2_GetEmployees()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(4));
        }

        [TestOrder(4)]
        public void Test3_UpdateEmployee()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees().FirstOrDefault(x => x.Id == 1);
            result.Name = "Suyash Jain";

            //Assert
            Assert.That(result, Has
                .Property("Name").EqualTo("Suyash Jain"));
        }

        [TestOrder(3)]
        public void Test4_DeleteEmployee()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees()
                .Remove(new EmployeeRepository().GetEmployees().FirstOrDefault(x => x.Id == 1));

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestOrder(5)]
        public void Test5_DeleteAllEmployees()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees().RemoveAll(x => x.Salary < 70000);

            //Assert
            Assert.AreEqual(result, 4);
        }

        [TestCaseSource(nameof(TestSource))]
        public void MyTest(TestStructure test)
        {
            test.Test();
        }

        public static IEnumerable<TestCaseData> TestSource
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var methods = assembly
                    .GetTypes()
                    .SelectMany(x => x.GetMethods())
                    .Where(y => y.GetCustomAttributes().OfType<TestOrderAttribute>().Any())
                    .GroupBy(z => z.GetCustomAttribute<TestOrderAttribute>().Sequence)
                    .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

                foreach (var order in methods.Keys.OrderBy(x => x))
                foreach (var methodInfo in methods[order])
                {
                    var info = methodInfo;
                    yield return new TestCaseData(
                        new TestStructure
                        {
                            Test = () =>
                            {
                                var classInstance = Activator.CreateInstance(info.DeclaringType!, null);
                                info.Invoke(classInstance, null);
                            }
                        }).SetName(methodInfo.Name);
                }
            }
        }
    }
}