using System;
using System.Collections.Generic;
using System.Linq;
using HMS.DAL.Database;
using HMS.Models;
using Room = HMS.Models.Room;

namespace HMS.DAL.Repository
{
    public class RoomRepo : IRoomRepo
    {
        private readonly HMSContext _dbContext;

        public RoomRepo(HMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Room> GetAllRoom(string city, int? pinCode, decimal? price,
            RoomCategory? roomCategory)
        {
            var entities = _dbContext.Rooms
                .Where(e => (city == null || e.Hotel.City == city) &&
                            (pinCode == null || e.Hotel.PinCode == pinCode.Value) &&
                            (price == null || e.RoomPrice <= price.Value) &&
                            (roomCategory == null || e.RoomCategory == (byte) roomCategory.Value))
                .OrderBy(e => e.RoomPrice)
                .ToList();

            var rooms = new List<Room>();

            if (entities.Count > 0)
                foreach (var item in entities)
                    rooms.Add(new Room
                    {
                        Id = item.Id,
                        RoomName = item.RoomName,
                        RoomCategory = (RoomCategory) item.RoomCategory,
                        RoomPrice = item.RoomPrice,
                        IsActive = item.IsActive,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy,
                        UpdatedDate = item.UpdatedDate,
                        UpdatedBy = item.UpdatedBy,
                        HotelId = item.HotelId
                    });

            return rooms;
        }

        public Room CreateRoom(Room model)
        {
            var entity = _dbContext.Rooms.Add(new Database.Room
            {
                RoomName = model.RoomName,
                RoomCategory = (byte) model.RoomCategory,
                RoomPrice = model.RoomPrice,
                IsActive = model.IsActive,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy,
                HotelId = model.HotelId
            });

            _dbContext.SaveChanges();

            var room = new Room
            {
                Id = entity.Id,
                RoomName = entity.RoomName,
                RoomCategory = (RoomCategory) entity.RoomCategory,
                RoomPrice = entity.RoomPrice,
                IsActive = entity.IsActive,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                HotelId = entity.HotelId
            };

            return room;
        }

        public bool GetRoomAvailability(int id, DateTime date)
        {
            if (_dbContext.Rooms.Find(id) != null)
            {
                var entity = _dbContext.Bookings
                    .FirstOrDefault(e => e.RoomId == id && e.BookingDate.Day == date.Day &&
                                         (e.BookingStatus == (byte) BookingStatus.Optional ||
                                          e.BookingStatus == (byte) BookingStatus.Definitive));

                if (entity != null)
                    return false;

                return true;
            }

            return false;
        }
    }
}