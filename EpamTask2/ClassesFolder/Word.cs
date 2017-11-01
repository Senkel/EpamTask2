using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2
{
    class Word
    {
        string word;

        public string GetWord { get { return word; } }

        public Word(string line)
        {
            word = line;
        }
    }
}
