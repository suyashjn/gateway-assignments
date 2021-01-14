using System.Collections.Generic;
using HMS.Models;

namespace HMS.BLL.HotelManager
{
    public interface IHotelManager
    {
        Hotel GetHotel(int id);
        IEnumerable<Hotel> GetAllHotel();
        Hotel CreateHotel(Hotel model);
    }
}