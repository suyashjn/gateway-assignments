using PMS.Data.RepositoryClass;
using PMS.Data.RepositoryInterface;
using Unity;
using Unity.Extension;

namespace PMS.Business.Helpers
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
