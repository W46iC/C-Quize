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

            Console.WriteLine(" \n Adja meg válaszát(a/b/c/d): ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            string valasz = Console.ReadLine();

            while (!(valasz.ToLower() == "a" || valasz.ToLower() == "b" || valasz.ToLower() == "c" || valasz.ToLower() == "d")) {

                Console.WriteLine("a/b/c/d választ adjon meg!");

                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("A B C D válasz lehetőséget adjon meg! \n");
                Console.WriteLine("Adja meg válaszát(a/b/c/d): ");
                valasz = Console.ReadLine();


            }
            return valasz.ToLower();

        }

       


        static void Main(string[] args)
        {
            string cim = @"                                                                                                 
    ,---,                  ,---,                ,----..                                          
  .'  .' `\              .'  .' `\             /   /   \                    ,--,                 
,---.'     \           ,---.'     \           /   .     :            ,--, ,--.'|          ,----, 
|   |  .`\  |,--,  ,--,|   |  .`\  |         .   /   ;.  \         ,'_ /| |  |,         .'   .`| 
:   : |  '  ||'. \/ .`|:   : |  '  |        .   ;   /  ` ;    .--. |  | : `--'_      .'   .'  .' 
|   ' '  ;  :'  \/  / ;|   ' '  ;  :        ;   |  ; \ ; |  ,'_ /| :  . | ,' ,'|   ,---, '   ./  
'   | ;  .  | \  \.' / '   | ;  .  |        |   :  | ; | '  |  ' | |  . . '  | |   ;   | .'  /   
|   | :  |  '  \  ;  ; |   | :  |  '        .   |  ' ' ' :  |  | ' |  | | |  | :   `---' /  ;--, 
'   : | /  ;  / \  \  \'   : | /  ;         '   ;  \; /  |  :  | : ;  ; | '  : |__   /  /  / .`| 
|   | '` ,/ ./__;   ;  \   | '` ,/           \   \  ',  . \ '  :  `--'   \|  | '.'|./__;     .'  
;   :  .'   |   :/\  \ ;   :  .'              ;   :      ; |:  ,      .-./;  :    ;;   |  .'     
|   ,.'     `---'  `--`|   ,.'                 \   \ .'`--""  `--`----'    |  ,   / `---'         
'---'                  '---'                    `---`                      ---`-'               ";
            Console.WriteLine(cim);

            beolvasas("kerdesek-valaszok.txt");
            

            HashSet<int> hash = new HashSet<int>();

            while (hash.Count <= 5)
            {
                hash.Add(rand.Next(1, 13));
            }

            int helyescount = 0;

            foreach (var i in hash) {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($" \t{kerdva[i-1].kerdes} \n");
                Console.WriteLine($"a){kerdva[i - 1].valasza}");
                Console.WriteLine($"b){kerdva[i - 1].valaszb}");
                Console.WriteLine($"c){kerdva[i - 1].valaszc}");
                Console.WriteLine($"d){kerdva[i - 1].valaszd} \n");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


                if (valaszbekeres() == kerdva[i - 1].helyes)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Helyes");
                    helyescount++;
                    Console.Beep();

                }
                else {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine("Helytelen");
                    Console.Beep();
                    Console.Beep();


                }
            }

            Console.WriteLine($"Pontok: {helyescount}");

            Console.ReadKey();
        }
    }
}

