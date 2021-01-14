using System.Collections.Generic;
using HMS.DAL.Repository;
using HMS.Models;

namespace HMS.BLL.HotelManager
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepo _hotelRepo;

        public HotelManager(IHotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public Hotel GetHotel(int id)
        {
            return _hotelRepo.GetHotel(id);
        }

        public IEnumerable<Hotel> GetAllHotel()
        {
            return _hotelRepo.GetAllHotel();
        }

        public Hotel CreateHotel(Hotel model)
        {
            return _hotelRepo.CreateHotel(model);
        }
    }
}