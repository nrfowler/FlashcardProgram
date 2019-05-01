using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    class SpeedReading
    {
        public List<string> RemoveVowels(List<string> words)
        {
            return new List<string>();
        }

        public static void SpacedReading(string file,int start, int end)
        {
            var f =  File.ReadAllLines(file);
            var words = new List<string>();
            int i;
            for( i=start;i<end;i++)
                words.AddRange(GetWords(f[i]));

            
            //td: go to end of the line (end)
             i = 0;
            foreach(string word in words)
            {
                if (i == 2)
                {
                    i = 0;
                    Console.WriteLine("{0,20}", word);
                }
                else if (i == 1)
                {
                    i++;
                    Console.Write("{0,20}",word);

                }
                else
                {
                    i++;
                    Console.Write("{0,20}",word);
                }

            }
        }

        static List<String> GetWords(string input)
        {
            {
                MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");



                var words = from m in matches.Cast<Match>()

                            where !string.IsNullOrEmpty(m.Value)

                            select m.Value;



                return words.ToList();

            }
        }

        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }
    }
}
