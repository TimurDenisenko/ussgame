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
            Tuple<int,string> tuple = Elements.Menu();
            int n = tuple.Item1;
            string nimi = tuple.Item2;
            Elements elements = new Elements();

            if (n==1 || n==2 || n==4)
            {
                int color1 = 0;
                int color2 = 0;
                if (n==4)
                {
                    Tuple<int, int> colors = Elements.Setting();
                    color1 = colors.Item1;
                    color2 = colors.Item2;
                }
                Elements.Muusika(nimi);

                Walls walls = new Walls(80, 20);
                walls.Draw();

                Point p = new Point(4, 5, "*");
                Snake snake = new Snake(p, 4, Direction.RIGHT);
                snake.Draw();

                Food newfood = new Food(80, 21, "*");
                Point food = newfood.CreateFood();
                food.Draw();

                while (true)
                {
                    Elements.Static(elements.Points, elements.Speeds, elements.Lengths, color1, color2);

                    if (walls.IsHit(snake)||snake.IsHitTail())
                    {
                        break;
                    }

                    if (snake.Eat(food))
                    {
                        Elements.UpStatic(elements);
                        food = newfood.CreateFood();
                        food.Draw();
                        if (elements.Speed!=30) { elements.Speed-=1; }
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
                Elements.End(nimi, elements);
            }
            else if (n==3)
            {
                Elements.Watch();
            }
            else if (n==5)
            {
                Console.Clear();
                Console.WriteLine("Head aega!");
            }
            Console.ReadLine();
        }
    }
}
