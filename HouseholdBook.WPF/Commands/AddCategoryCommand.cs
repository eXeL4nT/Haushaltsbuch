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
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel _addEntryViewModel;
        private readonly ICategoryService _categoryService;

        public AddCategoryCommand(AddEntryViewModel addBookingViewModel, ICategoryService categoryService)
        {
            _addEntryViewModel = addBookingViewModel;
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
                var category = await _categoryService.AddCategory(_addEntryViewModel.NewCategory);

                _addEntryViewModel.Categories.Add(category);

                Cleanup();
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
