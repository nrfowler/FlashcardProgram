using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Deck: ICollection
    {
        public ArrayList cards = new ArrayList();
        String Title;
        public Deck(string Title)
        {
            this.Title = Title;
        }

        public int Count => cards.Count;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void Add(FlashCard c)
        {
            cards.Add(c);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
