using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Figures.Services;
using Microsoft.Win32;

namespace Figures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PolygonsService service = new PolygonsService();
        private PointCollection points = new PointCollection();
        private ObservableCollection<Polygon> polygons = new ObservableCollection<Polygon>();
        private List<Line> lines = new List<Line>();
        private const double MinDistBetweenPoints = 10f;
        private bool dragging = false;
        private Point selectPoint;

        public Color polygonColor;
        public Polygon selectedPolygon;


        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            MainCanvas.MouseUp += OnMouseUp;
            MainCanvas.MouseMove += PolygonDrag;
            polygonesList.ItemsSource = polygons;
        }

        public void CleanCanvas()
        {
            MainCanvas.Children.Clear();
            points.Clear();
            lines.Clear();
            polygons.Clear();
            dragging = false;
            selectedPolygon = null;
        }

        public void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dragging)
            {
                Canvas.SetLeft(selectedPolygon, e.GetPosition(MainCanvas).X - selectPoint.X);
                Canvas.SetTop(selectedPolygon, e.GetPosition(MainCanvas).Y - selectPoint.Y);
            }
            dragging = false;
            
        }

        public void PolygonDrag(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Canvas.SetLeft(selectedPolygon, e.GetPosition(MainCanvas).X - selectPoint.X);
                Canvas.SetTop(selectedPolygon, e.GetPosition(MainCanvas).Y - selectPoint.Y);
            }
        }

        public void AddPoint(object sender, MouseButtonEventArgs e)
        {
            Point newPoint = e.GetPosition(this);
            if (points.Count >= 1)
            {

                if (GetDistance(points.First(), newPoint) <= MinDistBetweenPoints)
                {
                    lines.Add(DrawLine(points.First()));
                    CreateNewPolygon();
                    points.Clear();
                    foreach (var line in lines)
                    {
                        MainCanvas.Children.Remove(line);
                    }
                    lines.Clear();
                    return;
                }
                lines.Add(DrawLine(newPoint));
            }
            points.Add(newPoint);

        }

        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private Line DrawLine(Point newPoint)
        {
            Line newLine = new Line
            {
                X1 = points.Last().X,
                Y1 = points.Last().Y,
                X2 = newPoint.X,
                Y2 = newPoint.Y
            };
            newLine.Stroke = Brushes.Black;
            this.MainCanvas.Children.Add(newLine);
            return newLine;
        }

        private void CreateNewPolygon()
        {
            Polygon newPolygon = new Polygon();
            newPolygon.Points = this.points.Clone();
            ColorPickWindow window = new ColorPickWindow();
            window.ShowDialog();
            newPolygon.Fill = new SolidColorBrush(polygonColor);
            MainCanvas.Children.Add(newPolygon);
            newPolygon.StrokeThickness = 2;
            newPolygon.Stroke = new SolidColorBrush(Colors.Black);
            polygons.Add(newPolygon);

        }

        private void NewCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            CleanCanvas();
            service.repo.RemoveAll();
        }

        private void OpenCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*.xml)|*.xml";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                string fullPath = System.IO.Path.GetFullPath(dialog.FileName);
                var polygons = this.service.DeserializeAll(fullPath);
                CleanCanvas();
                foreach (var polygon in polygons)
                {
                    this.polygons.Add(polygon);
                    MainCanvas.Children.Add(polygon);
                }
            }
        }

        private void SaveCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileWindow = new SaveFileDialog();
            saveFileWindow.Filter = "Text file (*.xml)|*.xml";
            saveFileWindow.ShowDialog();
            if (saveFileWindow.FileName != string.Empty)
            {
                string path = System.IO.Path.GetFullPath(saveFileWindow.FileName);
                service.SerealizeAll(path);
            }
        }

        private void SelectPolygon(object sender, RoutedEventArgs e)
        {
            var MouseOverItem = e.OriginalSource;
            Polygon pol = MouseOverItem as Polygon;
            if (MouseOverItem is MenuItem)
            {
                Polygon fromMenu = (MouseOverItem as MenuItem).DataContext as Polygon;

                if (fromMenu != null)
                {
                    MainCanvas.Children.Add(new Polygon
                    {
                        Points = fromMenu.Points.Clone(),
                        Fill = fromMenu.Fill,
                        Stroke = fromMenu.Stroke,
                        StrokeThickness = fromMenu.StrokeThickness
                    });
                }
            }

            if (pol != null)
            {

                selectedPolygon = pol;
                selectPoint = Mouse.GetPosition(MainCanvas);
                dragging = true;

            }
        }
    }
}
