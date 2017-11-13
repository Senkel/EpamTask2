using System;
using System.Collections.Generic;

namespace EpamTask2.ClassesFolder
{
    internal class Sentence
    {
        string sentence;

        public string GetSentence { get { return sentence; } }

        List<Word> words = new List<Word>();
            
        public List<Word> Words { get { return words; } }

        public Sentence(string line)
        {
            sentence = line;

            String[] words_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in words_arr)
            {
                Word tmp = new Word(item);
                words.Add(tmp);
            } 
        }
        public void RemoveWord(Word word, string word_str)
        {
            sentence = sentence.Replace(" " + word_str, "");
            words.Clear();
            String[] words_arr = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in words_arr)
            {
                Word tmp = new Word(item);
                words.Add(tmp);
            }
        }
        public void ReplaceWord( string word, string substring)
        {
            sentence = sentence.Replace(word, substring);
            words.Clear();
            String[] words_arr = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in words_arr)
            {
                Word tmp = new Word(item);
                words.Add(tmp);
            }
        }
    }
}
