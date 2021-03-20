using System;
using System.Web.Http;
using HMS.BLL.HotelManager;
using HMS.Models;

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
        public IHttpActionResult Get()
        {
            try
            {
                var hotels = _hotelManager.GetAllHotel();
                return Ok(hotels);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var hotel = _hotelManager.GetHotel(id);
                return Ok(hotel);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Post([FromBody] Hotel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var hotel = _hotelManager.CreateHotel(model);
                return Created("successful", hotel);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}