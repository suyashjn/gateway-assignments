using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using HMS.BLL.BookingManager;
using HMS.Models;
using Newtonsoft.Json;

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
        public HttpResponseMessage Post([FromBody] Booking model)
        {
            try
            {
                var booking = _bookingManager.CreateBooking(model);

                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(booking),
                        Encoding.UTF8, "application/json")
                };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new {message = e.Message}),
                        Encoding.UTF8, "application/json")
                };
            }
        }

        [Route("{id:int}")]
        public HttpResponseMessage Put(int id, [FromBody] Booking model)
        {
            try
            {
                var booking = _bookingManager.UpdateBooking(id, model);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(booking),
                        Encoding.UTF8, "application/json")
                };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new {message = e.Message}),
                        Encoding.UTF8, "application/json")
                };
            }
        }

        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var booking = _bookingManager.DeleteBooking(id);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(booking),
                        Encoding.UTF8, "application/json")
                };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new {message = e.Message}),
                        Encoding.UTF8, "application/json")
                };
            }
        }
    }
}