using System;
using System.Collections.Generic;

namespace OPPLab1
{
    public class MyTest
    {
        
        // public static bool AreCrossing<T>(Vector2[] v11, Vector2[] v12, Vector2[] v21, Vector2[] v22, Vector2[] crossing = null)
        // {
        //     Vector3 cut1 = new Vector3(v12[0] - v11[0], v12[1] - v11[1], 0);
        //     Vector3 cut2 = new Vector3(v22[0] - v21[0], v22[1] - v21[1], 0);
        //     Vector3 prod1, prod2;
        //
        //     prod1 = Vector3.Cross(cut1, new Vector3(v21[0] - v11[0], v21[1] - v11[1], 0));
        //     prod2 = Vector3.Cross(cut1, new Vector3(v22[0] - v11[0], v22[1] - v11[1], 0));
        //
        //     if (Math.Sign(prod1.Z) == Math.Sign(prod2.Z) || prod1.Z == 0 || prod2.Z == 0)
        //     {
        //         return false;
        //     }
        //
        //     prod1 = Vector3.Cross(cut2, new Vector3(v11[0] - v21[0], v11[1] - v21[1], 0));
        //     prod2 = Vector3.Cross(cut2, new Vector3(v12[0] - v21[0], v12[1] - v21[1], 0));
        //
        //     if (Math.Sign(prod1.Z) == Math.Sign(prod2.Z) || prod1.Z == 0 || prod2.Z == 0)
        //     {
        //         return false;
        //     }
        //
        //     if (crossing != null)
        //     {
        //         crossing[0] = new Vector2(v11[0] + cut1.X * Math.Abs(prod1.Z) / Math.Abs(prod2.Z - prod1.Z), v11[1] + cut1.Y * Math.Abs(prod1.Z) / Math.Abs(prod2.Z - prod1.Z));
        //     }
        //
        //     return true;
        // }
        public static void test()
        {
            // Define the endpoints of the two segments
            double[] A = { 0, 1, 0 };
            double[] B = { 4, 5, 0 };
            double[] C = { 1, 4, 0 };
            double[] D = { 5, 0, 0 };

            // Call the function to get the intersection point
            double[] intersectionPoint = GetIntersectionPoint(A, B, C, D);

            // Print the intersection point
            Console.WriteLine("Intersection Point: ({0}, {1}, {2})", intersectionPoint[0], intersectionPoint[1],
                intersectionPoint[2]);
        }

        static double[] GetIntersectionPoint(double[] A, double[] B, double[] C, double[] D)
        {
            // Initialize the array to store the intersection point
            double[] intersectionPoint = new double[3];

            // Calculate the vectors AB and CD representing the segments
            double[] AB = new double[3];
            double[] CD = new double[3];
            double[] AC = new double[3];
            for (int i = 0; i < 3; i++)
            {
                AB[i] = B[i] - A[i];
                CD[i] = D[i] - C[i];
                AC[i] = C[i] - A[i];
            }

            // Calculate the cross product of AB and CD
            double[] crossProduct = CrossProduct(AB, CD);

            // Calculate the dot product of AC and the cross product
            double dotProduct = DotProduct(AC, crossProduct);

            // Calculate the magnitude of the cross product
            double crossProductMagnitude = Magnitude(crossProduct);

            // Check if the segments are parallel
            if (crossProductMagnitude == 0)
            {
                return null;
            }

            // Calculate the parameter t that gives the intersection point
            double t = dotProduct / crossProductMagnitude;

            // Calculate the intersection point using the parameter t
            for (int i = 0; i < 3; i++)
            {
                intersectionPoint[i] = A[i] + t * AB[i];
            }

            // Return the intersection point
            return intersectionPoint;
        }

        static double[] CrossProduct(double[] A, double[] B)
        {
            // Calculate the cross product of vectors A and B
            double[] crossProduct = new double[3];
            crossProduct[0] = A[1] * B[2] - A[2] * B[1];
            crossProduct[1] = A[2] * B[0] - A[0] * B[2];
            crossProduct[2] = A[0] * B[1] - A[1] * B[0];

            // Return the cross product
            return crossProduct;
        }

        static double DotProduct(double[] A, double[] B)
        {
            // Calculate the dot product of vectors A and B
            double dotProduct = 0;
            for (int i = 0; i < 3; i++)
            {
                dotProduct += A[i] * B[i];
            }

            return dotProduct;
        }

        static double Magnitude(double[] A)
        {
            double magnitude = 0;

            for (int i = 0; i < 3; i++)
            {
                magnitude += A[i] * A[i];
            }

            return Math.Sqrt(magnitude);
        }
    }
}