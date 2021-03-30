using System.Collections.Generic;
using HRM.ERP.Common.Models;

namespace HRM.ERP.Data.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> getAllemployees();
        bool AddEmployee(CreateEmployeeDTO model);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(EmployeeDTO model);
        EmployeeDTO GetEmployeeById(int id);
    }
}
