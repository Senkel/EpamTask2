using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2.ClassesFolder
{
    class Text
    {
        List<Paragraph> paragraphs = new List<Paragraph>();
        public List<Paragraph> Paragraphs { get { return paragraphs; } }

        public Text(string file_name)
        {
            StreamReader reader = new StreamReader(file_name);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Paragraph tmp = new Paragraph(line);
                    paragraphs.Add(tmp);
                    line = reader.ReadLine();
                }
            }
        }

        public List<string> GetFullText()
        {
            
            List<string> lines = new List<string>();
            string line = "";
           
            for (int i = 0; i < paragraphs.Count; i++)
            {
                for (int j = 0; j < paragraphs[i].Sentences.Count; j++)
                {
                    for (int k = 0; k < paragraphs[i].Sentences[j].Words.Count; k++)
                    {
                        string word = paragraphs[i].Sentences[j].Words[k].GetWords;

                        if (line.Length + word.Length > 77)
                        {
                            lines.Add(line);
                            line = "";
                        }

                        line += word + " ";
                    }
                }
                if (line.Length != 0)
                {
                    lines.Add(line);
                    line = "";
                }
                if (lines[lines.Count - 1] != "")
                    lines.Add("");
            }

            return lines;
        }

        public Dictionary<Sentence,int> SentencesInAscendingForm()
        {
            Dictionary<Sentence, int> sentences = new Dictionary<Sentence, int>();

            for (int i = 0; i < paragraphs.Count; i++)
            {
                for (int j = 0; j < paragraphs[i].Sentences.Count; j++)
                {
                    sentences.Add(paragraphs[i].Sentences[j], paragraphs[i].Sentences[j].Words.Count);
                }
            }

            return sentences.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key,pair=>pair.Value);
        }

        public List<string> WordsFromQuestions(int length)
        {
            List<string> words = new List<string>();

            for (int i = 0; i < paragraphs.Count; i++)
            {
                for (int j = 0; j < paragraphs[i].Sentences.Count; j++)
                {
                    if (paragraphs[i].Sentences[j].GetSentence.Contains('?'))
                    {
                        for (int k = 0; k < paragraphs[i].Sentences[j].Words.Count; k++)
                        {
                            string tmp = paragraphs[i].Sentences[j].Words[k].GetWord;
                            
                            if (tmp.Length == length && !words.Contains(tmp) && tmp != "-")
                                words.Add(tmp);
                        }
                    }
                }
            }

            return words;
        }

        public List<string> RemoveCertainWords(int length)
        {
            List<string> words = new List<string>();

            for (int i = 0; i < paragraphs.Count; i++)
            {
                for (int j = 0; j < paragraphs[i].Sentences.Count; j++)
                {
                    for (int k = 0; k < paragraphs[i].Sentences[j].Words.Count; k++)
                    {
                        string tmp = paragraphs[i].Sentences[j].Words[k].GetWord;
                        
                        string consonant_letters = "BbCcDdFfGgHhJjKkLlMmNnPpQqRrSsTtVvWwXxZz";
                        if (consonant_letters.Contains(tmp[0]) && tmp.Length == length && tmp != "-")
                        {
                            words.Add(tmp);
                            paragraphs[i].RemoveWord(paragraphs[i].Sentences[j].Words[k], tmp, j);
                        }
                    }
                }
            }

            return words;
        }

        public bool ReplaceWithSubstring(int sentence, int length, string substring)
        {
            int count = 0;
            bool replaced = false;
            for (int i = 0; i < paragraphs.Count; i++)
            {
                for (int j = 0; j < paragraphs[i].Sentences.Count; j++)
                {
                    count++;
                    if (count == sentence)
                    {
                        for (int k = 0; k < paragraphs[i].Sentences[j].Words.Count; k++)
                        {
                            if (paragraphs[i].Sentences[j].Words[k].GetWord.Length == length)
                            {
                                paragraphs[i].Sentences[j].ReplaceWord(substring, paragraphs[i].Sentences[j].Words[k].GetWords);
                                replaced = true;
                            }
                        }
                    }
                }
            }

            if (replaced)
                return true;
            else
                return false;
        }

        

        
        
    }
}
