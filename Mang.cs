using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ussgame
{
    public class Mang
    {
        public static void Main(string[] args)
        {
            Tuple<int,string> tuple = Elements.Menu();
            int n = tuple.Item1;
            string nimi = tuple.Item2;
            Elements elements = new Elements();
            Dictionary<string, string> records = FileToo.FileToList("../../../records.txt");

            if (n==1 || n==2)
            {
                Console.WriteLine("Nimi: ");
                Point nimi1 = new Point(6, 0, nimi);
                nimi1.Draw();

                Console.WriteLine("Points:      Speed:      Length:");


                Console.SetWindowSize(80, 21);
                Walls walls = new Walls(80, 20);
                walls.Draw();

                Point p = new Point(4, 5, "*");
                Snake snake = new Snake(p, 4, Direction.RIGHT);
                snake.Drow();

                Food newfood = new Food(80, 21, "*");
                Point food = newfood.CreateFood();
                Console.ForegroundColor = ConsoleColor.Green;
                food.Draw();
                Console.ForegroundColor = ConsoleColor.White;

                while (true)
                {
                    Elements.Static(elements.Points, elements.Speeds, elements.Lengths);
                    if (walls.IsHit(snake)||snake.IsHitTail())
                    {
                        break;
                    }
                    if (snake.Eat(food))
                    {
                        Elements.UpStatic(elements);
                        food = newfood.CreateFood();
                        Console.ForegroundColor = ConsoleColor.Green;
                        food.Draw();
                        Console.ForegroundColor = ConsoleColor.White;
                        if (elements.Speed!=30)
                        {
                            elements.Speed-=1;
                        }
                    }
                    else
                    {
                        snake.Move();
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.Moving(key.Key);
                    }
                    Thread.Sleep(elements.Speed);
                    elements.Time+=elements.Speed;

                }
                records = FileToo.FileToList("../../../records.txt");
                records.Add(nimi,Convert.ToString(elements.Points)); 
                FileToo.ListToFile(records, "../../../records.txt");
            }
            else if (n==3)
            {
                records = FileToo.FileToList("../../../records.txt");
                foreach (KeyValuePair<string,string> item in records)
                {
                    Console.WriteLine("{0}:{1}",item.Key,item.Value);
                }
            }
        }
    }
}
