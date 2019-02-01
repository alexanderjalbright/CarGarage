using System;
using System.Collections.Generic;
using System.Text;

namespace CarGarage
{
    public class Garage
    {
        public List<Car> ParkingSpots { get; private set; }

        public Garage()
        {
            ParkingSpots = new List<Car>() { };
        }

        public void AddCar()
        {
            ParkingSpots.Add(new Car());
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
    }
}
