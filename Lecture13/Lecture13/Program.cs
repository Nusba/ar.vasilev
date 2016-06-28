using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace Lecture13
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Lecture13Dz1();
        }

        private static void Lecture13Dz1()
        {
            // Создать список из N дробей, сериализовать их в файл. Десериализовать.
            try
            {
                Random random = new Random();

                List<SimpleFraction> fractions = new List<SimpleFraction>();
                for (int i = 0; i <= 100; i++)
                {
                    fractions.Add(new SimpleFraction(random.Next(30), random.Next(1, 30)));
                }
                var unicqueNameFile = DateTime.Now.ToString("ssmmhh", CultureInfo.InvariantCulture) + ".txt";

                SaveToFile(fractions, unicqueNameFile);

                LoadFromFile(unicqueNameFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SaveToFile(List<SimpleFraction> fract, string unicqueNameFile)
        {
            var writer = new XmlSerializer(typeof(List<SimpleFraction>));
            using (var sw = new StreamWriter("E:\\temp\\" + unicqueNameFile))
            {
                writer.Serialize(sw, fract);
            }
        }

        private static List<SimpleFraction> LoadFromFile(string unicqueNameFile) 
        {
            var read = new XmlSerializer(typeof(List<SimpleFraction>));

            using (var sr = new StreamReader("E:\\temp\\" + unicqueNameFile))
            {
                return (List<SimpleFraction>)read.Deserialize(sr);
            }
        }
    }
}