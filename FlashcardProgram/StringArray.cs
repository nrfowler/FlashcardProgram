using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardProgram
{
    public static class StringArray
    {
        public static string Rand(this string[] ob)
        {
            return ob[(new Random().Next()) % (ob.Length)];
        }
    }
}
