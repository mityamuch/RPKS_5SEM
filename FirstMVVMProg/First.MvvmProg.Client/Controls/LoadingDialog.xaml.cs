using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FIrstMVVMProg.Client.Controls
{
    public partial class LoadingDialog : UserControl
    {
        public LoadingDialog()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty LoadingForegroundColorProperty = DependencyProperty.Register(
            nameof(LoadingForegroundColor), typeof(Brush), typeof(LoadingDialog));
        public Brush LoadingForegroundColor
        {
            get =>
                (Brush)GetValue(LoadingForegroundColorProperty);

            set =>
                SetValue(LoadingForegroundColorProperty, value);
        }

        public static readonly DependencyProperty LoadingFontSizeProperty = DependencyProperty.Register(
            nameof(LoadingFontSize), typeof(double), typeof(LoadingDialog), new PropertyMetadata(30d));
        public double LoadingFontSize
        {
            get =>
                (double)GetValue(LoadingFontSizeProperty);

            set =>
                SetValue(LoadingFontSizeProperty, value);
        }

        public static readonly DependencyProperty LoadingFontWeightProperty = DependencyProperty.Register(
            nameof(LoadingFontWeight), typeof(FontWeight), typeof(LoadingDialog));
        public FontWeight LoadingFontWeight
        {
            get =>
                (FontWeight)GetValue(LoadingFontWeightProperty);

            set =>
                SetValue(LoadingFontWeightProperty, value);
        }

        public static readonly DependencyProperty LoadingFontFamilyProperty = DependencyProperty.Register(
            nameof(LoadingFontFamily), typeof(FontFamily), typeof(LoadingDialog), new PropertyMetadata(new FontFamily("Arial")));
        public FontFamily LoadingFontFamily
        {
            get =>
                (FontFamily)GetValue(LoadingFontFamilyProperty);

            set =>
                SetValue(LoadingFontFamilyProperty, value);
        }

        public static readonly DependencyProperty LoadingDialogTextProperty = DependencyProperty.Register(
            nameof(LoadingDialogText), typeof(string), typeof(LoadingDialog), new PropertyMetadata("Please wait..."));
        public string LoadingDialogText
        {
            get =>
                (string)GetValue(LoadingDialogTextProperty);

            set =>
                SetValue(LoadingDialogTextProperty, value);
        }
    }
}
