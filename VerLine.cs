using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ussgame
{
    class VerLine
    {
        List<Point> pList;
        public VerLine(int yLeft, int yRight, int x, char sym)
        {
            pList = new List<Point>();
            for (int i = yLeft; i <= yRight; i++)
            {
                Point p = new Point(x, i, sym);
                pList.Add(p);
            }
        }

        public void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}

