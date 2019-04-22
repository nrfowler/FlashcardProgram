using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    public static class RandUtil
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static object[] intList = new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

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
