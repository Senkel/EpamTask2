using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask2.ClassesFolder;

namespace EpamTask2.ClassesFolder
{
    class Paragraph
    {
        string paragraph;
        
        List<Sentence> sentences = new List<Sentence>();

        public List<Sentence> Sentences { get { return sentences; } }

        public Paragraph(string line)
        {
            paragraph = line;

            int i = 0;
            
            bool quotes = false;
            foreach (char symbol in line)
            {
                if (line[i] == '\"')
                    quotes = !quotes;
                if (symbol == '.' || symbol == '?' || symbol == '!')
                {
                    if (!quotes)
                    {
                        Sentence tmp = new Sentence(line.Substring(0, i+1).Trim());
                        sentences.Add(tmp);
                        line = line.Substring(i + 1);
                        i=-1;
                    }
                }
                i++;
            }
        }


        public void RemoveWord(Word word, string word_str, int j)
        {
            paragraph = paragraph.Replace(" " + word_str, "");
            sentences[j].RemoveWord(word, word_str);
        }

    }
}
