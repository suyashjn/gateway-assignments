using AutoMapper;
using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using SBS.Data.Models;

namespace SBS.Data.AutoMapperConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CustomerVM,Customer>();
            CreateMap<Customer,CustomerVM>();
            CreateMap<Customer, CustomerDropdownModel>();
            CreateMap<VehicleVM, Vehicle>();
            CreateMap<Vehicle, VehicleVM>();
            CreateMap<Dealer, DealerVM>();
            CreateMap<DealerVM,Dealer>();
            CreateMap<Mechanic, MechanicVM>();
            CreateMap<MechanicVM, Mechanic>();
            CreateMap<Service, ServiceVM>();
            CreateMap<ServiceVM, Service>();
            CreateMap<Dealer, DealerDropdownModel>();
            CreateMap<Service, ServiceDropdownModel>();
            CreateMap<Vehicle, VehicleDropdownModel>();
            CreateMap<AppointBookingVM, AppointBooking>();
            CreateMap<AppointBooking, AppointBookingVM>();
        }
    }
}
