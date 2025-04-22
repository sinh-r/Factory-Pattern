namespace NationalParkSimulator.Models
{
    public class Vulture(int height, int weight, Gender gender, int numberOfLegs, string speciality)
    {
        public int Height { get; } = height;
        public int Weight { get; } = weight;
        public Gender Gender { get; } = gender;
        public int NumberOfLegs { get; } = numberOfLegs;
        public string Speciality { get; } = speciality;

        public void Screech() => Console.WriteLine("The vulture screeches!");

        public void Scavenge() => Console.WriteLine("The vulture scavenges!");

        public void Eat() => Console.WriteLine("The vulture is eating.");

        public void Fly() => Console.WriteLine("The vulture is flying.");
    }
}
