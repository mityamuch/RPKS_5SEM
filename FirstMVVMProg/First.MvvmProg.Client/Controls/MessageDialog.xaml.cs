using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Muhanov.Wpf.MVVM;


namespace FIrstMVVMProg.Client.Controls
{



    public partial class MessageDialog : UserControl
    {
        public MessageDialog()
        {
            InitializeComponent();
        }

        #region Properties
        #region Foreground
        public static DependencyProperty MessageForegroundColorProperty = DependencyProperty.Register(
    nameof(MessageForegroundColor), typeof(Brush), typeof(MessageDialog), new PropertyMetadata(Brushes.Black));
        
        public Brush MessageForegroundColor
        {
            get =>
                (Brush)GetValue(MessageForegroundColorProperty);

            set =>
                SetValue(MessageForegroundColorProperty, value);
        }
        #endregion

        #region Fontsize
        public static DependencyProperty MessageFontSizeProperty = DependencyProperty.Register(
            nameof(MessageFontSize), typeof(double), typeof(MessageDialog), new PropertyMetadata(24d));

        public double MessageFontSize
        {
            get =>
                (double)GetValue(MessageFontSizeProperty);

            set =>
                SetValue(MessageFontSizeProperty, value);
        }
        #endregion

        #region FontWeight
        public static DependencyProperty MessageFontWeightProperty = DependencyProperty.Register(
            nameof(MessageFontWeight), typeof(FontWeight), typeof(MessageDialog));

        public FontWeight MessageFontWeight
        {
            get =>
                (FontWeight)GetValue(MessageFontWeightProperty);

            set =>
                SetValue(MessageFontWeightProperty, value);
        }
        #endregion

        #region FontFamily
        public static DependencyProperty MessageFontFamilyProperty = DependencyProperty.Register(
            nameof(MessageFontFamily), typeof(FontFamily), typeof(MessageDialog), new PropertyMetadata(new FontFamily("Arial")));
        
        public FontFamily MessageFontFamily
        {
            get =>
                (FontFamily)GetValue(MessageFontFamilyProperty);

            set =>
                SetValue(MessageFontFamilyProperty, value);
        }
        #endregion

        #region TypeButton
        public static DependencyProperty ButtonTypeProperty = DependencyProperty.Register(
   nameof(ButtonType), typeof(TypeButtons), typeof(MessageDialog), new PropertyMetadata((TypeButtons.OkCancel)));

        public TypeButtons ButtonType
        {
            get =>
                (TypeButtons)GetValue(ButtonTypeProperty);

            set
            {
                SetValue(ButtonTypeProperty, value);
            }
        }

        #endregion

        #region ButtonStyle
        public static DependencyProperty ButtonStyleProperty = DependencyProperty.Register(nameof(ButtonStyle), typeof(Style), typeof(MessageDialog), new UIPropertyMetadata(GetDefaultStyle()));
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }
        private static Style GetDefaultStyle()
        {
            Style buttonStyle = new Style();
            buttonStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            buttonStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(10) });
            buttonStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Blue) });
            buttonStyle.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.Black) });
            return buttonStyle;
        }
        #endregion

        #region ScrollStyle
        public static DependencyProperty ScrollStyleProperty = DependencyProperty.Register(nameof(ScrollStyle), typeof(Style), typeof(MessageDialog), new UIPropertyMetadata(GetDefaultScrollStyle()));
        public Style ScrollStyle
        {
            get { return (Style)GetValue(ScrollStyleProperty); }
            set { SetValue(ScrollStyleProperty, value); }
        }
        private static Style GetDefaultScrollStyle()
        {
            Style ScrollStyle = new Style();
            ScrollStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            ScrollStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(10) });
            ScrollStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Blue) });
            ScrollStyle.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.Black) });
            return ScrollStyle;
        }
        #endregion

        #endregion




    }
}
