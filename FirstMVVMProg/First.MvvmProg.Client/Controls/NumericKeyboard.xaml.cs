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
    /// <summary>
    /// Логика взаимодействия для NumericKeyboard.xaml
    /// </summary>
    public partial class NumericKeyboard : UserControl
    {
        

        public NumericKeyboard()
        {
            InitializeComponent();
           
        }
        #region Fields
        #region Style
        public static DependencyProperty ButtonStyleProperty = DependencyProperty.Register(nameof(ButtonStyle), typeof(Style), typeof(NumericKeyboard), new UIPropertyMetadata(GetDefaultStyle()));
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

        #region Command
        public static DependencyProperty ButtonCommandProperty = DependencyProperty.Register(nameof(ButtonCommand), typeof(ICommand), typeof(NumericKeyboard), new UIPropertyMetadata());
        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }


        #endregion

        #endregion

        public void OnClick(object sender, RoutedEventArgs e)
        {
            if (ButtonCommand!=null) {
                string text = (string)(((Button)sender).Content);
                ButtonCommand.Execute(text);
            }
        }

    }
}
