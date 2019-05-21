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
    public static class RandUtil
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static object[] intList = new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //public static string GetField(this string a, int i)
        //{
        //    MatchCollection matches = Regex.Matches(a, @";[\w']*;");

        //    var words = from m in matches.Cast<Match>()
        //                where !string.IsNullOrEmpty(m.Value)
        //                select m.Value;

        //    return words.ToList()[i];
        //}
    
        //public static void DuplicateDevour(this string file)
        //{
        //    var lines = File.ReadAllLines(file);
        //    Dictionary<string, int> map = new Dictionary<string, int>();
        //    foreach(string line in lines)
        //    {
        //        var num = line.GetField(0);
        //        if (map[num] == 1)
        //            continue;
        //        else
        //        {
                   
        //            map[line.GetField(0)] = 1;
        //        }
        //    }
        //    foreach(KeyValuePair<string,int> in map)
        //    {
        //            File.WriteLine(line);

        //    }
        //}
        public static ArrayList removeRepeats(this char[] a)
        {
            var foo = new ArrayList(a);
            var bar = new ArrayList();
            if (a.Length == 0)
                return new ArrayList();

            bar.Add(foo[0]);

            for(int i = 1; i < foo.Count; i++)
            {
                if(!foo[i].Equals(foo[i-1]))
                {
                    bar.Add(foo[i]);

                }
            }
            return bar;
        }
        public static Boolean isSimilar(this string a, string b)
        {
            var c = a.ToLower().Replace(" ", "").ToCharArray().removeRepeats();
            var d = b.ToLower().Replace(" ", "").ToCharArray().removeRepeats();
            if((c.Count==0) || (d.Count ==0))
                return false;
            for (int i = 0; i < c.Count; i++)
            {
                if (!c[i].Equals(d[i]))
                    return false;
            }
                return true;

                    }
        public static ArrayList Randomize(this ArrayList al)
        {
            int count = al.Count;
            //10^length-1=greatest possible count
            //length = log10(count+1)
            for (int i =0;i<count/2;i++)
            {
                int r=intList.RandInt((int)Math.Log10(count+1),0);
                var foo = al[i];

                al[i] = al[r];
                al[r] = foo;
            }
            return al;
        }
        public static string Rand(this object[] ob)
        {
            lock (syncLock)
            { // synchronize
                return (string) ob[(random.Next()) % (ob.Length)];
            } 
        }
        //length: number of digits
        //minVal: minimum value, inclusive
        public static double Rnd(this double f)
        {
            double res;
            lock (syncLock)
            { // synchronize
                res=random.NextDouble();
            }
            return res;
        }
        public static int RandInt(this object[] ob, int length, int minVal)
        {
            var finalInt = 0;
            do
            {
                lock (syncLock)
                { // synchronize
                    finalInt += (int)ob[(random.Next()) % (ob.Length)];
                }
                if (length == 1)
                    return finalInt;
                lock (syncLock)
                { // synchronize
                    finalInt += 10 * (int)ob[(random.Next()) % (ob.Length)];
                }
                if (length == 2)
                    return finalInt;
                lock (syncLock)
                { // synchronize
                    finalInt += 100 * (int)ob[(random.Next()) % (ob.Length)];
                }
                if (length == 3)
                    return finalInt;
                lock (syncLock)
                { // synchronize
                    finalInt += 1000 * (int)ob[(random.Next()) % (ob.Length)];
                }
                if (length == 4)
                    return finalInt;

            } while (finalInt < minVal);
            return finalInt;


        }
    }
}
