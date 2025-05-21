using System;

// Задание 1: Делегат для обработки чисел
class NumberProcessor
{
    public int Square(int x) => x * x;
    public int Double(int x) => x * 2;
}

// Задание 2: Событие на изменение значения
class ObservableValue
{
    private string _value;
    public event Action<string, string> ValueChanged;

    public string Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                string oldValue = _value;
                _value = value;
                ValueChanged?.Invoke(oldValue, value);
            }
        }
    }
}

// Задание 3: Калькулятор
class Calculator
{
    private double _currentValue;
    private double _buffer;
    private char? _pendingOperation;

    public event Action<double> CalculationPerformed;

    public void ProcessInput(char input)
    {
        if (char.IsDigit(input))
        {
            _buffer = _buffer * 10 + (input - '0');
        }
        else if (input == '+' || input == '-' || input == '*' || input == '/')
        {
            if (_pendingOperation.HasValue)
                Calculate();

            _pendingOperation = input;
            _currentValue = _buffer;
            _buffer = 0;
        }
        else if (input == '=')
        {
            Calculate();
            _pendingOperation = null;
        }
    }

    private void Calculate()
    {
        switch (_pendingOperation)
        {
            case '+': _currentValue += _buffer; break;
            case '-': _currentValue -= _buffer; break;
            case '*': _currentValue *= _buffer; break;
            case '/': _currentValue /= _buffer; break;
            default: _currentValue = _buffer; break;
        }
        CalculationPerformed?.Invoke(_currentValue);
        _buffer = _currentValue;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задание (1-3):");
        int choice = int.Parse(Console.ReadLine());

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
        }
    }

    static void Task1()
    {
        var processor = new NumberProcessor();
        Func<int, int> operation;

        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        operation = processor.Square;
        Console.WriteLine($"Квадрат числа: {operation(number)}");

        operation = processor.Double;
        Console.WriteLine($"Удвоенное число: {operation(number)}");
    }

    static void Task2()
    {
        var observable = new ObservableValue();
        observable.ValueChanged += (oldVal, newVal) =>
            Console.WriteLine($"Значение изменилось: {oldVal} -> {newVal}");

        while (true)
        {
            Console.Write("Введите новое значение (или 'exit' для выхода): ");
            string input = Console.ReadLine();
            if (input == "exit") break;
            observable.Value = input;
        }
    }

    static void Task3()
    {
        var calculator = new Calculator();
        calculator.CalculationPerformed += result =>
            Console.WriteLine($"Промежуточный результат: {result}");

        Console.WriteLine("Калькулятор. Вводите цифры и операции (+, -, *, /, =):");

        while (true)
        {
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (input == '=')
            {
                calculator.ProcessInput('=');
                break;
            }

            calculator.ProcessInput(input);
        }
    }
}