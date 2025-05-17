using System;
using System.Collections.Generic;

// Интерфейсы
interface IPart
{
    void Build();
    bool IsBuilt { get; }
}

interface IWorker
{
    void Work(House house);
}

// Части дома
class Basement : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        IsBuilt = true;
        Console.WriteLine("Фундамент построен");
    }
}

class Walls : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        IsBuilt = true;
        Console.WriteLine("Стены построены");
    }
}

class Door : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        IsBuilt = true;
        Console.WriteLine("Дверь установлена");
    }
}

class Window : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        IsBuilt = true;
        Console.WriteLine("Окно установлено");
    }
}

class Roof : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        IsBuilt = true;
        Console.WriteLine("Крыша построена");
    }
}

// Рабочие
class Worker : IWorker
{
    public void Work(House house)
    {
        if (house.Basement == null || !house.Basement.IsBuilt)
        {
            house.Basement = new Basement();
            house.Basement.Build();
        }
        else if (house.Walls == null || !house.Walls.IsBuilt)
        {
            house.Walls = new Walls();
            house.Walls.Build();
        }
        else if (house.Door == null || !house.Door.IsBuilt)
        {
            house.Door = new Door();
            house.Door.Build();
        }
        else if (house.Windows == null || house.Windows.Count < 4)
        {
            if (house.Windows == null)
                house.Windows = new List<Window>();

            house.Windows.Add(new Window());
            house.Windows[house.Windows.Count - 1].Build();
        }
        else if (house.Roof == null || !house.Roof.IsBuilt)
        {
            house.Roof = new Roof();
            house.Roof.Build();
        }
    }
}

class TeamLeader : IWorker
{
    public void Work(House house)
    {
        Console.WriteLine("\nОтчет бригадира:");

        if (house.Basement != null && house.Basement.IsBuilt)
            Console.WriteLine("- Фундамент готов");
        else
            Console.WriteLine("- Фундамент еще не построен");

        if (house.Walls != null && house.Walls.IsBuilt)
            Console.WriteLine("- Стены готовы");
        else
            Console.WriteLine("- Стены еще не построены");

        if (house.Door != null && house.Door.IsBuilt)
            Console.WriteLine("- Дверь установлена");
        else
            Console.WriteLine("- Дверь еще не установлена");

        Console.WriteLine($"- Установлено окон: {(house.Windows != null ? house.Windows.Count : 0)} из 4");

        if (house.Roof != null && house.Roof.IsBuilt)
            Console.WriteLine("- Крыша готова");
        else
            Console.WriteLine("- Крыша еще не построена");
    }
}

// Бригада и дом
class Team
{
    private List<IWorker> workers = new List<IWorker>();

    public Team()
    {
        workers.Add(new TeamLeader());
        for (int i = 0; i < 3; i++)
            workers.Add(new Worker());
    }

    public void BuildHouse(House house)
    {
        Console.WriteLine("Начало строительства...");

        foreach (var worker in workers)
        {
            worker.Work(house);
        }
    }
}

class House
{
    public Basement Basement { get; set; }
    public Walls Walls { get; set; }
    public List<Window> Windows { get; set; }
    public Door Door { get; set; }
    public Roof Roof { get; set; }

    public void DrawHouse()
    {
        Console.WriteLine("\nДом построен! Вот как он выглядит:");
        Console.WriteLine("   /\\");
        Console.WriteLine("  /  \\");
        Console.WriteLine(" /____\\");
        Console.WriteLine("|      |");
        Console.WriteLine("|  []  |");
        Console.WriteLine("|  __  |");
        Console.WriteLine("|______|");
    }
}

class Program
{
    static void Main()
    {
        House house = new House();
        Team team = new Team();

        team.BuildHouse(house);
        house.DrawHouse();
    }
}