﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GeneticRepository<T> : IRepository<T> where T : class
    {
        private Context c = new Context();
        private DbSet<T> _object;

        public GeneticRepository()
        {
            _object = c.Set<T>();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}