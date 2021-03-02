using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PMT.Core.Dto;
using PMT.Data.Models;

namespace PMT.Data.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly PMTContext _dbContext;

        public PassengerRepository()
        {
            _dbContext = new PMTContext();
        }

        public async Task<PassengerDto> AddPassenger(PassengerDto model)
        {
            var passenger = new Passenger
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MobileNo = model.MobileNo
            };

            _dbContext.Passengers.Add(passenger);
            await _dbContext.SaveChangesAsync();

            var dto = new PassengerDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MobileNo = model.MobileNo
            };

            return dto;
        }

        public IQueryable<PassengerDto> GetPassengers()
        {
            var books = _dbContext.Passengers.Select(p =>
                new PassengerDto()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    MobileNo = p.MobileNo

                });

            return books;
        }

        public async Task<PassengerDto> GetPassenger(int id)
        {
            var book = await _dbContext.Passengers.Select(p =>
                new PassengerDto()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    MobileNo = p.MobileNo

                }).FirstOrDefaultAsync(p => p.Id == id);

            if (book != null)
                return book;

            return null;
        }


        public async Task<bool> UpdatePassenger(PassengerDto model)
        {
            var entity = await _dbContext.Passengers.FindAsync(model.Id);
            if (entity != null)
            {
                _dbContext.Entry(entity).CurrentValues.SetValues(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeletePassenger(int id)
        {
            var entity = await _dbContext.Passengers.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Passengers.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
