﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ussgame
{
    public class Mang
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(80, 26);
            HorLine upLine = new HorLine(0,78,0,'*');
            HorLine downLine = new HorLine(0, 78, 24, '*');
            VerLine leftLine = new VerLine(0,24,0,'*');
            VerLine rightLine = new VerLine(0, 24, 78, '*');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();
            Console.ReadLine();
        }
    }
}
