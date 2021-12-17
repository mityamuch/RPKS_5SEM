using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wpf.MVVM.Core;
using FIrstMVVMProg.Client.Model;
using System.Collections;
using System.Windows.Threading;
using System.Windows;

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
        public InsertionSortState _ISS = new InsertionSortState {i = 1,j=1};
        public SelectionSortState _SSS = new SelectionSortState { i = 0, j = 1, indmin =0 };
        IEnumerator _sortState = null;
        bool _is_at_end = false;

        public ObservableCollection<Data> Col
        {
            get;
            set;
        } = new ObservableCollection<Data>();
        DispatcherTimer timer;

        public SortWindowViewModel() {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        #region Fields
        private bool _isGistVisible;
        private bool _isDiagVisible=true;
        private string _buttonText = "Пуск";
        private string _buttonBackground = "LightGreen";
        private int _n=10;//NumericUpDown
        private double _sliderValue=1;//Slider
        private string _selectedMethod;
        private bool _isSpinnerVisible=false;
        private bool _isEnabled = true;
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
                timer.Interval = TimeSpan.FromSeconds(Convert.ToInt32(value));
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

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
          public bool IsSpinnerVisible
        {
            get => _isSpinnerVisible;
            set
            {
                _isSpinnerVisible = value;
                OnPropertyChanged(nameof(IsSpinnerVisible));
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
                timer.Start();
                IsSpinnerVisible = true;
                IsEnabled = false;
            }
            else
            {
                ButtonText = "Пуск";
                IsSpinnerVisible = false ;
                ButtonBackground = "LightGreen";
                timer.Stop();
                IsEnabled = true ;

            }
        }
        private void MixClick()
        {
            Col.Clear();
            //Сброс алгоритмов
            _ISS.Clear();
            _SSS.Clear();


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
                }
                }

            
        }
        #endregion


        void timer_Tick(object sender, EventArgs e)
        {
            if (Col.Count != 0)
            {

                if ((SelectedMethod.IndexOf("Вставками")) != -1)
                {
                    InsertionSortStep();
                }

                if ((SelectedMethod.IndexOf("Выборами")) != -1)
                {
                    SelectionSortStep();
                }

                if ((SelectedMethod.IndexOf("Поразрядная")) != -1)
                {
                    RadixSortStep();
                }

                if ((SelectedMethod.IndexOf("Слиянием")) != -1)
                {
                    MergeSortStep();
                }

                if ((SelectedMethod.IndexOf("Пирамидальная")) != -1)
                {
                    HeapSortStep();
                }
            }
            else
            {
                MessageBox.Show("Нечего сортировать!");
                ButtonText = "Пуск";
                IsSpinnerVisible = false;
                ButtonBackground = "LightGreen";
                timer.Stop();
            }

        }

        public void EndOfSort()
        {
            timer.Stop();
            ButtonText = "Пуск";
            IsSpinnerVisible = false;
            ButtonBackground = "LightGreen";
            IsEnabled = true;
        }
        
        //БЕЗ Ienumerable
        private void InsertionSortStep() 
        {
            if (_ISS.i == Col.Count)
            {
                EndOfSort();
                return;
            }

            if (Col[_ISS.j].Value < Col[_ISS.j - 1].Value)
            {
                var extra = Col[_ISS.j].Value;
                Col[_ISS.j].Value = Col[_ISS.j - 1].Value;
                Col[_ISS.j - 1].Value = extra;
                _ISS.j--;
                if (_ISS.j == 0)
                {
                    _ISS.i++;
                    _ISS.j = _ISS.i;
                }
            }
            else
            {
                _ISS.i++;
                _ISS.j = _ISS.i;
            }
        }
        private void SelectionSortStep() 
        {
            if (_SSS.i == Col.Count)
            {
                EndOfSort();
                return;
            }
            _SSS.indmin = _SSS.i;
            for (_SSS.j = _SSS.i + 1; _SSS.j < Col.Count; _SSS.j++)
            {
                if (Col[_SSS.j].Value < Col[_SSS.indmin].Value)
                {
                    _SSS.indmin = _SSS.j;
                }
            }
            int temp = Col[_SSS.indmin].Value;
            Col[_SSS.indmin].Value = Col[_SSS.i].Value;
            Col[_SSS.i].Value = temp;
            _SSS.i++;
        }
        
        //С Ienumerable
        private void RadixSortStep() 
        {
            if (_sortState == null)
            {
                _sortState = Sorts.RadixSort(Col).GetEnumerator();
                _is_at_end = false;
            }
            if (_is_at_end)
            {
                EndOfSort();
                 _sortState = null;
                return;
            }
            _is_at_end = !_sortState.MoveNext();
        }
        private void MergeSortStep() 
        {
            if (_sortState == null)
            {
                _sortState = Sorts.MergeSort(Col,0,Col.Count-1).GetEnumerator();
                _is_at_end = false;
            }
            if (_is_at_end)
            {
                EndOfSort();
                _sortState = null;
                return;
            }
            _is_at_end = !_sortState.MoveNext();
        }
        private void HeapSortStep() 
        {
            if (_sortState == null)
            {
                _sortState = Sorts.Heapsort(Col).GetEnumerator();
                _is_at_end = false;
            }
            if (_is_at_end)
            {
                EndOfSort();
                _sortState = null;
                return;
            }
            _is_at_end = !_sortState.MoveNext();
        }
    }
}

