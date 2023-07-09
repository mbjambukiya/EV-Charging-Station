using EVChargingStationApi.Entities;
using EVChargingStationApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EVSitesController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public EVSitesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        //get all sites list
        [HttpGet]
        public IActionResult GetAllSites() {
            try
            {
                var sites = _repository.EVSite.GetAll();
                return Ok(sites);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //get charging sockets by site id
        [HttpGet("{siteId}")]
        public IActionResult GetChargingSockets(int siteId)
        {
            try { 
            var sites = _repository.ChargingSocket.GetChargingSocketsBySite(siteId);
            return Ok(sites);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // lock socket
        [HttpPut("lock-socket")]
        public IActionResult PutLockSocket(LockSocketModel lockSocket)
        {
            try { 
            var userchatrgingId = _repository.ChargingSocket.LockSocket(lockSocket);
            return Ok(userchatrgingId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //unlock socket
        [HttpPut("unlock-socket")]
        public IActionResult PutUnlockSocket(LockSocketModel lockSocket)
        {
            try { 
            var userReciept = _repository.ChargingSocket.UnlockSocket(lockSocket);
            return Ok(userReciept);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
