using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NationalParkSimulator.Models
{
    public class Lion
    {
        public int Height { get; }
        public int Weight { get; }
        public Gender Gender { get; }
        public int NumberOfLegs { get; }
        public string Speciality { get; }

        public Lion(int height, int weight, Gender gender, int numberOfLegs, string speciality)
        {
            Height = height;
            Weight = weight;
            Gender = gender;
            NumberOfLegs = numberOfLegs;
            Speciality = speciality;
        }

        public void Roar()
        {
            Console.WriteLine("The lion roars!");
        }

        public void Hunt()
        {
            Console.WriteLine("The lion is hunting.");
        }

        public void Eat()
        {
            Console.WriteLine("The lion is eating.");
        }

        public void Run()
        {
            Console.WriteLine("The lion is running.");
        }
    }
}
