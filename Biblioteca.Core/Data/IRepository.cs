using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IDbContext DbContext { get; }
        T GetById(object id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Upsert(T entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Delete(long id);

        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }

    }
}
