using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.ViewModels.Utility
{
    internal class ViewModelValidator : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName) ?? Enumerable.Empty<string>();
        }

        public void AddError(string propertyName, string error)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(error);
        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void ValidateProperty<T>(string propertyName, T value, object context)
        {
            var results = new List<ValidationResult>();

            ValidationContext validationContext = new ValidationContext(context);
            validationContext.MemberName = propertyName;
            Validator.TryValidateProperty(value, validationContext, results);

            if (results.Any())
            {
                foreach (var result in results)
                {
                    AddError(propertyName, result.ErrorMessage);
                }
            }
            else
            {
                _propertyErrors.Remove(propertyName);
            }

            OnErrorsChanged(propertyName);
        }
    }
}
