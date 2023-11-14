using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Balkezes> balkezesek = new List<Balkezes>();
            using (StreamReader fajl = new StreamReader("balkezesek.csv"))
            {
                fajl.ReadLine();
                while (!fajl.EndOfStream)
                {
                    balkezesek.Add(new Balkezes(fajl.ReadLine()));
                }
            }
            Console.WriteLine($"3. feladat: {balkezesek.Count}");

            Console.WriteLine("4. feladat:");
            balkezesek.Where(x => x.Utolso.Year == 1999 && x.Utolso.Month == 10).ToList().ForEach(y => Console.WriteLine($"\t{y.Nev}, {String.Format("{0:0.0}", y.MagassagInch * 2.54)} cm"));

            Console.WriteLine("5. feladat");
            int input = 0;
            do
            {
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot!: ");
                if (!(int.TryParse(Console.ReadLine(), out input) && input >= 1990 && input <= 1999))
                {
                    Console.Write("Hibás adat!");
                }

            } while (!(input >= 1990 && input <= 1999));

            Console.WriteLine($"6. feladat: {String.Format("{0:0.00}", balkezesek.Where(x => x.Elso.Year <= input && x.Utolso.Year >= input).Sum(x => x.SulyFont) * 1.0 / balkezesek.Count(x => x.Elso.Year <= input && x.Utolso.Year >= input))} font");
            Console.ReadKey();
        }
        class Balkezes
        {
            string nev;
            DateTime elso, utolso;
            int sulyFont;
            int magassagInch;

            public string Nev { get => nev; set => nev = value; }
            public DateTime Elso { get => elso; set => elso = value; }
            public DateTime Utolso { get => utolso; set => utolso = value; }
            public int SulyFont { get => sulyFont; set => sulyFont = value; }
            public int MagassagInch { get => magassagInch; set => magassagInch = value; }

            public Balkezes(string adatsor)
            {
                string[] adatok = adatsor.Split(';');
                Nev = adatok[0].Trim();
                Elso = DateTime.Parse(adatok[1].Trim());
                Utolso = DateTime.Parse(adatok[2].Trim());
                SulyFont = int.Parse(adatok[3].Trim());
                MagassagInch = int.Parse(adatok[4].Trim());
            }
        }
    }
}