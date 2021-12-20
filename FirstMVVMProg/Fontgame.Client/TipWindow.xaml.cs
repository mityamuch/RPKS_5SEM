using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fontgame.Client
{
    public partial class TipWindow : Window
    {
        private string _fontFamily;
        private string _fontStyle ;
        private int _fontSize ;
        private string _fontColour;
        private string _CurrentfontColour;
        private int _CurrrentFontsize;
        private MainWindowViewModel _model;

        public ObservableCollection<string> FontFamilies
        {
            get;
            set;
        } = new ObservableCollection<string>();
        public TipWindow(string fontFamily,  string fontStyle,  int fontSize,int CurrrentFontsize, string fontColour,string CurrentfontColour , int score, ObservableCollection<string> fontFamilies, MainWindowViewModel model)
        {
            InitializeComponent();
            _fontFamily=fontFamily;
            _fontStyle=fontStyle;
            _fontSize=fontSize;
            _fontColour=fontColour;
            FontFamilies = fontFamilies;
            _CurrrentFontsize = CurrrentFontsize;
            _CurrentfontColour = CurrentfontColour;
            _model = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            List<char> list = new List<char>();
            if (Tip1.IsChecked.Value)
            {
                foreach(char l in _fontFamily)
                {
                    list.Add(l);
                }
                Random rnd = new Random();

                char letter = list[rnd.Next(0, list.Count)];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != letter)
                        list[i] = '_';
                }
                string result="";
                foreach (char l in list)
                {
                    result += l;
                    result += ' ';
                }
                MessageBox.Show("Название шрифта:\n" + result);
            }
            else if(Tip2.IsChecked.Value)
            {

                FontLetter window = new FontLetter();
                
                window.ShowDialog();
            }
            else if (Tip3.IsChecked.Value)
            {
                if (_CurrrentFontsize > _fontSize)
                    MessageBox.Show("Текущий размер шрифта больше чем нужный");
                else if (_CurrrentFontsize < _fontSize)
                    MessageBox.Show("Текущий размер шрифта меньше чем нужный");
                else 
                    MessageBox.Show("Текущий размер шрифта угадан верно");
            }
            else if (Tip4.IsChecked.Value)
            {
                if (_CurrentfontColour ==_fontColour)
                    MessageBox.Show("Текущий цвет угадан верно");
                else
                    MessageBox.Show("Цвет указан неверно ");

            }
            Log.Write("log", "Подсказка -5");
            _model.Score -= 5;
        }
    }
}
