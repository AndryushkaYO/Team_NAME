using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Figures.DataAcces
{
    public class PolygonModel
    {
        public List<Point> Points = new List<Point>();
        public Color Color { get; set; }
        public double Stroke { get; set; }

        public PolygonModel() { }

        public PolygonModel(List<Point> points, Color color, double stroke)
        {
            Points = points;
            Color = color;
            Stroke = stroke;
        }
    }
}
