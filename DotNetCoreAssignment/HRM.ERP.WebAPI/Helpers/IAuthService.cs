using HRM.ERP.Common.Models;

namespace HRM.ERP.WebAPI.Helpers
{
    public interface IAuthService
    {
        UserLogin Authenticate(string email, string password);
    }
}
