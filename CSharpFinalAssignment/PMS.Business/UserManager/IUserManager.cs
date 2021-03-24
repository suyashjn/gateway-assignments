using PMS.Common.Models;

namespace PMS.Business.ManagerInterface
{
    public interface IUserManager
    {
        string CreateUser(User model);
        UserViewModel GetUser(UserLogin model);
        string UpdateUser(User model);
    }
}
