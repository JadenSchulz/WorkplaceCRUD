using Employee_WPF_MVVM_CRUD.Commands;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee_WPF_MVVM_CRUD.ViewModels.MainViewModels
{
    internal class LandingViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelFactory _viewModelFactory;
        public ICommand EmployeesCommand {  get; set; }
        public ICommand DepartmentsCommand { get; set; }
        public LandingViewModel(NavigationStore navigationStore, ViewModelFactory viewModelFactory)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;

            EmployeesCommand = new NavigateCommand(_navigationStore, _viewModelFactory.CreateEmployeesViewModel);
            DepartmentsCommand = new NavigateCommand(_navigationStore, _viewModelFactory.CreateDepartmentsViewModel);
        }
    }
}
