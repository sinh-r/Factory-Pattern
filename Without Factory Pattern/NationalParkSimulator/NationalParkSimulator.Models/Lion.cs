using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NationalParkSimulator.Models
{
    public class Lion(int height, int weight, Gender gender, int numberOfLegs, string speciality)
    {
        public int Height { get; } = height;
        public int Weight { get; } = weight;
        public Gender Gender { get; } = gender;
        public int NumberOfLegs { get; } = numberOfLegs;
        public string Speciality { get; } = speciality;

        public void Roar() => Console.WriteLine("The lion roars!");

        public void Hunt() => Console.WriteLine("The lion is hunting.");

        public void Eat() => Console.WriteLine("The lion is eating.");

        public void Run() => Console.WriteLine("The lion is running.");
    }
}
