using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bukkMaraton
{
    class Program
    {
        static void Main(string[] args)
        {
            var versenyzo = new List<Versenyzo>();

            using var sr = new StreamReader(@"..\..\..\src\bukkm2019.txt");

            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {          
                versenyzo.Add(new Versenyzo(sr.ReadLine()));
            }

            Console.WriteLine("4. feladat");
            var f4 = 691f - versenyzo.Count;
            Console.WriteLine($"Versenytávot nem teljesítők: {(f4/ 691) * 100}%");

            Console.WriteLine("5. feladat");

            Console.WriteLine("6. feladat");
            var f6 = versenyzo.FirstOrDefault(d => d.Ido.Hours >= 6 && d.Ido.Minutes > 0 || d.Ido.Seconds > 0);
            if (f6 != null)
            {
                Console.WriteLine("Volt ilyen versenyző");
            }
            else 
            {
                Console.WriteLine("Nem volt ilyen versenyző");
            }
            

        }
    }
}