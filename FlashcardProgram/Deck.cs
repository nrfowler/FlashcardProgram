using FlashcardProgram;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Deck : ICollection, IEnumerable
    {
        public ArrayList cards = new ArrayList();
        public int index = 0;
        public String Title;
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
            if (index == cards.Count) index = 0;
            yield return cards[index++];
        }
        public static string[] getCardFiles()
        {
            //get names of files in debug folder

           var files = Directory.GetFiles(Directory.GetCurrentDirectory()).Where(F => F.ToLower().EndsWith(".txt")).ToArray<string>();

            for(int i = 0; i <files.Length; i++)
            {
                files[i] = files[i].Replace(Directory.GetCurrentDirectory()+"\\", "");
            }
            return files;
        }

        public static void SaveRandomizedCards(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            Deck deck = new Deck("CSharp");

            using (StreamReader sr = new StreamReader(fs))
            {
                String line;
                int i = 0;
                FlashCard card = new FlashCard();
                while ((line = sr.ReadLine()) != null)
                {
                    if (i++ % 2 == 0)//is even numbered line, meaning it is a question field
                    {
                        //Console.WriteLine(line);
                        card.Question = line;
                    }
                    else
                    {
                        //If reversible, add another reversed card.
                        if (line.Contains("rev;"))
                        {
                            line = line.Remove(0, 4);
                            card.Answer = line;
                            deck.Add(card);
                            var temp = new FlashCard();
                            temp.Question = line;
                            temp.Answer = card.Question;
                            deck.Add(temp);
                            card = new FlashCard();



                        }
                        else
                        {
                            card.Answer = line;
                            deck.Add(card);
                            card = new FlashCard();


                        }
                    }
                }
            }
            deck.cards = deck.cards.Randomize();
            File.WriteAllLines(filename.Replace(".txt", "") + "random.txt", (string[])deck.cards.ToArray(typeof(string)));
        }
        public static Deck GetRandomizedDeck(string filename)
        {
            int method;
            //TODO: AUTOMATE FILENAMES LIST
            ArrayList onelinefiles = new ArrayList{ getCardFiles() };

            method = onelinefiles.Contains(filename.Replace(".txt", "")) ? 1: 0;
            FileStream fs = new FileStream(Directory.GetCurrentDirectory()+"\\"+filename, FileMode.Open);
            Deck deck = new Deck(filename.Replace(".txt",""));

            using (StreamReader sr = new StreamReader(fs))
            {
                ParseFC(deck, sr, method);
            }
            deck.cards = deck.cards.Randomize();
            return deck;
        }
        //Add fc to deck 
        private static void ParseFC(Deck deck, StreamReader sr, int method)
        {
            String line;
            int i = 0;
            FlashCard card = new FlashCard();
            while ((line = sr.ReadLine()) != null)
            {
                if(method ==0) TwoLineFCMethod(deck, ref line, ref i, ref card);
                else if (method==1) OneLineFCMethod(deck, ref line, ref i, ref card);
            }
        }
        private static void OneLineFCMethod(Deck deck, ref string line, ref int i, ref FlashCard card)
        {
            card.Question = line.Split(' ','\t',';')[0];
            card.Answer = line.Split(' ').Length > 1 ? line.Split(' ')[1] : line.Split(' ')[0];
            deck.Add(card);
            card = new FlashCard();

        }

        private static void TwoLineFCMethod(Deck deck, ref string line, ref int i, ref FlashCard card)
        {
            if (i++ % 2 == 0)//is even numbered line, meaning it is a question field
            {
                //Console.WriteLine(line);
                card.Question = line;
            }
            else
            {
                //If reversible, add another reversed card.
                if (line.Contains("rev;"))
                {
                    line = line.Remove(0, 4);
                    card.Answer = line;
                    deck.Add(card);
                    var temp = new FlashCard();
                    temp.Question = line;
                    temp.Answer = card.Question;
                    deck.Add(temp);
                    card = new FlashCard();



                }
                else
                {
                    card.Answer = line;
                    deck.Add(card);
                    card = new FlashCard();


                }
            }
        }

        public void DisplayAllFC()
        {
            Deck deck = this;

            foreach (FlashCard c in deck)
            {
                //Question and answer must contain one word

                Regex rx = new Regex(@"\b([a-zA-Z]+)\b");

                if (rx.IsMatch(c.Question) && rx.IsMatch(c.Answer))
                {
                    Console.WriteLine("\n{0}", c.Question);
                    Console.ReadKey();
                    Console.WriteLine(c.Answer);
                    Console.ReadKey();
                }

            }
        }
        public FlashCard getRandomFC()
        {
            return (FlashCard)cards.Randomize()[0];
        }
        //order: 0 for RND, 1 for FTL, 2 LTF
        public  void Get1FC(PharmacyForm PH, int order)
        {

            FlashCard c = new FlashCard();

            if (order == 0)  c = getRandomFC();
            else c = (FlashCard)cards[index++];
            if (index == cards.Count) index = 0;
            //Question and answer must contain one word

            Regex rx = new Regex(@"\b([a-zA-Z]+)\b");
            //System.Threading.Thread.Sleep(200);
            if (rx.IsMatch(c.Question) && rx.IsMatch(c.Answer))
            {
                PH.questionlabel.Text = c.Question;

                PH.rightAnswer = c.Answer;

            }


        }
    }
}
