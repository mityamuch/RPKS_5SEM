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
    /// Логика взаимодействия для DialogHost.xaml
    /// </summary>
    public partial class DialogHost : UserControl
    {
        public DialogHost()
        {
            InitializeComponent();
        }
        #region Properties
        #region CornRadius
        public static DependencyProperty CornRadiusProperty = DependencyProperty.Register(nameof(CornRadius), typeof(string), typeof(DialogHost), new UIPropertyMetadata("0,0,0,0"));
        public string CornRadius
        {
            get { return (string)GetValue(CornRadiusProperty); }
            set { SetValue(CornRadiusProperty, value); }
        }
        #endregion
        #region Opacity
        public static DependencyProperty OpacityBorderProperty = DependencyProperty.Register(nameof(OpacityBorder), typeof(double), typeof(DialogHost), new UIPropertyMetadata("0.4"));
        public double OpacityBorder
        {
            get { return (double)GetValue(OpacityBorderProperty); }
            set { SetValue(OpacityBorderProperty, value); }
        }
        #endregion
        #region Command
        public static DependencyProperty ClickCommandProperty = DependencyProperty.Register(nameof(ClickCommand), typeof(ICommand), typeof(DialogHost), new UIPropertyMetadata());
        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }


        #endregion

        #endregion

        public void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (ClickCommand != null)
            {
                Point p = e.GetPosition(this);
                ClickCommand.Execute(p);
            }
        }


    }
}
