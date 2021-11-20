 Возвести число в натуральную степень P за \Theta(\log P)Θ(logP). Рекурсивный и нерекурсивный варианты.


using System;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int exponent = int.Parse(Console.ReadLine());
            Console.WriteLine(WhilePow(num, exponent));
        }

        static double WhilePow(int num, int exponent)
        {
            if (exponent == 0) return 1;
            if (exponent % 2 == 0)
            {
                var tail = (int)WhilePow(num, exponent / 2);
                return tail * tail;
            }
            else return num * WhilePow(num, exponent - 1);
        }

    }

}



namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int exponent = int.Parse(Console.ReadLine());
            Console.WriteLine(WhilePow(num, exponent));
        }

        static double WhilePow(int num, int exponent)
        {
            if (exponent == 0) return 1;
            var tail = 1;
            while (exponent > 1)
            {
                if (exponent % 2 == 1)
                    tail *= num;
                num *= num;
                exponent /= 2;
            }
            return num * tail;
        }

    }

}
