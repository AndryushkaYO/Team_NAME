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

        /// <summary>
        /// Initialize component of main window
        /// </summary>
        public MainWindow()
        {
            
            try
            {
                this.DataContext = this;
                InitializeComponent();
                MainCanvas.Focus();
                MainCanvas.MouseUp += OnMouseUp;
                MainCanvas.MouseMove += PolygonDrag;

                polygonesList.ItemsSource = polygons;
                MainCanvas.KeyUp += KeyboardDragging;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
        /// <summary>
        /// Cleans canvas
        /// </summary>
        public void CleanCanvas()
        {
            try
            {
                MainCanvas.Children.Clear();
                points.Clear();
                lines.Clear();
                polygons.Clear();
                dragging = false;
                selectedPolygon = null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
        /// <summary>
        /// Drags polygon using keyboard buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardDragging(object sender, KeyEventArgs e)
        {
            if (selectedPolygon != null)
            {
               // selectedPolygon.StrokeThickness = 1;

                if (e.Key == Key.Down)
                {
                    var points = selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in points)
                    {
                        newPoints.Add(new Point(point.X, point.Y + 5));
                    }

                    selectedPolygon.Points = newPoints;
                }
                if (e.Key == Key.Up)
                {
                    var points = selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in points)
                    {
                        newPoints.Add(new Point(point.X, point.Y - 5));
                    }

                    selectedPolygon.Points = newPoints;
                }
                if (e.Key == Key.Left)
                {
                    var points = selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in points)
                    {
                        newPoints.Add(new Point(point.X-5, point.Y));
                    }

                    selectedPolygon.Points = newPoints;
                }
                if (e.Key == Key.Right)
                {
                    var points = selectedPolygon.Points;
                    PointCollection newPoints = new PointCollection();
                    foreach (var point in points)
                    {
                        newPoints.Add(new Point(point.X+5, point.Y ));
                    }

                    selectedPolygon.Points = newPoints;
                }
                
            }
        }
        /// <summary>
        /// Stop holding mouse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            dragging = false;
            //if (selectedPolygon != null) selectedPolygon.StrokeThickness = 1;
        }
        /// <summary>
        /// Drag polygon using mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PolygonDrag(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Canvas.SetLeft(selectedPolygon, e.GetPosition(MainCanvas).X - selectPoint.X);
                Canvas.SetTop(selectedPolygon, e.GetPosition(MainCanvas).Y - selectPoint.Y);
            }
            

        }
        /// <summary>
        /// Add point by tapping mouse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Calculate distance between two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Double distance</returns>
        public double GetDistance(Point p1, Point p2)
        {
            if (p1 != null && p2 != null)
                return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            else
            {
                if (p1 == null)
                    throw new ArgumentException("First point was set to null");
                else
                    throw new ArgumentException("Second point was set to null");
            }
        }
        /// <summary>
        /// Draws line connecting two points
        /// </summary>
        /// <param name="newPoint"></param>
        /// <returns>Line</returns>
        public Line DrawLine(Point newPoint)
        {
            if (newPoint != null)
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
            else
                throw new ArgumentException("Second point for a line was set to null");

        }
        /// <summary>
        /// Creates new polygon
        /// </summary>
        public void CreateNewPolygon()
        {
            try
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
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
        /// <summary>
        /// Creates new canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                CleanCanvas();
                service.repo.RemoveAll();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
        /// <summary>
        /// Opens saved canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
        /// <summary>
        /// Saves actual canvars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
        /// <summary>
        /// Chooses polygon or menu item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectPolygon(object sender, RoutedEventArgs e)
        {
            try
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
                    if (selectedPolygon != null)
                    {
                        foreach (var o in polygons)
                        {
                            if (selectedPolygon.Points == o.Points && o.Fill == selectedPolygon.Fill)
                            {
                                o.StrokeThickness = 1;
                            }
                        }
                    }
                    selectedPolygon = pol;
                    selectedPolygon.StrokeThickness = 6;
                    selectPoint = Mouse.GetPosition(sender as IInputElement);
                    dragging = true;
                }
              
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
        
    }
}
