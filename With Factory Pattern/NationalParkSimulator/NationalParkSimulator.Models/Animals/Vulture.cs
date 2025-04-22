using NationalParkSimulator.Models.Common;
using NationalParkSimulator.Models.Contract;

namespace NationalParkSimulator.Models.Animals
{
    public class Vulture(int height, int weight, Gender gender, int numberOfLegs, string speciality)
        : Animal(height, weight, gender, numberOfLegs, speciality)
    {
        public void Screech() => Console.WriteLine("The vulture screeches!");

        public void Scavenge() => Console.WriteLine("The vulture scavenges!");

        public override void Eat() => Console.WriteLine("The vulture is eating.");

        public override void Run() => Console.WriteLine("The vulture is flying.");
    }
}
