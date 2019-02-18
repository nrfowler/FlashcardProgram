using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Deck
    {
        public ArrayList cards = new ArrayList();
        String Title;
        public Deck(string Title)
        {
            this.Title = Title;
        }
        public void Add(FlashCard c)
        {
            cards.Add(c);
        }
    }
}
