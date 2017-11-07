using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2.ClassesFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            Text txt = new Text("E:/text.txt");

            while (true)
            {
                PrintFullText(txt, "ORIGINAL TEXT");
                ChooseTask(txt);
            }
        }

        static void ChooseTask(Text txt)
        {
            Console.Write("Enter number of the task (from 1 to 5): ");
            string task = Console.ReadLine();
            if (task == "1")
                SentencesInAscendingOrder(txt);
            else if (task == "2")
                WordsFromQuestions(txt);
            else if (task == "3")
                RemoveCertainWords(txt);
            else if (task == "4")
                ReplaceWithSubstring(txt);
            else if (task == "5")
                Concordance(txt);
            else
                Console.Clear();
        }

        static void EndOfAction()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrintLine()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        static void PrintFullText(Text txt, string title)
        {
            PrintLine();
            PrintLine();
            Console.WriteLine(title + ": ");
            PrintLine();

            foreach (string line in txt.GetFullText())
            {
                Console.WriteLine(line);
            }

            PrintLine();
            PrintLine();
        }

        static void SentencesInAscendingOrder(Text txt)
        {
            PrintLine();
            PrintLine();
            Console.WriteLine("Task 1. SENTENCES IN ASCENDING ORDER OF THE NUMBER OF WORDS: ");
            PrintLine();

            foreach (var item in txt.SentencesInAscendingForm())
            {
                Console.WriteLine(item.Value + " words:");
                int line_length = 0;
                for (int i = 0; i < item.Key.Words.Count; i++)
                {
                    string word = item.Key.Words[i].GetWords;
                    if (line_length + word.Length > 77)
                    {
                        Console.WriteLine();
                        line_length = 0;
                    }
                    Console.Write(word + " ");
                    line_length += word.Length + 1;
                }
                Console.Write("\n\n");
            }

            PrintLine();
            PrintLine();
            EndOfAction();
        }

        static void WordsFromQuestions(Text txt)
        {
            PrintLine();
            PrintLine();
            Console.WriteLine("Task 2. WORDS OF A CERTAIN LENGTH FROM THE QUESTIONS: ");
            PrintLine();

            int length = 0;
            Console.Write("Enter length: ");
            do
            {
                try
                {
                    length = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("ENTERED VALUE IS INCORRECT. Please try again: ");
                }
            }
            while (true);
            PrintLine();

            List<string> words = txt.WordsFromQuestions(length);

            if (words.Count == 0)
                Console.WriteLine("THERE ARE NO WORDS OF THIS LENGTH");

            foreach (string item in words)
                Console.WriteLine("> {0} ", item);

            PrintLine();
            PrintLine();
            EndOfAction();
        }

        static void RemoveCertainWords(Text txt)
        {
            PrintLine();
            PrintLine();
            Console.WriteLine("Task 3. REMOVING WORDS OF A CERTAIN LENGTH, BEGINING WITH A CONSONANT LETTER: ");
            PrintLine();

            int length = 0;
            Console.Write("Enter length: ");
            do
            {
                try
                {
                    length = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("ENTERED VALUE IS INCORRECT. Please try again: ");
                }
            }
            while (true);

            List<string> deleted_words = txt.RemoveCertainWords(length);

            if (deleted_words.Count == 0)
            {
                PrintLine();
                Console.WriteLine("FAILED TO PERFORM AN OPERATION WITH THE ENTERED DATA");
                PrintLine();
                PrintLine();
            }
            else
            {
                PrintLine();
                PrintLine();
                Console.WriteLine("DELETED WORDS: ");
                foreach (string word in deleted_words)
                    Console.WriteLine("> {0}", word);
                Console.Write("\n");
                PrintFullText(txt, "MODIFIED TEXT");
            }

            EndOfAction();
        }

        static void ReplaceWithSubstring(Text txt)
        {
            PrintLine();
            PrintLine();
            Console.WriteLine("Task 4. REPLACE THE WORDS OF A CERTAIN LENGTH WITH SUBSTRING: ");
            PrintLine();

            int sentence = 0, length = 0;
            Console.Write("Enter number of sentence: ");
            do
            {
                try
                {
                    sentence = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("ENTERED VALUE IS INCORRECT. Please try again: ");
                }
            }
            while (true);
            Console.Write("Enter length of word: ");
            do
            {
                try
                {
                    length = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("ENTERED VALUE IS INCORRECT. Please try again: ");
                }
            }
            while (true);
            Console.Write("Enter substring: ");
            string substring = Console.ReadLine();

            if (!txt.ReplaceWithSubstring(sentence, length, substring))
            {
                PrintLine();
                Console.WriteLine("FAILED TO PERFORM AN OPERATION WITH THE ENTERED DATA");
                PrintLine();
                PrintLine();
            }
            else
                PrintFullText(txt, "MODIFIED TEXT: ");

            EndOfAction();
        }
        static void Concordance(Text txt)
        {
            PrintLine();
            PrintLine();
            Console.WriteLine("Task 5. CONCORDANCE: ");
            PrintLine();

            List<string> lines = txt.GetFullText();
            List<string> words = txt.GetWords();

            char last_letter = '0';

            foreach (string word in words)
            {
                if (word[0] != last_letter)
                {
                    if (word[0] != 'A')
                        Console.Write('\n');
                    Console.WriteLine("                                     [{0}]", word[0]);
                    last_letter = word[0];
                }

                List<int> positions = new List<int>();
                for (int i = 0; i < lines.Count; i++)
                {
                    String[] words_arr = lines[i].ToLower().Split(new char[] { ' ', '.', ',', '?', '!', '(', ')', '\"' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in words_arr)
                    {
                        if (item == word.ToLower())
                            positions.Add(i + 1);
                    }
                }

                Console.Write(word.ToLower() + " ");
                Console.Write('.');
                for (int i = 0; i < 74 - word.Length - positions.Count / 10 - positions.Count * 2 - 1; i++)
                    Console.Write('.');
                Console.Write(" {0} -", positions.Count);
                foreach (int position in positions)
                    Console.Write(" " + (position + 5) / 4);
                Console.Write('\n');
            }

            PrintLine();
            PrintLine();

            EndOfAction();

        }
    }
}
