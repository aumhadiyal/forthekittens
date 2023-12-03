using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace forthekittens.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        //T - Category 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        //T Update(T entity);  because it complicated in some cases
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
