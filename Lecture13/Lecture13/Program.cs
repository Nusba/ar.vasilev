using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lecture13
{
    using System;

    static class Program
    {
        private static void Main(string[] args)
        {
            Lecture13DZ1();
        }

        public static void Lecture13DZ1()
        {
            // Создать коллекцию из 100 случайных дробей. Выбрать все дроби, которые являются целым числом. 
            // Вывести на консоль их как целые числа.
            try
            {
                Random random = new Random();

                List<SimpleFraction> fractions = new List<SimpleFraction>();
                for (int i = 0; i <= 100; i++)
                {
                    fractions.Add(new SimpleFraction(random.Next(30), random.Next(1, 30)));
                }

                SaveToFile(fractions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void SaveToFile(List<SimpleFraction> fract)
        {
            var writer = new XmlSerializer(typeof(List<SimpleFraction>));
            using (var sw = new StreamWriter(@"E:\TXT.txt"))
            {
                writer.Serialize(sw, fract);
            }
        }
    }
}