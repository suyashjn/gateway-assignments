using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMT.Core.Dto;

namespace PMT.Business.Interface
{
    public interface IPassengerManager
    {
        Task<PassengerDto> AddPassenger(PassengerDto model); 
        Task<PassengerDto> GetPassenger(int id);
        IQueryable<PassengerDto> GetPassengers();
        Task<bool> UpdatePassenger(PassengerDto model);
        Task<bool> DeletePassenger(int id);
    }
}
