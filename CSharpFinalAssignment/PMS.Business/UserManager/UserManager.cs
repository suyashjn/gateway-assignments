using PMS.Business.ManagerInterface;
using PMS.Common.Models;
using PMS.Data.RepositoryInterface;

namespace PMS.Business.ManagerClass
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string CreateUser(User model)
        {
            return _userRepository.CreateUser(model);
        }

        public UserViewModel GetUser(UserLogin model)
        {
            return _userRepository.GetUser(model);
        }

        public string UpdateUser(User model)
        {
            return _userRepository.UpdateUser(model);
        }
    }
}
