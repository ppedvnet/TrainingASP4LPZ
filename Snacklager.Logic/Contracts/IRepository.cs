using System.Collections.Generic;

namespace Snacklager.Logic.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);

        void Insert(T entity);
        void Remove(int id);
        void Update(T entity);

        bool SaveAll();
    }
}
