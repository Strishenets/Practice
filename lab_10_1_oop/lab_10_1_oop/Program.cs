using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10_1_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random random = new Random();

            int sizeMass, i, sizeSearchMass = 0, j = -1;
            Console.Write("Введіть кількість значень в масиві: ");
            sizeMass = int.Parse(Console.ReadLine());

            int[] consoleMass = new int[sizeMass], searchMass;

            for (i = 0; i < consoleMass.Length; i++)
            {
                consoleMass[i] = random.Next(-10, 10);
                if (consoleMass[i]>1)
                {
                    sizeSearchMass++;
                }
            }

            Console.WriteLine();

            Console.Write("Згенерований масив: ");
            for (i = 0; i < consoleMass.Length; i++)
            {
                Console.Write(consoleMass[i] + " ");
            }
            Console.WriteLine();

            if (sizeSearchMass == 0)
            {
                Console.WriteLine("Згенерований масив немає чисел більше 1");
            }
            else
            {
                searchMass = new int[sizeSearchMass];

                for (i = 0; i < consoleMass.Length; i++)
                {
                    if (consoleMass[i] > 1)
                    {
                        j++;
                        searchMass[j] = consoleMass[i];
                    }
                }

                Console.Write("Елементи згенерованого\nмасиву, що більше 1: ");

                for (i = 0; i < searchMass.Length; i++)
                {
                    Console.Write(searchMass[i] + " ");
                }
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
