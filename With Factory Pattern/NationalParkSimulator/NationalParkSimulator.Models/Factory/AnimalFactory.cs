using NationalParkSimulator.Models.Animals;
using NationalParkSimulator.Models.Common;
using NationalParkSimulator.Models.Contract;

namespace NationalParkSimulator.Models.Factory
{
    public class AnimalFactory : AnimalFactoryCreator
    {
        public override Animal CreateAnimal(
            string animal, 
            int height,
            int weight,
            Gender gender,
            int numberOfLegs,
            string speciality)
        {
            return animal.ToLower() switch
            {
                "vulture" => new Vulture(height, weight, gender, numberOfLegs, speciality),
                "tiger" => new Tiger(height, weight, gender, numberOfLegs, speciality),
                "lion" => new Lion(height, weight, gender, numberOfLegs, speciality),
                _ => throw new ArgumentException("Invalid animal type or missing parameters for the specified type.")
            };
        }
    }
}
