using System;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Задание 3: Шифр Цезаря ===");
        CaesarCipher();

        Console.WriteLine("\n=== Задание 4: Операции с матрицами ===");
        MatrixOperations();

        Console.WriteLine("\n=== Задание 5: Калькулятор выражений ===");
        SimpleCalculator();

        Console.WriteLine("\n=== Задание 6: Исправление регистра предложений ===");
        SentenceCaseConverter();

        Console.WriteLine("\n=== Задание 7: Фильтр недопустимых слов ===");
        BadWordFilter();
    }

    // Задание 3: Шифр Цезаря
    static void CaesarCipher()
    {
        Console.Write("Введите текст: ");
        string text = Console.ReadLine();
        Console.Write("Введите сдвиг (целое число): ");
        int shift = int.Parse(Console.ReadLine());

        string Encrypt(string input, int key)
        {
            return new string(input.Select(c =>
            {
                if (!char.IsLetter(c)) return c;
                char offset = char.IsUpper(c) ? 'A' : 'a';
                return (char)(((c + key - offset) % 26 + 26) % 26 + offset);
            }).ToArray());
        }

        string encrypted = Encrypt(text, shift);
        string decrypted = Encrypt(encrypted, -shift);

        Console.WriteLine($"Зашифрованный текст: {encrypted}");
        Console.WriteLine($"Расшифрованный текст: {decrypted}");
    }

    // Задание 4: Операции с матрицами
    static void MatrixOperations()
    {
        double[,] CreateMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rand.Next(1, 10);
            return matrix;
        }

        void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],5}");
                Console.WriteLine();
            }
        }

        double[,] matrixA = CreateMatrix(2, 3);
        double[,] matrixB = CreateMatrix(2, 3);
        double[,] matrixC = CreateMatrix(3, 2);

        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);
        Console.WriteLine("\nМатрица B:");
        PrintMatrix(matrixB);
        Console.WriteLine("\nМатрица C:");
        PrintMatrix(matrixC);

        // Умножение матрицы на число
        Console.Write("\nВведите число для умножения: ");
        double num = double.Parse(Console.ReadLine());
        Console.WriteLine("Результат умножения матрицы A на число:");
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.GetLength(1); j++)
                Console.Write($"{matrixA[i, j] * num,5}");
            Console.WriteLine();
        }

        // Сложение матриц
        Console.WriteLine("\nСумма матриц A и B:");
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.GetLength(1); j++)
                Console.Write($"{matrixA[i, j] + matrixB[i, j],5}");
            Console.WriteLine();
        }

        // Умножение матриц
        Console.WriteLine("\nПроизведение матриц A и C:");
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixC.GetLength(1); j++)
            {
                double sum = 0;
                for (int k = 0; k < matrixA.GetLength(1); k++)
                    sum += matrixA[i, k] * matrixC[k, j];
                Console.Write($"{sum,5}");
            }
            Console.WriteLine();
        }
    }

    // Задание 5: Калькулятор выражений
    static void SimpleCalculator()
    {
        Console.Write("Введите арифметическое выражение (только + и -): ");
        string expression = Console.ReadLine().Replace(" ", "");

        string[] numbers = expression.Split(new[] { '+', '-' });
        string[] operators = expression.Split(numbers, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(c => c.ToString()).ToArray();

        if (numbers.Length == 0 || numbers.Length - operators.Length != 1)
        {
            Console.WriteLine("Неверный формат выражения!");
            return;
        }

        double result = double.Parse(numbers[0]);
        for (int i = 0; i < operators.Length; i++)
        {
            double num = double.Parse(numbers[i + 1]);
            result += operators[i] == "+" ? num : -num;
        }

        Console.WriteLine($"Результат: {result}");
    }

    // Задание 6: Исправление регистра предложений
    static void SentenceCaseConverter()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Текст не введен!");
            return;
        }

        StringBuilder result = new StringBuilder();
        bool newSentence = true;

        foreach (char c in text)
        {
            if (newSentence && char.IsLetter(c))
            {
                result.Append(char.ToUpper(c));
                newSentence = false;
            }
            else
            {
                result.Append(c);
            }

            if (c == '.' || c == '!' || c == '?') newSentence = true;
        }

        Console.WriteLine("Результат:");
        Console.WriteLine(result.ToString());
    }

    // Задание 7: Фильтр недопустимых слов
    static void BadWordFilter()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();
        Console.Write("Введите недопустимое слово: ");
        string badWord = Console.ReadLine().ToLower();

        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(badWord))
        {
            Console.WriteLine("Неверный ввод!");
            return;
        }

        string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' },
                                  StringSplitOptions.RemoveEmptyEntries);
        int replacements = 0;
        StringBuilder result = new StringBuilder(text);

        foreach (string word in words)
        {
            if (word.ToLower() == badWord)
            {
                result.Replace(word, new string('*', word.Length));
                replacements++;
            }
        }

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(result.ToString());
        Console.WriteLine($"Статистика: {replacements} замен слова {badWord}");
    }
}