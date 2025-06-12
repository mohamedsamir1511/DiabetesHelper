using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.BLL.Interfaces
{
    public interface IGenericInterface<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync (T entity);
        Task Update(T entity);
        void Delete (T entity);
        Task<IEnumerable<T>>FindAsync(Expression<Func<T, bool>> predicate); 

    }
}
