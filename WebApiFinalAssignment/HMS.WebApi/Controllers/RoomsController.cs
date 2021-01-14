using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using HMS.BLL.RoomManager;
using HMS.Models;
using Newtonsoft.Json;

namespace HMS.WebApi.Controllers
{
    [RoutePrefix("api/rooms")]
    public class RoomsController : ApiController
    {
        private readonly IRoomManager _roomManager;

        public RoomsController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [Route("")]
        public HttpResponseMessage Get(string city, int? pinCode, decimal? price, RoomCategory? roomCategory)
        {
            try
            {
                var rooms = _roomManager.GetAllRoom(city, pinCode, price, roomCategory);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(rooms),
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

        [Route("{id:int}/availability")]
        public HttpResponseMessage GetAvailability(int id, DateTime date)
        {
            try
            {
                var availability = _roomManager.GetRoomAvailability(id, date);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new {availability}),
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
        public HttpResponseMessage Post([FromBody] Room model)
        {
            try
            {
                var room = _roomManager.CreateRoom(model);

                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(room),
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