using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        
        //Позволяет получить как весь список объектов,
        //так и по определенным условиям используя точку
        IQueryable<T> GetAll();
        Task Delete(T entity);
        Task<T> Update(T entity);
    }
}
