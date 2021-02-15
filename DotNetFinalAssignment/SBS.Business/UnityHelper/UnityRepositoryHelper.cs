using SBS.Data.Repository.Implementation;
using SBS.Data.Repository.Interfaces;
using Unity;
using Unity.Extension;

namespace SBS.Business.UnityHelper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IAdminRepository, AdminRepository>();
        }
    }
}
