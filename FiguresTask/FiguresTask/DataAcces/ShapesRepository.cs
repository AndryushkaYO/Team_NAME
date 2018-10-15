using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Figures.DataAcces
{
    class ShapesRepository : IRepository<Polygon>
    {
        private List<Polygon> Polygons = new List<Polygon>();
        public void Add(Polygon item)
        {
           Polygons.Add(item);
        }

        public void AddRange(IEnumerable<Polygon> items)
        {
           Polygons.AddRange(items);
        }


        public IEnumerable<Polygon> GetAll()
        {
            return Polygons;
        }

        public void Remove(Polygon item)
        {
            Polygons.Remove(item);
        }

        public void RemoveAll()
        {
            Polygons.Clear();
        }
    }
}
