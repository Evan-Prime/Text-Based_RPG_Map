using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG_Map
{
    internal class Program
    {
        static char[,] map = new char[,] // dimensions defined by following data:
        {
            {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
            {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
            {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
            {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        };
        // map legend:
        // ^ = mountain
        // ` = grass
        // ~ = water
        // * = trees

        static bool gameOver; // true or false
        static int playerPosx; // play position
        static int playerPosy; // play position

        static void Main(string[] args)
        {
            gameOver = false;

            playerPosx = 18;
            playerPosy = 10;

            Console.WriteLine();
            Console.WriteLine("Display Map: No Scaling.");
            Console.WriteLine();
            
            DisplayMap();

            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Display Map: With x2 Scaling.");
            Console.WriteLine();

            DisplayMap(2);

            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Display Map: With x3 Scaling.");
            Console.WriteLine();

            DisplayMap(3);

            Console.ReadKey(true);
            Console.Clear();

            // game loop
            while (gameOver == false)
            {
                PlayerUpdate();
                PlayerDraw();
            }
        }

        static void DisplayMap()
        {
            Console.Write("+");
            for (int borderLine = 0; borderLine < map.GetLength(1); borderLine++)
            {
                Console.Write("-");
            }
            Console.Write("+");

            Console.WriteLine();

            for (int y = 0; y <= 11; y++)
            {
                Console.Write("|");
                for (int x = 0; x <= 29; x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.Write("|");

                Console.WriteLine();
            }

            Console.Write("+");
            for (int borderLine = 0; borderLine < map.GetLength(1); borderLine++)
            {
                Console.Write("-");
            }
            Console.Write("+");

        }

        static void DisplayMap(int scale)
        {
            Console.Write("+");
            for (int borderLine = 0; borderLine < map.GetLength(1) * scale; borderLine++)
            {
                Console.Write("-");
            }
            Console.Write("+");

            Console.WriteLine();

            for (int y = 0; y <= 11; y++)
            {
                for (int rows = 0; rows < scale; rows++)
                {
                    Console.Write("|");
                    for (int x = 0; x <= 29; x++)
                    {
                        
                        for (int columns = 0; columns < scale; columns++)
                        {
                            Console.Write(map[y, x]);
                        }
                        
                    }
                    Console.Write("|");

                    Console.WriteLine();
                }
            }

            Console.Write("+");
            for (int borderLine = 0; borderLine < map.GetLength(1) * scale; borderLine++)
            {
                Console.Write("-");
            }
            Console.Write("+");
        }

        static void PlayerUpdate()
        {
            // read user input
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            //Console.WriteLine(input);
            //Console.WriteLine(input.KeyChar);
            //Console.WriteLine(input.Key);
            // update player position
            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
            {
                playerPosy--;
            }
            if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
            {
                playerPosy++;
            }
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            {
                playerPosx++;
            }
            if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
            {
                playerPosx--;
            }
            if (input.Key == ConsoleKey.Escape)
            {
                gameOver = true;
            }

            // DEBUG
            //Console.WriteLine("(" + x + "," + y + ")");

        }

        static void PlayerDraw()
        {
            Console.Clear();
            DisplayMap(2);
            Console.SetCursorPosition(playerPosx, playerPosy);
            //Console.SetCursorPosition();
            Console.Write("☺");
        }
    }
}
