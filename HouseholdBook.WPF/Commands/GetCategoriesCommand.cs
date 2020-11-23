using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class GetCategoriesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly AddBookingViewModel addBookingViewModel;
        private readonly ICategoryService categoryService;

        public GetCategoriesCommand(AddBookingViewModel addBookingViewModel, ICategoryService categoryService)
        {
            this.addBookingViewModel = addBookingViewModel;
            this.categoryService = categoryService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            addBookingViewModel.Categories = categoryService.GetCategories().Result;
        }
    }
}
