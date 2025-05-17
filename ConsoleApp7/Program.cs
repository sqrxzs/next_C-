// Seusing System;
using System.Linq;

class Website
{
    public string Name;
    public string Url;
    public string Description;
    public string Ip;

    public void PrintInfo()
    {
        Console.WriteLine($"Сайт: {Name}");
        Console.WriteLine($"Адрес: {Url}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"IP: {Ip}");
    }
}

class Magazine
{
    public string Title;
    public int Year;
    public string Description;
    public string Phone;
    public string Email;

    public void PrintInfo()
    {
        Console.WriteLine($"Журнал: {Title}");
        Console.WriteLine($"Год основания: {Year}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Телефон: {Phone}");
        Console.WriteLine($"Email: {Email}");
    }
}

class Shop
{
    public string Name;
    public string Address;
    public string Description;
    public string Phone;
    public string Email;

    public void PrintInfo()
    {
        Console.WriteLine($"Магазин: {Name}");
        Console.WriteLine($"Адрес: {Address}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Телефон: {Phone}");
        Console.WriteLine($"Email: {Email}");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 - Квадрат из символов");
            Console.WriteLine("2 - Проверка на палиндром");
            Console.WriteLine("3 - Фильтрация массива");
            Console.WriteLine("4 - Класс Веб-сайт");
            Console.WriteLine("5 - Класс Журнал");
            Console.WriteLine("6 - Класс Магазин");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Ошибка ввода!");
                continue;
            }

            switch (choice)
            {
                case 1: DrawSquare(); break;
                case 2: CheckPalindrome(); break;
                case 3: FilterArray(); break;
                case 4: TestWebsite(); break;
                case 5: TestMagazine(); break;
                case 6: TestShop(); break;
                case 0: return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }
        }
    }

    static void DrawSquare()
    {
        Console.Write("Введите размер квадрата: ");
        int size = int.Parse(Console.ReadLine());
        Console.Write("Введите символ: ");
        char symbol = Console.ReadLine()[0];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(symbol + " ");
            }
            Console.WriteLine();
        }
    }

    static void CheckPalindrome()
    {
        Console.Write("Введите число: ");
        string number = Console.ReadLine();
        bool isPalindrome = number == new string(number.Reverse().ToArray());
        Console.WriteLine($"Это {(isPalindrome ? "палиндром" : "не палиндром")}");
    }

    static void FilterArray()
    {
        int[] original = { 1, 2, 6, -1, 88, 7, 6 };
        int[] filter = { 6, 88, 7 };

        var result = original.Where(x => !filter.Contains(x)).ToArray();

        Console.WriteLine("Результат фильтрации: " + string.Join(" ", result));
    }

    static void TestWebsite()
    {
        Website site = new Website
        {
            Name = "Пример сайта",
            Url = "https://example.com",
            Description = "Тестовый сайт",
            Ip = "192.168.1.1"
        };
        site.PrintInfo();
    }

    static void TestMagazine()
    {
        Magazine mag = new Magazine
        {
            Title = "Научный журнал",
            Year = 2000,
            Description = "Популярное издание",
            Phone = "+123456789",
            Email = "info@magazine.com"
        };
        mag.PrintInfo();
    }

    static void TestShop()
    {
        Shop shop = new Shop
        {
            Name = "Продукты",
            Address = "ул. Центральная, 1",
            Description = "Продуктовый магазин",
            Phone = "+987654321",
            Email = "shop@example.com"
        };
        shop.PrintInfo();
    }
}