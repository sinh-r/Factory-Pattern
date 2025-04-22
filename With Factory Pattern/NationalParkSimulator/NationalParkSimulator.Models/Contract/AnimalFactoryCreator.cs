using NationalParkSimulator.Models.Common;

namespace NationalParkSimulator.Models.Contract
{
    public abstract class AnimalFactoryCreator
    {
        public abstract Animal CreateAnimal(
            string animal,
            int height,
            int weight,
            Gender gender,
            int numberOfLegs,
            string speciality);
    }
}
