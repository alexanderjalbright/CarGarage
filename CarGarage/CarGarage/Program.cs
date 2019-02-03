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
            Car selectedCar = new Car();
            int selectedCarIndex = -1;
            bool run = true;
            do
            {
                Pause();

                string menuTitle = "Main Menu | " + myGarage.UserName + "'s Garage | ";
                if (myGarage.IsCarCheckedOut)
                {
                    menuTitle += "Current Car: " + selectedCar.Year + " " + selectedCar.Make + " " + selectedCar.Model;

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

                    if (myGarage.IsCarCheckedOut)
                    {
                        menuItems.Add(menuIndex + ". Return Car");
                        menuIndex++;
                    }
                    else
                    {
                        menuItems.Add(menuIndex + ". Drive Car");
                        menuIndex++;
                    }
                    menuItems.Add(menuIndex + ". Refuel All Cars");
                    menuIndex++;

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
                        myGarage.ReturnCar(selectedCarIndex, selectedCar);
                        break;
                    case "Dri":
                        selectedCarIndex = SelectCar(myGarage);
                        selectedCar = DriveCarMenu(myGarage.CheckoutCar(selectedCarIndex));
                        break;
                    case "Ref":
                        myGarage.FuelAllCars();
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
            Console.WriteLine("Which car would you like to drive?");
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

        static Car DriveCarMenu(Car currentCar)
        {
            bool run = true;
            do
            {
                Console.Clear();

                
                Console.WriteLine("Drive Menu | " + currentCar.Year + " " + currentCar.Make+ " " + currentCar.Model);
                decimal gasLevel = currentCar.GasLevel/10;

                Console.WriteLine("\nGas Level: " + gasLevel + "%");
                Console.WriteLine("\nSpeed: " + currentCar.Speed + " MPH\n");

                if (currentCar.CarStarted)
                {
                    Console.WriteLine("Press A to turn Off car");
                    Console.WriteLine("Press UP ARROW to accelerate");
                    Console.WriteLine("Press DOWN ARROW to brake");
                }
                else
                {
                    Console.WriteLine("Press A to turn on car");
                    Console.WriteLine("Press F to add fuel to car");
                }
                
                Console.WriteLine("Press R to return to your garage");

                ConsoleKeyInfo userChoice = Console.ReadKey();
                switch (userChoice.Key)
                {
                    case ConsoleKey.A:
                        currentCar.ToggleEngine();
                        break;
                    case ConsoleKey.UpArrow:
                        if(currentCar.GasLevel == currentCar.MinGasLevel)
                        {
                            Console.WriteLine("You're out of gas!");
                            Pause();
                        }
                        if(!currentCar.CarStarted)
                        {
                            Console.WriteLine("You're car is off!");
                            Pause();
                        }
                        currentCar.Accelerate();
                        break;
                    case ConsoleKey.DownArrow:
                        currentCar.Brake();
                        break;
                    case ConsoleKey.F:
                        if (currentCar.CarStarted)
                        {
                            Console.WriteLine("You must turn you car off!");
                            Pause();
                        }
                        currentCar.AddFuel();
                        break;
                    case ConsoleKey.R:
                        if (currentCar.CarStarted)
                        {
                            Console.WriteLine("You must turn you car off!");
                            Pause();
                        }
                        else
                        {
                            run = false;
                        }
                        
                        break;
                }
            } while (run);

            return currentCar;
        }

    }
}
