using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Services.EmployeeProvider;
using Employee_WPF_MVVM_CRUD.Stores;
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
        private readonly ObservableCollection<Employee> _employees;
        public IEnumerable<Employee> Employees => _employees;
        public EmployeeListingViewModel(IEmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
            _employees = new ObservableCollection<Employee>(employeeProvider.GetAllEmployees());
        }
    }
}
