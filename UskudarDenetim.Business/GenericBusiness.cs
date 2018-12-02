using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UskudarDenetim.Business.Interface;
using UskudarDenetim.Repository;
using UskudarDenetim.Repository.Interface;

namespace UskudarDenetim.Business
{
    public class GenericBusiness<T> : IGenericBusiness<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericBusiness(IGenericRepository<T> _genericRepository)
        {
            this._genericRepository = _genericRepository;
        }

        public void Create(T entity)
        {
            _genericRepository.Create(entity);
        }

        public void Delete(T entity)
        {
            _genericRepository.Delete(entity);
        }

        public void Delete(Guid id)
        {
            _genericRepository.Delete(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
          return  _genericRepository.Get(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _genericRepository.GetAll(predicate);
        }

        public T GetById(Guid id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(T entity)
        {
            _genericRepository.Update(entity);
        }
    }
}
