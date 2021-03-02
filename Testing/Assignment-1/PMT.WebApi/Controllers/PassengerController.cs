using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using PMT.Core.Dto;
using PMT.Business.Interface;
using PMT.WebApi.Filters;

namespace PMT.WebApi.Controllers
{

    public class PassengerController : ApiController
    {
        private readonly IPassengerManager _passengerManager;

        public PassengerController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }

        // GET: api/Passenger
        public IQueryable<PassengerDto> GetPassengers()
        {
            return _passengerManager.GetPassengers();
        }

        // GET: api/Passenger/5
        public async Task<IHttpActionResult> GetPassenger(int id)
        {
            var passenger = await _passengerManager.GetPassenger(id);

            if (passenger != null)
                return Ok(passenger);

            return NotFound();
        }

        // POST: api/Passenger
        [ValidateModel]
        public async Task<IHttpActionResult> PostPassenger(PassengerDto model)
        {
            var passenger = await _passengerManager.AddPassenger(model);
            return Created("DefaultApi", passenger);
        }

        // PUT: api/Passenger/5
        [ValidateModel]
        public async Task<IHttpActionResult> PutPassenger(int id, PassengerDto model)
        {
            if (id != model.Id)
                return BadRequest();

            var isUpdated = await _passengerManager.UpdatePassenger(model);

            if (isUpdated)
                return StatusCode(HttpStatusCode.NoContent);

            return NotFound();
        }

        // DELETE: api/Passenger/5
        public async Task<IHttpActionResult> DeletePassenger(int id)
        {
            var isDeleted = await _passengerManager.DeletePassenger(id);
            if (isDeleted)
                return StatusCode(HttpStatusCode.NoContent);

            return NotFound();
        }
    }
}
