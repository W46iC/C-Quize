using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ayaya
{
    struct adatok { 
    
        public string kerdes;
        public string valasza;
        public string valaszb;
        public string valaszc;
        public string valaszd;

    }
    internal class Program
    {
        static List<adatok> kerdva = new List<adatok>();

        static int beolvasas(string fileName)
        {
            StreamReader ayaya = new StreamReader(fileName);
            ayaya.ReadLine();
            while (!ayaya.EndOfStream)
            {
                string[] temp = ayaya.ReadLine().Split(';');
                adatok adatok = new adatok();
                adatok.kerdes = temp[0];
                adatok.valasza = temp[1];
                adatok.valaszb = temp[2];
                adatok.valaszc = temp[3];
                adatok.valaszd = temp[4];

                kerdva.Add(adatok);
   
            }
            ayaya.Close();

            return kerdva.Count;
        }

        static string valaszbekeres()
        {

            Console.WriteLine("Adja meg válaszát: ");
            string valasz = Console.ReadLine();

            while (!(valasz.ToLower() == "a" || valasz.ToLower() == "b" || valasz.ToLower() == "c" || valasz.ToLower() == "d")) {

                Console.WriteLine();
            
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine(beolvasas("kerdesek-valaszok.txt"));
            

            Console.ReadKey();
        }
    }
}
