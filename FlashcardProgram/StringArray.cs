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

        public static string Rand(this string[] ob)
        {
            lock (syncLock)
            { // synchronize
                return ob[(random.Next()) % (ob.Length)];
            }
        }
    }
}
