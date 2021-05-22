using Haushaltsbuch.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> AddCategory(string newCategory);
        Task<Category> DeleteCategory(Category category);
    }
}
