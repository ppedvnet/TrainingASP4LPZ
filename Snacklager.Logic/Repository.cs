using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Snacklager.Data;
using Snacklager.Logic.Contracts;

namespace Snacklager.Logic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SnacklagerDB _db = null;
        protected readonly DbSet<T> _table = null;

        public Repository(SnacklagerDB db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        //public Repository()
        //{
        //    _db = new SnacklagerDB();
        //    _table = _db.Set<T>();
        //}

        public T FindById(int id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public void Insert(T entity)
        {
            _table.Add(entity);
        }

        public void Remove(int id)
        {
            T entry = _table.Find(id);
            _table.Remove(entry);
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public bool SaveAll()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
