using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class CellType
    {
        public string Empty { get; private set; }
        public string Zero { get; private set; }
        public string Cross { get; private set; }

        public CellType()
        {
            Empty = " ";
            Zero  = "O";
            Cross = "X";
        }
    }
}
