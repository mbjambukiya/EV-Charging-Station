using EVChargingStationApi.Entities;
using EVChargingStationApi.IRepository;
using EVChargingStationApi.Models;

namespace EVChargingStationApi.Repository
{
    public class ChargingSocketRepository : RepositoryBase<ChargingSocket>, IChargingSocketRepository
    {
        public ChargingSocketRepository(EvchargingStationContext _context) : base(_context)
        {

        }

        //get all charging sockets by using site id
        public IList<ChargingSocket> GetChargingSocketsBySite(int siteId)
        {
            var sockets = _context.ChargingSockets.Where(x => x.SiteId == siteId).ToList();
            return sockets;
        }

        //lock socket and craete new entry for user charging progress mapping
        public int LockSocket(LockSocketModel lockSocket)
        {
            var socket = _context.ChargingSockets.Where(x => x.ChargingSocketId == lockSocket.SocketId && x.IsLocked==false).FirstOrDefault();
            if (socket != null)
            {
                socket.IsLocked = true;
                socket.ModifiedDate = DateTime.UtcNow;
                var userCharging = new UserCharging();
                userCharging.UserId = lockSocket.UserId;
                userCharging.ChargingSocketId = lockSocket.SocketId;
                userCharging.StartTime = DateTime.UtcNow;
                userCharging.CreatedDate = DateTime.UtcNow;
                _context.UserChargings.Add(userCharging);
                _context.SaveChanges();
                return userCharging.UserChargingId;
            }
            return 0;
        }

        //unlock socket and update charging progress
        public VUserReciept UnlockSocket(LockSocketModel lockSocket)
        {
            var receipt = new VUserReciept();
            var socket = _context.ChargingSockets.Where(x => x.ChargingSocketId == lockSocket.SocketId && x.IsLocked == true).FirstOrDefault();
            if (socket != null)
            {
                socket.IsLocked = false;
                socket.ModifiedDate = DateTime.UtcNow;
                var userCharging = _context.UserChargings.Where(x => x.ChargingSocketId == socket.ChargingSocketId && x.UserId == lockSocket.UserId && x.EndTime==null).First();
                userCharging.EndTime = DateTime.UtcNow;
                userCharging.ModifiedDate = DateTime.UtcNow;
                _context.SaveChanges();
                receipt = _context.VUserReciepts.Where(x => x.TransactionId == userCharging.UserChargingId).First();
            }
            return receipt;
        }
    }
}
