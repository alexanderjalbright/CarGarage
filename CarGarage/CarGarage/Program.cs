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
            Console.WriteLine("Hello, new driver. Welcome to CarGarage.");

            Console.WriteLine("What is your name?");
            Garage myGarage = new Garage();
            myGarage.GetUserName(Console.ReadLine());
            Console.Clear();
            
            Console.WriteLine("Nice to meet you, " + myGarage.UserName + ". Lets get started by adding some cars to your garage.");
            
            return myGarage;
        }

        static bool TryAgain()
        {
            Console.WriteLine("\nPlease try again.");

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
            int selectedCar = 0;
            bool run = true;
            do
            {
                Pause();

                string menuTitle = "Main Menu | " + myGarage.UserName + "'s Garage | ";
                if (myGarage.IsCarSelected)
                {
                    menuTitle += "Current Car: " + myGarage.ParkingSpots[selectedCar].Year + " " + myGarage.ParkingSpots[selectedCar].Make + " " + myGarage.ParkingSpots[selectedCar].Model;

                }
                else
                {
                    menuTitle += "No Car Selected";
                }

                List<string> menuItems = new List<string>()
                {
                    menuTitle,
                    "1. Add Cars"
                };

                int menuIndex = 2;
                
                if (myGarage.ParkingSpots.Count > 0)
                {
                    menuItems.Add(menuIndex + ". Remove Car");
                    menuIndex++;

                    if (myGarage.IsCarSelected)
                    {
                        menuItems.Add(menuIndex + ". Return Car");
                        menuIndex++;
                    }
                    else
                    {
                        menuItems.Add(menuIndex + ". Drive Car");
                        menuIndex++;
                    }
                }
                menuItems.Add(menuIndex + ". Quit");

                foreach (string item in menuItems)
                {
                    Console.WriteLine(item);
                }

                ConsoleKeyInfo itemChosen = Console.ReadKey();
                Console.WriteLine("");

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
                        myGarage = UserAddsCar(myGarage);
                        break;
                    case "Rem":
                        myGarage = UserRemovesCar(myGarage);
                        break;
                    case "Ret":
                        myGarage.ReturnCar();
                        selectedCar = -1;
                        break;
                    case "Dri":
                        if(selectedCar == -1)
                        {
                            selectedCar = SelectCar(myGarage);
                            myGarage.CheckoutCar();
                        }
                        DriveCar(selectedCar, myGarage);
                        break;
                    case "Qui":
                        Console.WriteLine("Thank you for playing, CarGarage! See you next time!");
                        return;
                    default:
                        TryAgain();
                        break;
                }
            } while (run);
        }

        static Garage UserAddsCar(Garage myGarage)
        {
            Console.WriteLine("What is the car's make?");
            string make = Console.ReadLine();

            Console.WriteLine("What is the car's model");
            string model = Console.ReadLine();

            Console.WriteLine("What is the car's year?");
            string year = Console.ReadLine();

            myGarage.AddCar(make, model, year);

            Console.WriteLine("A " + year + " " + make + " " + model + " has been added to your garage!");


            return myGarage;
        }

        static Garage UserRemovesCar(Garage myGarage)
        {
            Console.WriteLine("Which car would you like to select?");
            int whichCar = SelectCar(myGarage);

            Console.WriteLine("A " + myGarage.ParkingSpots[whichCar].Year + " " + myGarage.ParkingSpots[whichCar].Make + " " + myGarage.ParkingSpots[whichCar].Model + " has been removed from your garage!");

            myGarage.RemoveCar(whichCar);

            return myGarage;
        }

        static int SelectCar(Garage myGarage)
        {
            int i = 1;
            foreach (Car item in myGarage.ParkingSpots)
            {
                Console.WriteLine(i + ". " + item.Year + " " + item.Make + " " + item.Model);
                i++;
            }

            bool error = false;
            int selectedCar;
            do
            {
                selectedCar = NumberCheck() - 1; 

                if (selectedCar > myGarage.ParkingSpots.Count)
                {
                    error = TryAgain();
                }
            } while (error);

            return selectedCar;            
        }

        static int NumberCheck()
        {
            bool error;
            int definitelyNumber;
            do
            {
                error = false;
                string checkIsNumber = Console.ReadLine();
                if (!int.TryParse(checkIsNumber, out definitelyNumber))
                {
                    Console.WriteLine("You must enter a number.");
                    error = TryAgain();
                }
            } while (error);

            return definitelyNumber;
        }

        static void DriveCar(int selectedCar, Garage myGarage)
        {
            

        }

    }
}
