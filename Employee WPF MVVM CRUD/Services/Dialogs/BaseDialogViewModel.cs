using Employee_WPF_MVVM_CRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Services.Dialogs
{
    internal abstract class BaseDialogViewModel<TResult> : BaseViewModel
    {
        public string Title { get; set; }
        public string Message {  get; set; }
        public TResult? DialogResult { get; set; }
         
        public BaseDialogViewModel() : this(string.Empty, string.Empty) { }
        public BaseDialogViewModel(string title) : this(title, string.Empty) { }
        public BaseDialogViewModel(string title, string message) 
        {
            Title = title;
            Message = message;
        }

        public void CloseDialogWithResult(IDialogWindow dialog, TResult? result)
        {
            DialogResult = result;
            if (dialog != null)
            {
                dialog.DialogResult = true;
            }
        }
    }
}
