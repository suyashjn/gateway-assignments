using System.Collections.Generic;
using HRM.ERP.Common.Models;

namespace HRM.ERP.Business.Interfaces
{
    public interface IEmployeeManager
    {
        List<EmployeeDTO> getAllemployees();
        bool AddEmployee(CreateEmployeeDTO model);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(EmployeeDTO model);
        EmployeeDTO GetEmployeeById(int id);
    }
}
