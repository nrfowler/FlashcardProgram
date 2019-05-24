using HelloWorld;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlashcardProgram.RandUtil;
namespace FlashcardProgram
{
    class Arithmetic
    {

      
        public static string OpType(string op)
        {
            if (op == "m")
                return "*";
            else if (op == "d")
                return "/";
            else if (op == "a")
                return "+";
            else if (op == "s")
                return "-";
            else if (op == "p")
                return "%";
            return "";


        }
        //5/3/19: LimitSolver
        //static float LimitSolver(float[] numerator, float[] denominator)
        //{
        //    if (numerator.Contains<int>(0))
        //        throw Exception("Wrong input");
        //    if (denominator.Contains<int>(0))
        //        throw Exception("Wrong input");
        //    if (numerator.Length > denominator.Length)
        //        return float.MaxValue;
        //    else if (numerator.Length <  denominator.Length)
        //        return 0;

        //    return 0;
        //}
        //Arithmetic game
        //totalQns: questions asked per round
        //digits: digits of both operands
        public static void Game(int totalQns, int digits, int minVal)
        {

            
            var quit = false;
            var points = 0;
            string opType = "";

            ArithmeticLoop al = new ArithmeticLoop(PlayRound);
            while (quit == false)
            {
                //Console.WriteLine("1 Decimal, 2 Decimal, or Integers?");
                //string useDecimal = Console.ReadLine();
                Console.WriteLine("Mulitply, Divide, Add,\nSubtract, Squares, Modulus, Percentage\n(m/d/a/s/2/x/p)");
                opType = Console.ReadLine();
                Stopwatch time10kOperations = Stopwatch.StartNew();
                time10kOperations.Start();
                 ScoredRounds(al,points,totalQns, digits, minVal, points, opType, time10kOperations);
                    



                Console.WriteLine("Quit (y/n)?");
                quit = Console.ReadLine() == "y" ? true : false;
            }


            //import phonetic.txt
            //random number and then append to text file
        }

        public static int ScoredRounds(ArithmeticLoop ld, int score, int x, int y, int z, int i, string s, Stopwatch w)
        {
            do
            {
                score += ld(x, y, z, i, s, w);
                Console.WriteLine("Continue?");
                var foo = Console.ReadLine();

                if (foo == "n" || foo == "N")
                    break;
                Console.Clear();
            } while (true);
            return score;
        }


        private static int PlayRound(int totalQns, int digits, int minVal, int points, string opType, Stopwatch time10kOperations)
        {
            for (int i = 0; i < totalQns; i++)
            {
                var firstRandom = intList.RandInt(digits, minVal);
                double pct = 0;
                int secondRandom = 0;
                if (opType == "2")
                    secondRandom = firstRandom;
                else if (opType == "p")
                    pct = ((int)(new double().Rnd() * 100)) / 100.00;
                else
                    secondRandom = intList.RandInt(digits, minVal);

                if (opType == "2")
                    Console.WriteLine("{0}^2 = ", firstRandom);
                else if (opType == "p")
                    Console.WriteLine("{0}% of {1} = ", pct * 100, firstRandom);
                else
                    Console.WriteLine("{0} " + OpType(opType) + "{1} = ", firstRandom, secondRandom);
                var ans = Console.ReadLine();
                double ra = 0;


                if (opType == "m" || opType == "2")
                    ra = firstRandom * secondRandom;
                else if (opType == "p")
                    ra = firstRandom * pct;
                else if (opType == "d")
                    ra = firstRandom / secondRandom;
                else if (opType == "a")
                    ra = firstRandom + secondRandom;
                else if (opType == "s")
                    ra = firstRandom - secondRandom;
                double result;
                if (!double.TryParse(ans, out result))
                    result = 0;
                 //remove repeating digits problem
                if (ra +.01 >= result && ra -.1 <= result)
                {
                    Console.WriteLine("Correct!");
                    points++;
                }
                else
                    Console.WriteLine("Wrong, value is " + ra+ " but you entered "+result);
            }
            time10kOperations.Stop();
            var dat = DateTime.Today.ToShortDateString();
            Console.WriteLine("Time Elapsed was " +time10kOperations.Elapsed.Seconds.ToString()+" seconds \nScore was "+points+"/"+totalQns);
            File.AppendAllText("arithmeticStats", string.Format("\n{0};digits:{1};score:{2}/{3};{4};seconds:{5}", opType,
                digits, points, totalQns, dat, time10kOperations.Elapsed.Seconds.ToString()));
            return points;
        }
    }
}
