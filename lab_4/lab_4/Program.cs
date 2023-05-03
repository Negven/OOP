using System;
using System.Collections.Generic;
using System.IO;

namespace lab_4
{
    internal class Program
    {

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
            Console.WriteLine("---------------");
            Console.WriteLine($@"{Environment.CurrentDirectory}\text.txt");
            Console.WriteLine("---------------");
            char[] symbols = text.ToCharArray();
            List<char> symbolsList = new List<char>();
            foreach (var sym in text)
            {
               symbolsList.Add(sym);
            }
            Console.WriteLine(countWords(symbols));
            Console.WriteLine(countWords(symbolsList));
        }
    }
}