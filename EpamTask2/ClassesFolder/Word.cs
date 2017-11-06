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
                //if (tmp.Contains('\"'))
                //    tmp = tmp.Replace("\"", "");
                //if (tmp.Contains('('))
                //    tmp = tmp.Replace("(", "");
                //if (tmp.Contains(')'))
                //    tmp = tmp.Replace(")", "");
                //if (tmp.Contains('.') || tmp.Contains(',') || tmp.Contains(':') || tmp.Contains(';') || tmp.Contains('?') || tmp.Contains('!'))
                //    tmp = tmp.Substring(0, tmp.Length - 1);
                return tmp;
            }
        }

        public Word(string line)
        {
            tmp = line;
        }
    }
}
