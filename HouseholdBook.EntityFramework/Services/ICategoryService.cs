using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public interface ICategoryService
    {
        Task<ObservableCollection<Category>> GetCategories();
        Task<Category> AddCategory(string newCategory);
        Task<Category> DeleteCategory(Category category);
    }
}
