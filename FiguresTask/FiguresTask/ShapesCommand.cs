using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Figures;

namespace FiguresTask
{
    public class ShapesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return MainWindow.polygons.Count != 0;
        }

        public void Execute(object parameter)
        {            
        }
    }
}
