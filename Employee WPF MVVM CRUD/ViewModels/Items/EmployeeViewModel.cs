using Employee_WPF_MVVM_CRUD.Enums;
using Employee_WPF_MVVM_CRUD.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
                _employee.FirstName = value;
                NotifyPropertyChanged(FirstName);
            }
        }
        public string LastName
        {
            get { return _employee.LastName; }
            set 
            {
                _employee.LastName = value;
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
        public Department? Department
        {
            get { return _employee.Department; }
            set
            {
                _employee.Department = value;
                NotifyPropertyChanged(Department);
                NotifyPropertyChanged(DeptName);
            }
        }

        public int Salary
        {
            get { return _employee.Salary; }
            set
            {
                _employee.Salary = value;
                NotifyPropertyChanged(Salary);
            }
        }

    }
}
