using System.Net.NetworkInformation;

namespace Task1
{
    public class Task1
    {
/*
 * Задание 1.1. Дана строка. Верните строку, содержащую текст "Длина: NN",
 * где NN — длина заданной строки. Например, если задана строка "hello",
 * то результатом должна быть строка "Длина: 5".
 */
        internal static int StringLength(string s)
        {
            return s.Length;
        }

/*
 * Задание 1.2. Дана непустая строка. Вернуть коды ее первого и последнего символов.
 * Рекомендуется найти специальные функции для вычисления соответствующих символов и их кодов.
 */
        internal static Tuple<int?, int?> FirstLastCodes(string s)
        {
            return new Tuple<int?, int?>(Code(First(s)), Code(Last(s)));
        }
        
        private static char? First(string s) => s[0]; 
        private static char? Last(string s) => s[^1];
        private static int? Code(char? c) => (int)c;
       

/*
 * Задание 1.3. Дана строка. Подсчитать количество содержащихся в ней цифр.
 * В решении необходимо воспользоваться циклом for.
 */
        internal static int CountDigits(string s)
        {
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    count += 1;
                }
            }

            return count;
        }

/*
 * Задание 1.4. Дана строка. Подсчитать количество содержащихся в ней цифр.
 * В решении необходимо воспользоваться методом Count:
 * https://docs.microsoft.com/ru-ru/dotnet/api/system.linq.enumerable.count?view=net-6.0#system-linq-enumerable-count-1(system-collections-generic-ienumerable((-0))-system-func((-0-system-boolean)))
 * и функцией Char.IsDigit:
 * https://docs.microsoft.com/ru-ru/dotnet/api/system.char.isdigit?view=net-6.0
 */
        internal static int CountDigits2(string s)
        {
            return s.Count(char.IsDigit);
        }
        
/*
 * Задание 1.5. Дана строка, изображающая арифметическое выражение вида «<цифра>±<цифра>±…±<цифра>»,
 * где на месте знака операции «±» находится символ «+» или «−» (например, «4+7−2−8»). Вывести значение
 * данного выражения (целое число).
 */
        internal static int CalcDigits(string expr)
        {
            var sum = 0;
            char sighn = '+';
            foreach (var VARIABLE in expr)
            {
                if (char.IsDigit(VARIABLE))
                {
                    if (sighn == '+')
                    {
                        sum += Int32.Parse(VARIABLE.ToString());
                    }
                    else
                    {
                        sum -= Int32.Parse(VARIABLE.ToString());
                    }
                }

                else
                {
                    sighn = VARIABLE;
                }
            }

            return sum;
        }

/*
 * Задание 1.6. Даны строки S, S1 и S2. Заменить в строке S первое вхождение строки S1 на строку S2.
 */
        internal static string ReplaceWithString(string s, string s1, string s2)
        {
            string stringReplace;
            try
            {
                stringReplace =
                    s.Remove(s.IndexOf(s1, StringComparison.Ordinal), s1.Length)
                        .Insert(s.IndexOf(s1, StringComparison.Ordinal), s2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                stringReplace = s;
            }
            return stringReplace;
        }


        public static void Main(string[] args)
        {
            Console.WriteLine(StringLength("Hello, world!"));
            Console.WriteLine(FirstLastCodes("Hello, world!"));
            Console.WriteLine(CountDigits("X1234Y9876Z5"));
            Console.WriteLine(CountDigits2("X1234Y9876Z5"));
            Console.WriteLine(CalcDigits("1+2-3+4-5+6-7+8-9"));
            Console.WriteLine(ReplaceWithString("Hello, world!", "world", "hell"));
        }
    }
}