using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Field
    {
        public string[,] GameField = new string[3, 3];
        private CellType cell = new CellType();

        public Field()
        {
            Console.ForegroundColor = ConsoleColor.White;
            InitilizeField();
        }

        private void InitilizeField()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    GameField[i, j] = cell.Empty;
                }
            }
        }

        private void ShowDependingOnColor(int i, int j)
        {
            if (GameField[i, j] == cell.Zero)
            {
                Console.Write("| ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(GameField[i, j]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" |");
            }

            if (GameField[i, j] == cell.Cross)
            {
                Console.Write("| ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(GameField[i, j]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" |");
            }

            if (GameField[i, j] == cell.Empty)
                Console.Write("| " + GameField[i, j] + " |");

        }

        public void Show()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    ShowDependingOnColor(i, j);
                }

                Console.WriteLine();
            }
        }

        public void Update(int x, int y, string type)
        {
            GameField[x, y] = type;
        }
    }
}
