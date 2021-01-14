using System;
using System.Collections.Generic;
using HMS.DAL.Repository;
using HMS.Models;

namespace HMS.BLL.RoomManager
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepo _roomRepo;

        public RoomManager(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public IEnumerable<Room> GetAllRoom(string city, int? pinCode, decimal? price, RoomCategory? roomCategory)
        {
            return _roomRepo.GetAllRoom(city, pinCode, price, roomCategory);
        }

        public Room CreateRoom(Room model)
        {
            return _roomRepo.CreateRoom(model);
        }

        public bool GetRoomAvailability(int id, DateTime date)
        {
            return _roomRepo.GetRoomAvailability(id, date);
        }
    }
}