using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDataService<Category> categoryDataService;

        public CategoryService(IDataService<Category> categoryDataService)
        {
            this.categoryDataService = categoryDataService;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = (List<Category>)await categoryDataService.GetAll();

            return categories;
        }
    }
}
