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
    internal class NavigateCommand : BaseCommand
    {
        private readonly NavigationStore _navigationStore;

        private readonly Func<BaseViewModel> _createViewModel;
        private readonly Func<bool>? _canExecute = null;

        public NavigateCommand(NavigationStore navigationStore, Func<BaseViewModel> createViewModel) : this(navigationStore, createViewModel, null) { }
        public NavigateCommand(NavigationStore navigationStore, Func<BaseViewModel> createViewModel, Func<bool>? canExecute) 
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _canExecute = canExecute;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }

        public override bool CanExecute(object? parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute.Invoke();
        }

        

    }
}
