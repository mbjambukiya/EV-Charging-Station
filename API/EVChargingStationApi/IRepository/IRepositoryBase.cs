namespace EVChargingStationApi.IRepository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Save();
    }
}
