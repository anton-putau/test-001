using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;

namespace WingsOn.Dal
{
    public class RepositoryBase<T> : IRepository<T> where T : DomainObject
    {
        protected RepositoryBase()
        {
            Repository = new List<T>();
        }

        protected List<T> Repository;

        protected IReadOnlyList<K> GetList<K>(IQueryable<K> source, Filter<K> filter)
            where K: DomainObject
        {
            var result = filter.WhereExpressions.Aggregate(source, (current, expr) => current.Where(expr));

            return result.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return Repository;
        }

        public T Get(int id)
        {
            return GetAll().SingleOrDefault(a => a.Id == id);
        }

        public T GetSingle(Filter<T> filter)
        {
            return GetList(filter).SingleOrDefault();
        }

        public IReadOnlyList<T> GetList(Filter<T> filter)
        {
            var result = GetAll().AsQueryable();

            return GetList(result, filter);
        }

        public void Save(T element)
        {
            if (element == null)
            {
                return;
            }

            T existing = Get(element.Id);
            if (existing != null)
            {
                Repository.Remove(existing);
            }

            Repository.Add(element);
        }
    }
}
