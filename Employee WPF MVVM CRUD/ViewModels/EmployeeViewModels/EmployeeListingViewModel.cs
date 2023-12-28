using Employee_WPF_MVVM_CRUD.Commands;
using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Services.DepartmentProvider;
using Employee_WPF_MVVM_CRUD.Services.Dialogs;
using Employee_WPF_MVVM_CRUD.Services.EmployeeProvider;
using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels.Dialogs;
using Employee_WPF_MVVM_CRUD.ViewModels.Items;
using Employee_WPF_MVVM_CRUD.ViewModels.Sources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee_WPF_MVVM_CRUD.ViewModels.EmployeeViewModels
{
    internal class EmployeeListingViewModel : BaseViewModel
    {
        private readonly IEmployeeProvider _employeeProvider;
        private readonly IDepartmentProvider _departmentProvider;

        // Employees
        private readonly EmployeesSource _employees;
        public IEnumerable<EmployeeViewModel> Employees => _employees;
        public EmployeeViewModel? SelectedRow { get; set; }
        public int SelectedIndex { get; set; }

        // Departments
        private readonly ObservableCollection<Department> _departments;
        public IEnumerable<Department> Departments => _departments;

        // Create/Update/Delete Data Caches
        private readonly List<EmployeeViewModel> _addedEmployees;
        private readonly List<EmployeeViewModel> _deletedEmployees;
        private readonly List<EmployeeViewModel> _updatedEmployees;

        // Commands
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand CommitCommand { get; private set; }

        public EmployeeListingViewModel(IEmployeeProvider employeeProvider, IDepartmentProvider departmentProvider)
        {
            _employeeProvider = employeeProvider;
            _departmentProvider = departmentProvider;

            _employees = new EmployeesSource(employeeProvider.GetAllEmployees());
            _departments = new ObservableCollection<Department>(departmentProvider.GetAllDepartments());

            foreach (var employee in Employees)
            {
                employee.PropertyChanged += EmployeePropertyChanged;
            }

            _addedEmployees = new List<EmployeeViewModel>();
            _deletedEmployees = new List<EmployeeViewModel>();
            _updatedEmployees = new List<EmployeeViewModel>();

            AddCommand = new RelayCommand(AddRecord);
            DeleteCommand = new RelayCommand(DeleteRecord, RowSelected);
            CommitCommand = new RelayCommand(CommitRecords, CanCommit);

        }

        private void EmployeePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _updatedEmployees.Add((sender as EmployeeViewModel)!);
        }
        private void DeleteRecord()
        {
            if (SelectedRow == null) return;
            _deletedEmployees.Add(SelectedRow);
            _employees.Remove(SelectedRow);

        }

        private void AddRecord()
        {
            DialogService ds = new DialogService();
            var result = ds.OpenDialog(new CreateEmployeeDialogViewModel(_departments, "New Employee"));

            if (result != null)
            {
                _employees.Insert((SelectedIndex == -1) ? 0 : SelectedIndex, result);
                _addedEmployees.Add(result);
            }
        }

        private void CommitRecords()
        {
            throw new NotImplementedException();
        }

        private bool CanCommit()
        {
            if (Employees.FirstOrDefault(x => x.HasErrors == true) == null) 
                return false;
            return true;
        }

        private bool RowSelected()
        {
            return (SelectedRow != null);
        }




    }
}
