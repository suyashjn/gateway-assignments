using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMT.Business.Interface;
using PMT.Core.Dto;
using PMT.Data.Repository;

namespace PMT.Business
{
    public class PassengerManager : IPassengerManager
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerManager(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<PassengerDto> AddPassenger(PassengerDto model)
        {
            return await _passengerRepository.AddPassenger(model);
        }

        public async Task<PassengerDto> GetPassenger(int id)
        {
            return await _passengerRepository.GetPassenger(id);
        }

        public IQueryable<PassengerDto> GetPassengers()
        {
            return _passengerRepository.GetPassengers();
        }

        public async Task<bool> UpdatePassenger(PassengerDto model)
        {
            return await _passengerRepository.UpdatePassenger(model);
        }

        public async Task<bool> DeletePassenger(int id)
        {
            return await _passengerRepository.DeletePassenger(id);
        }
    }
}
