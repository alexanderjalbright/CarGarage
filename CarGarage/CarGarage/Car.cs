using System;
using System.Collections.Generic;
using System.Text;

namespace CarGarage
{
    public class Car
    {
        public Car()
        {
            Speed = 0;
            MaxGasLevel = 1000;
            MinGasLevel = 0;
            GasLevel = MaxGasLevel;
            CarStarted = false;
        }

        public Car(int startGasLevel)
        {
            Speed = 0;
            MaxGasLevel = 1000;
            MinGasLevel = 0;
            GasLevel = startGasLevel;
            CarStarted = false;
        }

        public int Speed { get; private set; }

        public int MaxGasLevel { get; }
        
        public int MinGasLevel { get; }

        public int GasLevel { get; private set; }

        public bool CarStarted { get; private set; }
        
        public string Make { get; private set; }

        public string Model { get; private set; }

        public string Year { get; private set; }
                     
        public void Accelerate()
        {
            if (CarStarted && GasLevel > MinGasLevel)
            {
                int changeRate = 10 + (Speed / 10);
                Speed += changeRate;
                GasLevel -= changeRate;
                if (GasLevel < MinGasLevel)
                {
                    GasLevel = MinGasLevel;
                    Speed = 0;

                }
            }   
        }

        public void AddFuel()
        {
            if (!CarStarted)
            {
                GasLevel = MaxGasLevel;
            }
            
        }

        public void Brake()
        {
            Speed -= 10;

            if (Speed < 0)
                Speed = 0;
        }

        public void ToggleEngine()
        {
            if (CarStarted == true)
                CarStarted = false;
            else
                CarStarted = true;
        }

        public void NewCar(string newMake, string newModel, string newYear)
        {
            Make = newMake;
            Model = newModel;
            Year = newYear;
        }

    }
}
