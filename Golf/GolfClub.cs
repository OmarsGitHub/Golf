using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class GolfClub
    {
        public double Power { get; set; }
        public double Angle { get; set; }
        public int NumberOfSwings { get; set; }
        double[] distanceTravelled = new double[10];
        const double GRAVITY = 9.8;
        const int NUMBER_OF_TRIES = 10;
        const int TO_FAR_AWAY = -300;

        /// <summary>
        /// The main method which calculates and displays the information about one round(course) of the game
        /// </summary>
        /// <param name="distance"></param>
        public void DoSwing(ref double distance)
        {

            while (distance != 0)
            {

                try
                {
                    DisplayDistance(distance);
                    InputPower();
                    InputAngle();
                    SwingBall(ref distance);
                    if (distance < TO_FAR_AWAY)
                        throw new Exception("You have shot the ball way to far beyond the hole! The game terminates!");
                    else if (distance < 0)
                        distance *= -1;
                    else if (NumberOfSwings == NUMBER_OF_TRIES)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have used up all of your tries, better luck next time!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        break;
                    }
                    else if (distance <= 0.05 && distance > 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Congratulations you have completed the course!");
                        Console.ForegroundColor = ConsoleColor.White;
                        ShowAllSwings();
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You can only input an integer!");
                    Console.ReadKey();
                }

            }

        }

        /// <summary>
        /// Takes input from user to use as power for the swing
        /// </summary>
        public void InputPower()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please enter with which amount of power you would like to hit the ball (1-100):");
                int tryPower = int.Parse(Console.ReadLine());
                if (tryPower <= 100 && tryPower > 0)
                {
                    Power = tryPower;
                    loop = false;
                }
                else if (tryPower <= 0)
                {
                    Console.WriteLine("You cant have below 1 in power!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You dont have that amount of power!");
                    Console.ReadKey();
                }
            }

        }

        /// <summary>
        /// Takes angle from user to use for the swing
        /// </summary>
        public void InputAngle()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please enter with what angle you would like to aim (0-90):");
                int tryAngle = int.Parse(Console.ReadLine());
                if (tryAngle <= 90 && tryAngle > 0)
                {
                    Angle = tryAngle;
                    loop = false;
                }
                else if (tryAngle <= 0)
                {
                    Console.WriteLine("You have to aim above ground!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You cant aim backwards!");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Calculates and saves the distance remaining to 
        /// the hole and displays how far the ball travelled from the swing
        /// </summary>
        /// <param name="distance"></param>
        public void SwingBall(ref double distance)
        {
            Console.Clear();
            Console.WriteLine("Press any key to hit the ball");
            Console.ReadKey();
            Console.Clear();
            double travelled = CalculateSwing();
            distance -= travelled;
            Console.WriteLine("The ball travelled {0} meters!", travelled);
            Console.ReadKey();

        }

        /// <summary>
        /// Calculates the distance of the swing and saves the swing to an array.
        /// </summary>
        /// <returns></returns>
        public double CalculateSwing()
        {
            double angleInRadians = (Math.PI / 180) * Angle;
            double swing = Math.Round(Math.Pow(Power, 2) / GRAVITY * Math.Sin(2 * angleInRadians), 2);

            distanceTravelled[NumberOfSwings] = swing;
            NumberOfSwings++;
            return swing;

        }

        /// <summary>
        /// Displays how far from goal the ball is and shows how many swings the player has taken
        /// </summary>
        /// <param name="distance"></param>
        public void DisplayDistance(double distance)
        {
            Console.Clear();
            Console.WriteLine("You are {0} meters from goal.", Math.Round(distance, 2));
            Console.WriteLine("Swings used: ({0}\\{1})", NumberOfSwings, NUMBER_OF_TRIES);
        }

        /// <summary>
        /// Display all swings made during the game of one course
        /// </summary>
        public void ShowAllSwings()
        {
            int counter = 1;
            for (int i = 0; i < NumberOfSwings; i++)
            {
                Console.WriteLine("Swing number {0} travelled the distance of {1} meters", counter, distanceTravelled[i]);
                counter++;
            }
            Console.ReadKey();
        }
    }
}
