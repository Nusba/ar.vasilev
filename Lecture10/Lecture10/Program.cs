using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Lecture10
{
    class Program
    {
        static void Main(string[] args)
        {
            Lecture10Dz1();
           // Lecture10Dz2();
        }

        private static void Lecture10Dz1()
        {
            // Ввести с консоли N чисел, записать их в файл. Считать числа из файла, вывести на консоль. Сделать любым способом.
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

            using (StreamWriter sw = new StreamWriter(@"C:\Icons\testtxt.txt"))
            {
                foreach (var writeNumber in numbers)
                {
                    sw.WriteLine(writeNumber);
                }
            }

            using (StreamReader sr = new StreamReader(@"C:\Icons\testtxt.txt"))
            {
                string readNumber = sr.ReadLine();

                while (readNumber != null)
                {
                    Console.WriteLine(readNumber);
                    readNumber = sr.ReadLine();
                }
            }

            Console.ReadKey();
        }

        private static void Lecture10Dz2()
        {
            //Считать из файла flowCards.Card все контакты, сохранить в 2 разных файла: рекламные и не рекламные контакты (разделять по атрибуту IsPromotional). Формат файла: < Contact_Value > [< Description >]
            XmlDocument contactCard = new XmlDocument();
            contactCard.Load(@"E:\temp\flowCards.Card.xml");

            XmlNodeList promotionalCards = contactCard.SelectNodes("Card//Contacts//*[@IsPromotional=\"true\"]");
            XmlNodeList notPromotionalCards = contactCard.SelectNodes("Card//Contacts//*[@IsPromotional=\"false\"]");

            using (var streamWriter = new StreamWriter(@"E:\temp\Рекламные Контакты.xml"))
            {
                if (promotionalCards != null)
                    foreach (XmlNode node in promotionalCards)
                    {
                        if (node.Attributes != null)
                            streamWriter.WriteLine($"<{node.Attributes["Value"]?.Value}> [<{node.Attributes["Description"]?.Value}>]");
                    }
            }

            using (var streamWriter = new StreamWriter(@"E:\temp\Не Рекламные Контакты.xml"))
            {
                if (notPromotionalCards == null) return;
                foreach (XmlNode node in notPromotionalCards)
                {
                    if (node.Attributes != null)
                        streamWriter.WriteLine($"<{node.Attributes["Value"]?.Value}> [<{node.Attributes["Description"]?.Value}>]");
                }
            }
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
