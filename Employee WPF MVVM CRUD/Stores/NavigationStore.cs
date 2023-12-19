using Employee_WPF_MVVM_CRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Stores
{
    internal class NavigationStore 
    {
        private BaseViewModel _currentView;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentView; }
            set { _currentView = value; }
        }
    }
}
