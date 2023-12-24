using Employee_WPF_MVVM_CRUD.Services.EmployeeProvider;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.DepartmentViewModels;
using Employee_WPF_MVVM_CRUD.ViewModels.EmployeeViewModels;
using Employee_WPF_MVVM_CRUD.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Utility
{
    internal class ViewModelFactory
    {
        private readonly NavigationStore _navigationStore;
        private readonly IEmployeeProvider _employeeProvider;
        public ViewModelFactory(NavigationStore navigationStore, IEmployeeProvider employeeProvider) 
        { 
            _navigationStore = navigationStore;
            _employeeProvider = employeeProvider;
        }

        public BaseViewModel CreateLandingViewModel()
        {
            return new LandingViewModel(_navigationStore, this);
        }

        // Main view Models
        public BaseViewModel CreateEmployeesViewModel()
        {
            NavigationStore employeeListingNavigationStore = new NavigationStore()
            {
                CurrentViewModel = CreateEmployeeListingViewModel()
            };
            return new MainEmployeeViewModel(_navigationStore, employeeListingNavigationStore, this);
        }
        public BaseViewModel CreateDepartmentsViewModel()
        {
            NavigationStore departmentListingNavigationStore = new NavigationStore()
            {
                CurrentViewModel = CreateDepartmentListingViewModel()
            };
            return new MainDepartmentViewModel(_navigationStore, departmentListingNavigationStore, this);
        }

        // Employee listing view models
        public BaseViewModel CreateEmployeeListingViewModel()
        {
            return new EmployeeListingViewModel(_employeeProvider);
        }
        public BaseViewModel CreateMgmtHistoryViewModel()
        {
            return new MgmtHistoryViewModel();
        }
        public BaseViewModel CreateSalaryHistoryViewModel()
        {
            return new SalaryHistoryViewModel();
        }
        public BaseViewModel CreateTitleHistoryViewModel()
        {
            return new TitleHistoryViewModel();
        }
        public BaseViewModel CreateDeptHistoryViewModel()
        {
            return new DeptHistoryViewModel();
        }

        // Department listing view models

        public BaseViewModel CreateDepartmentListingViewModel()
        {
            return new DepartmentListingViewModel();
        }
        public BaseViewModel CreateDeptEmployeesViewModel()
        {
            return new DeptEmployeesViewModel();
        }
        public BaseViewModel CreateDeptManagersViewModel()
        {
            return new DeptManagersViewModel();
        }


    }
}
