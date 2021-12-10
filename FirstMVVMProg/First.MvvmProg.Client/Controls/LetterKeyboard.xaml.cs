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
    /// Логика взаимодействия для LetterKeyboard.xaml
    /// </summary>
    public partial class LetterKeyboard : UserControl
    {
        public bool CapsPressed = false;
        public bool RusLanguage = false;
        public LetterKeyboard()
        {
            InitializeComponent();
        }
        #region Fields
        #region Style
        public static DependencyProperty ButtonStyleProperty = DependencyProperty.Register(nameof(ButtonStyle), typeof(Style), typeof(LetterKeyboard), new UIPropertyMetadata(GetDefaultStyle()));
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
        public static DependencyProperty ButtonCommandProperty = DependencyProperty.Register(nameof(ButtonCommand), typeof(ICommand), typeof(LetterKeyboard), new UIPropertyMetadata());
        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }


        #endregion

        #endregion

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (ButtonCommand != null)
            {
                string text = (string)(((Button)sender).Content);
                ButtonCommand.Execute(text);
            }
        }

        private void LanguageOnClick(object sender, RoutedEventArgs e)
        {
            RusLanguage = !(RusLanguage);
            ChangeLanguage();
        }

        private void CapsOnClick(object sender, RoutedEventArgs e)
        {
            CapsPressed = !(CapsPressed);
            ChangeCaps();
        }

        public void ChangeLanguage()
        {
            if (RusLanguage)
            {
                btna.Content = "ф";
                btnc.Content = "с";
                btnd.Content = "в";
                btne.Content = "у";
                btnf.Content = "а";
                btnq.Content = "й";
                btnr.Content = "к";
                btns.Content = "ы";
                btnv.Content = "м";
                btnw.Content = "ц";
                btnx.Content = "ч";
                btnz.Content = "я";
            }
            else
            {
                btna.Content = "a";
                btnc.Content = "c";
                btnd.Content = "d";
                btne.Content = "e";
                btnf.Content = "f";
                btnq.Content = "q";
                btnr.Content = "r";
                btns.Content = "s";
                btnv.Content = "v";
                btnw.Content = "w";
                btnx.Content = "x";
                btnz.Content = "z";
            }
        }
        public void ChangeCaps() 
        {
            if (CapsPressed)
            {
                btna.Content = ((string)btna.Content).ToUpper();
                btnc.Content = ((string)btnc.Content).ToUpper();
                btnd.Content = ((string)btnd.Content).ToUpper();
                btne.Content = ((string)btne.Content).ToUpper();
                btnf.Content = ((string)btnf.Content).ToUpper();
                btnq.Content = ((string)btnq.Content).ToUpper();
                btnr.Content = ((string)btnr.Content).ToUpper();
                btns.Content = ((string)btns.Content).ToUpper();
                btnv.Content = ((string)btnv.Content).ToUpper();
                btnw.Content = ((string)btnw.Content).ToUpper();
                btnx.Content = ((string)btnx.Content).ToUpper();
                btnz.Content = ((string)btnz.Content).ToUpper();
            }
            else
            {
                btna.Content = ((string)btna.Content).ToLower();
                btnc.Content = ((string)btnc.Content).ToLower();
                btnd.Content = ((string)btnd.Content).ToLower();
                btne.Content = ((string)btne.Content).ToLower();
                btnf.Content = ((string)btnf.Content).ToLower();
                btnq.Content = ((string)btnq.Content).ToLower();
                btnr.Content = ((string)btnr.Content).ToLower();
                btns.Content = ((string)btns.Content).ToLower();
                btnv.Content = ((string)btnv.Content).ToLower();
                btnw.Content = ((string)btnw.Content).ToLower();
                btnx.Content = ((string)btnx.Content).ToLower();
                btnz.Content = ((string)btnz.Content).ToLower();
            }
        }

    }
}
