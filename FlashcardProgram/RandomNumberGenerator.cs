﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    public static class RandomNumberGenerator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static string Rand(this object[] ob)
        {
            lock (syncLock)
            { // synchronize
                return (string) ob[(random.Next()) % (ob.Length)];
            } 
        }
        //length: number of digits
        //minVal: minimum value, inclusive
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