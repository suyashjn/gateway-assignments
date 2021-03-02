using PMT.Data.Repository;
using Unity;
using Unity.Extension;

namespace PMT.Business.Helper
{
    public class UnityExtensionHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPassengerRepository, PassengerRepository>();
        }
    }
}
