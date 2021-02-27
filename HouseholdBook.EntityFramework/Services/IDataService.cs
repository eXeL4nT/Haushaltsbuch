using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public interface IDataService<T>
    {
        Task<ObservableCollection<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Get(string description);
        Task<T> Get(Category category);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<T> Delete(int id);
    }
}
