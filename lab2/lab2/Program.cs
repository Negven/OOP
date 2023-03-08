﻿using System;

namespace lab2
{
    internal class Program
    {

        static void task1_1()
        {
            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double[] x = new double[n];
            double[] y = new double[n];
            int zLength = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter x" + (i + 1) + ": ");
                x[i] = Convert.ToDouble(Console.ReadLine());
                if (x[i] > 0) zLength++;
                Console.Write("Enter y" + (i + 1) + ": ");
                y[i] = Convert.ToDouble(Console.ReadLine());
                if (y[i] > 0) zLength++;
            }
            double[] z = new double[zLength];
            int zIndex = 0;
            foreach (double elX in x)
            {
                if (elX > 0) z[zIndex++] = elX;
            }
            foreach (double elY in y)
            {
                if (elY > 0) z[zIndex++] = elY;
            }

            outArray(zLength, z);
        }

        public static void enterArray(int n, ref double[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter " + (i + 1) + ": ");
                arr[i] = Convert.ToDouble(Console.ReadLine());
            }
        }
        
        public static void enterArray(int a, int b, ref int[,] matrix)
        {
            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    Console.Write("Enter (" + (x + 1) + ", " + (y + 1) + "): ");
                    matrix[x, y] =  Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public static void outArray(int n, double[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + ", ");
            }
        }
        
        public static void outArray(int a, int b, ref int[,] matrix)
        {
            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    Console.Write(matrix[y, x] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void task1_2()
        {
            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            double[] a = new double[n];
            Console.WriteLine("Enter a");
            enterArray(n, ref a);
            double[] b = new double[n];
            Console.WriteLine("Enter b");
            enterArray(n, ref b);
            double[] c = new double[n];
            Console.WriteLine("Enter c");
            enterArray(n, ref c);
            
            
            for (int i = 0; i < n; i++)
            {
                c[i] = 2 * (a[i] + c[i]) - b[i];
            }

            outArray(n, c);
        }

        public static void task1_3()
        {
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            double[] arr = new double[n];
            Console.WriteLine("Enter array");
            enterArray(n, ref arr);

            int a, b;
            Console.Write("Enter a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter b: ");
            b = Convert.ToInt32(Console.ReadLine());
            double[] secondArr = new double[n];
            int secondCounter = 0;
            int newLength = n;
            for (int i = 0; i < newLength; i++)
            {
                if (!((int)Math.Floor(arr[i]) >= a && (int)Math.Floor(arr[i]) <= b))
                {
                    double el = arr[i];
                    for (int k = i; k < n - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }
                    i--;
                    newLength--;
                    secondArr[secondCounter++] = el;
                }
            }

            for (int i = 0; i < secondCounter; i++)
            {
                arr[n - secondCounter + i] = secondArr[i];
            }
            outArray(n, arr);
        }

        public static void task2_1()
        {
                 
            Console.Write("Enter a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            
            int[,] matrix = new int[a, b];
            int[,] matrixNew = new int[a, b];

            enterArray(a, b, ref matrix);

            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    matrixNew[x, y] = matrix[x, y];
                }

            }
            
            Console.Write("Enter k: ");
            int k = Convert.ToInt32(Console.ReadLine());
            
            outArray(a, b, ref matrix);

            for (int x = 1; x < a; x += 2)
            {
                for (int y = 0; y < b; y++)
                {
                    int xNew = (k * 2 + x) % b;
                    matrixNew[xNew, y] = matrix[x, y];
                }
            }
            Console.WriteLine("--------");
            outArray(a, b, ref matrixNew);
        }
        
        public static void Main(string[] args)
        {
            task1_1();
            task1_2();
            task1_3();   
            task2_1();
        }
    }   
}
