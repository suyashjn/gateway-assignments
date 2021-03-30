using System.Collections.Generic;
using HRM.ERP.Business.Interfaces;
using HRM.ERP.Common.Models;
using HRM.ERP.Data.Repository.Interfaces;

namespace HRM.ERP.Business
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool AddEmployee(CreateEmployeeDTO model)
        {
            return _employeeRepository.AddEmployee(model);
        }

        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public List<EmployeeDTO> getAllemployees()
        {
            return _employeeRepository.getAllemployees();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public bool UpdateEmployee(EmployeeDTO model)
        {
            return _employeeRepository.UpdateEmployee(model);
        }
    }
}
