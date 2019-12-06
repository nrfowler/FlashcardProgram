﻿using HelloWorld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    class TypingGame
    {
        public static void TypingGameStart()
        {
            Console.WriteLine("Type without errors: ");
            FileStream fs = new FileStream("dotnet.txt", FileMode.Open);
            Deck deck = new Deck("CSharp");

            using (StreamReader sr = new StreamReader(fs))
            {
                String line;
                int i = 0;
                FlashCard card = new FlashCard();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Count() > 4)//is valid line
                    {
                        //Console.WriteLine(line);
                        card = new FlashCard();
                        card.Question = line;
                        deck.Add(card);
                    }

                }
            }
            deck.cards = deck.cards.Randomize();
            var points = 0;
            foreach (FlashCard c in deck.cards)
            {
                //Question must contain one word

                Regex rx = new Regex(@"\b([a-zA-Z]+)\b");

                if (rx.IsMatch(c.Question))
                {
                    var taa = "";
                    var i = 0;
                    while ( ! taa.Equals(c.Question.Trim()) && i < 3)
                    {
                        Console.WriteLine("\n{0}", c.Question);
                        taa = Console.ReadLine();
                        if (i == 0) {
                            points++;
                            Console.WriteLine("\n{0}",points);
                            i++;
                        }
                        else
                            i++;
                    }
                }

            }
        }

    }
}

