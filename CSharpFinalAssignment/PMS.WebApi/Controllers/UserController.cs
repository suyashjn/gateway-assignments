using System.Web.Http;
using PMS.Business.ManagerInterface;
using PMS.Common.Models;

namespace PMS.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost, Route("RegisterUser")]
        public string CreateUser([FromBody]User model)
        {
            return _userManager.CreateUser(model);
        }

        [HttpPost, Route("Login")]
        public UserViewModel GetUser([FromBody]UserLogin model)
        {
            return _userManager.GetUser(model);
        }
    }
}
