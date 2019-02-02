using System;

namespace CarGarage
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage myGarage = new Garage();
            
            Console.WriteLine("Nice to meet you, " + Intro() + ". Lets get started by adding some cars to your garage.");

            myGarage = SetUpGarage(myGarage);



            
        }

        static string Intro()
        {
            Console.WriteLine("Hello, new driver. Welcome to Test Drive.");
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            Console.Clear();

            return userName;
        }

        static int GetNumOfCars()
        {
            bool error = false;
            int numberOfCars = 0;
            do
            {
                
                Console.WriteLine("How many cars would you like to add?");
                string checkIsNumber = Console.ReadLine();
                if (int.TryParse(checkIsNumber, out numberOfCars))
                {
                    if (numberOfCars > 5)
                    {
                        Console.WriteLine("Lets keep it to 5 or less cars.");
                        error = TryAgain();
                    }
                }
                else
                {
                    Console.WriteLine("You must enter a number.");
                    error = TryAgain();
                }
            } while (error);
            Console.Clear();

            return numberOfCars;
        }

        static bool TryAgain()
        {
            Console.WriteLine("Please try again.");
            Pause();

            return true;
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        static Garage SetUpGarage(Garage myGarage)
        {
            int howManyCars = GetNumOfCars();

            for (int i = 0; i < howManyCars; i++)
            {
                int oneBase = i + 1;
                Console.WriteLine("Car #" + oneBase + ":");

                Console.WriteLine("What is the car's make?");
                string tempMake = Console.ReadLine();

                Console.WriteLine("What is the car's model");
                string tempModel = Console.ReadLine();

                Console.WriteLine("What is the car's year?");
                string tempYear = Console.ReadLine();

                myGarage.AddCar(tempMake, tempModel, tempYear);

                Console.WriteLine("A " + tempYear + " " + tempMake + " " + tempModel + " has been added to your garage!");

                Pause();
            }

            return myGarage;
        }

    }
}
