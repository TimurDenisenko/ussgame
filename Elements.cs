using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ussgame
{
    public class Elements
    {
        int points = 0;
        int lengths = 4;
        int speeds = 1;
        int time = 0;
        int speed = 100;

        public static void Static(int points, int speeds, int lengths)
        {
            Point point = new Point(8, 1, Convert.ToString(points));
            point.Draw();
            Point point1 = new Point(20, 1, Convert.ToString(speeds));
            point1.Draw();
            Point point2 = new Point(33, 1, Convert.ToString(lengths));
            point2.Draw();
        }

        public static void Muusika()
        {
            Heli muusika = new Heli();
            _ = muusika.Tagaplaanis_Mangida("../../../tagaplaan.mp3");
        }

        public static Tuple<int, string> Menu()
        {
            Console.WriteLine("Menu\n1. Registreeri\n2. Alustada mäng\n3. Vaatada rekordid\n4. Sätted\n5. Mine välja");
            int n = Int32.Parse(Console.ReadLine());
            string nimi = "Anon";
            if (n==1)
            {
                Console.Clear();
                Console.WriteLine("Nimi:");
                nimi = Console.ReadLine();
            }
            Console.Clear() ;
            return Tuple.Create(n,nimi);
        }
        public static void UpStatic(Elements elements)
        {
            elements.Points+=1;
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
        public int UpPoints
        {
            get
            {
                return points+1;
            }
            set
            {
                points = value;
            }
        }
        public int Lengths
        {
            get
            {
                return lengths;
            }
            set
            {
                lengths = value;
            }
        }
        public int Speeds
        {
            get
            {
                return speeds;
            }
            set
            {
                speeds = value;
            }
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
    }
}
