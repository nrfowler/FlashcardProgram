using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    public static class StringArray
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
        public static int RandInt(this object[] ob)
        {
            lock (syncLock)
            { // synchronize
                return (int)ob[(random.Next()) % (ob.Length)];
            }
        }
    }
}
