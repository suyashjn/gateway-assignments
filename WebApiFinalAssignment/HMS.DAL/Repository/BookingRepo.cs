using System;
using HMS.DAL.Database;
using HMS.Models;
using Booking = HMS.Models.Booking;

namespace HMS.DAL.Repository
{
    public class BookingRepo : IBookingRepo
    {
        private readonly HMSContext _dbContext;

        public BookingRepo(HMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Booking CreateBooking(Booking model)
        {
            var booking = new Database.Booking
            {
                RoomId = model.RoomId,
                BookingDate = model.BookingDate,
                BookingStatus = (byte) BookingStatus.Optional
            };

            var entity = _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();

            return new Booking
            {
                Id = entity.Id,
                BookingDate = entity.BookingDate,
                RoomId = entity.RoomId,
                BookingStatus = (BookingStatus) entity.BookingStatus
            };
        }

        public Booking UpdateBooking(int id, Booking model)
        {
            var entity = _dbContext.Bookings.Find(id);

            if (entity != null)
            {
                entity.BookingDate = model.BookingDate;
                entity.BookingStatus = (byte) model.BookingStatus;


                _dbContext.SaveChanges();

                return new Booking
                {
                    Id = entity.Id,
                    BookingDate = entity.BookingDate,
                    RoomId = entity.RoomId,
                    BookingStatus = (BookingStatus) entity.BookingStatus
                };
            }

            throw new Exception("Booking with  given id doesn't exists");
        }

        public Booking DeleteBooking(int id)
        {
            var entity = _dbContext.Bookings.Find(id);

            if (entity != null)
            {
                entity.BookingStatus = (byte) BookingStatus.Deleted;

                _dbContext.SaveChanges();

                return new Booking
                {
                    Id = entity.Id,
                    BookingDate = entity.BookingDate,
                    RoomId = entity.RoomId,
                    BookingStatus = (BookingStatus) entity.BookingStatus
                };
            }

            throw new Exception("Booking with  given id doesn't exists");
        }
    }
}