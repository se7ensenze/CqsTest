using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Client.Infrastructure
{
    public class FooRepository
        : IRepository<Foo>
    {
        private readonly List<Foo> _fooList;
        public FooRepository()
        {
            _fooList = new List<Foo>();
        }
        public void Add(Foo obj)
        {
            _fooList.Add(obj);
        }

        public void Delete(Foo obj)
        {
            _fooList.Remove(obj);
        }

        public IEnumerable<Foo> Find(Expression<Func<Foo, bool>> expression)
        {
            return _fooList.AsQueryable()
                .Where(expression)
                .AsEnumerable();
        }

        public Foo FindOne(Expression<Func<Foo, bool>> expression)
        {
            return _fooList.AsQueryable()
                .Where(expression)
                .FirstOrDefault();
        }

        public void Update(Foo obj)
        {
            _fooList.Where(f => f.Id == obj.Id).FirstOrDefault().Name = obj.Name;
        }
    }
}
