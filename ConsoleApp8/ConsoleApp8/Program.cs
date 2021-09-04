using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"input.txt";
            string line;
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    ParseLine(line); 
                }
            }
            
            var items = from pair in Words
                        orderby pair.Value descending
                        select pair;


            int n = 0;
            using (var dest = File.AppendText("output.txt"))
            {
                foreach (KeyValuePair<string, int> pair in items)
                {
                    dest.WriteLine(string.Format("{0}: {1}", pair.Key, pair.Value));
                    n++;
                    if (n < 50)
                    {
                        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                    }
                }
            }
            Console.ReadLine();
        }

        static Dictionary<string, int> Words = new Dictionary<string, int>();
        static void ParseLine(string s)
        {
            string word = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    word += s[i];
                }
                else
                {
                    word = word.ToLower();
                    if (Words.ContainsKey(word))
                    {
                        Words[word]++;
                    }
                    else
                    {
                        if (word.Length > 2)
                        {
                            Words.Add(word, 1);
                        }
                    }
                    word = "";
                }
            }
        }
    }
}

