using EVChargingStationApi.Entities;
using EVChargingStationApi.Models;

namespace EVChargingStationApi.IRepository
{
    public interface IChargingSocketRepository:IRepositoryBase<ChargingSocket>
    {
        public IList<ChargingSocket> GetChargingSocketsBySite(int siteId);
        public int LockSocket(LockSocketModel lockSocket);
        public VUserReciept UnlockSocket(LockSocketModel lockSocket);
    }
}
