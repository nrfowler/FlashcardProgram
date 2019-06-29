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
            if (op == "m" || op=="sm")
                return "*";
            else if (op == "d")
                return "/";
            else if (op == "a" || op=="sa")
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
        public static void Game(int totalQns, int maxDigits, int minVal, int maxVal)
        {

            
            var quit = false;
            var score = 0;
            string opType = "";

            ArithmeticLoop al = new ArithmeticLoop(PlayRound);
            while (quit == false)
            {
                //Console.WriteLine("1 Decimal, 2 Decimal, or Integers?");
                //string useDecimal = Console.ReadLine();
                Console.WriteLine("Mulitply, Divide, Add\nSerial Add'n, Serial Multiplication\n" +
                    "Subtract, Squares(2), Modulus\nFactor, Percentage\nLog, Power(pow)");
                opType = Console.ReadLine();
                Stopwatch time10kOperations = Stopwatch.StartNew();
                 ScoredRounds(al,totalQns, maxDigits, minVal, maxVal,opType, time10kOperations);
                time10kOperations.Reset();



                Console.WriteLine("Continue (y/n)?");
                quit = Console.ReadLine() == "y" ? false : true;
            }


            //import phonetic.txt
            //random number and then append to text file
        }

        public static void ScoredRounds(ArithmeticLoop ld, int totalQns, int maxDigits, int minVal, int maxVal,string opType, Stopwatch w)
        {
            do
            {
                ld(totalQns, maxDigits, minVal, maxVal, opType, w);
                Console.WriteLine("Continue?");
                var foo = Console.ReadLine();

                if (foo == "n" || foo == "N")
                    break;
                Console.Clear();
            } while (true);
            
        }

        //FEATURE REQUEST: MAX VALUE
        private static int PlayRound(int totalQns, int maxDigits, int minVal, int maxVal, string opType, Stopwatch time10kOperations)
        {
            int points = 0;
            for (int i = 0; i < totalQns; i++)
            {
                if(opType=="f")
                    minVal=40;
                int firstRandom=0, secondRandom=0;
                double pct = 0;
                int product, sum;
                double ra = 0;
                int _base = 1;
                int power = 0;
                double result=0;
                if (opType == "sa" || opType == "sm")
                {
                    int[] operands = new int[5];//randomize length
                    product = 1;
                    sum = 0;
                    for(int it=0;it<5; it++)
                    {
                        operands[it]= opType=="sa"? intList.RandInt(maxDigits, minVal): intList.RandInt(1, 1);
                        string OS = it==0? " " : OpType(opType);
                        Console.WriteLine("{0}{1,2}",OS, operands[it]);
                        product *= operands[it];
                        sum += operands[it];
                    }
                    Console.WriteLine("---");
                    if (opType == "sa")
                        ra = sum;
                    else
                        ra = product;
                }
                else
                {
                    
                     firstRandom = intList.RandInt(maxDigits, minVal,maxVal);
                     pct = 0;
                     secondRandom = 0;
                    if (opType == "2")
                        secondRandom = firstRandom;
                    else if (opType == "p")
                        pct = ((int)(new double().Rnd() * 100)) / 100.00;
                    else if (opType == "pow")
                    {
                         _base= intList.RandInt(1, 1,5);
                         power = intList.RandInt(1, 3,5);

                    }
                    else
                        secondRandom = intList.RandInt(maxDigits, minVal,firstRandom-1);//ensure subtraction yields no negatives

                    if (opType == "2")
                        Console.WriteLine("{0}^2 = ", firstRandom);
                    else if (opType == "p")
                        Console.WriteLine("{0}% of {1} = ", pct * 100, firstRandom);
                    else if (opType == "pow")
                        Console.WriteLine("{0}^{1} = ", _base,power);
                    else if (opType == "f")
                        Console.WriteLine("Factor {0} ", firstRandom);
                    else if (opType == "log")
                        Console.WriteLine("Log {0} Base {1}", firstRandom);
                    else
                        Console.WriteLine("{0} " + OpType(opType) + " {1} = ", firstRandom, secondRandom);
                }
                var ans = Console.ReadLine();
                

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
                else if (opType == "pow")
                    ra = Math.Pow(_base,power);
                else if (opType == "log")
                    ra = Math.Log(firstRandom);
                else if (opType == "f")
                {
                    ra = firstRandom;
                    int[] numbers = Array.ConvertAll(ans.Split(' '), int.Parse);
                     product = 1;
                    foreach (int number in numbers)
                    {
                        for (int a = 2; a <= number / 2; a++)
                                                                        {
                            if (number % a == 0)
                            {
                                product = 0;//number is not prime, therefore wrong answer
                            }

                        }
                        product *= number;
                    }
                    result = product;
                }
                if (opType != "f" && !double.TryParse(ans, out result))
                    result = 0;
                //remove repeating digits problem
                Console.Clear();
                if (ra +.01 >= result && ra -.1 <= result)
                {
                    Console.WriteLine("Correct!\n");
                    points++;
                }
                else
                    Console.WriteLine("Wrong, value is " + ra+ " but you entered "+result);
                
            }
            time10kOperations.Stop();
            var dat = DateTime.Today.ToShortDateString();
            Console.WriteLine("Time Elapsed was " +time10kOperations.Elapsed.Seconds.ToString()+" seconds \nScore was "+points+"/"+totalQns);
            File.AppendAllText("arithmeticStats", string.Format("\n{0};digits:{1};score:{2}/{3};{4};seconds:{5};minmax:{6}-{7}", opType,
                maxDigits, points, totalQns, dat, time10kOperations.Elapsed.Seconds.ToString(),minVal, maxVal));
            return points;
        }
    }
}
