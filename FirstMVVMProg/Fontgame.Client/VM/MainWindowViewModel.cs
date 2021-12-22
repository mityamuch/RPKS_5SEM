using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wpf.MVVM.Core;

using System.Windows;
using System.Windows.Media;
using System.IO;
using System.Collections.Generic;

namespace Fontgame.Client
{
   public sealed class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> FontFamilies
        {
            get;
            set;
        } = new ObservableCollection<string>();

        public ObservableCollection<string> FontStyles
        {
            get;
            set;
        } = new ObservableCollection<string>();

        public ObservableCollection<string> Colours
        {
            get;
            set;
        } = new ObservableCollection<string>();


        #region Fields

        private string _fontFamily = "Calibri";
        private string _fontStyle = "Normal";
        private int _fontSize = 50;
        private string _fontColour = "Black";
        private  int _score = 0;

        private string _CurfontFamily;
        private string _CurfontStyle;
        private int _CurfontSize;
        private string _CurfontColour;

        #endregion

        public MainWindowViewModel()
        {
            #region Fill
            foreach (FontFamily item in Fonts.SystemFontFamilies)
            {
                if((item.Source).Length<=10)
                    FontFamilies.Add(item.Source);
            }
            FontStyles.Add("Normal");
            FontStyles.Add("Oblique");
            FontStyles.Add("Italic");

            Colours.Add("#FF0000FF");
            Colours.Add("#FF000000");
            Colours.Add("#FFFFFF00");
            Colours.Add("#FF008000");
            Colours.Add("#FFEE82EE");
            Colours.Add("#FFFF0000");
            Colours.Add("#FFFFC0CB");
            Colours.Add("#FFD2691E");
            Colours.Add("#FFFF7F50");
            Colours.Add("#FF7FFF00");
            Colours.Add("#FFDCDCDC");
            Colours.Add("#FFFFD700");

            #endregion
            Random rnd = new Random();

            FontSize= rnd.Next(30, 70);
            FontFamily = FontFamilies[rnd.Next(0,130)];
            FontStyle =FontStyles[rnd.Next(0,2)];
            FontColour = Colours[rnd.Next(0,11)];
            Log.Write("log", "Новая игра");

        }


        #region Propertiers
        public int FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged(nameof(FontSize));
            }
        }

        public string FontFamily
        {
            get => _fontFamily;
            set
            {
                _fontFamily = value;
                OnPropertyChanged(nameof(FontFamily));
            }
        }

        public string FontColour
        {
            get => _fontColour;
            set
            {
                _fontColour = value;
                OnPropertyChanged(nameof(FontColour));
            }
        }

        public string FontStyle
        {
            get => _fontStyle;
            set
            {
                _fontStyle = value;
                OnPropertyChanged(nameof(FontStyle));
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }


        public int CurFontSize
        {
            get => _CurfontSize;
            set
            {
                _CurfontSize = value;
                OnPropertyChanged(nameof(CurFontSize));
            }
        }

        public string CurFontFamily
        {
            get => _CurfontFamily;
            set
            {
                _CurfontFamily = value;
                OnPropertyChanged(nameof(CurFontFamily));
            }
        }

        public string CurFontColour
        {
            get => _CurfontColour;
            set
            {
                _CurfontColour = value;
                OnPropertyChanged(nameof(CurFontColour));
            }
        }

        public string CurFontStyle
        {
            get => _CurfontStyle;
            set
            {
                _CurfontStyle = value;
                OnPropertyChanged(nameof(CurFontStyle));
            }
        }
        #endregion

        #region Commands
        private ICommand _answer;
        private ICommand _tip;

        public ICommand AnswerCommand =>
            _answer ??= new RelayCommand(_ => Answer());

        public ICommand TipCommand =>
            _tip ??= new RelayCommand(_ => Tip());

        public void Answer()
        {
            if (CurFontStyle == FontStyle && CurFontSize == FontSize && CurFontFamily == FontFamily && CurFontColour == FontColour)
            {
                Score += 100;
                MessageBox.Show("Поздравляем вы выиграли!!!\nВаши очки:"+Score.ToString());
                Random rnd = new Random();
                FontSize = rnd.Next(30, 70);
                FontFamily = FontFamilies[rnd.Next(0, 130)];
                FontStyle = FontStyles[rnd.Next(0, 2)];
                FontColour = Colours[rnd.Next(0, 11)];
                //Запись результата в файл
                Cache cache = new Cache();
                cache.SaveInTop(Score);
                //Запись в log
                Log.Write("log","Правильный ответ +100"+"Итог: "+Score.ToString());


                Score = 0;
                Log.Write("log", "Новая игра");
            }
            else
            {
                MessageBox.Show("Неправильно!");
                Score -= 1;
                Log.Write("log", "Неправильный ответ -1");
            }
            
        }

        public void Tip() 
        {
            TipWindow window = new TipWindow(FontFamily,FontStyle,FontSize,CurFontSize,FontColour,CurFontColour,Score,FontFamilies,this);
            window.ShowDialog();
            
        }

        #endregion
     
    }
    
 
}
