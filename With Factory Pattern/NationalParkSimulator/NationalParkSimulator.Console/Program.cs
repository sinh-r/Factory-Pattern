using NationalParkSimulator.Models.Common;
using NationalParkSimulator.Models.Factory;

namespace NationalParkSimulator.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var animalFactory = new AnimalFactory();

            // Create a Vulture
            var vulture = animalFactory.CreateAnimal(
                "vulture",
                height: 100,
                weight: 15,
                gender: Gender.FEMALE,
                numberOfLegs: 2,
                speciality: "Scavenger"
            );
            vulture.Eat();
            vulture.Run();

            // Create a Tiger
            var tiger = animalFactory.CreateAnimal(
                "tiger",
                height: 90,
                weight: 100,
                gender: Gender.FEMALE,
                numberOfLegs: 4,
                speciality: "Hunter"
            );
            tiger.Eat();
            tiger.Run();

            // Create a Lion
            var lion = animalFactory.CreateAnimal(
                "lion",
                height: 120,
                weight: 190,
                gender: Gender.MALE,
                numberOfLegs: 4,
                speciality: "King of the Jungle"
            );
            lion.Eat();
            lion.Run();
        }
    }
}
