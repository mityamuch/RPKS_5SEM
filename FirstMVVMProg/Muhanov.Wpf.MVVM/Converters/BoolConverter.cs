using System;
using System.Globalization;
using System.Windows.Media;
using Muhanov.Wpf.MVVM.Core;

namespace Muhanov.Wpf.MVVM
{
    public sealed class BoolConverter : ValueConverterBase<BoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool @bool))
            {
                throw new ArgumentException("value is not of type System.Bool", nameof(value));
            }

            return @bool
                ? "Visible"
                : "Hidden";
        }

    }
}
