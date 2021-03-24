using System;
using System.Web.Http;
using HMS.BLL.RoomManager;
using HMS.Models;

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
        public IHttpActionResult Get(string city, int? pinCode, decimal? price, RoomCategory? roomCategory)
        {
            try
            {
                var rooms = _roomManager.GetAllRoom(city, pinCode, price, roomCategory);
                return Ok(rooms);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{id:int}/availability")]
        public IHttpActionResult GetAvailability(int id, DateTime date)
        {
            try
            {
                var availability = _roomManager.GetRoomAvailability(id, date);
                return Ok(availability);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Room model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var room = _roomManager.CreateRoom(model);
                return Created("Successful", room);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}