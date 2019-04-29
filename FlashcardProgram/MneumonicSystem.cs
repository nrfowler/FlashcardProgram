using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    class MneumonicSystem
    {

        //A flashcard game for memorizing numners using the Phonetic Mneumonic System
        public static void Phonetic()
        {

            var quit = false;
            while (quit == false)
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
                            var digits = new string[] { "2", "3" }.Rand();
                            randomnum = numarray.Rand() + numarray.Rand();
                            switch (digits)
                            {

                                case "3":
                                    randomnum = numarray.Rand() + numarray.Rand() + numarray.Rand();
                                    break;
                                case "4":
                                    randomnum = numarray.Rand() + numarray.Rand() + numarray.Rand() + numarray.Rand();
                                    break;
                                case "7":
                                    randomnum = numarray.Rand() + numarray.Rand() + numarray.Rand() + "-" +
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
                else
                {
                    quit = true;
                }
            }
            //import phonetic.txt
            //random number and then append to text file
        }
        //contains a list of 00-99 user created celebrity names for use in a mneumonic system
        public static void Celebrity()
        {
            var quit = false;
            while (quit == false)
            {
                Console.WriteLine("Review old number assoc'ns (r) \nor make new ones (n)\nor quit(q)?");
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
                        if (response.isSimilar(value))
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
                    var lines = File.ReadAllLines("celeb.text");
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
                else
                {
                    quit = true;
                }
            }
            //import phonetic.txt
            //random number and then append to text file
        }
    }
}
