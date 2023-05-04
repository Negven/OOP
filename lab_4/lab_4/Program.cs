using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;

namespace lab_4
{
    internal class Program
    {
        public static readonly char[] alphabet = new [] {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        public static readonly string[] shortWords = new[]
        {
            "do", "is", "no", "we", "go"
        };

        public static List<string> splitTextByWords(char[] text)
        {
            List<string> result = new List<string>();
            int indexText = 0;
            while (indexText < text.Length)
            {
                string word = "";
                while (indexText < text.Length && alphabet.Contains(text[indexText]))
                {
                    word += text[indexText];
                    indexText++;
                }
                if(word.Length > 2) result.Add(word);
                if (word.Length == 2)
                {
                    if(shortWords.Contains(word)) result.Add(word);
                }
                indexText++;
            }

            return result;
        }

        public static int countWordsByLetters(char[] text)
        {
            List<string> splitText = splitTextByWords(text);
            foreach (var word in splitText)
            {
                Console.WriteLine(word);
            }

            return splitText.Count;
        }
        
        public static int countWords(char[] text)
        {
            int counter = 0;
            int ind = 0;
            foreach (char symbol  in text)
            {
                if (symbol == ' ' || symbol == '\n' || symbol == '\r')
                {
                    if (ind > 0)
                    {
                        if (text[ind - 1] != ' ' && text[ind - 1] != '\n' && text[ind - 1] != '\r')
                        {
                            counter++;
                        }
                    }
                }

                ind++;
            }

            return counter + 1;
        }
        
        public static int countWords(List<char> text)
        {
            int counter = 0;
            int ind = 0;
            foreach (char symbol  in text)
            {
                if (symbol == ' ' || symbol == '\n' || symbol == '\r')
                {
                    if (ind > 0)
                    {
                        if (text[ind - 1] != ' ' && text[ind - 1] != '\n' && text[ind - 1] != '\r')
                        {
                            counter++;
                        }
                    }
                }

                ind++;
            }

            return counter + 1;
        }
        
        public static void Main(string[] args)
        {
            string text = File.ReadAllText($@"{Environment.CurrentDirectory}\..\..\..\text.txt");
            char[] symbols = text.ToCharArray();
            List<char> symbolsList = new List<char>();
            // foreach (var sym in text)
            // {
            //    symbolsList.Add(sym);
            // }
            // Console.WriteLine(countWords(symbols));
            // Console.WriteLine(countWords(symbolsList));
            Console.WriteLine(countWordsByLetters(symbols));
        }
    }
}