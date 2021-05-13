using System;
using System.Diagnostics;

namespace Reflex_Game
{
    class Program
    {
        static long runGame()
        {
            var rand = new Random();
            int waitTime = rand.Next(1500, 6000); //generate random waiting time

            System.Threading.Thread.Sleep(waitTime); //wait random amount of time

            Console.WriteLine("\nGO!");

            Stopwatch stopWatch = new Stopwatch();

            ConsoleKeyInfo space = new ConsoleKeyInfo();
            while (space.Key != ConsoleKey.Spacebar)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true); //clear input buffer
                }
                stopWatch.Reset();
                stopWatch.Start(); //begin counting elapsed time
                space = Console.ReadKey(true); //wait for user input
                stopWatch.Stop(); //stop counting elapsed time
            }

            long elapsedTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Reaction time: " + elapsedTime + " ms");

            return elapsedTime;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Reflex Game!");
            Console.WriteLine("Press enter to begin, or escape to exit ...");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true); //detect user input

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exiting ...");
                    System.Environment.Exit(0); //exit application if esc is pressed
                }

                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("\nPress spacebar as soon as you see the word GO!");

                    long[] times = new long[5]; //create array of times
                    for (int i = 0; i < 5; i++)
                    {
                        times[i] = runGame(); //run game if enter key is pressed and save time to array
                    }

                    Console.WriteLine("\nYour times were: ");
                    for (int i = 0; i < 5; i++)
                    {
                        if (i != 4)
                        {
                            Console.Write(times[i] + " ms, ");
                        }
                        else
                        {
                            Console.Write(times[i] + " ms");
                        }
                    }

                    long avgTime = (times[0] + times[1] + times[2] + times[3] + times[4]) / 5;
                    Console.WriteLine("\nAverage time: " + avgTime + " ms"); //display average time

                    Console.WriteLine("\nPress enter to play again, or escape to exit ...");
                }
            }
        }
    }
}
