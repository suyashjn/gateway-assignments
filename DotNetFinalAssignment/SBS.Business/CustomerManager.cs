using System.Collections.Generic;
using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using SBS.Business.Interfaces;
using SBS.Data.Repository.Interfaces;

namespace SBS.Business.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public string createAppointment(AppointBookingVM appointBookingVM)
        {
            return _customerRepository.createAppointment(appointBookingVM);
        }

        public string createCustomer(CustomerVM customer)
        {
            return _customerRepository.createCustomer(customer);
        }

        public string createVehicle(VehicleVM vehicle)
        {
            return _customerRepository.createVehicle(vehicle);
        }

        public IEnumerable<DealerDropdownModel> DealerDropdown()
        {
            return _customerRepository.DealerDropdown();
        }

        public CustomerVM forgotPassword(CustomerVM customer)
        {
            return _customerRepository.forgotPassword(customer);
        }

        public string resetPassword(CustomerVM customer)
        {
            return _customerRepository.resetPassword(customer);
        }

        public IEnumerable<ServiceDropdownModel> ServiceDropdown()
        {
            return _customerRepository.ServiceDropdown();
        }

        public CustomerVM validateCustomer(CustomerVM customer)
        {
            return _customerRepository.validatCustomer(customer);
        }

        public IEnumerable<VehicleDropdownModel> VehicleDropdown(int id)
        {
            return _customerRepository.VehicleDropdown(id);
        }
    }
}
