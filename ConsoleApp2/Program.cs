using System;

void Main()
{
    FizzBuzzGame();
    CalculatePercentage();
    BuildNumberFromDigits();
    SwapDigitsInNumber();
    ShowSeasonAndDay();
    TemperatureConverter();
    ShowEvenNumbers();
}

// Задание 1: FizzBuzz
void FizzBuzzGame()
{
    Console.WriteLine("\n[Задание 1] FizzBuzz (1-100)");
    Console.Write("Введите число от 1 до 100: ");
    if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > 100)
    {
        Console.WriteLine("Ошибка! Введите число от 1 до 100.");
        return;
    }

    string result = "";
    if (number % 3 == 0) result += "Fizz";
    if (number % 5 == 0) result += "Buzz";
    Console.WriteLine(string.IsNullOrEmpty(result) ? number.ToString() : result);
}

// Задание 2: Процент от числа
void CalculatePercentage()
{
    Console.WriteLine("\n[Задание 2] Расчет процента");
    Console.Write("Введите число: ");
    double value = double.Parse(Console.ReadLine());
    Console.Write("Введите процент: ");
    double percent = double.Parse(Console.ReadLine());

    double result = value * percent / 100;
    Console.WriteLine($"{percent}% от {value} = {result}");
}

// Задание 3: Сборка числа из цифр
void BuildNumberFromDigits()
{
    Console.WriteLine("\n[Задание 3] Сборка числа из 4 цифр");
    int[] digits = new int[4];
    for (int i = 0; i < 4; i++)
    {
        Console.Write($"Введите цифру {i + 1}: ");
        digits[i] = int.Parse(Console.ReadLine());
    }

    int number = digits[0] * 1000 + digits[1] * 100 + digits[2] * 10 + digits[3];
    Console.WriteLine($"Полученное число: {number}");
}

// Задание 4: Обмен цифр в числе
void SwapDigitsInNumber()
{
    Console.WriteLine("\n[Задание 4] Обмен цифр в шестизначном числе");
    Console.Write("Введите шестизначное число: ");
    string input = Console.ReadLine();

    if (input.Length != 6 || !int.TryParse(input, out _))
    {
        Console.WriteLine("Ошибка! Число должно быть шестизначным.");
        return;
    }

    Console.Write("Введите первый разряд (1-6): ");
    int pos1 = int.Parse(Console.ReadLine()) - 1;
    Console.Write("Введите второй разряд (1-6): ");
    int pos2 = int.Parse(Console.ReadLine()) - 1;

    char[] digits = input.ToCharArray();
    (digits[pos1], digits[pos2]) = (digits[pos2], digits[pos1]);
    Console.WriteLine($"Результат: {new string(digits)}");
}

// Задание 5: Определение сезона и дня недели
void ShowSeasonAndDay()
{
    Console.WriteLine("\n[Задание 5] Определение сезона и дня недели");
    Console.Write("Введите дату (дд.мм.гггг): ");
    DateTime date = DateTime.Parse(Console.ReadLine());

    string season = date.Month switch
    {
        12 or 1 or 2 => "Winter",
        3 or 4 or 5 => "Spring",
        6 or 7 or 8 => "Summer",
        9 or 10 or 11 => "Autumn",
        _ => "Unknown"
    };

    string day = date.DayOfWeek.ToString();
    Console.WriteLine($"{season} {day}");
}

// Задание 6: Конвертер температуры
void TemperatureConverter()
{
    Console.WriteLine("\n[Задание 6] Конвертер температуры");
    Console.Write("Введите температуру: ");
    double temp = double.Parse(Console.ReadLine());
    Console.Write("Конвертировать в (1 - Цельсий, 2 - Фаренгейт): ");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        double celsius = (temp - 32) * 5 / 9;
        Console.WriteLine($"{temp}°F = {celsius:F1}°C");
    }
    else
    {
        double fahrenheit = temp * 9 / 5 + 32;
        Console.WriteLine($"{temp}°C = {fahrenheit:F1}°F");
    }
}

// Задание 7: Четные числа в диапазоне
void ShowEvenNumbers()
{
    Console.WriteLine("\n[Задание 7] Четные числа в диапазоне");
    Console.Write("Введите первое число: ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Введите второе число: ");
    int b = int.Parse(Console.ReadLine());

    if (a > b) (a, b) = (b, a);

    Console.WriteLine($"Четные числа от {a} до {b}:");
    for (int i = a; i <= b; i++)
    {
        if (i % 2 == 0) Console.Write(i + " ");
    }
    Console.WriteLine();
}

Main();