using Haushaltsbuch.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public class CategoryService : ICategoryService
    {
        private CategoryDataService _categoryDataService;
        private BookingDataService _bookingDataService;

        public CategoryService(CategoryDataService categoryDataService, BookingDataService bookingDataService)
        {
            _categoryDataService = categoryDataService;
            _bookingDataService = bookingDataService;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoryDataService.GetAll();
        }

        public async Task<Category> AddCategory(string newCategory)
        {
            if (string.IsNullOrEmpty(newCategory)) throw new Exception("Die Kategorie muss einen Namen besitzen.");
            if (!CheckIfCategoryAlreadyExists(newCategory)) throw new Exception("Die Kategorie existiert bereits.");

            return await _categoryDataService.Create(new Category { Name = newCategory});
        }

        public async Task<Category> DeleteCategory(Category category)
        {
            if (!CheckIfCategoryHasDependencies(category)) throw new Exception("Die Kategorie wird bereits verwendet und kann daher nicht gelöscht werden.");
            
            return await _categoryDataService.Delete(category.Id);
        }

        private bool CheckIfCategoryAlreadyExists(string categoryName)
        {
            var searchResult = _categoryDataService.Get(categoryName).Result;

            return searchResult is null;
        }

        private bool CheckIfCategoryHasDependencies(Category category)
        {
            var searchResult = _bookingDataService.Get(category).Result;

            return searchResult is null;
        }
    }
}
