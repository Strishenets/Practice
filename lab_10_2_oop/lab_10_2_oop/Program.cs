using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10_2_oop
{
    internal class Program
    {
        static int SumElementsMatrAboveMainLine(int[,] matr, int n, int m)
        {
            int sumElement = 0, i, j;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (j > i)
                    {
                        sumElement += matr[i, j];
                    }
                }
            }

            return sumElement;
        }
        static int SearchMinElement(int[,] matr, int n, int m)
        {
            int minElement = matr[0, 0], i, j;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (minElement > matr[i, j])
                    {
                        minElement = matr[i, j];
                    }
                }
            }
            return minElement;
        }

        static int SearchCountMinElement(int[,] matr, int n, int m)
        {
            int minElement = SearchMinElement(matr, n, m), countMassIndexes = 0, i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (minElement == matr[i, j])
                    {
                        countMassIndexes++;
                    }
                }
            }
            return countMassIndexes;
        }

        static int[,] SearchIndexesMinElementMatr(int[,] matr, int n, int m)
        {
            int i, j, k = -1, minElement = SearchMinElement(matr, n, m), countMassIndexes = SearchCountMinElement(matr, m, n);

            int[,] massIndexesMinElementMatr = new int[countMassIndexes, 2];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (minElement == matr[i, j])
                    {
                        k++;
                        massIndexesMinElementMatr[k, 0] = i+1;
                        massIndexesMinElementMatr[k, 1] = j+1;
                    }
                }
            }

            return massIndexesMinElementMatr;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random random = new Random();

            int n, m, i, j, sumElement;
            Console.Write("Введіть кількість стовпців: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість рядків: ");
            m = int.Parse(Console.ReadLine());

            int[,] matr = new int[n, m];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    matr[i, j] = random.Next(1, 10);
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(matr[i, j] + " ");
                }
                Console.WriteLine();
            }

            sumElement = SumElementsMatrAboveMainLine(matr, n, m);
            Console.WriteLine($"Сума елементів матриці \nнад головною діагоналлю дорівнює: {sumElement}");

            Console.WriteLine();

            int[,] massIndexesMinElementMatr;

            massIndexesMinElementMatr = SearchIndexesMinElementMatr(matr, n, m);
            int minElement = SearchMinElement(matr, n, m), countMassIndexes = SearchCountMinElement(matr, n, m);

            Console.WriteLine($"Найменший елемент в матриці: {minElement}");
            Console.WriteLine("Індекси найменшого елементу в матриці");
            for (i = 0; i < countMassIndexes; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    Console.Write(massIndexesMinElementMatr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
