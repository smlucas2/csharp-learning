using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMemoryGame.Card
{
    class Card
    {
        private CardState state;

        public Card() 
        {
            this.state = new HiddenState();
        }
    }
}
