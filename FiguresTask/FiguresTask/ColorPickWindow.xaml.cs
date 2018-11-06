using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Figures
{

    /// <summary>
    /// Interaction logic for ColorPickWindow.xaml
    /// </summary>
    public partial class ColorPickWindow : Window
    {
        public ColorPickWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.ToString());
            }
        }
        private void ColorPicker_OnSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            try
            {
                if (e.NewValue != null)
                {
                    Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().polygonColor = e.NewValue.Value;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }

        }
    }
}
