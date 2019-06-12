using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using FlashcardProgram.Properties;
using static FlashcardProgram.RandUtil;
using System.Diagnostics;
using FlashcardProgram;

namespace HelloWorld
{
    public delegate void LoopDelegate();
    public delegate int ArithmeticLoop(int x, int y, int z, int  i, string s, Stopwatch w);

    class Program
    {
        public static object[] intList = new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            if(args.Length==0)
            {
                
                    int foo = intList.RandInt(3, 0);
                    SpeedReading.SpacedReading("C:\\Users\\Nathan\\OneDrive\\data\\Dropbox\\journal\\rlzn.txt", foo, foo +5);
                    MneumonicSystem.Phonetic();
                    WorkingMemoryGame.Play(10, 2, true);//keep constant at this value for accurate stats
                    //MneumonicSystem.Celebrity();
                    Arithmetic.Game(10, 2, 20);
                    Console.WriteLine("Do an exercise offline");
                    Timer();
                
            }
            else if (args[0] == "fc")
                FlashCard.FlashCards();
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
                Arithmetic.Game(10, 2, 20);
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
            SpeedReading.RandRead("C:\\Users\\Nathan\\OneDrive\\data\\Dropbox\\journal\\rlzn.txt", foo, foo + 5);
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
