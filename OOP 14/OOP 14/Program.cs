using System;
using System.Text;

namespace OOP_14
{
    internal class Program
    {
        interface IShape
        {
            double a { set; get; }
            double b { set; get; }
            void PrintInfo();
        }

        class Diamond : IShape, IComparable<Diamond>
        {
            public double a { set; get; }
            public double b { set; get; }

            public Diamond()
            {
                Console.WriteLine("Дані відсутні");
                this.a = 0;
                this.b = 0;
            }
            public Diamond(double a, double b)
            {
                this.a = a;
                this.b = b;
            }

            public double CalculateSquare()
            {
                double diagonal = Math.Sqrt(2 * a * a - b * b);
                double square = 0.5 * diagonal * b;
                return square;
            }

            public void PrintInfo()
            {
                double square = CalculateSquare();
                Console.WriteLine($"Сторона ромба: {a}\nМенша діагональ ромба: {b}\nПлоща ромба: {square:F2}");
                Console.WriteLine("---------------------------------------------------");
            }

            public int CompareTo(Diamond other)
            {
                return CalculateSquare().CompareTo(other.CalculateSquare());
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int N = 5;

            Diamond[] ArrayDiamond = new Diamond[N];

            ArrayDiamond[0] = new Diamond(8, 10);
            ArrayDiamond[1] = new Diamond(6, 8);
            ArrayDiamond[2] = new Diamond(10, 11);
            ArrayDiamond[3] = new Diamond(7, 9);
            ArrayDiamond[4] = new Diamond(5, 3);

            Console.WriteLine("Інформація про об'єкти масиву: \n");
            foreach (var diamond in ArrayDiamond)
            {
                diamond.PrintInfo();
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------------------");

            Array.Sort(ArrayDiamond);

            Console.WriteLine("Інформація про об'єкти масиву після сортування за площею:\n");
            foreach (var diamond in ArrayDiamond)
            {
                diamond.PrintInfo();
            }
            Console.WriteLine("---------------------------------------------------\n\n");
        }
    }
}
