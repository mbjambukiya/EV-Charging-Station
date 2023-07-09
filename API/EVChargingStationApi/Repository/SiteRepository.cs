using EVChargingStationApi.IRepository;
using EVChargingStationApi.Models;

namespace EVChargingStationApi.Repository
{
    public class SiteRepository : RepositoryBase<EvSite>, ISiteRepository
    {
        public SiteRepository(EvchargingStationContext _context) : base(_context)
        {

        }
    }
}
