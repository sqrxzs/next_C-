using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FileAndCodeAnalyzer
{
    class Program
    {
        static string filePath = "Day17.txt";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Создать файл");
                Console.WriteLine("2. Прочитать файл");
                Console.WriteLine("3. Записать данные");
                Console.WriteLine("4. Прочитать и разобрать файл");
                Console.WriteLine("5. Анализатор кода");
                Console.WriteLine("0. Выход");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": CreateFile(); break;
                    case "2": ReadFile(); break;
                    case "3": WriteFormattedData(); break;
                    case "4": ParseFile(); break;
                    case "5": CodeAnalyzer(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод"); break;
                }
            }
        }

        static void CreateFile()
        {
            if (File.Exists(filePath))
                Console.WriteLine("Файл уже существует.");
            else
            {
                File.Create(filePath).Close();
                Console.WriteLine("Файл создан.");
            }
        }

        static void ReadFile()
        {
            if (!File.Exists(filePath))
                Console.WriteLine("Файл не найден.");
            else
                Console.WriteLine(File.ReadAllText(filePath));
        }

        static void WriteFormattedData()
        {
            var lines = new List<string>();
            Console.Write("ФИО и дата рождения: ");
            lines.Add(Console.ReadLine());

            Console.Write("Строк и столбцов в массиве double: ");
            var sizeD = Console.ReadLine().Split().Select(int.Parse).ToArray();
            lines.Add(string.Join(" ", sizeD));
            var rnd = new Random();

            for (int i = 0; i < sizeD[0]; i++)
            {
                var row = Enumerable.Range(0, sizeD[1]).Select(_ => (rnd.NextDouble() * 100).ToString("F2", CultureInfo.InvariantCulture));
                lines.Add(string.Join(" ", row));
            }

            Console.Write("Строк и столбцов в массиве int: ");
            var sizeI = Console.ReadLine().Split().Select(int.Parse).ToArray();
            lines.Add(string.Join(" ", sizeI));
            for (int i = 0; i < sizeI[0]; i++)
            {
                var row = Enumerable.Range(0, sizeI[1]).Select(_ => rnd.Next(100).ToString());
                lines.Add(string.Join(" ", row));
            }

            lines.Add(DateTime.Now.ToString());
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Данные записаны.");
        }

        static void ParseFile()
        {
            if (!File.Exists(filePath)) { Console.WriteLine("Файл не найден."); return; }
            var lines = File.ReadAllLines(filePath);
            Console.WriteLine("ФИО и дата рождения: " + lines[0]);

            var sizeD = lines[1].Split().Select(int.Parse).ToArray();
            Console.WriteLine("Массив double:");
            for (int i = 2; i < 2 + sizeD[0]; i++)
                Console.WriteLine(lines[i]);

            int startI = 2 + sizeD[0];
            var sizeI = lines[startI].Split().Select(int.Parse).ToArray();
            Console.WriteLine("Массив int:");
            for (int i = startI + 1; i < startI + 1 + sizeI[0]; i++)
                Console.WriteLine(lines[i]);

            Console.WriteLine("Дата записи: " + lines.Last());
        }

        static void CodeAnalyzer()
        {
            Console.Write("Введите путь к C#-файлу: ");
            string sourcePath = Console.ReadLine();
            if (!File.Exists(sourcePath)) { Console.WriteLine("Файл не найден."); return; }

            string[] lines = File.ReadAllLines(sourcePath);
            var transformed = new List<string>();

            foreach (var line in lines)
            {
                string trimmed = string.Join(" ", line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));
                string modified = trimmed.Replace("public", "private");
                string upper = string.Concat(modified.Select(c => char.IsLetter(c) && char.IsLower(c) ? char.ToUpper(c) : c));
                transformed.Add(new string(upper.Reverse().ToArray()));
            }

            string resultPath = Path.Combine(Path.GetDirectoryName(sourcePath), "Transformed.txt");
            File.WriteAllLines(resultPath, transformed);
            Console.WriteLine($"Обработанный файл сохранён как: {resultPath}");
        }
    }
}