using EVChargingStationApi.IRepository;
using EVChargingStationApi.Models;

namespace EVChargingStationApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EvchargingStationContext _context;
        public IUserRepository User { get; private set; }
        public ISiteRepository EVSite { get; private set; }
        public IChargingSocketRepository ChargingSocket { get; private set; }
        public IUserChargingRepository UserCharging { get; private set; }

        public RepositoryWrapper(EvchargingStationContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            EVSite = new SiteRepository(_context);
            ChargingSocket = new ChargingSocketRepository(_context);
            UserCharging = new UserChargingRepository(_context);
        }
    }
}