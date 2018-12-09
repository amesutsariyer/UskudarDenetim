using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.Repository.Interface;

namespace UskudarDenetim.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly musa_UdMainEntities _dbContext;
        public UnitOfWork(musa_UdMainEntities dbContext)
        {
            Database.SetInitializer<musa_UdMainEntities>(null);
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext can not be null.");

            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public GenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>();
        }

        public int SaveChanges()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw ex;
            }
        }
    }
}
