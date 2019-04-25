using System;

namespace Exercise3
{
    class Program
    {
        private static readonly string fileName = "Data.txt";

        static void Main(string[] args)
        {
            FileReader reader = new FileReader();
            var airports = reader.ReadFile(fileName);

            airports.Sort(new Airport());

            foreach (var item in airports)
            {
                Console.WriteLine($"{item.Name}, {item.CountryCode}, {item.Size}");
            }

        }
    }
}
