namespace EVChargingStationApi.IRepository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISiteRepository EVSite { get; }
        IChargingSocketRepository ChargingSocket { get; }
        IUserChargingRepository UserCharging { get; }
    }
}
