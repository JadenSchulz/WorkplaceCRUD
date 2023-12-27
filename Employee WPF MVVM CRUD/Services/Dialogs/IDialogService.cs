using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.Dialogs
{
    internal interface IDialogService
    {
        T? OpenDialog<T>(BaseDialogViewModel<T> viewModel);

    }
}
