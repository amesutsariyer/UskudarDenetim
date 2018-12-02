﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.Repository.Interface;

namespace UskudarDenetim.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UskudarDenetimEntities _dbContext;
        public GenericRepository( )
        {
            _dbContext = new UskudarDenetimEntities();
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                this.Update(_entity);
            }
            else
            {
                // Önce entity'nin state'ini kontrol etmeliyiz.
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbContext.Set<T>().Attach(entity);
                    _dbContext.Set<T>().Remove(entity);
                }
            }
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            else
            {
                if (entity.GetType().GetProperty("IsDelete") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                    this.Update(_entity);
                }
                else
                {
                    Delete(entity);
                }
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).SingleOrDefault();
        }

        public IQueryable<T> GetAll()
        {
          return  _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
