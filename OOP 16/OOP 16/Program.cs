using System;

namespace work_16
{
    internal class Program
    {
        static void HandleKeyPress(string text) { Console.WriteLine(text); }
        delegate double Func(double x);
        delegate void MyEvent(string text);

        class MEvent
        {
            static public string Name = "нгелiна";
            public event MyEvent KeyPress;
            public void Read()
            {
                Console.Write("Введiть першу лiтеру: ");
                while (true)
                {
                    char symbol = Console.ReadKey(true).KeyChar;
                    Console.Write(symbol);
                    if (char.ToUpper(symbol) == 'А')
                    {
                        KeyPress(Name);
                        break;
                    }
                    else
                        Console.WriteLine("\nНе вiрно введенi данi");
                }
            }
        }

        static double Trap(Func F, double a, double b, ushort pre = 50)
        {
            if (pre == 0) 
                pre = 1;
            double s = Math.Abs(b - a) / pre;
            double res = (F(a) + F(b)) / 2;
            for (double i = a + s; i < b; i += s) 
                res += F(i);
            return Math.Round(Math.Abs(res * s), 5);
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Результат функцiї f(x)=1/sqrt(|x|) в iнтервалi 1 i 10 = {Trap(x => 1 / Math.Sqrt(Math.Abs(x)), 1, 10)}\n");
            Console.WriteLine($"Результат функцiї f(x)=1/(x^2 + 1) в iнтервалi 4 i 18 = {Trap(x => 1 / (Math.Pow(x, 2) + 1), 4, 18)}\n");
            Console.WriteLine($"Результат функцiї f(x)=ln(x) в iнтервалi 3 i 5 = {Trap(x => x, 0, 1)}\n");

            MEvent m = new MEvent();
            m.KeyPress += HandleKeyPress;
            m.Read();
        }   
    }
}
