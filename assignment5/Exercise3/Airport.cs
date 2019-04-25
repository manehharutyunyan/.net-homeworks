using System;
using System.Collections.Generic;

namespace Exercise3
{
    /// <summary>
    /// Class represents an airport
    /// </summary>
    public class Airport : IComparer<Airport>
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Size { get; set; }

        /// <summary>
        /// Orders two airports according to their size. 
        /// </summary>
        /// <param name="airport 1"></param>
        /// <param name="airport 2"></param>
        /// <returns></returns>
        public int Compare(Airport x, Airport y)
        {
            int index1 = (int)Enum.Parse(typeof(Sizes), x.Size);// the index of "x.size" in enum Sizes
            int index2 = (int)Enum.Parse(typeof(Sizes), y.Size);

            if (index1 == index2)
                return 0;
            else if (index1 < index2)
                return -1;
            return 1;
        }

        enum Sizes
        {
            Small,
            Medium,
            Large,
            Mega,
            SuperMega
        }
    }
}
