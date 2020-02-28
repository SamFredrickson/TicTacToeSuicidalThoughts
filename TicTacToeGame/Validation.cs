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
                var busy_field = from error in Errors
                                 where error == "Координата X не должна быть меньше нуля"
                                 select error;

                if (!busy_field.Any())
                    Errors.Add("Координата X не должна быть меньше нуля");

                flag = false;
            }
            if (yCoor < 0)
            {
                var busy_field = from error in Errors
                                 where error == "Координата Y не должна быть меньше нуля"
                                 select error;

                if (!busy_field.Any())
                    Errors.Add("Координата Y не должна быть меньше нуля");

                flag = false;
            }

            if (xCoor > 2)
            {
                var busy_field = from error in Errors
                                 where error == "Координата X не должна быть больше двух"
                                 select error;

                if (!busy_field.Any())
                    Errors.Add("Координата X не должна быть больше двух");

                flag = false;
            }
            if (yCoor > 2)
            {
                var busy_field = from error in Errors
                                 where error == "Координата Y не должна быть больше двух"
                                 select error;

                if (!busy_field.Any())
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

                var busy_field = from error in Errors
                                 where error == "Поле занято!"
                                 select error;

                if (!busy_field.Any())
                       Errors.Add("Поле занято!");


                flag = false;
            }

            return flag;
        }
    }
}
