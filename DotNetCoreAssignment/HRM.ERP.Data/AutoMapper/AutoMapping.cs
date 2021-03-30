using AutoMapper;
using HRM.ERP.Common.Models;
using HRM.ERP.Data.Models;

namespace HRM.ERP.Data.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<CreateEmployeeDTO, Employee >();
            CreateMap<EmployeeDTO, Employee>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}
