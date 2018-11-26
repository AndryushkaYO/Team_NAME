using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Figures.DataAcces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity item);
        void AddRange(IEnumerable<TEntity> items);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity item);
        void RemoveAll();
    }
}
