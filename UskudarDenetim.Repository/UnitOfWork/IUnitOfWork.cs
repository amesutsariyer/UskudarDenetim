using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UskudarDenetim.Repository.Interface;

namespace UskudarDenetim.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
