using Employee_WPF_MVVM_CRUD.Commands;
using Employee_WPF_MVVM_CRUD.Enums;
using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.Services.Dialogs;
using Employee_WPF_MVVM_CRUD.ViewModels.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Dialogs
{
    internal class CreateEmployeeDialogViewModel : BaseDialogViewModel<EmployeeViewModel>
    {
        private readonly ObservableCollection<Department> _departments;
        public IEnumerable<Department> Departments => _departments;

        private readonly EmployeeViewModel _newEmployee;
        public EmployeeViewModel NewEmployee => _newEmployee;   
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public CreateEmployeeDialogViewModel(IEnumerable<Department> departments, string title) : base(title) 
        {
            _departments = new ObservableCollection<Department>(departments);
            _newEmployee = new EmployeeViewModel(Employee.NewEmployee());

            AddCommand = new RelayCommand<IDialogWindow>(Add, CanAdd);
            CancelCommand = new RelayCommand<IDialogWindow>(Cancel);

        }

        private void Cancel(IDialogWindow window)
        {
            CloseDialogWithResult(window, null);
        }

        private void Add(IDialogWindow window)
        {
            CloseDialogWithResult(window, NewEmployee);
        }

        private bool CanAdd(IDialogWindow window)
        {
            return !NewEmployee.HasErrors;
        }

    }

}
