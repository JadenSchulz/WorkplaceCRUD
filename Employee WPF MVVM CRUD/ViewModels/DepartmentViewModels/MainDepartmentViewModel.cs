using Employee_WPF_MVVM_CRUD.Commands;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee_WPF_MVVM_CRUD.ViewModels.DepartmentViewModels
{
    internal class MainDepartmentViewModel : BaseViewModel
    {
        private readonly NavigationStore _parentNavigationStore;
        private readonly NavigationStore _listingNavigationStore;
        private readonly ViewModelFactory _viewModelFactory;
        public BaseViewModel CurrentListingViewModel => _listingNavigationStore.CurrentViewModel;
        public ICommand EditEmployeesCommand { get; private set; }
        public ICommand ViewEmployeesCommand { get; private set; }
        public ICommand ViewManagersCommand { get; private set; }
        public ICommand AllDepartmentsCommand { get; private set; }
        public MainDepartmentViewModel(NavigationStore parentNavigationStore, NavigationStore listingNavigationStore, ViewModelFactory viewModelFactory)
        {
            _parentNavigationStore = parentNavigationStore;
            _listingNavigationStore = listingNavigationStore;
            _viewModelFactory = viewModelFactory;

            _listingNavigationStore.ViewModelChanged += ViewModelChanged;

            EditEmployeesCommand = new NavigateCommand(_parentNavigationStore, _viewModelFactory.CreateEmployeesViewModel);

            ViewEmployeesCommand = new NavigateCommand(_listingNavigationStore, _viewModelFactory.CreateDeptEmployeesViewModel);
            ViewManagersCommand = new NavigateCommand(_listingNavigationStore, _viewModelFactory.CreateDeptManagersViewModel);
            AllDepartmentsCommand = new NavigateCommand(_listingNavigationStore, _viewModelFactory.CreateDepartmentListingViewModel);

        }

        private void ViewModelChanged()
        {
            NotifyPropertyChanged(CurrentListingViewModel);
        }
    }
}
