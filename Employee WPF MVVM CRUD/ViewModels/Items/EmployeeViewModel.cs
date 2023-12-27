using Employee_WPF_MVVM_CRUD.Enums;
using Employee_WPF_MVVM_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Items
{
    internal class EmployeeViewModel : BaseViewModel
    {
        private readonly Employee _employee;
        public Employee Employee => _employee;

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }         

        public string FirstName
        {
            get { return _employee.FirstName; }
            set 
            {
                NotifyPropertyChanged(FirstName);
                _employee.FirstName = value;
            }
        }
        public string LastName
        {
            get { return _employee.LastName; }
            set 
            {
                NotifyPropertyChanged(LastName);
                _employee.LastName = value;
            }
        }
        public Gender Gender
        {
            get { return _employee.Gender; }
            set 
            {
                NotifyPropertyChanged(Gender);
                _employee.Gender = value;
            }
        }
        public DateTime BirthDate
        {
            get { return _employee.BirthDate; }
            set 
            {
                NotifyPropertyChanged(BirthDate);
                _employee.BirthDate = value;
            }
        }

        public DateTime HireDate
        {
            get { return _employee.HireDate; }
            set
            {
                NotifyPropertyChanged(HireDate);
                _employee.HireDate = value;
            }
        }

        public string? DeptName => _employee.Department?.Name;
        public Department? Department
        {
            get { return _employee.Department; }
            set
            {
                NotifyPropertyChanged(Department);
                NotifyPropertyChanged(DeptName);
                _employee.Department = value;
            }
        }

        public int Salary
        {
            get { return _employee.Salary; }
            set
            {
                NotifyPropertyChanged(Salary);
                _employee.Salary = value;
            }
        }


    }
}
