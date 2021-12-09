﻿using System;
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
    public partial class Spinner : UserControl
    {
        public enum direction
        {
            Clockwise,
            Counterclockwise
        }

        public Spinner()
        {
            InitializeComponent();
            SizeChanged += Spinner_SizeChanged;
            Refresh();
        }
        #region Event Handlers
        private void Spinner_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Transform.CenterX = ActualWidth / 2;
            Transform.CenterY = ActualHeight / 2;
            Refresh();
        }
        #endregion

        #region Dependency Properties
        #region BallBrush
        public static DependencyProperty BallBrushProperty = DependencyProperty.Register(nameof(BallBrush), typeof(Brush), typeof(Spinner), new UIPropertyMetadata(Brushes.Blue, PropertyChangedCallback));
        public Brush BallBrush
        {
            get { return (Brush)GetValue(BallBrushProperty); }
            set { SetValue(BallBrushProperty, value); }
        }
        #endregion
        #region Balls
        public static DependencyProperty BallsProperty = DependencyProperty.Register(nameof(Balls), typeof(int), typeof(Spinner), new UIPropertyMetadata(8, PropertyChangedCallback, CoerceBallsValue));
        public int Balls
        {
            get { return (int)GetValue(BallsProperty); }
            set { SetValue(BallsProperty, value); }
        }
        private static object CoerceBallsValue(DependencyObject d, object baseValue)
        {
            var spinner = (Spinner)d;
            int value = Convert.ToInt32(baseValue);
            value = Math.Max(1, value);
            value = Math.Min(100, value);
            return value;
        }
        #endregion
        #region BallSize
        public static DependencyProperty BallSizeProperty = DependencyProperty.Register(nameof(BallSize), typeof(double), typeof(Spinner), new UIPropertyMetadata(20d, PropertyChangedCallback, CoerceBallSizeValue));
        public double BallSize
        {
            get { return (double)GetValue(BallSizeProperty); }
            set { SetValue(BallSizeProperty, value); }
        }
        private static object CoerceBallSizeValue(DependencyObject d, object baseValue)
        {
            var spinner = (Spinner)d;
            double value = Convert.ToDouble(baseValue);
            value = Math.Max(1, value);
            value = Math.Min(100, value);
            return value;
        }
        #endregion
        #region Direction
        public static DependencyProperty DirectionProperty = DependencyProperty.Register(nameof(Direction), typeof(direction), typeof(Spinner), new UIPropertyMetadata(direction.Counterclockwise, PropertyChangedCallback, CoerceDirectionValue));
        public direction Direction
        {
            get { return (direction)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }
        private static object CoerceDirectionValue(DependencyObject d, object baseValue)
        {
            var spinner = (Spinner)d;
            direction value = direction.Counterclockwise;
            return value;
        }


        #endregion 
        #region Speed
        public static DependencyProperty SpeedProperty = DependencyProperty.Register(nameof(Speed), typeof(int), typeof(Spinner), new UIPropertyMetadata(8, PropertyChangedCallback, CoerceSpeedValue));
        public int Speed
        {
            get { return (int)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }
        private static object CoerceSpeedValue(DependencyObject d, object baseValue)
        {
            var spinner = (Spinner)d;
            int value = Convert.ToInt32(baseValue);
            value = Math.Max(1, value);
            value = Math.Min(59, value);
            return value;
        }



        #endregion
        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var spinner = (Spinner)d;
            spinner.Refresh();
        }
        #endregion


        private void Refresh()
        {
            int n = Balls;
            double size = BallSize;

            canvas.Children.Clear();
            double x = ActualWidth / 2;
            double y = ActualHeight / 2;
            double r = Math.Min(x, y) - size / 2;
            double doubleN = Convert.ToDouble(n);
            for (int i = 1; i <= n; i++)
            {
                double doubleI = Convert.ToDouble(i);
                double x1 = x + Math.Cos(doubleI / doubleN * 2d * Math.PI) * r - size / 2;
                double y1 = y + Math.Sin(doubleI / doubleN * 2d * Math.PI) * r - size / 2;
                var e = new Ellipse
                {
                    Fill = BallBrush,
                    Opacity = doubleI / doubleN,
                    Height = size,
                    Width = size
                };
                Canvas.SetLeft(e, x1);
                Canvas.SetTop(e, y1);
                canvas.Children.Add(e);
            };
        }
    }
}
