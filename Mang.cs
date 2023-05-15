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
            int speed = 100;
            Console.SetWindowSize(80, 26);
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            Food newfood = new Food(80, 25, '*');
            Point food = newfood.CreateFood();
            Console.ForegroundColor = ConsoleColor.Green;
            food.Draw();
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                if (walls.IsHit(snake)||snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
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

            }
        }
    }
}
