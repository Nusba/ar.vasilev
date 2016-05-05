namespace Lecture._4
{
    class Program
    {
        static void Main(string[] args)
        {
             Lecture4Dz1();
             Lecture4Dz2();
        }

        private static void Lecture4Dz1()
        {
            // Лекция 4, задание 1
            // - Создать класс “Телефон”, который содержит следующие данные (которые не могут быть изменены.):
            // - код города, 
            // - номер телефона,  
            // - Добавить метод, который возвращает строку вида “(999) 999999” или “999999”, если код города отсутствует.
            Telephone t = new Telephone("999", "9999999");
            t.Compare();
        }

        private static void Lecture4Dz2()
        {               
            // Лекция 4, задание 2
            // Преобразовать класс “Телефон” на работу со свойствами
            TelephoneDZ2 t2 = new TelephoneDZ2("999", "9999999");
            var compare = t2.Compare;
        }
    }
}