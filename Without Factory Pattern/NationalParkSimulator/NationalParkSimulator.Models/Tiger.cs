namespace NationalParkSimulator.Models
{
    public class Tiger(int height, int weight, Gender gender, int numberOfLegs, string speciality)
    {
        public int Height { get; } = height;
        public int Weight { get; } = weight;
        public Gender Gender { get; } = gender;
        public int NumberOfLegs { get; } = numberOfLegs;
        public string Speciality { get; } = speciality;

        public void Roar() => Console.WriteLine("The tiger roars!");

        public void Hunt() => Console.WriteLine("The tiger is hunting.");

        public void Eat() => Console.WriteLine("The tiger is eating.");

        public void Run() => Console.WriteLine("The tiger is running.");
    }
}
