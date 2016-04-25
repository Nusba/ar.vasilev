namespace Lecture2
{
    using System;

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Лекция 2 Задание 1
            // Program.Lecture2_1();

            // Лекция 2 Задание 2
            // Program.Lecture2_2();

            // Лекция 2 Задание 3
            // Program.Lecture2_3();

            // Лекция 2 Домашнее задание 1
            // Program.Lecture2_4();

            // Лекция 2 Домашнее задание 2
            // Program.Lecture2_5();

            // Лекция 2 Домашнее задание 3
            Program.Lecture2_6();
        }

        private static void Lecture2_1()
        {
            // Лекция 2 Задание 1

            // Ввести с консоли N чисел. Вывести:
            // - сумму, 
            // - максимальное, минимальное значения, 
            // - количество четных чисел
            // - произведение нечетных чисел
            int nMax = 0;
            int nMin = 1;
            int nSum = 0;
            int countEven = 0;
            int multiplicationNotEven = 0;

            while (true)
            {
                Console.WriteLine("Введите число");
                int n = Convert.ToInt32(Console.ReadLine());

                if (n > nMax)
                {
                    nMax = n;
                }

                if (n < nMin)
                {
                    nMin = n;
                }

                if ((n % 2) == 0)
                {
                    countEven++;
                }

                if ((n % 2) != 0)
                {
                    if (multiplicationNotEven == 0)
                    {
                        multiplicationNotEven = 1;
                    }

                    multiplicationNotEven = multiplicationNotEven * n;
                }

                nSum = nSum + n;

                Console.WriteLine("Сумма введенных чисел: " + nSum);
                Console.WriteLine("Максимальное значение: " + nMax);
                Console.WriteLine("Минимальное значение: " + nMin);
                Console.WriteLine("Количество четных чисел: " + countEven);
                Console.WriteLine("Произведение нечетных чисел: " + multiplicationNotEven);
            }
        }

        private static void Lecture2_2()
        {
            // Лекция 2 Задание 2

            // Заполнить с консоли массив из N элементов (N - задается с консоли). 
            // - Отсортировать.
            // - Вывести результат. 
            Console.WriteLine("Введите необходимую размерность массива");

            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(n);

            int[] numbers = new int[n];

            Console.WriteLine("Введите числа для заполнения массива");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите число");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Sort(numbers);

            Console.WriteLine("Числа в массиве отсортированые по возрастанию:");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(numbers[j]);
            }

            Console.ReadKey();
        }

        private static void Lecture2_3()
        {
            // Лекция 2 Задание 3

            // Заполнить 2 матрицы размерности NxN случайными числами. 
            // - Вывести на консоль. 
            // - Сложить 2 матрицы. 
            // - Вывести результат.

            Console.WriteLine("Введите размерность двумерных массивов");
            Console.WriteLine("Введите число строк");
            int matrix_number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число столбцов");
            int matrix_number2 = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = new int[matrix_number1, matrix_number2]; 

            Random rnd = new Random();

            Console.WriteLine("Матрица 1: ");
            for (int i = 0; i < matrix_number1; i++)
            {
                for (int j = 0; j < matrix_number2; j++)
                {
                    matrix1[i, j] = rnd.Next(100500);
                    Console.Write(matrix1[i, j] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Матрица 2: ");
            int[,] matrix2 = new int[matrix_number1, matrix_number2]; 
            for (int i = 0; i < matrix_number1; i++)
            {
                for (int j = 0; j < matrix_number2; j++)
                {
                    matrix2[i, j] = rnd.Next(100500);
                    Console.Write(matrix2[i, j] + " ");
                }

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сумма Матриц: ");
            int[,] result = new int[matrix_number1, matrix_number2]; 

            for (int i = 0; i < matrix_number1; i++)
            {
                for (int j = 0; j < matrix_number2; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];

                    Console.Write(result[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Lecture2_4()
        {
            // Лекция 2 Домашнее задание 1

            // Заполнить массив длиной N случайными числами. 
            // - Ввести с консоли число A. 
            // - Вывести Yes, если число A есть в массиве, 
            // - No - в противном случае.
            Console.WriteLine("Введите необходимую размерность массива");

            int n = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[n];

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                numbers[i] = rnd.Next(100500);
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(numbers[i]);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine("Введите число, которое необходмо найти в массиве");

            int a = Convert.ToInt32(Console.ReadLine());
            bool q = false;
            
            for (int i = 0; i < n; i++)
            {
                if (a == numbers[i])
                {
                    Console.WriteLine("Yes");
                    q = true;
                    break;
                }
            }

            if (q == false)
            {
                Console.WriteLine("No");
            }

            Console.ReadKey();
        }
        private static void Lecture2_5()
        {
            // Лекция 2 Домашнее задание 2

            // Заполнить матрицу NxM случайными числами.
            // - Из каждой строки выбрать минимальный элемент, занести его в массив.
            // - Отсортировать полученный массив 
            // - и вывести его значения в обратном порядке.

            Console.WriteLine("Введите число строк");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число столбцов");
            int m = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[n];
            int[,] matrix = new int[n, m];
            int Min = 0;

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(100500);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
            }

            for (int i = 0; i < n; i++)
            {
                Min = matrix[i, 0];
                for (int j = 0; j < m; j++)
                {

                    if (matrix[i, j] < Min)
                    {
                        Min = matrix[i, j];
                    }
                }

                numbers[i] = Min;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Числа в массиве отсортированые по возрастанию:");

            Array.Sort(numbers);
            for (int i = n - 1; i > 0; i--)
            {
                Console.WriteLine(numbers[i]);
            }

            Console.ReadKey();
        }
        private static void Lecture2_6()
        {
            // Лекция 2 Домашнее задание 3

            // Калькулятор.
            // - С консоли вводится левый операнд, операция, правый операнд. 
            // Выводится результат операции над операндами.
            // - Реализовать как минимум 4 операции, обработку ошибок (деление на 0 и др).
            Console.WriteLine("Калькулятор");
            Console.WriteLine("Поддерживаемые операции: -, +, *, /, cqrt (корень из суммы операндов) ");
            while (true)
            {
                Console.WriteLine("Введите лeвый операнд:");
                int operand1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите операцию:");
                var operation = Console.ReadLine();

                Console.WriteLine("Введите правый операнд:");
                int operand2 = Convert.ToInt32(Console.ReadLine());

                if (operation == "+")
                {
                    Console.WriteLine("Результат операции над операндами:" + (operand1 + operand2));
                }
                else if (operation == "-")
                {
                    Console.WriteLine("Результат операции над операндами:" + (operand1 - operand2));
                }
                else if (operation == "*")
                {
                    Console.WriteLine("Результат операции над операндами:" + (operand1 * operand2));
                }
                else if (operation == "/")
                {
                    if (operand2 == 0)
                    {
                        Console.WriteLine("Деление на 0 запрещено");
                    }
                    else
                    {
                        Console.WriteLine("Результат операции над операндами:" + (operand1 / operand2));
                    }
                }
                else if (operation == "cqrt")
                {
                    if ((operand1 + operand2) < 0)
                    {
                        Console.WriteLine("Недопустимый ввод");
                    }
                    else
                    {
                        Console.WriteLine("Результат операции над операндами:" + Math.Sqrt(operand1 + operand2));
                    }
                }
                else
                {
                    Console.WriteLine("Операция не поддерживается, используйте -, +, *, /, cqrt (корень из суммы операндов)");
                }
            }
        }
    }
}