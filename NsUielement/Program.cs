using System;

namespace NsUielement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barLength = 10;
            string commandExit = "exit";
            bool isWork = true;
            int percentHealth = 0;
            int percentMana = 0;

            while (isWork)
            {
                DrawBar(percentHealth, barLength, ConsoleColor.Red, 0);
                DrawBar(percentMana, barLength, ConsoleColor.Blue, 1);
                Console.SetCursorPosition(0, 5);
                Console.Write("Введите процент жизней: ");
                
                if(int.TryParse(Console.ReadLine(), out percentHealth) == false)
                {
                    Console.WriteLine("Некорректный ввод");
                }

                Console.Write("Введите процент маны: ");
                
                if (int.TryParse(Console.ReadLine(),out percentMana) == false)
                {
                    Console.WriteLine("Некорректный ввод");
                }
               
                Console.WriteLine($"Введите {commandExit}, чтобы выйти из программы. Нажмите любую клавишу для продолжения работы...");
                string userInput = Console.ReadLine();
                Console.Clear();

                if (userInput == commandExit)
                {
                    isWork = false;
                }
            }
        }

        private static void DrawBar(int percent, int barLength, ConsoleColor color, int position, char symbol = '#')
        {
            ConsoleColor consoleColor = Console.BackgroundColor;
            char openBracket = '[';
            char closeBracket = ']';
            char emptyPart = '_';
            int oneHundredPercent = 100; 
            float value = barLength * percent / oneHundredPercent;

            if (percent >= 0 && percent <= oneHundredPercent)
            {
                string bar = CompletePartBar(value, symbol);
                Console.SetCursorPosition(0, position);
                Console.Write(openBracket);
                Console.BackgroundColor = color;
                Console.Write(bar);
                Console.BackgroundColor = consoleColor;
                bar = CompletePartBar(barLength-value, emptyPart);
                Console.Write(bar + closeBracket);
            }
            else
            {
                Console.WriteLine("Введённые данные некорректны");
            }
        }

        private static string CompletePartBar(float amount, char symbol = ' ')
        {
            string bar = "";

            for (int i = 0; i < amount; i++)
            {
                bar += symbol;
            }

            return bar;
        }
    }
}