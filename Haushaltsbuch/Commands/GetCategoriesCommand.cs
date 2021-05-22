using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    public class GetCategoriesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel _addEntryViewModel;
        private readonly ICategoryService _categoryService;

        public GetCategoriesCommand(AddEntryViewModel addEntryViewModel, ICategoryService categoryService)
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
                _addEntryViewModel.Categories = await _categoryService.GetCategories();
            }
            catch (Exception e)
            {
                _addEntryViewModel.ErrorMessage = $"Es ist ein Fehler beim Abrufen der Daten aufgetreten. {e.Message}";
            }
        }
    }
}
