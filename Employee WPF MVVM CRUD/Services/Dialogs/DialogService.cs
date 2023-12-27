using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.Dialogs
{
    internal class DialogService : IDialogService
    {
        public T? OpenDialog<T>(BaseDialogViewModel<T> viewModel)
        {
            IDialogWindow window= new DialogWindow();
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}
