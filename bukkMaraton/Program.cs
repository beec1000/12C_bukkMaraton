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
            var versenyzok = new List<Versenyzo>();

            using var sr = new StreamReader(@"..\..\..\src\bukkm2019.txt");

            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {          
                versenyzok.Add(new Versenyzo(sr.ReadLine()));
            }

            Console.WriteLine("4. feladat");
            var f4 = 691f - versenyzok.Count;
            Console.WriteLine($"Versenytávot nem teljesítők: {(f4/ 691) * 100}%");

            Console.WriteLine("5. feladat");
            var f5 = versenyzok.Where(d => d.Kategoria.Last() == 'n' && d.Tav == "Rövid").Count();
            Console.WriteLine($"Női versenyzők száma a rövid távú versenyen: {f5}fő");

            Console.WriteLine("6. feladat");
            var f6 = versenyzok.FirstOrDefault(d => d.Ido.Hours >= 6 && d.Ido.Minutes > 0 || d.Ido.Seconds > 0);
            if (f6 != null)
            {
                Console.WriteLine("Volt ilyen versenyző");
            }
            else 
            {
                Console.WriteLine("Nem volt ilyen versenyző");
            }

            Console.WriteLine("7. feladat");
            var f7 = versenyzok.Where(v => v.Kategoria == "ff" && v.Tav == "Rövid").MinBy(v => v.Ido);
            Console.WriteLine($"A felnőtt férfi (ff) kategória győztese rövid távon \n\t Rajtszám: {f7.Rajtszam} \n\t Név: {f7.Nev} \n\t Egyesület: {f7.Egyesulet} \n\t Idő: {f7.Ido}");

            Console.WriteLine("8. feladat \nStatisztika:");
            var f8 = versenyzok.Where(d => d.Kategoria.Last() == 'f').GroupBy(d => d.Kategoria).ToDictionary(d => d.Key, dd => dd.Count());
            foreach (var i in f8)
            {
                Console.WriteLine($"{i.Key} - {i.Value}fő");
            }
        }
    }
}