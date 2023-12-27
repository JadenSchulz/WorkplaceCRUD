using Employee_WPF_MVVM_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Items
{
    internal class DepartmentViewModel : BaseViewModel
    {
        private readonly Department _department;
        public Department Employee => _department;

        public DepartmentViewModel(Department department)
        {
            _department = department;
        }

        public string Name
        {
            get { return _department.Name; }
            set
            {
                NotifyPropertyChanged(Name);
                _department.Name = value;
            }
        }

        public override string ToString()
        {
            return _department.ToString();
        }

        public override bool Equals(object? obj)
        {
            return _department.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _department.GetHashCode();
        }
    }
}
