using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Figures.DataAcces
{
    public class ShapesRepository : IRepository<Polygon>
    {
        public List<Polygon> Polygons = new List<Polygon>();
        /// <summary>
        /// Adds the polygon
        /// </summary>
        /// <param name="item"></param>
        public void Add(Polygon item)
        {
            if (item != null)
            {
                Polygons.Add(item);
            }
            else
                throw new ArgumentException("Impossible to Add unexisting polygon");
        }
        /// <summary>
        /// Adds some polygones
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<Polygon> items)
        {
            if (items != null)
                Polygons.AddRange(items);
            else
                throw new ArgumentException("Impossible to get range between unexisting polygons or their points");
        }

        /// <summary>
        /// Returns all polygons
        /// </summary>
        /// <returns>Polygons</returns>
        public IEnumerable<Polygon> GetAll()
        {
            return Polygons;
        }
        /// <summary>
        /// Remove chosen polygon
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Polygon item)
        {
            if (item != null)
                Polygons.Remove(item);
            else
                throw new ArgumentException("Impossible to remove unselected polygon");
        }
        /// <summary>
        /// Remove all polygons
        /// </summary>
        public void RemoveAll()
        {
            Polygons.Clear();
        }
    }
}
