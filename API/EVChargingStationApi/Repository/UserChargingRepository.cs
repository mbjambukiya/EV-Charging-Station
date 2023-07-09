using EVChargingStationApi.IRepository;
using EVChargingStationApi.Models;

namespace EVChargingStationApi.Repository
{
    public class UserChargingRepository : RepositoryBase<UserCharging>, IUserChargingRepository
    {
        public UserChargingRepository(EvchargingStationContext _context) : base(_context)
        {

        }
    }
}
