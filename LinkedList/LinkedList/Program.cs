using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace LinkedList
{
    class Solution
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            //list.Print();
            foreach (var item in list)
            {
                Console.WriteLine(item.data);
            }
        }
    }
}
