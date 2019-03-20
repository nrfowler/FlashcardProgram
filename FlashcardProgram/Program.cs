﻿using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using FlashcardProgram.Properties;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "fc")
                FlashCard.FlashCards();
            else if (args[0] == "wm")
                WorkingMemory(int.Parse(args[1]), int.Parse(args[2]), bool.Parse(args[3]));
            //else if (args[0] == "mn")
            //    PhoneticSystem();

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
            int top = RandomInteger(3,20,level);
            int bottom = RandomInteger(3, 20, level);
            Console.WriteLine("Compute: " + top.ToString() + "*" + bottom.ToString() + ": ");
            if (int.Parse(Console.ReadLine()) == top * bottom)
                return true;



            return false;
        }
        

        private static int RandomInteger(int start, int stop, int level)
        {
            return (new Random().Next() + start) % (stop + level);
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
                level=PlayGame(level)+1;
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
