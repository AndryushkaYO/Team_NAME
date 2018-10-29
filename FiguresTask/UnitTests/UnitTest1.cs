using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresTask;
using Figures;
using Figures.Services;
using Figures.DataAcces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Windows;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //Shape repository tests

        //Test Add function
        [TestMethod]
        public void ShapesRepository_Add_AddRange_Test()
        {
            Polygon polygon1 = new Polygon();
            Polygon polygon2 = new Polygon();
            Polygon polygon3 = new Polygon();
            Polygon polygon4 = new Polygon();
            List<Polygon> list = new List<Polygon>();
            list.Add(polygon3);
            list.Add(polygon4);
            ShapesRepository arr = new ShapesRepository();
            arr.Add(polygon1);
            arr.Add(polygon2);
            Assert.AreEqual(2, arr.Polygons.Count);
            arr.AddRange(list);
            Assert.AreEqual(4, arr.Polygons.Count);
        }

        //Test Get All function
        [TestMethod]
        public void ShapesRepository_GetAll_Test()
        {
            Polygon polygon1 = new Polygon();
            Polygon polygon2 = new Polygon();

            polygon2.StrokeThickness = 2;
            polygon1.HorizontalAlignment = HorizontalAlignment.Left;
            ShapesRepository arr = new ShapesRepository();
            arr.Add(polygon1);
            arr.Add(polygon2);
            List<Polygon> pol = arr.GetAll().ToList();
            Assert.AreEqual(2, pol[1].StrokeThickness);
            Assert.AreEqual(HorizontalAlignment.Left, pol[0].HorizontalAlignment);
        }

        //Test Remove and RemoveAll function
        [TestMethod]
        public void ShapesRepository_Remove_RemoveAll_Test()
        {
            Polygon polygon1 = new Polygon();
            Polygon polygon2 = new Polygon();
            Polygon polygon3 = new Polygon();
            ShapesRepository arr = new ShapesRepository();
            arr.Add(polygon1);
            arr.Add(polygon2);
            arr.Remove(polygon2);
            Assert.AreEqual(1, arr.Polygons.Count);
            arr.Add(polygon2);
            arr.Add(polygon3);
            arr.RemoveAll();
            Assert.AreEqual(0, arr.Polygons.Count);
        }

        //Polygon Model Test
        [TestMethod]
        public void PolygonModel_Test()
        {
            PolygonModel polygon1 = new PolygonModel();
            Point Point1 = new Point(1, 50);
            Point Point2 = new Point(10, 80);
            Point Point3 = new Point(50, 50);
            List<Point> points_arr = new List<Point>();
            points_arr.Add(Point1);
            points_arr.Add(Point2);
            points_arr.Add(Point3);
            Color color = new Color();
            color = Color.FromRgb(255, 0, 0);
            PolygonModel polygon2 = new PolygonModel(points_arr, color, 2);
            polygon1.Stroke = 2;
            Assert.AreNotEqual(3, polygon1.Stroke);
            Assert.AreEqual(3, polygon2.Points.Count);
            Assert.AreEqual(2, polygon2.Stroke);
            Assert.AreEqual(color, polygon2.Color);
        }


        //Polygon Service Test
        [TestMethod]
        public void PolygonService_SerializeAll_DeseriallizeAll_Test()
        {
            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = Brushes.Black;
            myPolygon.Fill = Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 5;            
            Point Point1 = new Point(1, 50);
            Point Point2 = new Point(10, 80);
            Point Point3 = new Point(50, 50);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPolygon.Points = myPointCollection;
            PolygonsService ps = new PolygonsService();
            ps.repo.Add(myPolygon);
            string path = "C:/Users/Hp/Desktop/Team_NAME/FiguresTask/UnitTests/bin/Debug/rez.txt";
            ps.SerealizeAll(path);
            List<Polygon> polArr = (ps.DeserializeAll(path)).ToList();            
            Assert.AreEqual(5, polArr[0].StrokeThickness);
        }

        //Get Polygon Test
        [TestMethod]
        public void PolygonService_GetPolygon_Test()
        {            
            Point Point1 = new Point(1, 50);
            Point Point2 = new Point(10, 80);
            Point Point3 = new Point(50, 50);
            List<Point> pointsList = new List<Point>();
            pointsList.Add(Point1);
            pointsList.Add(Point2);
            pointsList.Add(Point3);
            Color color = new Color();
            color = Color.FromRgb(255, 0, 0);
            PolygonModel pm = new PolygonModel(pointsList, color, 1);
            PolygonsService ps = new PolygonsService();   
            PrivateObject priv = new PrivateObject(ps);
            object myPolygon = priv.Invoke("GetPolygon",pm);

            Assert.IsNotNull(myPolygon);
        }

    }
}
