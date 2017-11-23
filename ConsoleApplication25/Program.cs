using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication25
{
    class Program
    {
        static List<string> dict = new List<string>();
        static int dictsize = 0;
        static List<int> tokens = new List<int>();

        static void Main(string[] args)
        {
            int charactersize = 0;
            int p = 0;
            StreamReader sr = new StreamReader("D:\\Language Translator.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                charactersize += line.Length;

                string[] words = line.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    p = dict.IndexOf(words[i]);
                    if (p == -1)
                    {
                        dict.Add(words[i]);
                        p = dict.Count - 1;
                        dictsize += words[i].Length ;
                    }
                    tokens.Add(p);
                }
            }

            sr.Close();
            ReadTokens(tokens, dict);
            Console.WriteLine("\nNumber of bytes in original file: " + charactersize);
            Console.WriteLine("Number of dictionary entries: " + dict.Count);
            Console.WriteLine("Number of bytes in dictionary file: " + dictsize);
            Console.WriteLine("Number of bytes in token based file: " + tokens.Count);
            Console.WriteLine("Number of bytes saved is: " + (charactersize - dictsize - tokens.Count).ToString());
            Console.ReadLine();
        }

        private static void ReadTokens(List<int> tokens, List<string> dict)
        {
            for (int i = 0; i < tokens.Count; i++)
                Console.Write(dict[tokens[i]] + " ");
        }
    }
}
