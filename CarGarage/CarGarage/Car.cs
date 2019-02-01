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
        }

        public int Speed { get; private set; }

        public int MaxGasLevel { get; }
        
        public int MinGasLevel { get; }

        public int GasLevel { get; private set; }

        public bool CarStarted { get; private set; }
        

        public void Accelerate()
        {
            int changeRate = 10 + (Speed / 10);
            Speed += changeRate;
            GasLevel -= changeRate;
        }

        public void AddFuel()
        {
            GasLevel = MaxGasLevel;
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

    }
}
