using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Wpf_Service.Bussiness_Logic
{
    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return MainWindow.Instance.HasChanges();
        }

        public void Execute(object parameter)
        {
           MainWindow.Instance.Save();
        }
    }
}
