/*1.	Написать программу, которая вводит текст, состоящий из нескольких предложений,
 * и выводит его на экран меняя местами каждые два соседних слова. 
 Дан текст. Составить программу проверки правильности написания сочетаний
«жи», «ши», «ча», «ща», «чу» и «щу». Исправить ошибки. */

namespace Laba51
{
    /// <summary>
    /// Программа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Метод выводит на консоль текст, состоящий из нескольких предложений с обменом местами каждого соседнего слово и исправляет ошибки правописания.
        /// </summary>
        public static void Main()
        {
            string textByUser = new(Console.ReadLine());
            Console.WriteLine("Пункт 5.1.1");
            ExchangePlaces(textByUser);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Пункт 5.1.2");
            int count = NumberOfErrors(textByUser);
            Console.WriteLine($"Количество ошибок в вашем тексте: {count}");
            Console.WriteLine("Исправленный текст");
            Console.WriteLine(ReplaceCombinationsTwo(textByUser));
            Console.WriteLine();
            Console.WriteLine(Places(textByUser));

        }
        /// <summary>
        /// Программа.
        /// </summary>
        /// <param name="textByUser"></param>
        /// <returns></returns>
        public static int Places(string textByUser)
        {
            string[] array = textByUser.Split(' ');
            return array.Length - 1;
        }
        /// <summary>
        /// Функция, которая производит обмен местами соседних слов.
        /// </summary>
        /// <param name="textByUser">Текст, введенный пользователем в консоль.</param>
        public static void ExchangePlaces(string textByUser)
        {
            //создаем пустой список 
            List<string> strSplitted = new List<string>();
            // заполняем список 
            foreach (string word in textByUser.Split(' ', '.', ',', '!', '?', ';', ':'))
            {
                //исключаем двойные пробелы
                if (word.Length != 0)
                {
                    //добавляем в словарь слова 
                    strSplitted.Add(word);
                }
            }
            // преобразуем список в массив 
            string[] array = strSplitted.ToArray();
            Console.WriteLine("Измененный текст");
            string temp;
            // цикл для обмена местами элементов, если честное количество
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                for (int j = i; j < i + 1; j++)
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
            //если нечетное количество
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
        /// <summary>
        /// Функция, для поиска количества ошибок(проверки правильности написания слов).
        /// </summary>
        /// <param name="textByUser">Введенный пользователем текст.</param>
        /// <returns>Значение количества ошибок.</returns>
        public static int NumberOfErrors(string textByUser)
        {
            //создаем массив с ошибками
            string[] combinations = { "жы", "Жы", "шы", "Шы", "чя", "Чя", "щя", "Щя", "Чю", "чю", "щю", "Щю" };
            //задаем счетчик 
            int count = 0;
            // цикл для поиска количества ошибок в введеном тексте 
            foreach (string combination in combinations)
            {
                /*Находит первое вхождение заданной подстроки или символа в строке. Если
                искомый символ или подстрока не обнаружены,то возвращается значение -1 */

                int index = textByUser.IndexOf(combination);

                while (index != -1)
                {
                    count++;
                    /*с указанием начального индекса index + combination.Length.
                     * Это позволяет исключить повторное совпадение с уже найденными вхождениями.*/
                    index = textByUser.IndexOf(combination, index + combination.Length);
                }
            }
            return count;
        }
        /// <summary>
        /// Функция для исправления ошибок в тексте.
        /// </summary>
        /// <param name="textByUser">Текст, введенный в консоль пользователем.</param>
        /// <returns>Исправленный текст.</returns>
        public static string ReplaceCombinationsTwo(string textByUser)
        {
            string[] textByUserToReplace = { "жы", "Жы", "шы", "Шы", "чя", "Чя", "щя", "Щя", "щю", "Щю", "чю", "Чю" };
            string[] replacements = { "жи", "Жи", "ши", "Ши", "ча", "Ча", "ща", "Ща", "щу", "Щу", "чу", "Чу" };

            for (int i = 0; i < textByUserToReplace.Length; i++)
            {
                textByUser = textByUser.Replace(textByUserToReplace[i], replacements[i]);
            }

            return textByUser;
        }
    }
}
