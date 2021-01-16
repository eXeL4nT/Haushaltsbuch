using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class SearchCategoriesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel _addEntryViewModel;
        private readonly ICategoryService _categoryService;

        public SearchCategoriesCommand(AddEntryViewModel addBookingViewModel, ICategoryService categoryService)
        {
            _addEntryViewModel = addBookingViewModel;
            _categoryService = categoryService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var foundCategory = false;
            var categories = _categoryService.GetCategories().Result;
            var searchTerm = parameter as string;

            _addEntryViewModel.SearchResults.Clear();

            if (searchTerm.Length == 0) return;

            foreach (var category in categories)
            {
                if (category.Name.ToLower().StartsWith(searchTerm.ToLower()))
                {
                    _addEntryViewModel.SearchResults.Add(category);
                    foundCategory = true;
                }
            }

            if (!foundCategory)
            {
                _addEntryViewModel.SearchResults.Add(null);
            }
        }
    }
}
