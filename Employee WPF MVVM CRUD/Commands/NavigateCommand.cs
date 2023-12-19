using Employee_WPF_MVVM_CRUD.Stores;
using Employee_WPF_MVVM_CRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee_WPF_MVVM_CRUD.Commands
{
    class NavigateCommand : BaseCommand
    {
        private readonly NavigationStore _navigationStore;
        public event EventHandler? CanExecuteChanged;

        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = parameter as BaseViewModel;
        }
    }
}
