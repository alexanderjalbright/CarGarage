﻿using System;
using Xunit;

namespace CarGarage.Tests
{
    public class GarageTests
    {
        [Fact]
        public void shouldAddCarToGarage()
        {
            // Tests AddCar() method
            // Arrange
            Garage myGarage = new Garage();

            // Act
            // NameOfInstance.ListProperty.Add(new ClassOfListItem());
            myGarage.AddCar();

            // Assert
            Assert.NotEmpty(myGarage.ParkingSpots);

        }

        [Fact]
        public void shouldRemoveCarFromGarage()
        {
            // Tests RemoveCar() method
            // Arrange
            Garage myGarage = new Garage();

            // Act
            myGarage.AddCar();
            myGarage.RemoveCar(0);
            // Assert
            Assert.Empty(myGarage.ParkingSpots);
        }

        [Fact]
        public void shouldFuelAllCars()
        {
            // Tests FuelAllCars() method
            // Arrange
            Garage myGarage = new Garage();

            // Act
            myGarage.ParkingSpots.Add(new Car(50));
            myGarage.ParkingSpots.Add(new Car(50));

            myGarage.FuelAllCars();

            // Assert
            int combinedGasBothCars = myGarage.ParkingSpots[0].GasLevel + myGarage.ParkingSpots[1].GasLevel;
            Assert.Equal(2000, combinedGasBothCars);

        }

        [Fact]
        public void shouldTestDriveOneCar()
        {
            // Use the Program class to let you select a single car
            // Program class should then let you choose what you want to do with that car
            // You do not need to test user input in the Program class
        }

        [Fact]
        public void youShouldNameThisTest()
        {
            // Should be able to list stats of all cars
            // Create necessary method(s)
            // Garage class should provide cars
            // Program class should list all stats
        }
    }
}
