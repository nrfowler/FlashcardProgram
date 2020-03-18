using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using FlashcardProgram.Properties;
using static FlashcardProgram.RandUtil;
using System.Diagnostics;
using FlashcardProgram;
using System.Windows.Forms;

namespace HelloWorld
{
    public delegate void LoopDelegate();
    public delegate int ArithmeticLoop(int totalQns,int maxDigits, int minVal, int maxVal, string opType, Stopwatch w);

    class Program
    {
        public static object[] intList = new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            var PH = new PharmacyForm();
            Application.Run(PH);
            //FlashCard.Get1FC(PH);
            if (args.Length==0)
            {
                //MneumonicSystem.Phonetic();
                //TypingGame.TypingGameStart();
                //WorkingMemoryGame.Play(10, 3, true);//keep constant at this value for accurate stats
                //Arithmetic.Game(10, 2, 11, 20);
                
                //Console.WriteLine("Do a plank or prone y");
                //Timer();
                //FlashCard.FlashCards();
                //if scores increase run a rnd porn file

            }
            else if (args[0] == "fc")
                new Deck("").DisplayAllFC();
            else if (args[0] == "tg")
                TypingGame.TypingGameStart();
            else if (args[0] == "ph")
            {
                MneumonicSystem.Phonetic();

            }
            else if (args[0] == "read")
            {
                LoopDelegate ld = new LoopDelegate(OneRandRead);

                InfRounds(ld);

            }
            else if (args[0] == "wm")
                WorkingMemoryGame.Play(10, 2, true);//keep constant at this value for accurate stats
            else if (args[0] == "celeb")
                MneumonicSystem.Celebrity();
            else if (args[0] == "ag")
                Arithmetic.Game(10, 2, 4,20);
            else if (args[0] == "timer")
                Timer();
            else if (args[0] == "test")
                TestP();
            
            


        }
       

        public static void InfRounds(LoopDelegate ld) { 
            do{
        ld();
                Console.WriteLine("Continue?");
                var foo = Console.ReadLine();

                if (foo == "n"||foo=="N")
                    break;
                Console.Clear();
        }while(true);

        }

        
        private static void OneRandRead()
        {
            int foo = intList.RandInt(3, 0);
            WorkingMemoryGame.DisplayJournal();
        }

        private static void TestP()
        {
            //SpeedReading.SpacedReading("C:\\Users\\Nathan\\OneDrive\\prince.txt",0,20);
            

            Console.Read();
        }

        private static void Timer()
        {
            Console.WriteLine();
            Console.WriteLine("Enter what you are timing:");

            string todo = Console.ReadLine();
             Stopwatch time10kOperations = Stopwatch.StartNew();

                Console.WriteLine();

                Console.WriteLine("Press any key to stop");

                Console.ReadLine();

                time10kOperations.Stop();

                Console.WriteLine("Elapsed time: " + time10kOperations.Elapsed);

                File.WriteAllText("timer", todo + ";" + time10kOperations.Elapsed.Seconds.ToString());
            Console.ReadLine();

        }

        

        

        

       


     

       
    }
}
