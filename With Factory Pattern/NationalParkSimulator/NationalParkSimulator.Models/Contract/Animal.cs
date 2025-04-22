using NationalParkSimulator.Models.Common;

namespace NationalParkSimulator.Models.Contract
{
    public abstract class Animal(int height, int weight, Gender gender, int numberOfLegs, string speciality)
    {
        public int Height { get; } = height;
        public int Weight { get; } = weight;
        public Gender Gender { get; } = gender;
        public int NumberOfLegs { get; } = numberOfLegs;
        public string Speciality { get; } = speciality;

        public virtual void Eat() => Console.WriteLine("Animal is making a sound.");
        public virtual void Run() => Console.WriteLine("Animal is running.");
    }
}
