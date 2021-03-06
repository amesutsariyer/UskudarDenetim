﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UskudarDenetim.Repository.Interface
{

    public interface GenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate); // LINQ desteği sunabilmek içinde expression'ları kullanıyoruz.
        T GetById(Guid id);
        T Get(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Guid id);
    }
}
