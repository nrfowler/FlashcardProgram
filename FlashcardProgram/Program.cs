using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "fc")
                FlashCards();
            else if (args[0] == "wm")
                WorkingMemory();

        }

        private static void WorkingMemory()
        {
            var input="n";
            int level = 2;
            do
            {
                level=PlayGame(level)+1;
                Console.WriteLine("Play Again ? ");
                input = Console.ReadLine();
                Console.Clear();
            } while (input != "n");
            

        }

        private static int PlayGame(int numPackages)
        {
            var r = new Random();
            //var numPackages = 2;// (int)(r.NextDouble() * 10) % 4 + 2;
            int i = 0, points = 0;
            var PackageIDList = new ArrayList(numPackages);
            while (i < numPackages)
            {
                PackageIDList.Add((int)((r.NextDouble() * 10000) % 7999+1000));
                Console.WriteLine(PackageIDList[i++]);
            }
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Enter packages: ");
            foreach (var package in PackageIDList)
            {
                var input = Console.ReadLine();
                Console.Clear();

                if (input.Length < 4)
                    continue;
                //.WriteLine(int.Parse(input));
                
                if ((int)package == int.Parse(input))
                    points++;

            }
            Console.Clear();
            Console.WriteLine("You scored " + points.ToString());
            Console.ReadLine();
            return points;
        }

        private static void FlashCards()
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
