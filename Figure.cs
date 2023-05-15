using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ussgame
{
    class Figure
    {
       protected List<Point> pList;

        public virtual void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}
