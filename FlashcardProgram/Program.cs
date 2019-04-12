using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using FlashcardProgram.Properties;
using static FlashcardProgram.StringArray;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "fc")
                FlashCard.FlashCards();
            else if (args[0] == "rc")
                ReadingComprehension();
            else if (args[0] == "ph")
                PhoneticDictionary();
            else if (args[0] == "wm")
                WorkingMemory(10, 2, true);//keep constant at this value for accurate stats
            else if (args[0] == "celeb")
                CelebrityMneumonicSystem();
            //WorkingMemory(int.Parse(args[1]), int.Parse(args[2]), bool.Parse(args[3]));
            //else if (args[0] == "mn")
            //    PhoneticSystem();

        }
        //contains a list of 00-99 user created celebrity names for use in a mneumonic system
        private static void CelebrityMneumonicSystem()
        {

            Console.WriteLine("Review old number assoc'ns (r) or make new ones (n)?");
            var input = Console.ReadLine();
            if (input == "r")
            {
                var lines = File.ReadAllLines("celeb.text");
                var cont = true;
                while (cont)
                {

                    string item = (string)lines.Rand();
                    Console.WriteLine(item.Split(new char[] { ';' })[0]);
                    var response = Console.ReadLine();

                    string value = item.Split(new char[] { ';' })[1];
                    if (response == value)
                    {
                        Console.WriteLine("Correct!");

                    }
                    else
                        Console.WriteLine("Wrong-value is " + value);
                    Console.WriteLine("Continue?");
                    var foo = Console.ReadLine();
                    if (foo == "n")
                    {
                        cont = false;
                    }
                    else
                    {
                        cont = true;
                    }
                }
            }
            else if (input == "n")
            {
                var lines = File.ReadAllLines("pd.text");
                var nums = new ArrayList();
                foreach (string line in lines)
                {
                    nums.Add(line.Split(new char[] { ';' })[0]);

                }

                var cont = true;
                while (cont)
                {
                    string randomnum;
                    do
                    {
                        var numarray = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                        //var digits = new string[] { "2", "3", "4", "7" }.Rand();
                        randomnum = numarray.Rand() + numarray.Rand();
                    } while (nums.Contains(randomnum));

                    Console.WriteLine(randomnum + "\n");
                    var word = Console.ReadLine();
                    if (word.Length > 1)
                    {
                        var line = randomnum + ";" + word;
                        File.AppendAllLines("celeb.text", new string[] { line });


                    }

                    Console.WriteLine("Continue?");
                    var foo = Console.ReadLine();
                    if (foo == "n")
                    {
                        cont = false;
                    }
                    else
                    {
                        cont = true;
                    }
                }
            }
            //import phonetic.txt
            //random number and then append to text file
        }

        //A flashcard game for memorizing numners using the Phonetic Mneumonic System
        private static void PhoneticDictionary()
        {
         
            Console.WriteLine("Review old words (r) or make new ones (n)?");
            var input = Console.ReadLine();
            if (input == "r")
            {
                var lines = File.ReadAllLines("pd.text");
                var cont = true;
                while (cont)
                {

                    string item = (string)lines.Rand();
                    Console.WriteLine(item.Split(new char[] { ';' })[0]);
                    var response = Console.ReadLine();

                    string value = item.Split(new char[] { ';' })[1];
                    if (response == value)
                    {
                        Console.WriteLine("Correct!");

                    }
                    else
                        Console.WriteLine("Wrong-value is "+value);
                    Console.WriteLine("Continue?");
                    var foo = Console.ReadLine();
                    if (foo == "n")
                    {
                        cont = false;
                    }
                    else
                    {
                        cont = true;
                    }
                }
            }
            else if (input == "n")
            {
                var lines = File.ReadAllLines("pd.text");
                var nums = new ArrayList();
                foreach (string line in lines) {
                    nums.Add(line.Split(new char[] { ';' })[0]);

                }

                var cont = true;
                while (cont)
                {
                    string randomnum;
                    do
                    {
                        var numarray = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                        var digits = new string[] { "2", "3", "4","7" }.Rand();
                        randomnum = numarray.Rand() + numarray.Rand();
                        switch (digits) {

                            case "3":
                        randomnum = numarray.Rand() + numarray.Rand() + numarray.Rand();
                                break;
                        case "4":
                         randomnum = numarray.Rand() + numarray.Rand() + numarray.Rand() + numarray.Rand();
                                break;
                        case "7":
                            randomnum = numarray.Rand() + numarray.Rand() + numarray.Rand() + "-"+
                                numarray.Rand() + numarray.Rand() + numarray.Rand() + numarray.Rand();
                            break;

                        }




                        

                    } while (nums.Contains(randomnum));

                     Console.WriteLine(randomnum + "\n");
                    var word = Console.ReadLine();
                    if (word.Length > 1)
                    {
                        var line = randomnum + ";" + word;
                        File.AppendAllLines("pd.text", new string[] { line });


                    }

                    Console.WriteLine("Continue?");
                    var foo = Console.ReadLine();
                    if (foo == "n")
                    {
                        cont = false;
                    }
                    else
                    {
                        cont = true;
                    }
                }
            }
            //import phonetic.txt
            //random number and then append to text file
        }

        private static void ReadingComprehension()
        {
            var pronoun = new string[]{ "My" };
            var pronoun2 = new string[] { "your ", "my opponents " };

            var patriot = new string[] { "George Washington's","Donald Trump's","Lincoln's" ,"South","North","Bill O'Reilly's"};
            var subj = new string[]{ "idea", "novel", "essay", "article", "work", "speech", "platform" ,"comment"};
            var verbclause =  new string[]{ "implies","denies","questions","ignores","muses","recommends", "warns"};
            var topic = new string[]{ "federal penitentaries", "politicians", "labor unions","wars abroad", "black people",
                "we","robot factories","blustery nights","Globalists","Colbert writers","Vogue editors","Alex Jones videos","CNN pundits" };
            var verbMoney = new string[] { "spend", "waste","distribute to citizens","give back to taxpayers",
            "socialize"};
            var verbPerson = new string[] {"exploit", "sell off","promote","inhibit","convince","hire","fire","follow","lead",
            "mislead"};
            var adj = new string[] { "too much money", "just the right amount of money", "an unknown amount of money", "too many lives",
            "human resources","soil fertility","precious moments","global warming credits","tax returns"};
            var quan = new string[] { "\n","."};
            var Person = new string[] { "teachers", "lawyers", "politicians", "doctors", "workers","labor unions"};
            //, "medicaid resources", "benefits", "missle launchers", "Universal Basic Income stamps"
            //instead of -- verb adj quan or adj quan
            var prep = new string[] { "However, ", "Instead, " };

            while (true)
            {

                Console.WriteLine(pronoun[RandomInteger(pronoun.Length)] + " " + subj[RandomInteger(subj.Length)] + "\n" + verbclause[RandomInteger(verbclause.Length)] +
                    " that " + topic[RandomInteger(topic.Length)] + "\n" + verbMoney[RandomInteger(verbMoney.Length)] + " " + adj[RandomInteger(adj.Length)] + " \n" +
                    quan[RandomInteger(quan.Length)] + ".\n" +
                    prep[RandomInteger(prep.Length)]
                + pronoun2.Rand()+subj.Rand()+" "+verbclause.Rand()+"\nthat "+topic.Rand()
                +" "+verbPerson.Rand()+" "+Person.Rand()+".\nNot in "+patriot[RandomInteger(patriot.Length)]+ " America!");
                
            Console.Read();
                Console.Clear();
            }
            

        }

        //private static void PhoneticSystem()
        //{
        //    var input = "n";
        //    int level = 2, times = 0;
        //    double average =0;
        //    do
        //    {
        //        level = TestPMS(level) + 1;
        //        GiveAverageScore(level, ref times, ref average);
        //        Console.WriteLine("Play Again ? ");
        //        input = Console.ReadLine();
        //        Console.Clear();

        //    } while (input != "n");
        //}

        private static double GiveAverageScore(int totalscore,  int times)
        {
            double average = totalscore / (double) times;
            Console.WriteLine("Your average is " + average.ToString()+" out of "+ times.ToString()+ " games");
            return average;
        }

        private static bool MentalMath(int level=0)
        {
            //currently just a square of int. will have nxm, and decimals for higher points
            int top = RandomInteger(3,50,level);
            //int bottom = RandomInteger(3, 50, level);
            Console.WriteLine("Compute: " + top.ToString() + "*" + top.ToString() + ": ");
            if (int.Parse(Console.ReadLine()) == top * top)
                return true;



            return false;
        }
        

        private static int RandomInteger(int start, int stop, int level)
        {
            return (new Random().Next() + start) % (stop + level);
        }
        private static int RandomInteger(int level)
        {
            return (new Random().Next()) % (level);
        }

        

        private static void WorkingMemory(int total, int MaxPkgs, bool KeepScore)
        {
            int level = 2, times = 0;
            int totalscore = 0;
            if (KeepScore)
            {
                if ((double)Settings.Default["LastAverage"] >= (double)Settings.Default["PenultimateAverage"] + .5)
                {
                    total = (int)Settings.Default["LastSets"] + 1;
                    Console.WriteLine("You have improved \nso you will have " + total.ToString() + " sets");

                }
                else if ((double)Settings.Default["LastAverage"] >= (double)Settings.Default["PenultimateAverage"] + 1)
                {
                    if ((int)Settings.Default["MS"] != 0)
                        Settings.Default["MS"] = (int)Settings.Default["MS"] - 1000;

                    Console.WriteLine("You have improved by a LOT \n so you will have less time to view numbers");

                }
                else
                {
                    total = (int)Settings.Default["LastSets"] - 1;
                    if (total < 5)
                        total = 5;

                }
            }
            do
            {
                level= PlayGame(level)+1;
                level = level > MaxPkgs ? MaxPkgs : level; //function?
                totalscore += level - 1;

                if (++times != total)
                {
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();

                }
            } while (times != total);
            Console.WriteLine("Game is Over");
            if (KeepScore)
            {

                Settings.Default["PenultimateAverage"] = Settings.Default["LastAverage"];
                Settings.Default["LastAverage"] = GiveAverageScore(totalscore, times);
                Settings.Default["LifetimeAverage"] = (((double)Settings.Default["LifetimeAverage"]
                    * (int)Settings.Default["LifetimeSets"]) + totalscore) /
                    ((int)Settings.Default["LifetimeSets"] + total);
                Settings.Default["LifetimeSets"] = (int)Settings.Default["LifetimeSets"] + total;
                Console.WriteLine("You have played " + Settings.Default["LifetimeSets"] + " times since March 2019");
                Console.WriteLine("Your lifetime average is " + Settings.Default["LifetimeAverage"]);
                Settings.Default["LastSets"] = total;
                Settings.Default.Save();
            }
            Console.ReadKey();
            

        }

        private static int PlayGame(int numPackages)
        {
            int points=0;
            ArrayList PackageIDList;
            CreatePackageList(numPackages, out PackageIDList);
            System.Threading.Thread.Sleep((int)Settings.Default["MS"]);


            Console.Clear();
            if (MentalMath(0))
                points++;
            Console.WriteLine("Enter packages: ");
            foreach (var package in PackageIDList)
            {
                var input = Console.ReadLine();
                //Console.Clear();

                if (input.Length < 4)
                    continue;
                //.WriteLine(int.Parse(input));

                if ((int)package == int.Parse(input))
                    points++;

            }
            Console.Clear();
            Console.WriteLine("You scored " + points.ToString());
            return points;
        }

        private static void CreatePackageList(int numPackages, out ArrayList PackageIDList)
        {
            var r = new Random();
            //var numPackages = 2;// (int)(r.NextDouble() * 10) % 4 + 2;
            int i = 0;
            PackageIDList = new ArrayList(numPackages);
            while (i < numPackages)
            {
                PackageIDList.Add((int)((r.NextDouble() * 10000) % 7999 + 1000));
                Console.WriteLine(PackageIDList[i++]);
                System.Threading.Thread.Sleep((int)Settings.Default["MS"]);

            }
        }

       
    }
}
