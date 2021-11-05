using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DXpress2022.Client.Services
{
    public interface IDialogWindowService<T>
    {
        void Show();
        void ShowDialog();
    }


    public class DialogWindowService<T> : IDialogWindowService<T> where T : Window
    {
        public void Show()
        {
            //container.Resolve<T>().Show();
        }



        public void ShowDialog()
        {
            //container.Resolve<T>().ShowDialog();
        }
    }
}
