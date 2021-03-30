using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;
using HRM.ERP.Data.Models;
using HRM.ERP.Common.Models;
using HRM.ERP.Data.Repository.Interfaces;

namespace HRM.ERP.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddEmployee(CreateEmployeeDTO model)
        {
            if(model != null)
            {
                var employee = _mapper.Map<Employee>(model);
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<EmployeeDTO> getAllemployees()
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();

            var employeeEntities = _context.Employees.ToList();

            if(employeeEntities != null)
            {
                foreach (var item in employeeEntities)
                {
                    EmployeeDTO employee = _mapper.Map<EmployeeDTO>(item);
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var entity = _context.Employees.Find(id);

            if(entity != null)
            {
                EmployeeDTO employee = _mapper.Map<EmployeeDTO>(entity);
                return employee;
            }
            return null;
        }

        public bool UpdateEmployee(EmployeeDTO model)
        {
            if(model != null)
            {
                var entity = _context.Employees.Find(model.ID);
                if(entity != null)
                {
                    //entity = _mapper.Map<tblEmployees>(model);

                    #region Update Employee

                    entity.Name = model.Name;
                    entity.Manager = model.Manager;
                    entity.Phone = model.Phone;
                    entity.IsManager = model.isManager;
                    entity.Department = model.Department;
                    entity.Email = model.Email;

                    #endregion

                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
