using System;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
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

            foreach (var elZ in z)
            {
                Console.Write(elZ + ", ");
            }
        }
    }   
}
