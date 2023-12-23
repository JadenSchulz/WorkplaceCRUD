using Employee_WPF_MVVM_CRUD.Commands;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Employee_WPF_MVVM_CRUD.ViewModels.EmployeeViewModels
{
    internal class MainEmployeeViewModel : BaseViewModel
    {
        private readonly NavigationStore _parentNavigationStore;
        private readonly ViewModelFactory _viewModelFactory;
        private readonly NavigationStore _listingsNavigationStore;
        public BaseViewModel CurrentListingViewModel => _listingsNavigationStore.CurrentViewModel;
        public ICommand DepartmentsCommand { get; private set; }
        public ICommand SalaryHistoryCommannd {  get; private set; }
        public ICommand TitleHistoryCommannd { get; private set; }
        public ICommand MgmtHistoryCommannd { get; private set; }
        public ICommand DeptHistoryCommand { get; private set; }
        public ICommand AllEmployeesCommand { get; private set; }

        public MainEmployeeViewModel(NavigationStore parentNavigationStore, NavigationStore listingNavigationStore, ViewModelFactory viewModelFactory)
        {
            _parentNavigationStore = parentNavigationStore;
            _listingsNavigationStore = listingNavigationStore;
            _viewModelFactory = viewModelFactory;

            _listingsNavigationStore.ViewModelChanged += ViewModelChanged;

            DepartmentsCommand = new NavigateCommand(_parentNavigationStore, _viewModelFactory.CreateDepartmentsViewModel);

            SalaryHistoryCommannd = new NavigateCommand(_listingsNavigationStore, _viewModelFactory.CreateSalaryHistoryViewModel);
            TitleHistoryCommannd = new NavigateCommand(_listingsNavigationStore, _viewModelFactory.CreateTitleHistoryViewModel);
            MgmtHistoryCommannd = new NavigateCommand(_listingsNavigationStore, _viewModelFactory.CreateMgmtHistoryViewModel);
            DeptHistoryCommand = new NavigateCommand(_listingsNavigationStore, _viewModelFactory.CreateDeptHistoryViewModel);
            AllEmployeesCommand = new NavigateCommand(_listingsNavigationStore, _viewModelFactory.CreateEmployeeListingViewModel);
        }

        private void ViewModelChanged()
        {
            NotifyPropertyChanged(CurrentListingViewModel);
        }

    }
}
