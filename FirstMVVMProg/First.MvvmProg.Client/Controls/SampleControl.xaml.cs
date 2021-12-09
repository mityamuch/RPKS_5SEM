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
    /// Логика взаимодействия для SampleControl.xaml
    /// </summary>
    public partial class SampleControl : UserControl
    {
        public SampleControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public readonly static DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(SampleControl), new PropertyMetadata(100));
        public readonly static DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(SampleControl), new PropertyMetadata(0));
        public readonly static DependencyProperty StepProperty = DependencyProperty.Register("Step", typeof(int), typeof(SampleControl), new PropertyMetadata(1));
        public readonly static DependencyProperty ValueProperty  = 
            DependencyProperty.Register
            ("Value",
            typeof(int),
            typeof(SampleControl),
            new FrameworkPropertyMetadata(0,
            FrameworkPropertyMetadataOptions.None,
            PropertyChangedCallback,
            CoerceValue),
            IsValidateValue );



        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ValueChanged new value is {0}", e.NewValue);
        }

        private static  object CoerceValue(DependencyObject d, object value)
        {
            /*
            if ((int)value >= (int)GetValue(MaximumProperty))
                value = GetValue(MaximumProperty);
            else if ((int)value <= (int)GetValue(MinimumProperty))
                value = GetValue(MinimumProperty);
            
            */
            return value;
        }

        private static bool IsValidateValue(object value)
        {
            int a;
            try
            {
                a=Convert.ToInt32(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetCurrentValue(ValueProperty, value); }
        }
        public int StepValue
        {
            get { return (int)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > Minimum)
            {
                Value -= StepValue;
                if (Value < Minimum)
                    Value = Minimum;
            }
        }

        void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < Maximum)
            {
                Value += StepValue;
                if (Value > Maximum)
                    Value = Maximum;
            }
        }
    }
}
