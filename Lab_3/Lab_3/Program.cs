using System;
using Lab_3.Properties;

namespace Lab_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ArrTwoSpace arrOne = new ArrTwoSpace(new  int[2, 4]{ { 3, 5, -3, 4 }, {10, 2, 3, 2}});
            Console.WriteLine(arrOne.sumMinMax());
        }
    }
}