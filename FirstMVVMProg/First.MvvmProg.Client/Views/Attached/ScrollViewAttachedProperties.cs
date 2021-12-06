using System.Windows;
using System.Windows.Controls;

namespace FIrstMVVMProg.Client.Views.Attached
{
    public class ScrollViewAttachedProperties : ScrollViewer
    {
        public static readonly DependencyProperty trackBackgroundProperty = DependencyProperty.RegisterAttached(
            "TrackBackground", typeof(object), typeof(ScrollViewAttachedProperties));
        public static readonly DependencyProperty thumbBackgroundProperty = DependencyProperty.RegisterAttached(
            "ThumbBackground", typeof(object), typeof(ScrollViewAttachedProperties));

        public static object GetTrackBackground(DependencyObject obj)
        {
            return obj.GetValue(trackBackgroundProperty);
        }
        public static object GetThumbBackground(DependencyObject obj)
        {
            return obj.GetValue(thumbBackgroundProperty);
        }


        public static void SetTrackBackground(DependencyObject obj, object value)
        {
            obj.SetValue(trackBackgroundProperty, value);
        }
        public static void SetThumbBackground(DependencyObject obj, object value)
        {
            obj.SetValue(thumbBackgroundProperty, value);
        }
    }
}
