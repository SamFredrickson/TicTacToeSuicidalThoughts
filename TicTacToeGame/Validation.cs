using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Validation
    {
        private Int32 xCoor { get; set; }
        private Int32 yCoor { get; set; }
        private Field Fieldishe { get; set; }
        public List<string> Errors = new List<string>();
        private CellType celltype = new CellType();

        public Validation(int x, int y, Field field)
        {
            xCoor = x;
            yCoor = y;
            Fieldishe = field;
        }

        public bool Validate()
        {
            bool flag = true;

            if (!ValidateCoors())
            {
                flag = false;
            }
            else
            {
                if (!ValidateBusyness())
                    flag = false;
            }


            return flag;
              
        }

        private bool ValidateCoors()
        {
            bool flag = true;

            if (xCoor < 0)
            {
                Errors.Add("Координата X не должна быть меньше нуля");
                flag = false;
            }
            if (yCoor < 0)
            {
                Errors.Add("Координата Y не должна быть меньше нуля");
                flag = false;
            }

            if (xCoor > 2)
            {
                Errors.Add("Координата X не должна быть больше двух");
                flag = false;
            }
            if (yCoor > 2)
            {
                Errors.Add("Координата Y не должна быть больше двух");
                flag = false;
            }

            return flag;
        }

        private bool ValidateBusyness()
        {
            bool flag = true;

            if(Fieldishe.GameField[xCoor, yCoor] != celltype.Empty)
            {
                Errors.Add("ТЫ ШТО САМЫЙ УМНЫЙ???? ИГРАЙ А НЕ ПЫТАЙСЯ СЛОМАТЬ ЧТО НИБУДЬ!1111");
                flag = false;
            }

            return flag;
        }
    }
}
