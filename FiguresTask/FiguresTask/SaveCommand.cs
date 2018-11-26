using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Figures;

namespace FiguresTask
{
    class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool canExecute = false;
        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
                
            MainWindow.service.SerealizeAll(MainWindow.path);
        }
    }
}
