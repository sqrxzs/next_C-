using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Задание 1 ===");
        Task1();

        Console.WriteLine("\n=== Задание 2 ===");
        Task2();

        Console.WriteLine("\n=== Задание 3 ===");
        Task3();

        Console.WriteLine("\n=== Задание 4 ===");
        Task4();

        Console.WriteLine("\n=== Задание 5 ===");
        Task5();

        Console.WriteLine("\n=== Задание 6 ===");
        Task6();

        Console.WriteLine("\n=== Задание 7 ===");
        Task7();

        Console.WriteLine("\n=== Задание 8 ===");
        Task8();

        Console.WriteLine("\n=== Задание 9 ===");
        Task9();
    }

    static void Task1()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 4, 6, 8 };

        int evenCount = array.Count(x => x % 2 == 0);
        int oddCount = array.Count(x => x % 2 != 0);
        int uniqueCount = array.Distinct().Count();

        Console.WriteLine($"Чётные: {evenCount}, Нечётные: {oddCount}, Уникальные: {uniqueCount}");
    }

    static void Task2()
    {
        int[] array = { 3, 7, 2, 9, 5, 6, 1, 8, 4 };
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        int count = array.Count(x => x < number);
        Console.WriteLine($"Чисел меньше {number}: {count}");
    }

    static void Task3()
    {
        int[] array = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5 };
        Console.WriteLine("Введите 3 числа через пробел:");
        int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int count = 0;
        for (int i = 0; i <= array.Length - 3; i++)
        {
            if (array[i] == sequence[0] && array[i + 1] == sequence[1] && array[i + 2] == sequence[2])
                count++;
        }
        Console.WriteLine($"Последовательность встретилась {count} раз(а)");
    }

    static void Task4()
    {
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 3, 4, 5, 6, 7 };

        var common = array1.Intersect(array2).ToArray();
        Console.WriteLine("Общие элементы: " + string.Join(", ", common));
    }

    static void Task5()
    {
        int[,] matrix = { { 3, 7, 2 }, { 9, 5, 6 }, { 1, 8, 4 } };
        int min = matrix[0, 0], max = matrix[0, 0];

        foreach (int num in matrix)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }
        Console.WriteLine($"Минимальное: {min}, Максимальное: {max}");
    }

    static void Task6()
    {
        Console.Write("Введите предложение: ");
        string sentence = Console.ReadLine();

        int wordCount = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"Количество слов: {wordCount}");
    }

    static void Task7()
    {
        Console.Write("Введите предложение: ");
        string sentence = Console.ReadLine();

        string reversed = string.Join(" ",
            sentence.Split(' ')
                   .Select(word => new string(word.Reverse().ToArray())));
        Console.WriteLine($"Результат: {reversed}");
    }

    static void Task8()
    {
        Console.Write("Введите предложение: ");
        string sentence = Console.ReadLine().ToLower();

        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        int count = sentence.Count(c => vowels.Contains(c));
        Console.WriteLine($"Гласных букв: {count}");
    }

    static void Task9()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine();
        Console.Write("Введите подстроку для поиска: ");
        string substring = Console.ReadLine();

        int count = (text.Length - text.Replace(substring, "").Length) / substring.Length;
        Console.WriteLine($"Подстрока '{substring}' встретилась {count} раз(а)");
    }
}