using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpamTask2.ClassesFolder
{
    class Word
    {
        string tmp;

        public string GetWords { get { return tmp; } }

        public string GetWord
        {
            get
            {
                tmp = Regex.Replace(tmp,"[\")(.,:;!?]","");
                
                return tmp;
            }
        }

        public Word(string line)
        {
            tmp = line;
        }
    }
}
