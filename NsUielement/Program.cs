using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsUielement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barLength = 10;
            string exit = "exit";
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
                percentHealth += Convert.ToInt32(Console.ReadLine()) / barLength;
                Console.Write("Введите процент маны: ");
                percentMana += Convert.ToInt32(Console.ReadLine()) / barLength;
                Console.WriteLine($"Введите {exit}, чтобы выйти из программы. Нажмите любую клавишу для продолжения работы...");
                string userInput = Console.ReadLine();
                Console.Clear();

                if (userInput == exit)
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

            FormBar(ref bar, 0, percent, symbol);
            Console.SetCursorPosition(0, position);
            Console.Write(openBracket);
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = consoleColor;
            bar = "";
            FormBar(ref bar,percent,barLength);
            Console.Write(bar + closeBracket);
        }

        private static string FormBar(ref string bar,int value, int maxValue, char symbol = ' ')
        {
            for (int i = value; i < maxValue; i++)
            {
                bar += symbol;
            }

            return bar;
        }
    }
}