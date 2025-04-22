namespace NationalParkSimulator.Models
{
    public class Tiger
    {
        public int Height { get; }
        public int Weight { get; }
        public Gender Gender { get; }
        public int NumberOfLegs { get; }
        public string Speciality { get; }

        public Tiger(int height, int weight, Gender gender, int numberOfLegs, string speciality)
        {
            Height = height;
            Weight = weight;
            Gender = gender;
            NumberOfLegs = numberOfLegs;
            Speciality = speciality;
        }

        public void Roar()
        {
            Console.WriteLine("The tiger roars!");
        }

        public void Hunt()
        {
            Console.WriteLine("The tiger is hunting.");
        }

        public void Eat()
        {
            Console.WriteLine("The tiger is eating.");
        }

        public void Run()
        {
            Console.WriteLine("The tiger is running.");
        }
    }
}
