using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Client
{
    public interface IRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        T FindOne(Expression<Func<T, bool>> expression); 
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
