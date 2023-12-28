using Employee_WPF_MVVM_CRUD.Enums;
using Employee_WPF_MVVM_CRUD.Models;
using Employee_WPF_MVVM_CRUD.ViewModels.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Items
{
    internal class EmployeeViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private readonly ViewModelValidator _viewModelValidator; 
        private readonly Employee _employee;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors => _viewModelValidator.HasErrors;
        public Employee Employee => _employee;

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
            _viewModelValidator = new ViewModelValidator();

            _viewModelValidator.ValidateProperty(nameof(FirstName), FirstName, this);
            _viewModelValidator.ValidateProperty(nameof(LastName), LastName, this);
            _viewModelValidator.ValidateProperty(nameof(Department), Department, this);
            _viewModelValidator.ValidateProperty(nameof(Title), Title, this);
            _viewModelValidator.ValidateProperty(nameof(Salary), Salary, this);
        }

        [Required(ErrorMessage = "*")]
        public string FirstName
        {
            get { return _employee.FirstName; }
            set 
            {
                _employee.FirstName = value;
                _viewModelValidator.ValidateProperty(nameof(FirstName), value, this);
                NotifyPropertyChanged(FirstName);
            }
        }
        [Required(ErrorMessage = "*")]
        public string LastName
        {
            get { return _employee.LastName; }
            set 
            {
                _employee.LastName = value;
                _viewModelValidator.ValidateProperty(nameof(LastName), value, this);
                NotifyPropertyChanged(LastName);
            }
        }
        public Gender Gender
        {
            get { return _employee.Gender; }
            set 
            {
                _employee.Gender = value;
                NotifyPropertyChanged(Gender);
            }
        }
        public DateTime BirthDate
        {
            get { return _employee.BirthDate; }
            set 
            {
                _employee.BirthDate = value;
                NotifyPropertyChanged(BirthDate);
            }
        }

        public DateTime HireDate
        {
            get { return _employee.HireDate; }
            set
            {
                _employee.HireDate = value;
                NotifyPropertyChanged(HireDate);
            }
        }

        public string? DeptName => _employee.Department?.Name;
        [Required(ErrorMessage = "*")]
        public Department? Department
        {
            get { return _employee.Department; }
            set
            {
                _employee.Department = value;
                _viewModelValidator.ValidateProperty(nameof(Department), value, this);
                NotifyPropertyChanged(Department);
                NotifyPropertyChanged(DeptName);
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0.")]
        public int Salary
        {
            get { return _employee.Salary; }
            set
            {
                _employee.Salary = value;
                _viewModelValidator.ValidateProperty(nameof(Salary), value, this);
                NotifyPropertyChanged(Salary);
            }
        }

        [Required(ErrorMessage = "*")]
        public string Title
        {
            get { return _employee.Title; }
            set
            {
                _employee.Title = value;
                _viewModelValidator.ValidateProperty(nameof(Title), value, this);
                NotifyPropertyChanged(Title);
            }
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _viewModelValidator.GetErrors(propertyName);
        }
    }
}
