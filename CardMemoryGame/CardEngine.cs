using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMemoryGame
{

    class CardEngine
    {
        private int xCards { get; set; }
        private int yCards { get; set; }
        private Difficulty difficulty;

        public CardEngine()
        {

        }

        private enum Difficulty
        {
            EASY = 0,
            MEDIUM = 1,
            HARD = 2
        }
    }
}
