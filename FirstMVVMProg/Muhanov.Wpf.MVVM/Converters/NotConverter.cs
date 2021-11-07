using System;
using System.Globalization;
using System.Windows.Media;
using Muhanov.Wpf.MVVM.Core;

namespace Muhanov.Wpf.MVVM.Converters
{
    public sealed class NotConverter : ValueConverterBase<NotConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Int32) && !(value is bool))
            {
                throw new ArgumentException("value is not of type System.Int32", nameof(value));
            }
            if (!(parameter is string operation))
            {
                throw new ArgumentException("parameter should be of type System.String", nameof(parameter));
            }

            var Operand = (dynamic)value;
            switch (operation)
            {
                case "!": return !(Operand).ToString();
                case "~": return (~Operand).ToString();
                default: throw new ArgumentException("Invalid operation", nameof(operation));
            }


        }
    }
}
