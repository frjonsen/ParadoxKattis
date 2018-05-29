using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line == "0") return;
                var split = line.Split(' ').Select(n => float.Parse(n, CultureInfo.InvariantCulture)).ToArray();
                
                var x = Math.Abs(split[0] - split[2]);
                var y = Math.Abs(split[1] - split[3]);
                var p = split[4];
                var xy = Math.Pow(x, p) + Math.Pow(y, p);
                Console.WriteLine(Math.Pow(xy, 1 / p));
            }
        }
    }
