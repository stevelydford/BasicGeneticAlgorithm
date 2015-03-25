using System;

namespace GA1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // generate initial population
            var population = new Population(2000);

            // breed fifteen times
            for (var i = 0; i < 15; i++)
            {
                var fittest = population.Breed();
                OutputResult(fittest.Value, fittest.Fitness);
            }

            Console.ReadLine();
        }

        private static void OutputResult(string value, int fitness)
        {
            Console.WriteLine("{0} [{1}]", value, fitness);
        }
    }
}
