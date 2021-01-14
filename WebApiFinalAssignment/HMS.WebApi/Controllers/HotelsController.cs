using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using HMS.BLL.HotelManager;
using HMS.Models;
using Newtonsoft.Json;

namespace HMS.WebApi.Controllers
{
    [RoutePrefix("api/hotels")]
    public class HotelsController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HotelsController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var hotels = _hotelManager.GetAllHotel();

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(hotels),
                        Encoding.UTF8, "application/json")
                };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new {message = e.Message}),
                        Encoding.UTF8, "application/json")
                };
            }
        }

        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var hotel = _hotelManager.GetHotel(id);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(hotel),
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

        [Route("")]
        public HttpResponseMessage Post([FromBody] Hotel model)
        {
            try
            {
                var hotel = _hotelManager.CreateHotel(model);

                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(hotel),
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