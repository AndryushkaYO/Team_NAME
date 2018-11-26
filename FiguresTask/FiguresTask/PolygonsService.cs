using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Figures.DataAcces;

namespace Figures.Services
{
    public class PolygonsService
    {
        public ShapesRepository repo = new ShapesRepository();
        /// <summary>
        /// Serializes into XML
        /// </summary>
        /// <param name="path"></param>
        public void SerealizeAll(string path)
        {
            if (path != "" && path != null)
            {
                IEnumerable<Polygon> allPolygons = repo.GetAll();
                var points = allPolygons.Select(polygon => new PolygonModel(polygon.Points.ToList(), ((SolidColorBrush)polygon.Fill).Color, polygon.StrokeThickness)).ToArray();
                XmlSerializer formatter = new XmlSerializer(typeof(PolygonModel[]));

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, points);
                }
            }
            else
            {
                if (path == "")
                    throw new ArgumentException("Path to serealization file was set incorrectly");
                else
                    throw new ArgumentException("There was no path to serealization file");
            }

        }
        /// <summary>
        /// Deserialize chosen polygon
        /// </summary>
        /// <param name="xmlPolygon"></param>
        /// <returns>Polygon</returns>
        public Polygon GetPolygon(PolygonModel xmlPolygon)
        {
            if (xmlPolygon != null)
            {
                return new Polygon()
                {
                    Points = new PointCollection(xmlPolygon.Points),
                    StrokeThickness = xmlPolygon.Stroke,
                    Fill = new SolidColorBrush(xmlPolygon.Color),
                    Stroke = new SolidColorBrush(Colors.Black)
                };
            }
            else
                throw new ArgumentException("There was no Polygon to get.");
        }
        /// <summary>
        /// Deserialize all Polygons
        /// </summary>
        /// <param name="path"></param>
        /// <returns>IEnumerable<Polygon></returns>
        public IEnumerable<Polygon> DeserializeAll(string path)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(PolygonModel[]));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    List<PolygonModel> xmlPolygons = ((PolygonModel[])formatter.Deserialize(fs)).ToList();
                    List<Polygon> newPolygons = new List<Polygon>();
                    foreach (var xmlPolygon in xmlPolygons)
                    {
                        newPolygons.Add(this.GetPolygon(xmlPolygon));
                    }

                    repo.AddRange(newPolygons);
                    return repo.GetAll();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }
    }
}
