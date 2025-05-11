using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Задание 1 ===");
        Task1();

        Console.WriteLine("\n=== Задание 2 ===");
        Task2();
    }

    static void Task1()
    {
        // Объявление и заполнение массивов
        double[] A = new double[5];
        double[,] B = new double[3, 4];
        Random rand = new Random();

        // Заполнение массива A
        Console.WriteLine("Введите 5 чисел для массива A:");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write($"A[{i}] = ");
            A[i] = double.Parse(Console.ReadLine());
        }

        // Заполнение массива B случайными числами
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i, j] = Math.Round(rand.NextDouble() * 20 - 10, 2); // числа от -10 до 10
            }
        }

        // Вывод массивов
        Console.WriteLine("\nМассив A:");
        Console.WriteLine(string.Join(" ", A));

        Console.WriteLine("\nМассив B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{B[i, j],8}");
            }
            Console.WriteLine();
        }

        // Поиск общих характеристик
        double max = A[0];
        double min = A[0];
        double sum = 0;
        double product = 1;
        double sumEvenA = 0;
        double sumOddColumnsB = 0;

        // Обработка массива A
        foreach (double num in A)
        {
            if (num > max) max = num;
            if (num < min) min = num;
            sum += num;
            product *= num;
            if (num % 2 == 0) sumEvenA += num;
        }

        // Обработка массива B
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (B[i, j] > max) max = B[i, j];
                if (B[i, j] < min) min = B[i, j];
                sum += B[i, j];
                product *= B[i, j];
                if (j % 2 == 0) sumOddColumnsB += B[i, j]; // столбцы с нечетными индексами (0, 2)
            }
        }

        // Вывод результатов
        Console.WriteLine($"\nМаксимальный элемент: {max}");
        Console.WriteLine($"Минимальный элемент: {min}");
        Console.WriteLine($"Общая сумма элементов: {sum}");
        Console.WriteLine($"Общее произведение элементов: {product}");
        Console.WriteLine($"Сумма четных элементов массива A: {sumEvenA}");
        Console.WriteLine($"Сумма нечетных столбцов массива B: {sumOddColumnsB}");
    }

    static void Task2()
    {
        // Создание и заполнение массива
        double[,] matrix = new double[5, 5];
        Random rand = new Random();

        Console.WriteLine("Исходный массив 5x5:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = rand.Next(-100, 101);
                Console.Write($"{matrix[i, j],6}");
            }
            Console.WriteLine();
        }

        // Поиск min и max элементов и их позиций
        double min = matrix[0, 0], max = matrix[0, 0];
        int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minRow = i;
                    minCol = j;
                }
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                    maxCol = j;
                }
            }
        }

        Console.WriteLine($"\nМинимальный элемент: {min} (позиция [{minRow},{minCol}])");
        Console.WriteLine($"Максимальный элемент: {max} (позиция [{maxRow},{maxCol}])");

        // Вычисление суммы между min и max
        double sumBetween = 0;
        bool between = false;

        // Преобразуем позиции в линейный индекс
        int minIndex = minRow * 5 + minCol;
        int maxIndex = maxRow * 5 + maxCol;

        // Определяем начальную и конечную точки
        int start = Math.Min(minIndex, maxIndex) + 1;
        int end = Math.Max(minIndex, maxIndex);

        // Суммируем элементы между ними
        for (int i = start; i < end; i++)
        {
            int row = i / 5;
            int col = i % 5;
            sumBetween += matrix[row, col];
            between = true;
        }

        if (between)
            Console.WriteLine($"Сумма элементов между min и max: {sumBetween}");
        else
            Console.WriteLine("Между min и max нет элементов");
    }
}