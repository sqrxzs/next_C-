using System;

void Main()
{
    
    BankVklad();
    VivodChisel();
    KvadratiVPryamougolnike();
    PerevernutChislo();
}

void BankVklad()
{
    Console.WriteLine("\nБанковский вклад (10000 → 11000)");

    double vklad = 10000;
    Console.WriteLine("Введите процент P (0 < P < 25):");
    double P = double.Parse(Console.ReadLine());

    if (P <= 0 || P >= 25)
    {
        Console.WriteLine("Ошибка! Процент должен быть от 0 до 25.");
        return;
    }

    int mesyac = 0;

    while (vklad <= 11000)
    {
        vklad += vklad * (P / 100);
        mesyac++;
    }

    Console.WriteLine($"Через {mesyac} месяцев вклад будет {vklad:F2} руб.");
}

void VivodChisel()
{
    Console.WriteLine("\nВывод чисел от A до B");

    Console.WriteLine("Введите число A:");
    int A = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите число B (B > A):");
    int B = int.Parse(Console.ReadLine());

    if (A <= 0 || B <= A)
    {
        Console.WriteLine("Ошибка! Должно быть A > 0 и B > A.");
        return;
    }

    for (int i = A; i <= B; i++)
    {
        for (int j = 0; j < i; j++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

void KvadratiVPryamougolnike()
{
    Console.WriteLine("\nКвадраты в прямоугольнике");

    Console.WriteLine("Введите длину прямоугольника (A):");
    int A = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите ширину прямоугольника (B):");
    int B = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите сторону квадрата (C):");
    int C = int.Parse(Console.ReadLine());

    if (A <= 0 || B <= 0 || C <= 0)
    {
        Console.WriteLine("Ошибка! Все числа должны быть положительными.");
        return;
    }

    if (C > A || C > B)
    {
        Console.WriteLine("Квадрат не помещается в прямоугольник!");
        return;
    }

    int kvadr_v_dlinu = A / C;
    int kvadr_v_shirinu = B / C;
    int vsego_kvadr = kvadr_v_dlinu * kvadr_v_shirinu;

    int ploshad = A * B;
    int zanyato = vsego_kvadr * C * C;
    int svobodno = ploshad - zanyato;

    Console.WriteLine($"Квадратов поместится: {vsego_kvadr}");
    Console.WriteLine($"Свободная площадь: {svobodno}");
}

void PerevernutChislo()
{
    Console.WriteLine("\nПереворот числа");

    Console.WriteLine("Введите число N (N > 0):");
    int N = int.Parse(Console.ReadLine());

    if (N <= 0)
    {
        Console.WriteLine("Ошибка! Число должно быть положительным.");
        return;
    }

    int perevernutoe = 0;
    int original = N;

    while (N > 0)
    {
        int cifra = N % 10;
        perevernutoe = perevernutoe * 10 + cifra;
        N /= 10;
    }

    Console.WriteLine($"Число {original} после переворота: {perevernutoe}");
}

Main();