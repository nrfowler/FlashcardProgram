using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    class FlashCard
    {
        public String Question { get; set;}
        public String Answer { get; set;}
        public static void FlashCards()
        {
            Console.WriteLine("Hello World!");
            FileStream fs = new FileStream("data.txt", FileMode.Open);
            Deck deck = new Deck("CSharp");

            using (StreamReader sr = new StreamReader(fs))
            {
                String line;
                int i = 0;
                FlashCard card = new FlashCard();
                while ((line = sr.ReadLine()) != null)
                {
                    if (i++ % 2 == 0)
                    {
                        //Console.WriteLine(line);
                        card.Question = line;
                    }
                    else
                    {
                        card.Answer = line;
                        deck.Add(card);
                        card = new FlashCard();
                    }
                }
            }
            foreach (FlashCard c in deck.cards)
            {
                //Question and answer must contain one word
                Regex rx = new Regex(@"\b([a-zA-Z]+)\b");

                if (rx.IsMatch(c.Question) && rx.IsMatch(c.Answer))
                {
                    Console.WriteLine("\nQuestion: {0}", c.Question);
                    Console.ReadKey();
                    Console.WriteLine(c.Answer);
                    Console.ReadKey();
                }

            }
        }

    }
}
