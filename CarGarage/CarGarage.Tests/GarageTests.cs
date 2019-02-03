using System;
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
            myGarage.AddCar("Lexus", "CT200h", "2012");

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
            myGarage.AddCar("Lexus", "CT200h", "2012");
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

            myGarage.AddCar("Lexus", "CT200h", "2012");
            myGarage.AddCar("Lexus", "CT200h", "2012");
            Car car1 = myGarage.CheckoutCar(0);
            Car car2 = myGarage.CheckoutCar(1);

            car1.ToggleEngine();
            car2.ToggleEngine();

            car1.Accelerate();
            car2.Accelerate();

            car1.ToggleEngine();
            car2.ToggleEngine();

            myGarage.ReturnCar(0,car1);
            myGarage.ReturnCar(1, car2);


            // Act
            myGarage.FuelAllCars();

            // Assert
            int combinedGasBothCars = myGarage.ParkingSpots[0].GasLevel + myGarage.ParkingSpots[1].GasLevel;
            Assert.Equal(2000, combinedGasBothCars);

        }

        [Fact]
        public void car_is_selected()
        {
            Garage myGarage = new Garage();
            myGarage.AddCar("Lexus", "CT200h", "2012");

            Car checkedOutCar = myGarage.CheckoutCar(0);

            Assert.Equal("Lexus", checkedOutCar.Make);
        }


        [Fact]
        public void Return_Selected_Car()
        {
            Garage myGarage = new Garage();
            myGarage.AddCar("Lexus", "CT200h", "2012");
            myGarage.AddCar("Lambo", "Diablo", "2019");
            Car checkedOutCar = myGarage.CheckoutCar(0);

            checkedOutCar.ToggleEngine();

            myGarage.ReturnCar(0, checkedOutCar);

            Assert.True(myGarage.ParkingSpots[0].CarStarted);
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
