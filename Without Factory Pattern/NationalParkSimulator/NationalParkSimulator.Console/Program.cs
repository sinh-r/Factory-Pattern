using NationalParkSimulator.Models;

namespace NationalParkSimulator.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate a Lion
            Lion lion = new(130, 220, Gender.FEMALE, 4, "King of the Jungle");
            lion.Roar();
            lion.Hunt();
            lion.Eat();
            lion.Run();

            // Instantiate a Tiger
            Tiger tiger = new(120, 200, Gender.MALE, 4, "Stealthy Hunter");
            tiger.Roar();
            tiger.Hunt();
            tiger.Eat();
            tiger.Run();

            // Instantiate a Vulture
            Vulture vulture = new(90, 15, Gender.MALE, 2, "Scavenger");
            vulture.Screech();
            vulture.Eat();
            vulture.Fly();
        }
    }
}
