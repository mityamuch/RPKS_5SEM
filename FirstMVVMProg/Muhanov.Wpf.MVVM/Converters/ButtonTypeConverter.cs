using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using Muhanov.Wpf.MVVM.Core;


namespace Muhanov.Wpf.MVVM
{
    public enum TypeButtons
    {
        Ok, OkCancel, YesNo
    }

    public enum ParamType
    {
        button1Visibility,button1Text,button2Text
    }


    public class ButtonTypeConverter : ValueConverterBase<ButtonTypeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TypeButtons type = (TypeButtons)((int)value);
            ParamType param = (ParamType)System.Convert.ToInt32(parameter);
            switch (type)
            {
                case TypeButtons.Ok:
                    {
                        switch (param)
                        {
                            case ParamType.button1Visibility:
                                return Visibility.Hidden;
                            case ParamType.button1Text:
                                return "";
                            case ParamType.button2Text:
                                return "Ok";
                            default:
                                throw new Exception();
                        }
                    }
                case TypeButtons.OkCancel:
                    {
                        switch (param)
                        {
                            case ParamType.button1Visibility:
                                return Visibility.Visible;
                            case ParamType.button1Text:
                                return "Cancel";
                            case ParamType.button2Text:
                                return "Ok";
                            default:
                                throw new Exception();
                        }
                    }
                case TypeButtons.YesNo:
                    {
                        switch (param)
                        {
                            case ParamType.button1Visibility:
                                return Visibility.Visible;
                            case ParamType.button1Text:
                                return "No";
                            case ParamType.button2Text:
                                return "Yes";
                            default:
                                throw new Exception();
                        }
                    }
                default:
                    throw new Exception();
            }
        }
    }
}
