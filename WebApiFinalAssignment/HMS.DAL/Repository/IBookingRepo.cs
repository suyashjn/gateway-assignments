using HMS.Models;

namespace HMS.DAL.Repository
{
    public interface IBookingRepo
    {
        Booking CreateBooking(Booking model);

        Booking UpdateBooking(int id, Booking model);

        Booking DeleteBooking(int id);
    }
}