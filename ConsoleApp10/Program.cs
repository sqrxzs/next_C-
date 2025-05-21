using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Game
    {
        private char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private bool isPlayerTurn;
        private bool vsComputer;

        public void Start(bool againstComputer)
        {
            vsComputer = againstComputer;
            var random = new Random();
            isPlayerTurn = random.Next(2) == 0;

            Console.WriteLine("Добро пожаловать в игру Крестики-Нолики!");
            Console.WriteLine(isPlayerTurn ? "Вы ходите первым!" : "Противник ходит первым!");

            while (true)
            {
                DrawBoard();
                if (CheckWinner() != ' ')
                {
                    Console.WriteLine(CheckWinner() == 'D' ? "Ничья!" : $"Победил {CheckWinner()}!");
                    break;
                }

                if (isPlayerTurn) PlayerMove();
                else if (vsComputer) ComputerMove();
                else SecondPlayerMove();

                isPlayerTurn = !isPlayerTurn;
            }
        }

        private void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        private void PlayerMove()
        {
            Console.Write("Выберите клетку (1-9): ");
            int move;
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || board[move - 1] == 'X' || board[move - 1] == 'O')
            {
                Console.Write("Неверный ход. Выберите свободную клетку (1-9): ");
            }
            board[move - 1] = 'X';
        }

        private void SecondPlayerMove()
        {
            Console.Write("Ход второго игрока (1-9): ");
            int move;
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || board[move - 1] == 'X' || board[move - 1] == 'O')
            {
                Console.Write("Неверный ход. Выберите свободную клетку (1-9): ");
            }
            board[move - 1] = 'O';
        }

        private void ComputerMove()
        {
            var random = new Random();
            int move;
            do
            {
                move = random.Next(0, 9);
            } while (board[move] == 'X' || board[move] == 'O');

            Console.WriteLine($"Компьютер выбрал клетку {move + 1}");
            board[move] = 'O';
        }

        private char CheckWinner()
        {
            // Проверка строк
            for (int i = 0; i < 9; i += 3)
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2])
                    return board[i];

            // Проверка столбцов
            for (int i = 0; i < 3; i++)
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                    return board[i];

            // Проверка диагоналей
            if (board[0] == board[4] && board[4] == board[8]) return board[0];
            if (board[2] == board[4] && board[4] == board[6]) return board[2];

            // Проверка на ничью
            foreach (char spot in board)
                if (spot != 'X' && spot != 'O') return ' ';

            return 'D';
        }
    }
}

namespace MorseTranslator
{
    class Translator
    {
        private static Dictionary<char, string> morseCode = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"},
            {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."},
            {'7', "--..."}, {'8', "---.."}, {'9', "----."}, {' ', "/"}
        };

        private static Dictionary<string, char> reverseMorse = new Dictionary<string, char>();

        static Translator()
        {
            foreach (var pair in morseCode)
                reverseMorse[pair.Value] = pair.Key;
        }

        public static string TextToMorse(string text)
        {
            string result = "";
            foreach (char c in text.ToUpper())
            {
                if (morseCode.ContainsKey(c))
                    result += morseCode[c] + " ";
            }
            return result;
        }

        public static string MorseToText(string morse)
        {
            string result = "";
            string[] codes = morse.Split(' ');
            foreach (string code in codes)
            {
                if (reverseMorse.ContainsKey(code))
                    result += reverseMorse[code];
            }
            return result;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите программу:");
        Console.WriteLine("1. Крестики-Нолики (против компьютера)");
        Console.WriteLine("2. Крестики-Нолики (2 игрока)");
        Console.WriteLine("3. Переводчик в азбуку Морзе");
        Console.WriteLine("4. Переводчик из азбуки Морзе");
        Console.Write("Ваш выбор: ");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.Write("Неверный выбор. Введите число от 1 до 4: ");
        }

        switch (choice)
        {
            case 1:
                new TicTacToe.Game().Start(true);
                break;
            case 2:
                new TicTacToe.Game().Start(false);
                break;
            case 3:
                Console.Write("Введите текст для перевода: ");
                string text = Console.ReadLine();
                Console.WriteLine("Результат: " + MorseTranslator.Translator.TextToMorse(text));
                break;
            case 4:
                Console.Write("Введите код Морзе (разделяйте символы пробелами): ");
                string morse = Console.ReadLine();
                Console.WriteLine("Результат: " + MorseTranslator.Translator.MorseToText(morse));
                break;
        }
    }
}