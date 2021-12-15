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
        }
        public readonly static DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(SampleControl), new PropertyMetadata(100));
        public readonly static DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(SampleControl), new PropertyMetadata(0));
        public readonly static DependencyProperty StepProperty = DependencyProperty.Register("Step", typeof(int), typeof(SampleControl), new PropertyMetadata(1));
        public readonly static DependencyProperty ValueProperty  = 
            DependencyProperty.Register
            (nameof(Value),
            typeof(int),
            typeof(SampleControl),
            new FrameworkPropertyMetadata(0,
            FrameworkPropertyMetadataOptions.None,
            PropertyChangedCallback,
            CoerceValue));



        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ValueChanged new value is {0}", e.NewValue);
        }

        private static  object CoerceValue(DependencyObject d, object value)
        {
            // тут лучше валидацию приделать раньше был validate но я его просто стер
            // я не про ValidateValueCallback, а обработку входных параметров коирса
            // что если value вовсе не int
            // или d вовсе не SampleControl
            // надеюсь смысл понятен
            // ну и по 100500 раз заниматься приведениями типов и распаковкой - это некруто
            //что происходит?
            // я дурачёк просто

            var @int = (int)value;
            var cntrl = d as SampleControl;
            var coerced = @int;

            if (@int >= cntrl.Maximum) 
                coerced = cntrl.Maximum;
            else if (@int <= cntrl.Minimum)
                coerced = cntrl.Minimum;
            
            return coerced;
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

        // не думаешь что этих ребят стоит сделать public?
        // я тоже так не думаю всё-таки)00
        // но модификатор доступа лучше всегда указывать, повышается читабельность
        public void DownButton_Click(object sender, RoutedEventArgs e)
        {
                Value -= StepValue;
        }

        public void UpButton_Click(object sender, RoutedEventArgs e)
        {
                Value += StepValue;
        }

        // теперь давай подумаем логически
        // Ты хочешь из этого контрола менять int
        // могут быть траблы, потому что это value-тип
        // ща продебажу
    }
}
