using System;

// Класс Money для работы с деньгами
class Money
{
    public int Dollars;
    public int Cents;

    public void SetAmount(int dollars, int cents)
    {
        Dollars = dollars;
        Cents = cents;
        Normalize();
    }

    public void Display()
    {
        Console.WriteLine($"{Dollars}.{Cents:D2}");
    }

    private void Normalize()
    {
        if (Cents >= 100)
        {
            Dollars += Cents / 100;
            Cents %= 100;
        }
    }
}

// Класс Product на базе Money
class Product : Money
{
    public string Name;

    public void ReducePrice(int dollars, int cents)
    {
        Dollars -= dollars;
        Cents -= cents;

        if (Cents < 0)
        {
            Dollars--;
            Cents += 100;
        }
    }
}

// Базовый класс Устройство
class Device
{
    public string Name;
    public string Description;

    public Device(string name, string desc)
    {
        Name = name;
        Description = desc;
    }

    public virtual void Sound() => Console.WriteLine("Устройство издает звук");
    public void Show() => Console.WriteLine($"Устройство: {Name}");
    public void Desc() => Console.WriteLine($"Описание: {Description}");
}

// Производные классы устройств
class Kettle : Device
{
    public Kettle() : base("Чайник", "Кухонный прибор для кипячения воды") { }
    public override void Sound() => Console.WriteLine("Чайник свистит: Ссссс!");
}

class Microwave : Device
{
    public Microwave() : base("Микроволновка", "Прибор для разогрева пищи") { }
    public override void Sound() => Console.WriteLine("Микроволновка: Пип-пип!");
}

class Car : Device
{
    public Car() : base("Автомобиль", "Транспортное средство") { }
    public override void Sound() => Console.WriteLine("Автомобиль: Врум-врум!");
}

class Steamship : Device
{
    public Steamship() : base("Пароход", "Водное судно") { }
    public override void Sound() => Console.WriteLine("Пароход: Ту-тууу!");
}

// Базовый класс Музыкальный инструмент
class MusicalInstrument
{
    public string Name;
    public string Description;

    public MusicalInstrument(string name, string desc)
    {
        Name = name;
        Description = desc;
    }

    public virtual void Sound() => Console.WriteLine("Инструмент издает звук");
    public void Show() => Console.WriteLine($"Инструмент: {Name}");
    public void Desc() => Console.WriteLine($"Описание: {Description}");
    public virtual void History() => Console.WriteLine("История инструмента");
}

// Производные классы музыкальных инструментов
class Violin : MusicalInstrument
{
    public Violin() : base("Скрипка", "Смычковый инструмент") { }
    public override void Sound() => Console.WriteLine("Скрипка: Скрип-скрип!");
    public override void History() => Console.WriteLine("Скрипка появилась в XVI веке");
}

class Trombone : MusicalInstrument
{
    public Trombone() : base("Тромбон", "Медный духовой инструмент") { }
    public override void Sound() => Console.WriteLine("Тромбон: Ту-ту-ту!");
    public override void History() => Console.WriteLine("Тромбон известен с XV века");
}

class Ukulele : MusicalInstrument
{
    public Ukulele() : base("Укулеле", "Гавайская гитара") { }
    public override void Sound() => Console.WriteLine("Укулеле: Плин-плин!");
    public override void History() => Console.WriteLine("Укулеле появилась в XIX веке");
}

class Cello : MusicalInstrument
{
    public Cello() : base("Виолончель", "Большой смычковый инструмент") { }
    public override void Sound() => Console.WriteLine("Виолончель: Ммм-ммм!");
    public override void History() => Console.WriteLine("Виолончель развилась в XVI веке");
}

// Абстрактный класс Worker
abstract class Worker
{
    public abstract void Print();
}

// Производные классы работников
class President : Worker
{
    public override void Print() => Console.WriteLine("Я Президент компании");
}

class Security : Worker
{
    public override void Print() => Console.WriteLine("Я Охранник");
}

class Manager : Worker
{
    public override void Print() => Console.WriteLine("Я Менеджер");
}

class Engineer : Worker
{
    public override void Print() => Console.WriteLine("Я Инженер");
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Работа с деньгами ===");
        Money money = new Money();
        money.SetAmount(10, 50);
        money.Display();

        Console.WriteLine("\n=== Работа с продуктом ===");
        Product product = new Product();
        product.Name = "Хлеб";
        product.SetAmount(3, 75);
        Console.Write("Цена продукта: ");
        product.Display();
        product.ReducePrice(1, 50);
        Console.Write("Цена после скидки: ");
        product.Display();

        Console.WriteLine("\n=== Устройства ===");
        Device[] devices = { new Kettle(), new Microwave(), new Car(), new Steamship() };
        foreach (var device in devices)
        {
            device.Show();
            device.Sound();
            device.Desc();
            Console.WriteLine();
        }

        Console.WriteLine("=== Музыкальные инструменты ===");
        MusicalInstrument[] instruments = { new Violin(), new Trombone(), new Ukulele(), new Cello() };
        foreach (var instrument in instruments)
        {
            instrument.Show();
            instrument.Sound();
            instrument.Desc();
            instrument.History();
            Console.WriteLine();
        }

        Console.WriteLine("=== Работники ===");
        Worker[] workers = { new President(), new Security(), new Manager(), new Engineer() };
        foreach (var worker in workers)
        {
            worker.Print();
        }
    }
}