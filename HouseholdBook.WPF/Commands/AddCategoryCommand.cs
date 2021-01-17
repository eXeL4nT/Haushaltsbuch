using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class AddCategoryCommand : ICommand
    {
        private event CategoryCallback CategoryCallback;
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel _addEntryViewModel;
        private readonly ICategoryService _categoryService;

        public AddCategoryCommand(AddEntryViewModel addBookingViewModel, ICategoryService categoryService, CategoryCallback categoryCallback)
        {
            _addEntryViewModel = addBookingViewModel;
            _categoryService = categoryService;

            CategoryCallback = categoryCallback;
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
                await _categoryService.AddCategory(_addEntryViewModel.NewCategory);
                Cleanup();
                CategoryCallback?.Invoke();
            }
            catch (Exception e)
            {
                _addEntryViewModel.ErrorMessage = $"Fehler beim Bearbeiten der Daten. {e.Message}";
            }
        }

        public void Cleanup()
        {
            _addEntryViewModel.NewCategory = null;
        }
    }
}
