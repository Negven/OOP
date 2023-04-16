using System;
using Lab_3.Properties;

namespace Lab_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the dimensionality of the array: ");
            int numberSpace = Convert.ToInt32(Console.ReadLine());
            if (numberSpace == 1)
            {
                Console.Write("Enter n: ");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int [n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write(i + ". ");
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }

                ArrOneSpace arrOne = new ArrOneSpace(arr);
                Console.WriteLine(arrOne.sumMinMax());
            }

            if (numberSpace == 2)
            {
                Console.Write("Enter n: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter m: ");
                int m = Convert.ToInt32(Console.ReadLine());
                int[,] arr = new int [n,m];
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < m; k++) {
                        Console.Write(i + ", " + k + ": ");
                        arr[i, k] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                ArrTwoSpace arrOne = new ArrTwoSpace(arr);
                Console.WriteLine(arrOne.sumMinMax());
            }
        }
    }
}