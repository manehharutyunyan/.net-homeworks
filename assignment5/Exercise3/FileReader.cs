using System.Collections.Generic;
using System.IO;

namespace Exercise3
{
    /// <summary>
    /// Class for reading data from file
    /// </summary>
    class FileReader
    {
        private string FileName { get; set; }

        public FileReader()
        {

        }

        /// <summary>
        /// Method reads data from file and makes list of
        /// Airport objects from it
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<Airport> ReadFile(string fileName)
        {
            List<Airport> airports = new List<Airport>();
            StreamReader reader = new StreamReader(fileName);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] columns = line.Split(' ');
                Airport airport = new Airport()
                {
                    Name = columns[0],
                    CountryCode = columns[1],
                    Size = columns[2]
                };
                airports.Add(airport);
            }
            return airports;
        }
    }
}
