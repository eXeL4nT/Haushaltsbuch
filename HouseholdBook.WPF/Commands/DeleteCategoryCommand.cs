using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class DeleteCategoryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel _addEntryViewModel;
        private readonly ICategoryService _categoryService; 

        public DeleteCategoryCommand(AddEntryViewModel addEntryViewModel, ICategoryService categoryService)
        {
            _addEntryViewModel = addEntryViewModel;
            _categoryService = categoryService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            _addEntryViewModel.ErrorMessage = string.Empty;

            try
            {
                var category = parameter as Category;
                await _categoryService.DeleteCategory(category);

                _addEntryViewModel.Categories.Remove(category);
            }
            catch (Exception e)
            {
                _addEntryViewModel.ErrorMessage = $"Fehler beim Bearbeiten der Daten. {e.Message}";
            }
        }
    }
}
