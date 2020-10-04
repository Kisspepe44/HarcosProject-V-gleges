using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProject
{
    class Program
    {

        static List<Harcos> harcosok = new List<Harcos>();

        static void Main(string[] args)
        {
            beOlvas();


        }

        public static void beOlvas()
        {
            harcosok = new List<Harcos>();
           
            StreamReader sr = new StreamReader("harcosok.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] bontottSor = sor.Split(';');
                Harcos harcosBe = new Harcos(bontottSor[0], Convert.ToInt32(bontottSor[1]));
                harcosok.Add(harcosBe);
            
            
            }
            sr.Close();
            harcosok.Add(new Harcos("Romeo", 1));
            harcosok.Add(new Harcos("Julia", 2));
            harcosok.Add(new Harcos("Albert", 3));
            
            

            Console.WriteLine("A játék harcosai:\n");

            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }
            Console.ReadKey();
        
        }

        public static void menet()
        {
            Console.WriteLine("Kérem adja meg a harcosa nevét:");
            string nev = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Kérem adja meg a harcosa státuszát(1-3):");
            int statusz = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Harcos bekertHarcos = new Harcos(nev,statusz);

           

        
        }


    }
}
