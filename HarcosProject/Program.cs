using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HarcosProject
{
    class Program
    {

        static List<Harcos> harcosok = new List<Harcos>();

        static void Main(string[] args)
        {
            beOlvas();
            menet();

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

            Harcos bekertHarcos = new Harcos(nev, statusz);

            Console.WriteLine();
            Console.WriteLine("A ön által megadott harcos adatai: \n" + bekertHarcos);
            Console.WriteLine();
            Console.WriteLine("A többi harcos karakter és adataik: ");
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine((i + 1) + "." + harcosok[i]);
            }


            Console.WriteLine();
            Console.WriteLine("Kérem adja meg mi a következő lépés:");
            Console.WriteLine();
            Console.WriteLine("a) Megküzdeni egy harcossal.");
            Console.WriteLine("b) Gyógyul");
            Console.WriteLine("c) Kilép");

            string valasz = "";
            int kor = 0;
            while (!(valasz == "c"))
            {
                valasz = Console.ReadLine();
                while (!(valasz.Equals("a") || valasz.Equals("b") || valasz.Equals("c")))
                {
                    Console.WriteLine("Kérem adjon meg egy létező menüpontot!");
                    valasz = Console.ReadLine();
                }

                if (valasz == "a")
                {
                    kor++;
                    int harcol;
                    Console.WriteLine();
                    Console.WriteLine("Kérem adja meg melyik ellenféllel szeretne harcolni.");
                    Console.WriteLine();
                    for (int i = 0; i < harcosok.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ") " + harcosok[i]);
                    }
                    Console.WriteLine();
                    while (!(int.TryParse(Console.ReadLine(), out harcol)))
                    {

                        Console.WriteLine("A ellenfelet nem a sorszáma alapján adta meg kérem adja meg úrja");
                    }
                    while (harcol > harcosok.Count || harcol < 0)
                    {
                        Console.WriteLine("Kérem a listából válasszon harcost a sorszáma alapján.");
                        while (!(int.TryParse(Console.ReadLine(), out harcol)))
                        {

                            Console.WriteLine("A ellenfelet nem a sorszáma alapján adta meg kérem adja meg úrja");
                        }
                    }

                    bekertHarcos.MegKuzd(harcosok[harcol - 1]);

                    if (bekertHarcos.Eletero <= 0)
                    {
                        Console.WriteLine("VEsztettél");

                    }
                    else
                    {
                        Console.WriteLine("Nyertél");
                    }

                    if (kor % 3 == 0)
                    {
                        Console.WriteLine("A következő ellenfeled:");
                        Random rnd = new Random();
                        int rndHarcos = rnd.Next(1, harcosok.Count);
                        Console.WriteLine(harcosok[rndHarcos]);
                        Console.WriteLine();
                        bekertHarcos.MegKuzd(harcosok[rndHarcos - 1]);
                        if (bekertHarcos.Eletero <= 0)
                        {
                            Console.WriteLine("VEsztettél");

                        }
                        else
                        {
                            Console.WriteLine("Nyertél");
                        }
                        for (int i = 0; i < harcosok.Count; i++)
                        {
                            harcosok[i].Gyogyul();

                        }
                        bekertHarcos.Gyogyul();

                    }
                    Console.ReadKey();
                }

                else if (valasz == "b")
                {
                    bekertHarcos.Gyogyul();
                    for (int i = 0; i < harcosok.Count; i++)
                    {
                        harcosok[i].Gyogyul();

                    }
                }
                else if (valasz == "c")
                {
                    Console.WriteLine("Köszönjük a játékot.");
                    Thread.Sleep(3000);
                    Environment.Exit(0);

                }
                Console.WriteLine();
                Console.WriteLine("Kérem adja meg mi a következő lépés:");
                Console.WriteLine();
                Console.WriteLine("a) Megküzdeni egy harcossal.");
                Console.WriteLine("b) Gyógyul");
                Console.WriteLine("c) Kilép");


            }

        }
    }
}
