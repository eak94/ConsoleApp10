/*1.Дан текст, имеющий структуру «Фамилия И.О. – рост см – вес кг». Вывести на экран фамилии всех лиц, чей рост превышает 190 см. 
2.	Дан текст. Найти число вхождение в данный текст предлога «не».*/


using System.Text.RegularExpressions;

namespace Laba52
{
    /// <summary>
    /// Выполнение лабораторной 5.2.1 и 5.2.2.
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// Метод, который выводит на экран фамилии всех лиц, чей рост превышает 190 см и число вхождение в данный текст предлога «не».
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Первое задание");
            Console.WriteLine("Вид записа: Фамилия И.О. – рост см – вес кг ");
            string textByUser = "Иванов И.О. – 180 см – 90 кг " +
                "Петров И.О. – 170 см – 60 кг " +
                "Сидоров И.О. – 190 см – 100 кг " +
                "Наумкин И.О. – 189 см – 35 кг " +
                "Папочкин И.О. – 191 см – 68 кг ";
            Console.WriteLine(textByUser);
            Height(textByUser);
            Console.WriteLine();
            Console.WriteLine("Второе задание");
            Console.WriteLine("Предложения с не");
            string text = new(Console.ReadLine());
            WordNo(text);
        }

        /// <summary>
        /// Функция, выводит на экран фамилии всех лиц, чей рост превышает 190 см.
        /// </summary>
        /// <param name="textByUser">Текст, введенный в консоль.</param>
        public static void Height(string textByUser)
        {
            string pattern = (@"(\S+\s\S+\.)\s–\s(\d+)\sсм");
            // Метод возвращает все вхождения регулярного выражения 
            MatchCollection matches = Regex.Matches(textByUser, pattern);
            //цикл по нахождению фамилии, если рост больше 190
            List<string> strregex = new List<string>();
            foreach (Match match in matches)
            {
                //присваивается результат поиска по имени. Groups[1].Value - значение в первой скобке регулярки
                string name = match.Groups[1].Value;
                //присваивается результат поиска по росту. Groups[2].Value - значение во второй скобке регулярки
                // конвертируется в целое число
                int height = int.Parse(match.Groups[2].Value);
                // условия нахождения 
                if (height >= 190)
                {
                    strregex.Add(name);
                    Console.WriteLine($"{name}");
                }
            }
            if (strregex.Count == 0)
            {
                Console.WriteLine("Совпадений не найдено");
            }
        }
        /// <summary>
        /// Фунция для поиска числа вхождение в данный текст предлога «не».
        /// </summary>
        /// <param name="text">Текст, введенный в консоль. </param>
        public static void WordNo(string text)
        {
            string pattern = (@"\s*не\s*");
            MatchCollection matches = Regex.Matches(text, pattern);
            if (matches.Count > 0)
            {
                // Перебор элементов коллекции
                foreach (Match i in matches)
                {
                    Console.WriteLine($"Количество вхождений предлога {i}:");
                    Console.WriteLine(matches.Count);
                }
            }
            // Если объектов нет,то пользователю сообщается об отсутствии совпадений
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
        }
    }
}
