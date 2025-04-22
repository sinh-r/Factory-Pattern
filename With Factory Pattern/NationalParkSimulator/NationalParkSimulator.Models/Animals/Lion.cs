using NationalParkSimulator.Models.Common;
using NationalParkSimulator.Models.Contract;

namespace NationalParkSimulator.Models.Animals
{
    public class Lion(int height, int weight, Gender gender, int numberOfLegs, string speciality)
        : Animal(height, weight, gender, numberOfLegs, speciality)
    {
        public void Roar() => Console.WriteLine("The lion roars!");

        public void Hunt() => Console.WriteLine("The lion is hunting.");

        public override void Eat() => Console.WriteLine("The lion is eating.");

        public override void Run() => Console.WriteLine("The lion is running.");
    }
}
