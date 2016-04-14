namespace Lecture1._1
{
    using System;

    class Program
    {
        public static void Main(string[] args)
        {   // Часть 1
            Console.WriteLine("Лекция 1, Часть 1");
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            int a1 = Convert.ToInt32(a);
            int b1 = Convert.ToInt32(b);

            int sum = a1 + b1;
            Console.WriteLine(sum);
            Console.ReadKey();

            // Часть 2
            Console.WriteLine("Лекция 1, Часть 2");
            string n = Console.ReadLine();
            string i = Console.ReadLine();

            int n1 = Convert.ToInt32(n);
            int i1 = Convert.ToInt32(i);

            int result;

            result = (n1 >> (i1 - 1)) & 1;
            Console.WriteLine(result);
            Console.ReadKey();

            // Часть 3
            Console.WriteLine("Лекция 1, Часть 3");
            string z = Console.ReadLine();
            int z1 = Convert.ToInt32(z);

            int res;
            int res1;

            res = z1 >> 1;
            res1 = res << 1;

            Console.WriteLine(res1);
            Console.ReadKey();
        }
    }
}