using System;

namespace TirePressureMonitoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Random _randomPressureSampleSimulator = new Random();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble());
            }
        }
    }
}
