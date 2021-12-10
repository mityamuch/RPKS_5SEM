using System;
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

        private string _text="0";
        public string text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(text));
            }
        }

        private ICommand _textChangeCommand;

        public ICommand TextChangeCommand =>
            _textChangeCommand ??= new RelayCommand(x => TextChange((string)x));

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

        private void TextChange(string number)
        {
            if (number == "C")
            {
                text = "";
            }
            else
            {
                text+=Convert.ToInt32(number);
            }

        }

    }

}