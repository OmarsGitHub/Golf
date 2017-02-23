using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        /// <summary>
        /// Creates the menu and game loop for the game
        /// </summary>
        public static void Menu()
        {
            bool loop = true;

            try
            {
                while (loop)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("-------------Welcome to PGA Golf Tour 2017©------------");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("P - Play new game");
                    Console.WriteLine("Q - Quit");
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;

                    switch (keyPressed)
                    {
                        case ConsoleKey.P:
                            GolfCourse newCourse = new GolfCourse();
                            newCourse.GenerateCourse();
                            break;
                        case ConsoleKey.Q:
                            Console.WriteLine("\nThank you for playing PGA Golf Tour 2017©!");
                            Console.ReadKey();
                            loop = false;
                            break;
                    }
                    Console.Clear();
                }
            }
            catch(Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
