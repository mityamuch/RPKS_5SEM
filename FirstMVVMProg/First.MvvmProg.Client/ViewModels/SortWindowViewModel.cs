using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.MVVM.Core;

namespace FIrstMVVMProg.Client.ViewModels
{
    public class Data:ViewModelBase
    {

        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

    }

    class SortWindowViewModel : ViewModelBase
    {

        public ObservableCollection<Data> Col
        {
            get;
            set;
        } = new ObservableCollection<Data>();

        public SortWindowViewModel() {
            
            Col.Add(new Data { Value = 100 });
            Col.Add(new Data { Value = 500 });
            Col.Add(new Data { Value = 300 });
            Col.Add(new Data { Value = 900 });
            Col.Add(new Data { Value = 480 });
            Col.Add(new Data { Value = 600 });
            Col.Add(new Data { Value = 700 });
            Col.Add(new Data { Value = 950 });
            
        }

        #region Fields
        private bool _isGistVisible;
        private bool _isDiagVisible=true;
        private string _buttonText = "Пуск";
        private string _buttonBackground = "LightGreen";
        private int _n;//NumericUpDown
        private double _sliderValue=1;//Slider

        #endregion

        #region Propertiers
        public bool IsGistVisible
        {
            get=>_isGistVisible;
            set
            {
                _isGistVisible = value;
                OnPropertyChanged(nameof(IsGistVisible));
            }
        }
        public bool IsDiagVisible
        {
            get=>_isDiagVisible;
            set
            {
                _isDiagVisible = value;
                OnPropertyChanged(nameof(IsDiagVisible));
            }
        }
        public int N
        {
            get => _n;
            set
            {
                _n = value;
                OnPropertyChanged(nameof(N));
            }
        }
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }
        public string ButtonBackground
        {
            get=>_buttonBackground;
            set
            {
                _buttonBackground = value;
                OnPropertyChanged(nameof(ButtonBackground));
            }
        }
        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                OnPropertyChanged(nameof(SliderValue));
            }
        }
        #endregion

        #region Commands
        private ICommand _gistVisible;
        private ICommand _diagVisible;
        private ICommand _startClick;
        private ICommand _mixClick;

        public ICommand GistVisibleCommand =>
    _gistVisible ??= new RelayCommand(_ => GistVisible());
        public ICommand DiagVisibleCommand =>
           _diagVisible ??= new RelayCommand(_ => DiagVisible());
        public ICommand StartClickCommand =>
            _startClick ??= new RelayCommand(_ => StartClick());

        public ICommand MixClickCommand =>
            _mixClick ??= new RelayCommand(_ => MixClick());

        private void GistVisible() {

            IsDiagVisible = false;
            IsGistVisible = true;
        }
        private void DiagVisible() {
            IsDiagVisible = true;
            IsGistVisible = false;

        }
        private void StartClick()
        {
            if (ButtonText == "Пуск")
            {
                ButtonText = "Пауза";
                ButtonBackground = "IndianRed";
            }
            else
            {
                ButtonText = "Пуск";
                ButtonBackground = "LightGreen";
            }
        }

        private void MixClick()
        {
            Random rand = new Random();
            Task<ObservableCollection<Data>>.Factory.StartNew(() =>
            {
                while (Col.Count != N)
                {
                    int n = rand.Next(1, N);
                    if (!Col.Contains(new Data { Value=n }))
                    {
                        Col.Add(new Data { Value = n });
                    }
                }
                return Col;
            }).ContinueWith(task => {}, TaskScheduler.FromCurrentSynchronizationContext());
        }
        #endregion







    }
}

