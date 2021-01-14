using HMS.DAL.Repository;
using Unity;
using Unity.Extension;

namespace HMS.BLL.UnityHelper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepo, HotelRepo>();
            Container.RegisterType<IRoomRepo, RoomRepo>();
            Container.RegisterType<IBookingRepo, BookingRepo>();
        }
    }
}