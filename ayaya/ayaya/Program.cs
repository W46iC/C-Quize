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
        public string helyes;

    }
    internal class Program
    {
        static List<adatok> kerdva = new List<adatok>();

        static Random rand = new Random();

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
                
                adatok.helyes = temp[5];

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

                Console.WriteLine("a/b/c/d választ adjon meg!");


                Console.WriteLine("Adja meg válaszát: ");
                valasz = Console.ReadLine();


            }
            return valasz;

        }

       


        static void Main(string[] args)
        {
            Console.WriteLine(beolvasas("kerdesek-valaszok.txt"));
            

            HashSet<int> hash = new HashSet<int>();

            while (hash.Count <= 5)
            {
                hash.Add(rand.Next(1, 13));
            }

            int helyescount = 0;

            foreach (var i in hash) {

                Console.WriteLine($"{kerdva[i-1].kerdes}");
                Console.WriteLine($"{kerdva[i - 1].valasza}");
                Console.WriteLine($"{kerdva[i - 1].valaszb}");
                Console.WriteLine($"{kerdva[i - 1].valaszc}");
                Console.WriteLine($"{kerdva[i - 1].valaszd}");


                if (valaszbekeres() == kerdva[i - 1].helyes)
                {

                    Console.WriteLine("Helyes");
                    helyescount++;
                }
                else {

                    Console.WriteLine("Helytelen");
                
                }
            }

            Console.WriteLine($"Pontok: {helyescount}");

            Console.ReadKey();
        }
    }
}
