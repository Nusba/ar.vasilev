using System;
using System.Collections.Generic;

namespace Lecture11
{
    class Program
    {

        static void Main(string[] args)
        {
         //   Lecture11DZ1();
            Lecture11DZ2();
        }

        public static void Lecture11DZ1()
        {
            // Написать метод-расширение для массива целых чисел, который выводит этот массив на консоль.
            Console.WriteLine("Введите ряд чисел, что бы закончить ввод используйте '-1' ");
            List<int> numbers = new List<int>();

            while (true)
            {
                var inputNumber = GetIntegerNumber();

                if (inputNumber == -1)
                {
                    break;
                }

                numbers.Add(inputNumber);
            }
            try
            {
                numbers.PrintNumbers();
            }
            catch (NullReferenceException exception)
            {
                throw exception;
            }


            Console.ReadKey();
        }

        public static void Lecture11DZ2()
        {
            // Написать метод-расширение для массива целых чисел, который принимает как параметр строку-разделитель, а возвращает строку,
            // в которой содержатся все элементы массива, перечисленные через указанный разделитель.

            List<int> numbers = new List<int>();

            Console.WriteLine("Введите ряд чисел, что бы закончить ввод используйте '-1' ");
            while (true)
            {
                var inputNumber = GetIntegerNumber();

                if (inputNumber == -1)
                {
                    break;
                }

                numbers.Add(inputNumber);
            }

            Console.WriteLine("Введите разделитель");
            try
            {
                string delimiter = Console.ReadLine();
                Console.Write(string.Join(delimiter, numbers));
            }
            catch (NullReferenceException exception)
            {
                throw exception;
            }

            Console.ReadKey();
        }

        private static int GetIntegerNumber()
        {
            int integerNumber;

            if (int.TryParse(Console.ReadLine(), out integerNumber))
            {
                return integerNumber;
            }

            return 0;
        }
    }
}
