using PMS.Common.Models;

namespace PMS.Data.RepositoryInterface
{
    public interface IUserRepository
    {
        string CreateUser(User model);
        UserViewModel GetUser(UserLogin model);
        string UpdateUser(User model);
    }
}
