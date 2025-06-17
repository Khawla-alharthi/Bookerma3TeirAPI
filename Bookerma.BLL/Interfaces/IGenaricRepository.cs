using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookerma.BLL.Interfaces
{
    public interface IGenaricRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
