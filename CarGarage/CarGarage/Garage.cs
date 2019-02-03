using System;
using System.Collections.Generic;
using System.Text;

namespace CarGarage
{
    public class Garage
    {
        public Garage()
        {
            ParkingSpots = new List<Car>();
            IsCarCheckedOut = false;
        }

        public List<Car> ParkingSpots { get; private set; }

        public bool IsCarCheckedOut { get; private set; }

        public string UserName { get; set; }

        public void AddCar(string newMake, string newModel, string newYear)
        {
            Car newCar = new Car();

            newCar.NewCar(newMake, newModel, newYear);

            ParkingSpots.Add(newCar);
        }

        public void RemoveCar(int whichCar)
        {
            ParkingSpots.Remove(ParkingSpots[whichCar]);
        }

        public void FuelAllCars()
        {
            foreach(Car currentCar in ParkingSpots)
            {
                currentCar.AddFuel();
            }
        }

        public Car CheckoutCar(int whichCar)
        {
            IsCarCheckedOut = true;
            return ParkingSpots[whichCar];
        }

        public void ReturnCar(int whichCar, Car checkedOutCar)
        {
            IsCarCheckedOut = false;
            ParkingSpots[whichCar] = checkedOutCar;

        }

        public void GetUserName(string name)
        {
            UserName = name;
        }
    }
}
