﻿using FlashcardProgram.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    class WorkingMemoryGame
    {
        public static double GiveAverageScore(int totalscore, int times)
        {
            double average = totalscore / (double)times;
            Console.WriteLine("Your average is " + average.ToString() + " out of " + times.ToString() + " games");
            return average;
        }

        public static bool MentalMath(int level = 0)
        {
            //currently just a square of int. will have nxm, and decimals for higher points
            int top = RandomInteger(3, 50, level);
            //int bottom = RandomInteger(3, 50, level);
            Console.WriteLine("Compute: " + top.ToString() + "*" + top.ToString() + ": ");
            if (int.Parse(Console.ReadLine()) == top * top)
                return true;



            return false;
        }


        public static int RandomInteger(int start, int stop, int level)
        {
            return (new Random().Next() + start) % (stop + level);
        }
        public static int RandomInteger(int level)
        {
            return (new Random().Next()) % (level);
        }



        public static void Play(int total, int MaxPkgs, bool KeepScore)
        {
            int level = 2, times = 0;
            int totalscore = 0;
            bool newGame = false;
            do
            {
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
                    level = PlayGame(level) + 1;
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
                Console.WriteLine("New Game (y/n)?");

                if (Console.ReadLine() == "y")
                {
                    newGame = true;
                }
                else
                    newGame = false;

            } while (newGame == true);


        }

        public static int PlayGame(int numPackages)
        {
            int points = 0;
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

        public static void CreatePackageList(int numPackages, out ArrayList PackageIDList)
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