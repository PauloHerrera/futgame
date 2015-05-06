using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FutGame.Model.Queries
{
    public interface IGenericRepository<T>
    {
        T Add(T entity);
        T Remove(T entity);
        void Remove(long id);
        void Update(T entity);
        IQueryable<T> GetAll();
        T Get(object key);
        void Salvar();
    }
}
