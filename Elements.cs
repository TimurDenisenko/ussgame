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


    public static void Static(int points, int speeds, int lengths, int color1, int color2)
    {
        switch (color1)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.White; break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Blue; break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green; break;
            case 3: 
                Console.ForegroundColor = ConsoleColor.Yellow; break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Red; break;
            default:
                break;
        }
        Point point = new Point(8, 1, Convert.ToString(points));
        point.Draw();
        Point point1 = new Point(20, 1, Convert.ToString(speeds));
        point1.Draw();
        Point point2 = new Point(33, 1, Convert.ToString(lengths));
        point2.Draw();
        switch (color2)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.White; break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Blue; break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green; break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow; break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Red; break;
            default:
                break;
        }
    }

    public static Tuple<int, int> Setting()
    {
        int color1 = 0;
        int color2 = 0;
        int n;
            Console.Clear();
            while (true)
            {
                do
                {
                    Console.WriteLine("Värv\n1 - Menu\n2 - Uss\n3 - Mine välja");
                    n = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                } while (n!=1 && n!=2 && n!=3);
                if (n==1)
                {
                    Console.WriteLine("Menu Värv\n0 - Valge\n1 - Sinine\n2 - Roheline\n3 - Kollane\n4 - Punane");
                    color1 = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                }
                else if (n==2)
                {
                    Console.WriteLine("Uss Värv\n0 - Valge\n1 - Sinine\n2 - Roheline\n3 - Kollane\n4 - Punane");
                    color2 = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        Console.Clear() ;
        return Tuple.Create(color1,color2);
    }
    public static void Muusika(string nimi)
    {
        Console.WriteLine("Nimi: ");
        Point nimi1 = new Point(6, 0, nimi);
        Console.WriteLine("Points:      Speed:      Length:");
        Console.SetWindowSize(80, 21);
        nimi1.Draw();
        Heli muusika = new Heli();
        _ = muusika.Tagaplaanis_Mangida("../../../tagaplaan1.mp3");
    }

    public static Tuple<int, string> Menu()
    {
        int n, len;
        do
        {
            Console.WriteLine("Menu\n1. Registreeri\n2. Alustada mäng\n3. Vaatada rekordid\n4. Sätted\n5. Mine välja");
            n = Int32.Parse(Console.ReadLine());
        }
        while (n!=1 && n!=2 && n!=3 && n!=4 && n!=5);
        string nimi = "Anon";
        Dictionary<string, string> records = FileToo.FileToList("../../../records.txt");
        if (n==1 || n==2)
        {
            if (n==1)
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("Nimi:");
                    nimi = Console.ReadLine();
                    len = nimi.Length;
                } while (records.ContainsKey(nimi) || len<3 || len>10);
            }
            Console.Clear();
        }
        return Tuple.Create(n,nimi);
    }
    public static void UpStatic(Elements elements)
    {
        elements.Points+=1;
        elements.Lengths+=1;
        elements.Speeds+=1;
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
    public static void End(string nimi, Elements elements)
    {

        if (nimi!="Anon")
        {
            Dictionary<string,string> records = FileToo.FileToList("../../../records.txt");
            records.Add(nimi, Convert.ToString(elements.Points));
            FileToo.ListToFile(records, "../../../records.txt");
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The end!");
        Console.WriteLine("Naudi muusikat!");
    }

    public static void Watch()
    {
        Console.Clear();
        Dictionary<string, string> records = FileToo.FileToList("../../../records.txt");
        var sorted = records.OrderBy(x => x.Value);
        var sorted1 = sorted.Reverse();
        foreach (KeyValuePair<string, string> item in sorted1)
        {
            int speed;
            if (Convert.ToInt32(item.Value)>=30)
            {
                speed = 30;
            }
            else
            {
                speed = Convert.ToInt32(item.Value);
            }
            Console.WriteLine("{0}: {1}p, {2}s, {1}l", item.Key, item.Value, speed);
        }
    }
}
}
