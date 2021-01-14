using System;
using System.Collections.Generic;
using HMS.Models;

namespace HMS.BLL.RoomManager
{
    public interface IRoomManager
    {
        IEnumerable<Room> GetAllRoom(string city, int? pinCode, decimal? price,
            RoomCategory? roomCategory);

        Room CreateRoom(Room model);

        bool GetRoomAvailability(int id, DateTime date);
    }
}