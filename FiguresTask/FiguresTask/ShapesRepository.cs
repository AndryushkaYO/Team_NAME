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
        public void Add(Polygon item)
        {
            if (item != null)
            {
                Polygons.Add(item);
            }
            else
                throw new ArgumentException("Impossible to Add unexisting polygon");
        }

        public void AddRange(IEnumerable<Polygon> items)
        {
            if (items != null)
                Polygons.AddRange(items);
            else
                throw new ArgumentException("Impossible to get range between unexisting polygons or their points");
        }


        public IEnumerable<Polygon> GetAll()
        {
            return Polygons;
        }

        public void Remove(Polygon item)
        {
            if (item != null)
                Polygons.Remove(item);
            else
                throw new ArgumentException("Impossible to remove unselected polygon");
        }

        public void RemoveAll()
        {
            Polygons.Clear();
        }
    }
}
