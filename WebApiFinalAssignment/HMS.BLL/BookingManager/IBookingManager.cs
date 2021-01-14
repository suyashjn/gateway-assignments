using HMS.Models;

namespace HMS.BLL.BookingManager
{
    public interface IBookingManager
    {
        Booking CreateBooking(Booking model);
        Booking UpdateBooking(int id, Booking model);
        Booking DeleteBooking(int id);
    }
}