using System;

class City
{
    public string Name;
    public string Country;
    public int Population;
    public string PhoneCode;
    public string[] Districts;

    public void PrintInfo()
    {
        Console.WriteLine($"\nИнформация о городе:");
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Страна: {Country}");
        Console.WriteLine($"Население: {Population} чел.");
        Console.WriteLine($"Телефонный код: {PhoneCode}");
        Console.WriteLine($"Районы: {string.Join(", ", Districts)}");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 - Произведение чисел в диапазоне");
            Console.WriteLine("2 - Проверка числа Фибоначчи");
            Console.WriteLine("3 - Сортировка массива");
            Console.WriteLine("4 - Класс 'Город'");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка ввода! Попробуйте еще раз.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте еще раз.");
                    break;
            }
        }
    }

    static void Task1()
    {
        Console.WriteLine("\n=== Произведение чисел в диапазоне ===");
        Console.Write("Введите начало диапазона: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Введите конец диапазона: ");
        int end = int.Parse(Console.ReadLine());

        if (start > end)
        {
            Console.WriteLine("Ошибка: начало диапазона должно быть меньше конца!");
            return;
        }

        long result = 1;
        for (int i = start; i <= end; i++)
        {
            result *= i;
        }
        Console.WriteLine($"Произведение чисел от {start} до {end} = {result}");
    }

    static void Task2()
    {
        Console.WriteLine("\n=== Проверка числа Фибоначчи ===");
        Console.Write("Введите число: ");
        int num = int.Parse(Console.ReadLine());

        int a = 0, b = 1;
        while (b < num)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        bool isFib = b == num;

        Console.WriteLine($"Число {num} {(isFib ? "является" : "не является")} числом Фибоначчи");
    }

    static void Task3()
    {
        Console.WriteLine("\n=== Сортировка массива ===");
        int[] numbers = { 5, 2, 8, 1, 9, 3, 6, 4, 7 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", numbers));

        Console.Write("Сортировать по возрастанию (да/нет)? ");
        bool ascending = Console.ReadLine().ToLower() == "да";

        // Сортировка пузырьком
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - 1 - i; j++)
            {
                if ((ascending && numbers[j] > numbers[j + 1]) ||
                    (!ascending && numbers[j] < numbers[j + 1]))
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", numbers));
    }

    static void Task4()
    {
        Console.WriteLine("\n=== Класс 'Город' ===");
        City city = new City();

        Console.Write("Введите название города: ");
        city.Name = Console.ReadLine();

        Console.Write("Введите страну: ");
        city.Country = Console.ReadLine();

        Console.Write("Введите количество жителей: ");
        city.Population = int.Parse(Console.ReadLine());

        Console.Write("Введите телефонный код: ");
        city.PhoneCode = Console.ReadLine();

        Console.Write("Введите районы через запятую: ");
        city.Districts = Console.ReadLine().Split(',');

        city.PrintInfo();
    }
}