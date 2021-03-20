using System;
using System.Web.Http;
using HMS.BLL.BookingManager;
using HMS.Models;

namespace HMS.WebApi.Controllers
{
    [RoutePrefix("api/bookings")]
    public class BookingsController : ApiController
    {
        private readonly IBookingManager _bookingManager;

        public BookingsController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Booking model)
        {
            if (model == null)
                return BadRequest();

            try
            {
                var booking = _bookingManager.CreateBooking(model);
                return Created("Successful", booking);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody] Booking model)
        {
            try
            {
                var booking = _bookingManager.UpdateBooking(id, model);
                return Ok(booking);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var booking = _bookingManager.DeleteBooking(id);
                return Ok("delete successful");
            }
            catch (Exception e)
            {
               return InternalServerError(e);
            }
        }
    }
}