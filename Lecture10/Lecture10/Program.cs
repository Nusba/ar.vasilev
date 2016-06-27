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
            //Lecture8Dz1();
            Lecture8Dz2();
        }

        private static void Lecture8Dz1()
        {
            // Ввести с консоли N чисел, записать их в файл. Считать числа из файла, вывести на консоль. Сделать любым способом.
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

            StreamWriter sw = new StreamWriter(@"C:\Icons\testtxt.txt");
            foreach (var number in numbers)
            {
                sw.WriteLine(number);
            }
            sw.Close();

            StreamReader sr = new StreamReader(@"C:\Icons\testtxt.txt");

            string name = sr.ReadLine();

            while (name != null)
            {
                Console.WriteLine(name);
                name = sr.ReadLine();
            }

            sr.Close();

            Console.ReadKey();
        }

        private static void Lecture8Dz2()
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
