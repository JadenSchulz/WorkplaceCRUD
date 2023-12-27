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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Dialogs
{
    internal class NewEmployeeDialogViewModel : BaseDialogViewModel<EmployeeViewModel>
    {
        private readonly ObservableCollection<Department> _departments;
        public IEnumerable<Department> Departments => _departments;
        public EmployeeViewModel NewEmployee { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public NewEmployeeDialogViewModel(IEnumerable<Department> departments)
        {
            _departments = new ObservableCollection<Department>(departments);

            NewEmployee = new EmployeeViewModel(Employee.NewEmployee());

            AddCommand = new RelayCommand<IDialogWindow>(Add, CanAdd);
            CancelCommand = new RelayCommand<IDialogWindow>(Cancel);

        }

        private void Cancel(IDialogWindow window)
        {
            CloseDialogWithResult(window, null);
        }

        private void Add(IDialogWindow window)
        {
            CloseDialogWithResult(window, null);
        }

        private bool CanAdd(IDialogWindow window)
        {
            return true;
        }

    }
}
