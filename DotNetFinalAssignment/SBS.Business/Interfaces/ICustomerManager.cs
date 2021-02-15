using System.Collections.Generic;
using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;

namespace SBS.Business.Interfaces
{
    public interface ICustomerManager
    {
        string createCustomer(CustomerVM customer);
        CustomerVM validateCustomer(CustomerVM customer);
        CustomerVM forgotPassword(CustomerVM customer);
        string resetPassword(CustomerVM customer);
        string createVehicle(VehicleVM vehicle);
        IEnumerable<DealerDropdownModel> DealerDropdown();
        IEnumerable<ServiceDropdownModel> ServiceDropdown();
        IEnumerable<VehicleDropdownModel> VehicleDropdown(int id);
        string createAppointment(AppointBookingVM appointBookingVM);
    }
}
