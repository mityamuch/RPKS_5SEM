
using System.Collections.ObjectModel;
using System.Windows.Media;
using Wpf.MVVM.Core;

namespace Fontgame.Client
{
    class FontLetterVM:ViewModelBase
    {
        public ObservableCollection<string> FontFamilies
        {
            get;
            set;
        } = new ObservableCollection<string>();
        private string _CurfontFamily;
        public string CurFontFamily
        {
            get => _CurfontFamily;
            set
            {
                _CurfontFamily = value;
                OnPropertyChanged(nameof(CurFontFamily));
            }
        }

        public FontLetterVM()
        {
            foreach (FontFamily item in Fonts.SystemFontFamilies)
            {
                if ((item.Source).Length <= 10)
                    FontFamilies.Add(item.Source);
            }
        }

    }
}
