using System;
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
            string nimi = "Anon";
            Console.WriteLine("Menu\n1. Registreeri\n2. Alustada mäng\n3. Vaatada rekordid\n4. Mine välja\n");
            int n = Int32.Parse(Console.ReadLine());
            if (n==1 || n==2)
            {
                if (n==1)
                {
                    Console.Clear();
                    Console.WriteLine("Nimi:");
                    nimi = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine("Nimi: ");
                Console.WriteLine("Points:      Speed:      Length:");
                Point nimi1 = new Point(6,0,nimi);
                nimi1.Draw();

                string points = "0";
                int points2 = 0;
                string speeds = "1";
                string lengths = "4";
                int lengths2 = 4;
                int speeds2 = 1;
                int time = 0;
                int speed = 100;
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
                Heli muusika = new Heli();
                _ = muusika.Tagaplaanis_Mangida("../../../tagaplaan.mp3");

                while (true)
                {
                    Point point = new Point(8, 1, points);
                    point.Draw();
                    Point point1 = new Point(20, 1, speeds);
                    point1.Draw();
                    Point point2 = new Point(33, 1, lengths);
                    point2.Draw();
                    if (walls.IsHit(snake)||snake.IsHitTail())
                    {
                        break;
                    }
                    if (snake.Eat(food))
                    {
                        points2+=1;
                        points = Convert.ToString(points2);
                        speeds2+=1;
                        speeds = Convert.ToString(speeds2);
                        lengths2+=1;
                        lengths= Convert.ToString(lengths2);
                        _ = muusika.Tagaplaanis_Mangida("../../../povezlo.mp3");
                        food = newfood.CreateFood();
                        Console.ForegroundColor = ConsoleColor.Green;
                        food.Draw();
                        Console.ForegroundColor = ConsoleColor.White;
                        if (speed!=30)
                        {
                            speed-=1;
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
                    Thread.Sleep(speed);
                    time+=speed;
                    if (time >= 240000)
                    {
                        _ = muusika.Tagaplaanis_Mangida("../../../tagaplaan.mp3");
                        time=0;
                    }
                }
            }
        }
    }
}
