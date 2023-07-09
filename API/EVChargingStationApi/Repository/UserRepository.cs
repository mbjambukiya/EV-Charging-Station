using EVChargingStationApi.IRepository;
using EVChargingStationApi.Models;

namespace EVChargingStationApi.Repository
{
    public class UserRepository:RepositoryBase<User>,IUserRepository
    {
        public UserRepository(EvchargingStationContext _context):base(_context)
        {
            
        }
    }
}
