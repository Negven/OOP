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

        public static void outArray(int n, double[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + ", ");
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
        public static void Main(string[] args)
        {
            task1_1();
            task1_2();
        }
    }   
}
