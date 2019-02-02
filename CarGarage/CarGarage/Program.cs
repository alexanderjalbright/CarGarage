using System;
using System.Collections.Generic;

namespace CarGarage
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage myGarage = Intro();

            

            

            Menu(myGarage);


            
        }

        static Garage Intro()
        {
            Console.WriteLine("Hello, new driver. Welcome to Test Drive.");

            Console.WriteLine("What is your name?");
            Garage myGarage = new Garage();
            myGarage.GetUserName(Console.ReadLine());
            Console.Clear();
            
            Console.WriteLine("Nice to meet you, " + myGarage.UserName + ". Lets get started by adding some cars to your garage.");

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

                Console.WriteLine("Now you have some vehicles to test drive. You are free to do as you please!");
                
            }

            return myGarage;
        }

        static int GetNumOfCars()
        {
            bool error;
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
                    else
                    {
                        error = false;
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
            Console.WriteLine("\nPlease try again.");
            Pause();

            return true;
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        static void Menu(Garage myGarage)
        {

            bool run = true;
            do
            {
                Pause();

                List<string> menuItems = new List<string>()
                {
                    "Main Menu:"
                };

                int menuIndex = 1;

                if (myGarage.ParkingSpots.Count < 5)
                {
                    menuItems.Add(menuIndex + ". Add Cars");
                    menuIndex++;
                }
                if (myGarage.ParkingSpots.Count > 0)
                {
                    menuItems.Add(menuIndex + ". Remove Car");
                    menuIndex++;
                }
                if (myGarage.IsCarSelected)
                {
                    menuItems.Add(menuIndex + ". Return Car");
                    menuIndex++;
                }
                else
                {
                    menuItems.Add(menuIndex + ". Test Drive Car");
                    menuIndex++;
                }
                menuItems.Add(menuIndex + ". Quit");

                foreach (string item in menuItems)
                {
                    Console.WriteLine(item);
                }

                ConsoleKeyInfo itemChosen = Console.ReadKey();

                int indexCheck = menuItems.Count + 1;
                switch (itemChosen.Key)
                {
                    case (ConsoleKey.D1):
                    case ConsoleKey.NumPad1:
                        indexCheck = 1;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        indexCheck = 2;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        indexCheck = 3;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        indexCheck = 4;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        indexCheck = 5;
                        break;
                    default:
                        break;
                }

                string itemSelected = "";
                if (indexCheck < menuItems.Count)
                {
                    itemSelected = menuItems[indexCheck].Substring(3).Remove(3);
                }

                switch (itemSelected)
                {
                    case "Add":
                        Console.WriteLine("\nADDED\n");
                        break;
                    case "Rem":
                        Console.WriteLine("\nREMOVED\n");
                        break;
                    case "Ret":
                        Console.WriteLine("\nRETURNED\n");
                        break;
                    case "Tes":
                        Console.WriteLine("\nTEST DROVE\n");
                        break;
                    case "Qui":
                        Console.WriteLine("\nQUIT\n");
                        break;
                    default:
                        TryAgain();
                        break;
                }



            } while (run);

        }

    }
}
