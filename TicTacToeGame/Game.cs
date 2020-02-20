using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Game
    {
        private CellType celltype = new CellType();
        private DialogManager dialog = new DialogManager();
        private Field field = new Field();
        private Validation validation;
        private Player pl1;
        private Player pl2;
        private string[] names;
        private string[] coors;
        private bool isterm = false;
        private bool isWon = false;
        private bool isTie = false;


        public Game()
        {
           
        }

        public void Start()
        {
            dialog.ShowHi();
            InitilizePlayers();
            Console.Clear();
            dialog.ShowHi();
            field.Show();
            PlayerGoes();
        }

        private void PutCoors(Player player)
        {
            coors = dialog.AskForCoors(player).Split(',');
            validation = new Validation(Int32.Parse(coors[0].Trim()), Int32.Parse(coors[1].Trim()), field);

            if (validation.Validate())
            {
                player.Step(field, Int32.Parse(coors[0].Trim()),
                Int32.Parse(coors[1].Trim()), player.Type);

                Console.Clear();
                dialog.ShowHi();
                field.Show();
            }
            else
            {
                Console.Clear();
                dialog.ShowHi();
                field.Show();
                Console.WriteLine();

                foreach (var error in validation.Errors)
                    Console.WriteLine(error);

                validation.Errors.Clear();

                Console.ReadKey();

                Console.Clear();
                dialog.ShowHi();
                field.Show();
                PlayerGoes();
            }
        }


        private bool CheckIsZeroWinner()
        {
            bool flag = false;

            // X_Checking

            if ((field.GameField[0, 0] == celltype.Zero) && (field.GameField[0, 1] == celltype.Zero) && (field.GameField[0, 2] == celltype.Zero))
                flag = true;

            if ((field.GameField[1, 0] == celltype.Zero) && (field.GameField[1, 1] == celltype.Zero) && (field.GameField[1, 2] == celltype.Zero))
                flag = true;

            if ((field.GameField[2, 0] == celltype.Zero) && (field.GameField[2, 1] == celltype.Zero) && (field.GameField[2, 0] == celltype.Zero))
                flag = true;

            // Y_Checking

            if ((field.GameField[0, 0] == celltype.Zero) && (field.GameField[1, 0] == celltype.Zero) && (field.GameField[2, 0] == celltype.Zero))
                flag = true;

            if ((field.GameField[0, 1] == celltype.Zero) && (field.GameField[1, 1] == celltype.Zero) && (field.GameField[2, 1] == celltype.Zero))
                flag = true;

            if ((field.GameField[0, 2] == celltype.Zero) && (field.GameField[1, 2] == celltype.Zero) && (field.GameField[2, 2] == celltype.Zero))
                flag = true;

            // XY_Checking

            if ((field.GameField[0, 0] == celltype.Zero) && (field.GameField[1, 1] == celltype.Zero) && (field.GameField[2, 2] == celltype.Zero))
                flag = true;

            if ((field.GameField[0, 2] == celltype.Zero) && (field.GameField[1, 1] == celltype.Zero) && (field.GameField[2, 0] == celltype.Zero))
                flag = true;

            return flag;
        }

        private bool CheckIsCrossWinner()
        {
            bool flag = false;

            // X_Checking

            if ((field.GameField[0, 0] == celltype.Cross) && (field.GameField[0, 1] == celltype.Cross) && (field.GameField[0, 2] == celltype.Cross))
                flag = true;

            if ((field.GameField[1, 0] == celltype.Cross) && (field.GameField[1, 1] == celltype.Cross) && (field.GameField[1, 2] == celltype.Cross))
                flag = true;

            if ((field.GameField[2, 0] == celltype.Cross) && (field.GameField[2, 1] == celltype.Cross) && (field.GameField[2, 0] == celltype.Cross))
                flag = true;

            // Y_Checking

            if ((field.GameField[0, 0] == celltype.Cross) && (field.GameField[1, 0] == celltype.Cross) && (field.GameField[2, 0] == celltype.Cross))
                flag = true;

            if ((field.GameField[0, 1] == celltype.Cross) && (field.GameField[1, 1] == celltype.Cross) && (field.GameField[2, 1] == celltype.Cross))
                flag = true;

            if ((field.GameField[0, 2] == celltype.Cross) && (field.GameField[1, 2] == celltype.Cross) && (field.GameField[2, 2] == celltype.Cross))
                flag = true;

            // XY_Checking

            if ((field.GameField[0, 0] == celltype.Cross) && (field.GameField[1, 1] == celltype.Cross) && (field.GameField[2, 2] == celltype.Cross))
                flag = true;

            if ((field.GameField[0, 2] == celltype.Cross) && (field.GameField[1, 1] == celltype.Cross) && (field.GameField[2, 0] == celltype.Cross))
                flag = true;

            return flag;
        }

        private bool CheckIsTieHappend()
        {
            bool flag = true;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(field.GameField[i,j] == celltype.Empty)
                    {
                        flag = false;
                        break;
                    }
                }
            }

            return flag;
        }

        private void CheckWinner()
        {
            if (CheckIsZeroWinner())
            {
                isWon = true;
                dialog.CallWinner(pl1);
                Console.ReadKey();
            }

            if (CheckIsCrossWinner())
            {
                isWon = true;

                if (pl2.Type == celltype.Cross)
                {
                    dialog.CallWinner(pl2);
                    Console.ReadKey();
                }
            }

            if (CheckIsTieHappend())
            {
                if (isWon == false)
                {
                    isTie = true;
                    dialog.CallTie();
                    Console.ReadKey();
                }
            }

        }
        private void PlayerGoes()
        {
            while (!isWon && !isTie) {

                if (isterm)
                {
                    PutCoors(pl1);
                    isterm = false;
                }
                else
                {
                    PutCoors(pl2);
                    isterm = true;
                }

                CheckWinner();
            }
        }

        private void InitilizePlayers()
        {
            names = dialog.AskForUserName().Split(',');
            pl1 = new Player(names[0].Trim(), celltype.Zero);
            pl2 = new Player(names[1].Trim(), celltype.Cross);
        }
    }
}
