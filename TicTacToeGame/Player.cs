using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Player
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Player(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public void Step(Field field, int x, int y, string type)
        {
           field.Update(x, y, type);
        }
    }
}
