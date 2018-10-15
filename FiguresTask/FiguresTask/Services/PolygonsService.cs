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
    class PolygonsService
    {
        public ShapesRepository repo = new ShapesRepository();
        public void SerealizeAll(string path)
        {
            IEnumerable<Polygon> allPolygons = repo.GetAll();
            var points = allPolygons.Select(polygon => new PolygonModel(polygon.Points.ToList(), ((SolidColorBrush)polygon.Fill).Color, polygon.StrokeThickness)).ToArray();
            XmlSerializer formatter = new XmlSerializer(typeof(PolygonModel[]));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, points);
            }
        }
        private Polygon GetPolygon(PolygonModel xmlPolygon)
        {
            return new Polygon()
            {
                Points = new PointCollection(xmlPolygon.Points),
                StrokeThickness = xmlPolygon.Stroke,
                Fill = new SolidColorBrush(xmlPolygon.Color),
                Stroke = new SolidColorBrush(Colors.Black)
            };
        }
        public IEnumerable<Polygon> DeserializeAll(string path)
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
    }
}
