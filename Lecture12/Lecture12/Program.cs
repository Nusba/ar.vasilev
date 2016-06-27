using System.Linq;

namespace Lecture12
{
    using System;

    static class Program
    {
        private static void Main(string[] args)
        {
           // Lecture12DZ1();
            Lecture12DZ2();
        }

        public static void Lecture12DZ1()
        {
           // Создать массив из 10 числе.Вывести на экран с помощью LINQ только четные или те, что больше 5.Отсортировать по убыванию.
            Random random = new Random();

            var arrayOf10Numbers = Enumerable.Range(0, 10).Select(i => random.Next(30)).Where(i => i%2 == 0 || i > 5).OrderByDescending(i => i).Where(i =>
            {
                Console.WriteLine(i);
                return true;
            }).ToArray();

            Console.ReadKey();
        }

        public static void Lecture12DZ2()
        {
            // Создать коллекцию из 100 случайных дробей. Выбрать все дроби, которые являются целым числом. Вывести на консоль их как целые числа.
            try
            {
                Random random = new Random();

                var fractions = Enumerable.Range(0, 100)
                    .Select(f => new SimpleFraction(random.Next(30), random.Next(1, 30)))
                    .Where(f => f.Numerator % f.Denominator == 0)
                    .Select(f => new
                    {
                        fraction = f.ToString(),
                        fractionInt = f.Numerator / f.Denominator
                    });

                Console.WriteLine("Целое число | простая дробь:");

                foreach (var digit in fractions)
                {
                    Console.Write($"{digit.fractionInt} | ");
                    Console.WriteLine($"{digit.fraction}");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}