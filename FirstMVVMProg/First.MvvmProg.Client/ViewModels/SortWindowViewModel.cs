using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Wpf.MVVM.Core;

namespace FIrstMVVMProg.Client.ViewModels
{
    class SortWindowViewModel : ViewModelBase
    {
        public class Data {
            public int Value { get; set; }
        }
        public ObservableCollection<Data> Line1
        {
            get;
            set;
        } = new ObservableCollection<Data>();
        public SortWindowViewModel() {
            Line1.Add(new Data { Value = 100 });
            Line1.Add(new Data { Value = 500 });
            Line1.Add(new Data { Value = 300 });
            Line1.Add(new Data { Value = 900 });
            Line1.Add(new Data { Value = 480 });
            Line1.Add(new Data { Value = 600 });
            Line1.Add(new Data { Value = 700 });
            Line1.Add(new Data { Value = 950 });
        }
    }
}

