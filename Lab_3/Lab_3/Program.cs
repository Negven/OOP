using System;

namespace Lab_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ArrOneSpace arrOne = new ArrOneSpace(new  int[4]{3, 5, 1, 4});
            Console.WriteLine(arrOne.sumMinMax());
        }
    }
}