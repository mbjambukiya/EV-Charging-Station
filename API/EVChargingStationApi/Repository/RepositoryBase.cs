using EVChargingStationApi.IRepository;
using EVChargingStationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EVChargingStationApi.Repository
{
    public class RepositoryBase<T>:IRepositoryBase<T> where T : class
    {
        protected EvchargingStationContext _context;
        private DbSet<T> _table;
        public RepositoryBase(EvchargingStationContext context) {
            _context = context;
            _table = _context.Set<T>();
        }



        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
