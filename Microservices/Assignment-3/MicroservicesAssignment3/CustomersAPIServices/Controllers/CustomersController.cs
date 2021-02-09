using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomersAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]  
        public IEnumerable<string> Get()  
        {  
            return new[] { "Suyash Jain", "John Doe" };  
        }  
  
        [HttpGet("{id}")]  
        public string Get(int id)  
        {  
            return $"Suyash Jain - {id}";  
        }
    }
}
