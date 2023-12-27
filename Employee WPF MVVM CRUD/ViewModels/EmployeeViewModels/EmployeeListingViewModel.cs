using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Services.DepartmentProvider;
using Employee_WPF_MVVM_CRUD.Services.EmployeeProvider;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Items;
using Employee_WPF_MVVM_CRUD.ViewModels.Sources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.EmployeeViewModels
{
    internal class EmployeeListingViewModel : BaseViewModel
    {
        private readonly IEmployeeProvider _employeeProvider;
        private readonly IDepartmentProvider _departmentProvider;

        private readonly EmployeesSource _employees;
        public IEnumerable<EmployeeViewModel> Employees => _employees;

        private readonly ObservableCollection<Department> _departments;
        public IEnumerable<Department> Departments => _departments;
        public EmployeeListingViewModel(IEmployeeProvider employeeProvider, IDepartmentProvider departmentProvider)
        {
            _employeeProvider = employeeProvider;
            _departmentProvider = departmentProvider;

            _employees = new EmployeesSource(employeeProvider.GetAllEmployees());
            _departments = new ObservableCollection<Department>(departmentProvider.GetAllDepartments());
        }
    }
}
