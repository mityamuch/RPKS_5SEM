
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace Muhanov.Wpf.Controls
{
    public partial class NumericUpDown : UserControl
    {

        private RepeatButton _UpButton;
        private RepeatButton _DownButton;
        public readonly static DependencyProperty MaximumProperty=DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new UIPropertyMetadata(100));
        public readonly static DependencyProperty MinimumProperty= DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDown), new UIPropertyMetadata(0));
        public readonly static DependencyProperty ValueProperty = DependencyProperty.Register("Step", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(1));
        public readonly static DependencyProperty StepProperty= DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0));
        public  NumericUpDown()
        {
            this.DataContext = this;
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _UpButton = Template.FindName("Part_UpButton", this) as RepeatButton;
            _DownButton = Template.FindName("Part_DownButton", this) as RepeatButton;
            _UpButton.Click += UpButton_Click;
            _DownButton.Click += DownButton_Click;
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
