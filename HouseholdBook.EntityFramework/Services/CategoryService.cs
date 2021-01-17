using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryDataService categoryDataService;

        public CategoryService(CategoryDataService categoryDataService)
        {
            this.categoryDataService = categoryDataService;
        }

        public async Task<ObservableCollection<Category>> GetCategories()
        {
            ObservableCollection<Category> categories = new ObservableCollection<Category>(await categoryDataService.GetAll());

            return categories;
        }

        public async Task<Category> AddCategory(string newCategory)
        {
            if (string.IsNullOrEmpty(newCategory)) throw new Exception("Die Kategorie muss einen Namen besitzen.");
            if (!CheckIfCategoryAlreadyExists(newCategory)) throw new Exception("Die Kategorie existiert bereits.");

            return await categoryDataService.Create(new Category { Name = newCategory});
        }

        public async void DeleteCategory(Category category)
        {
            //TODO CONTRAINT ABFRAGE
            await categoryDataService.Delete(category.Id);
        }

        private bool CheckIfCategoryAlreadyExists(string category)
        {
            var searchResult = categoryDataService.Get(category).Result;

            return searchResult is null;
        }
    }
}
