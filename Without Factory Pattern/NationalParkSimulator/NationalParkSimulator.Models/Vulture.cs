namespace NationalParkSimulator.Models
{
    public class Vulture
    {
        public int Height { get; }
        public int Weight { get; }
        public Gender Gender { get; }
        public int NumberOfLegs { get; }
        public string Speciality { get; }

        public Vulture(int height, int weight, Gender gender, int numberOfLegs, string speciality)
        {
            Height = height;
            Weight = weight;
            Gender = gender;
            NumberOfLegs = numberOfLegs;
            Speciality = speciality;
        }

        public void Screech()
        {
            Console.WriteLine("The vulture screeches!");
        }

        public void Eat()
        {
            Console.WriteLine("The vulture is eating.");
        }

        public void Fly()
        {
            Console.WriteLine("The vulture is flying.");
        }
    }
}
