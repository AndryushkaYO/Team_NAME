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
        {   Polygon polygon1 = new Polygon();
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

        //Test Get All function
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
    }
}
