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
        private event CategoryCallback CategoryCallback;

        public event EventHandler CanExecuteChanged;

        private AddEntryViewModel _addEntryViewModel;
        private ICategoryService _categoryService; 

        public DeleteCategoryCommand(AddEntryViewModel addEntryViewModel, ICategoryService categoryService, CategoryCallback categoryCallback)
        {
            _addEntryViewModel = addEntryViewModel;
            _categoryService = categoryService;

            CategoryCallback = categoryCallback;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _addEntryViewModel.ErrorMessage = string.Empty;

            try
            {
                _categoryService.DeleteCategory(parameter as Category);
                CategoryCallback?.Invoke();
            }
            catch (Exception e)
            {
                _addEntryViewModel.ErrorMessage = $"Das Löschen der Kategorie hat nicht funktioniert. {e.Message}";
            }
        }
    }
}
