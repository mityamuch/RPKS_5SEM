using System.Windows;
using System.Windows.Input;
using Wpf.MVVM.Core;

namespace FIrstMVVMProg.Client.ViewModels
{

    internal sealed class StartWindowViewModel : ViewModelBase
    {

        private ICommand _exampleCommand;
        private bool _canExecute;
        public bool _boolFontSize=false;
        public bool BoolFontSize
        {
            get =>
                _boolFontSize;
            private set
            {
                _boolFontSize = true;
                OnPropertiesChanged(nameof(BoolFontSize));
            }
        }




        public StartWindowViewModel()
        {
            CanExecute = true;
        }

        public bool CanExecute
        {
            get =>
                _canExecute;

            private set
            {
                _canExecute = value;
                OnPropertyChanged(nameof(CanExecute));
            }
        }
        public ICommand ExampleCommand =>
            _exampleCommand ??= new RelayCommand(_ => Example(), _ => CanExecute);
        private void Example()
        {
            MessageBox.Show("Привет чувак");
        }

    }

}