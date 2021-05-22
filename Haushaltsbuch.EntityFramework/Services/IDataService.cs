using Haushaltsbuch.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Get(string description);
        Task<T> Get(Category category);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<T> Delete(int id);
    }
}
