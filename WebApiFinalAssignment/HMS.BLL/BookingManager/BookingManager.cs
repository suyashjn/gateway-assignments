using HMS.DAL.Repository;
using HMS.Models;

namespace HMS.BLL.BookingManager
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepo _bookingRepo;

        public BookingManager(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public Booking CreateBooking(Booking model)
        {
            return _bookingRepo.CreateBooking(model);
        }

        public Booking UpdateBooking(int id, Booking model)
        {
            return _bookingRepo.UpdateBooking(id, model);
        }

        public Booking DeleteBooking(int id)
        {
            return _bookingRepo.DeleteBooking(id);
        }
    }
}