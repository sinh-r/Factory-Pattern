using NationalParkSimulator.Models.Common;
using NationalParkSimulator.Models.Contract;

namespace NationalParkSimulator.Models.Animals
{
    public class Tiger(int height, int weight, Gender gender, int numberOfLegs, string speciality)
        : Animal(height, weight, gender, numberOfLegs, speciality)
    {
        public void Roar() => Console.WriteLine("The tiger roars!");

        public void Hunt() => Console.WriteLine("The tiger is hunting.");

        public override void Eat() => Console.WriteLine("The tiger is eating.");

        public override void Run() => Console.WriteLine("The tiger is running.");
    }
}
