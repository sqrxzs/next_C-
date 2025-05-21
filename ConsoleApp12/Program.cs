using System;
using System.Collections.Generic;

// Класс для хранения информации о пользователе
public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
}

// Класс для управления пользователями
public class UserManager
{
    // Список зарегистрированных пользователей
    private List<User> _users = new List<User>();

    // Делегат для обработки события регистрации
    public delegate void UserRegisteredEventHandler(User newUser);

    // Событие, возникающее при успешной регистрации
    public event UserRegisteredEventHandler UserRegistered;

    // Метод для регистрации нового пользователя
    public void RegisterUser(string username, string email)
    {
        var newUser = new User
        {
            Username = username,
            Email = email,
            RegistrationDate = DateTime.Now
        };

        _users.Add(newUser);

        // Вызываем событие
        OnUserRegistered(newUser);
    }

    // Метод для вызова события
    protected virtual void OnUserRegistered(User user)
    {
        UserRegistered?.Invoke(user);
    }
}

// Класс для уведомления администратора
public class AdminNotifier
{
    // Метод-обработчик события регистрации
    public void NotifyAdmin(User newUser)
    {
        Console.WriteLine($"\n[УВЕДОМЛЕНИЕ АДМИНИСТРАТОРУ]");
        Console.WriteLine($"Зарегистрирован новый пользователь:");
        Console.WriteLine($"Имя: {newUser.Username}");
        Console.WriteLine($"Email: {newUser.Email}");
        Console.WriteLine($"Дата регистрации: {newUser.RegistrationDate}\n");
    }
}

class Program
{
    static void Main()
    {
        // Создаем менеджер пользователей
        var userManager = new UserManager();

        // Создаем уведомитель администратора
        var notifier = new AdminNotifier();

        // Подписываемся на событие
        userManager.UserRegistered += notifier.NotifyAdmin;

        Console.WriteLine("Система регистрации пользователей");

        while (true)
        {
            Console.Write("\nВведите имя пользователя (или 'exit' для выхода): ");
            string username = Console.ReadLine();

            if (username.ToLower() == "exit")
                break;

            Console.Write("Введите email: ");
            string email = Console.ReadLine();

            // Регистрируем пользователя
            userManager.RegisterUser(username, email);

            Console.WriteLine($"Пользователь {username} успешно зарегистрирован!");
        }
    }
}