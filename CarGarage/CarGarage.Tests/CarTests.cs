using System;
using Xunit;

namespace CarGarage.Tests
{
    public class CarTests
    {
        [Fact]
        public void Create_Car()
        {
            Car firstCar = new Car();
        }

        [Fact]
        public void Speed_Starts_Zero()
        {
            Car firstCar = new Car();

            Assert.Equal(0, firstCar.Speed);
        }

        [Fact]
        public void shouldAccelerate()
        {
            // Tests Accelerate() method in Car increases Speed
            // Arrange
            Car firstCar = new Car();

            // Act
            firstCar.Accelerate();

            // Assert
            Assert.Equal(10, firstCar.Speed);
        }

        [Fact]
        public void shouldConsumeFuel()
        {
            // Tests Accelerate() method reduces Fuel amount
            // Arrange
            Car firstCar = new Car();

            // Act
            firstCar.Accelerate();

            // Assert
            Assert.Equal(990, firstCar.GasLevel);
        }

        [Fact]
        public void shouldRefuel()
        {
            // Tests AddFuel() method increases Fuel amount
            // Arrange
            Car firstCar = new Car();

            // Act
            firstCar.Accelerate();
            firstCar.AddFuel();

            // Assert
            Assert.Equal(firstCar.MaxGasLevel, firstCar.GasLevel);
        }

        [Fact]
        public void shouldRefuelFromCurrentLevel()
        {
            // Tests AddFuel() method increases Fuel amount
            // Arrange
            Car firstCar = new Car(50);

            // Act
            firstCar.Accelerate();
            firstCar.AddFuel();

            // Assert
            Assert.Equal(firstCar.MaxGasLevel, firstCar.GasLevel);
        }

        [Fact]
        public void shouldSlowDown()
        {
            // Tests Brake() method in Car reduces Speed amount
            // Arrange
            Car firstCar = new Car();

            // Act
            firstCar.Accelerate();
            firstCar.Brake();

            // Assert
            Assert.Equal(0, firstCar.Speed);
        }

        [Fact]
        public void shouldStart()
        {
            // Tests ToggleEngine() method starts car when its off
            // Arrange
            Car firstCar = new Car();

            // Act
            firstCar.ToggleEngine();

            // Assert
            Assert.True(firstCar.CarStarted);
        }

        [Fact]
        public void shouldTurnOff()
        {
            // Tests ToggleEngine() method turns car off when its on
            // Arrange
            // Act
            // Assert
        }
    }
}
