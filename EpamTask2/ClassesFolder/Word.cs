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
        Regex vr = new Regex("[.?!)(,:]");
        
        string tmp;


       public string GetWord { get { return tmp; } }

         

       
               

        public Word(string line)
            {
            tmp = line;
            //if (vr.IsMatch(word))
            //    word = vr.Replace(word,"");
            //GetPunctuation = Regex.Replace(word, "[A-z0-9]", "");//non
        }
        }
    } 
