using System;
using System.Globalization;
using System.Windows.Media;
using Muhanov.Wpf.MVVM.Core;

namespace Muhanov.Wpf.MVVM
{
    public sealed class NullCheckConverter : ValueConverterBase<NullCheckConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return  (value is null).ToString();
        }
    }
}
