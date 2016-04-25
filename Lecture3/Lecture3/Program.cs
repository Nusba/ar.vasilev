namespace Lecture3
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Лекция 3 Домашнее задание 1
            // Program.Lecture3Dz1();
            // Лекция 3 Домашнее задание 2
            Program.Lecture3Dz2();
        }

        // Лекция 3 Задание 1
        // Сделать методы для считывания:
        // - целых чисел,
        // - дробных чисел.
        // Сделать методы для вывода на консоль:
        // - этих типов данных, 
        // - массивов целых 
        // - и дробных чисел(можно доработать любое ДЗ).
        private static int GetIntegerNumber()
        {
            int integerNumber;

            if (int.TryParse(Console.ReadLine(), out integerNumber))
            {
                return integerNumber;
            }

            return 0;
        }

        private static decimal GetFractionalNumber()
        {
            decimal fractionalNumber;

            if (decimal.TryParse(Console.ReadLine(), out fractionalNumber))
            {
                return fractionalNumber;
            }

            return 0;
        }

        public void PrintIntegerNumber(int integerNumber)
        {
            Console.WriteLine("int number = " + integerNumber);
        }

        public void PrintFractionalNumber(decimal fractionalNumber)
        {
            Console.WriteLine("decimal number = " + fractionalNumber);
        }

        public void PrintIntegerArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.PrintIntegerNumber(array[i]);
            }
        }

        public void PrintFractionalArray(decimal[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.PrintFractionalNumber(array[i]);
            }
        }

        // Лекция 3 Домашнее задание 1
        // Считать строку с консоли.
        // Создать словарь, где ключом будет символ строки, а значением - количество данных символов в считанной строке.
        private static void Lecture3Dz1()
        {
            string inputString = Console.ReadLine();

            Dictionary<char, int> stringsdictionary = new Dictionary<char, int>();

            for (int i = 0; i < inputString.Length; i++)
            {
                char currentSymbol = inputString[i];

                if (!stringsdictionary.ContainsKey(currentSymbol))
                {
                    stringsdictionary.Add(currentSymbol, 1);
                }
                else
                {
                    stringsdictionary[currentSymbol] = stringsdictionary[currentSymbol] + 1;
                }
            }
        }

        // Лекция 3 Домашнее задание 2
        // - Cчитывать с консоли числа, пока не будет введено число “-1”,
        // - среди введенных чисел вывести все дублирующиеся.
        private static void Lecture3Dz2()
        {
            List<int> numbers = new List<int>();
            List<int> duplicates = new List<int>();

            Console.ReadLine();

            while (true)
            {
                var inputNumber = GetIntegerNumber();

                if (inputNumber == -1)
                {
                    break;
                }

                if (numbers.Contains(inputNumber))
                {
                    duplicates.Add(inputNumber);
                }

                numbers.Add(inputNumber);
            }

            for (int i = 0; i < duplicates.Count; i++)
            {
                Console.WriteLine(duplicates[i]);
            }

            Console.ReadKey();
        }
    }
}