using System.Windows;
using System.Windows.Input;
using Wpf.MVVM.Core;

namespace FIrstMVVMProg.Client.ViewModels
{

    internal sealed class StartWindowViewModel : ViewModelBase
    {

        private ICommand _exampleCommand;
        private ICommand _switchCanExecuteCommand;
        private bool _canExecute;

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

        public ICommand SwitchCanExecuteCommand =>
            _switchCanExecuteCommand ??= new RelayCommand(_ => SwitchCanExecute());

        private void Example()
        {
            MessageBox.Show("Привет чувак");
        }

        private void SwitchCanExecute()
        {
            CanExecute = !CanExecute;
        }

    }

}