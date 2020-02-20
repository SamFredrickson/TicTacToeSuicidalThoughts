using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class DialogManager
    {
        public void ShowHi()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("  Tic Tac Toe Game");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string AskForCoors(Player pl)
        {
            Console.WriteLine();
            Console.WriteLine("Игрок {0} вводит координаты через зяпятую: ", pl.Name);
            Console.WriteLine("Пример: 0, 1");
            Console.WriteLine();

            Console.Write("Ввод: ");
            string coors = Console.ReadLine();

            return coors;
        }

        public string AskForUserName()
        {
            Console.WriteLine("Введите имена игроков через зяпятую: ");
            Console.WriteLine("Пример: Sam, Jhon");
            Console.WriteLine();

            Console.Write("Ввод: ");
            string names = Console.ReadLine();

            return names;
        }

       public string AskForCoords()
        {
            Console.WriteLine("Введите координаты через зяпятую: ");
            Console.WriteLine("Пример: 0, 1");
            Console.WriteLine();

            Console.Write("Ввод: ");
            string coors = Console.ReadLine();

            return coors;
        }

        public void CallWinner(Player player)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Игрок с иненем {0} одержал победу!", player.Name);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void CallTie()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("В этом раунде ничья!");
            Console.ForegroundColor = ConsoleColor.White;
        }

      
    }
}
