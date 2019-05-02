using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimap
{
    class Program
    {
        static void Main(string[] args)
        {
            Multimap<int, string> multimap = new Multimap<int, string>();
            multimap.Add(1, "a1");
            multimap.Add(1, "a2");
            multimap.Add(1, "a3");

            multimap.Add(2, "b1");
            multimap.Add(2, "b2");
            multimap.Add(2, "b3");

            //KeyValuePair<int, List<string>>[] multimap2 = new KeyValuePair<int, List<string>>[multimap.Count];
            //multimap.CopyTo(multimap2, 0);
            //Console.WriteLine(multimap2);
            //ICollection intList = multimap.Values;
            //Console.WriteLine(intList);
            //List<string> newL = (List<string>)multimap[1];
            //Console.WriteLine(multimap[1]);
            //multimap.Print();
            //multimap.Remove(1);
            //multimap.Print();

        }
    }
}
