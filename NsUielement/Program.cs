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
                percentHealth = 0;
                percentMana = 0;
                Console.SetCursorPosition(0, 5);
                Console.Write("Введите процент жизней: ");
                percentHealth = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите процент маны: ");
                percentMana = Convert.ToInt32(Console.ReadLine());
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
            string bar = "";
            char openBracket = '[';
            char closeBracket = ']';
            int oneHundredPercent = 100; 
            float value = barLength * percent / oneHundredPercent;

            if (percent >= 0 && percent <= oneHundredPercent)
            {
                FormBar(ref bar, 0, value, symbol);
                Console.SetCursorPosition(0, position);
                Console.Write(openBracket);
                Console.BackgroundColor = color;
                Console.Write(bar);
                Console.BackgroundColor = consoleColor;
                bar = "";
                FormBar(ref bar, value, barLength);
                Console.Write(bar + closeBracket);
            }
            else
            {
                Console.WriteLine("Введённые данные некорректны");
            }
        }

        private static string FormBar(ref string bar,float value, float maxValue, char symbol = ' ')
        {
            for (float i = value; i < maxValue; i++)
            {
                bar += symbol;
            }

            return bar;
        }
    }
}