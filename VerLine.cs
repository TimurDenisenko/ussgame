﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ussgame
{
    class VerLine : Figure
    {
        public VerLine(int yLeft, int yRight, int x, string sym)
        {
            pList = new List<Point>();
            for (int i = yLeft; i <= yRight; i++)
            {
                Point p = new Point(x, i, sym);
                pList.Add(p);
            }
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Point p in pList)
            {
                p.Draw();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
