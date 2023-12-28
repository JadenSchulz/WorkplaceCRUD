using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Employee_WPF_MVVM_CRUD.Utilities.Converters
{
    internal class StringToCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int date = (int)value;
            return date.ToString("c0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            int result;
            if (int.TryParse(strValue, NumberStyles.Currency, culture, out result))
            {
                return result;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
