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
        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="points"></param>
        /// <param name="color"></param>
        /// <param name="stroke"></param>
        public PolygonModel(List<Point> points, Color color, double stroke)
        {
            if (points != null && color != null)
            {
                Points = points;
                Color = color;
                Stroke = stroke;
            }
            else
            {
                if (points == null)
                    throw new ArgumentException("List of point was empty or set to null");
                else if (color == null)
                    throw new ArgumentException("Color value was set to null");
                else
                    throw new ArgumentException("Stroke value was set to null");
            }

        }
    }
}
