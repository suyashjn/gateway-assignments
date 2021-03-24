using System.Linq;
using AutoMapper;
using PMS.Common.Models;
using PMS.Data.RepositoryInterface;

namespace PMS.Data.RepositoryClass
{
    public class UserRepository : IUserRepository
    {
        private readonly PMSContext _dbContext;
        public UserRepository(PMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CreateUser(User model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, Data.Models.User>());
            var mapper = config.CreateMapper();

            var user = mapper.Map<Data.Models.User>(model);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return "Registration successfully";
        }

        public UserViewModel GetUser(UserLogin model)
        {
            if(model == null)
            {
                return null;
            }
            else
            {
                var result = (from u in _dbContext.Users
                              where (u.EmailId == model.EmailId)
                              && (u.Password == model.Password) select u).FirstOrDefault();

                UserViewModel user = new UserViewModel()
                {
                    EmailId = result.EmailId,
                    Name = result.Name,
                    UserId = result.UserId
                };
                return user;
            }
        }

        public string UpdateUser(User model)
        {
            var entity = _dbContext.Users.Find(model.UserId);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.ContactNo = model.ContactNo;
                entity.EmailId = model.EmailId;
                entity.Password = model.Password;

                _dbContext.SaveChanges();
                return "Updated Successfully!";
            }
            else
            {
                return "Something went wrong. Please try after sometime.";
            }
        }
    }
}
