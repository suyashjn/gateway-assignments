using System.Collections.Generic;
using HMS.Models;

namespace HMS.DAL.Repository
{
    public interface IHotelRepo
    {
        Hotel GetHotel(int id);
        List<Hotel> GetAllHotel();
        Hotel CreateHotel(Hotel model);
    }
}