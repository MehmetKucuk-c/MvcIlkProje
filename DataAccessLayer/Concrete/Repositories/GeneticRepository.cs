using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GeneticRepository<T> : IRepository<T> where T : class
    {
        private readonly Context _c = new Context();
        private readonly DbSet<T> _object;

        public GeneticRepository()
        {
            _object = _c.Set<T>();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Insert(T p)
        {
            var addedEntity = _c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            _c.SaveChanges();
        }

        public void Delete(T p)
        {
            var deletedEntity = _c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            _c.SaveChanges();
        }

        public void Update(T p)
        {
            var updatedEntity = _c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            _c.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
            //Tek DEger Döndürüsü Id Göre Arama yaparken kullanmak mantıklı linq sorgusu 
        }
    }
}