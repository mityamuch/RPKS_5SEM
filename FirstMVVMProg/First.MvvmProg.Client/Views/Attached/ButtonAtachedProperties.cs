using System.Windows;
using System.Windows.Controls;

namespace FIrstMVVMProg.Client.Views.Attached
{
    class ButtonAtachedProperties:Button
    {
        public static readonly DependencyProperty FontfamilyProperty = DependencyProperty.RegisterAttached(
           "Fontfaamily", typeof(object), typeof(ButtonAtachedProperties));

        public static readonly DependencyProperty EnabledBackgroundProperty = DependencyProperty.RegisterAttached(
            "EnabledBackGround", typeof(object), typeof(ButtonAtachedProperties));

        public static readonly DependencyProperty EnabledForeGroundProperty = DependencyProperty.RegisterAttached(
            "EnabledForeGround", typeof(object), typeof(ButtonAtachedProperties));

        public static readonly DependencyProperty NotEnabledBackgroundProperty = DependencyProperty.RegisterAttached(
           "NotEnabledBackGround", typeof(object), typeof(ButtonAtachedProperties));

        public static readonly DependencyProperty NotEnabledForeGroundProperty = DependencyProperty.RegisterAttached(
            "NotEnabledForeGround", typeof(object), typeof(ButtonAtachedProperties));

        public static object GetFontfaamily(DependencyObject obj)
        {
            return obj.GetValue(FontfamilyProperty);
        }

        public static void SetFontfaamily(DependencyObject obj, object value)
        {
            obj.SetValue(FontfamilyProperty, value);
        }

        public static object GetEnabledBackGround(DependencyObject obj)
        {
            return obj.GetValue(EnabledBackgroundProperty);
        }

        public static void SetEnabledBackGround(DependencyObject obj, object value)
        {
            obj.SetValue(EnabledBackgroundProperty, value);
        }

        public static object GetEnabledForeGround(DependencyObject obj)
        {
            return obj.GetValue(EnabledForeGroundProperty);
        }

        public static void SetEnabledForeGround(DependencyObject obj, object value)
        {
            obj.SetValue(EnabledForeGroundProperty, value);
        }


        public static object GetNotEnabledBackGround(DependencyObject obj)
        {
            return obj.GetValue(NotEnabledBackgroundProperty);
        }

        public static void SetNotEnabledBackGround(DependencyObject obj, object value)
        {
            obj.SetValue(NotEnabledBackgroundProperty, value);
        }

        public static object GetNotEnabledForeGround(DependencyObject obj)
        {
            return obj.GetValue(NotEnabledForeGroundProperty);
        }

        public static void SetNotEnabledForeGround(DependencyObject obj, object value)
        {
            obj.SetValue(NotEnabledForeGroundProperty, value);
        }


    }
}
