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

namespace Muhanov.Wpf.Controls
{
    public partial class NumericUpDown : UserControl
    {
        private int _numValue = 0;
        private int _step = 1;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                text.Text = value.ToString();
            }
        }

        public int Step
        {
            get { return _step; }
            set 
            {
                _step = value;
            }
        }

        public NumericUpDown()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            _numValue += _step;
            text.Text = _numValue.ToString();

        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            _numValue -= _step;
            text.Text = _numValue.ToString();

        }
    }
}
