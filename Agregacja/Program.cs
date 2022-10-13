using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agregacja
{
    internal class Program
    {

        /// <summary>
        /// Symulacja rzutów kostką, rzucamy kostką 100 razy i sumujemy tylko pary wylowanych liczb 
        /// </summary>

        static int[] zbiorSumyOczekZDwochKostek(int liczbaRzutowKostka = 100)
        {
            Random r = new Random();
            int[] wyniki = new int[liczbaRzutowKostka];
            for (int i = 0; i < liczbaRzutowKostka; i++)
            {
                int pierwszaKostka = r.Next(1, 7);                  ///losujemy liczbę oczek dla pierwszej kostki określając jej zakres
                int drugaKostka = r.Next(1, 7);                     ///losujemy liczbę oczek dla drugiej kostki określając jej zakres
                wyniki[i] = pierwszaKostka + drugaKostka;
            }
            return wyniki;                                          //zwracamy sumę dwóch kostek
        }

        static void Main(string[] args)
        {

            int[] wartosci = zbiorSumyOczekZDwochKostek(10000);
            double[] tablica = Array.ConvertAll<int, double>(wartosci, i => (double)i);

            int liczbaElementow = tablica.Count();
            double suma = tablica.Sum();
            double srednia = tablica.Average();
            double wariancja = tablica.Sum(element => (element - srednia) * (element - srednia));
            wariancja /= liczbaElementow;
            double odchylenieStnd = Math.Sqrt(wariancja);

            Console.WriteLine( "Liczba elementow: " + liczbaElementow);
            Console.WriteLine("Suma = " + suma);
            Console.WriteLine("Srednia: " + srednia);
            Console.WriteLine("Wariancja: " + wariancja);
            Console.WriteLine("Odchlenie standardowe = " + odchylenieStnd);

            double minimum = tablica.Min();
            double maximum = tablica.Max();

            Console.WriteLine("Wartości od " + minimum + " Do " + maximum);
            Console.WriteLine("Zakres: " + (maximum - minimum));

            Console.ReadLine();

        }
    }
}
