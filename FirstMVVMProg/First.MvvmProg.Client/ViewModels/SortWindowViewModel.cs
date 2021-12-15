using System;

using System.Collections.ObjectModel;
using System.Windows.Input;
using Wpf.MVVM.Core;
using FIrstMVVMProg.Client.Model;
using System.Collections.Specialized;
using System.ComponentModel;

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


        }

        #region Fields
        private bool _isGistVisible;
        private bool _isDiagVisible=true;
        private string _buttonText = "Пуск";
        private string _buttonBackground = "LightGreen";
        private int _n=10;//NumericUpDown
        private double _sliderValue=1;//Slider
        private string _selectedMethod;

       
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
        public string SelectedMethod
        {
            get =>_selectedMethod; 
            set 
            {
                _selectedMethod = value;
                OnPropertyChanged(nameof(SelectedMethod));
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
            Col.Clear();
            Random rand = new Random();
            while (Col.Count != N)
            {
                int chislo = rand.Next(1, N+1);
                bool flag = false;
                foreach(Data d in Col)
                {
                    if (d.Value == chislo)
                        flag = true;
                }

                if (!flag)
                {
                    Col.Add(new Data { Value = chislo });
                    
                    System.Threading.Thread.Sleep(50);
                }
                }
        }
        #endregion







    }
}

