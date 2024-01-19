using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMemoryGame.Card;

namespace CardMemoryGame.CardGameComponents.Cards
{
    class Card
    {
        private CardState state;

        public Card()
        {
            state = new HiddenState();
        }
    }
}
