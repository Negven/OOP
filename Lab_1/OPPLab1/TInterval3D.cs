// using System;
//
// namespace OPPLab1
// {
//     public class TInterval3D: TInterval2D
//     {
//         private double az;
//         private double bz;
//
//         public TInterval3D(): base()
//         {
//             az = 0;
//             bz = 0;
//         }
//
//         public TInterval3D(double x1, double y1, double x2, double y2, double z1, double z2) : base(x1, y1, x2, y2)
//         {
//             az = z1;
//             bz = z1;
//         }
//
//         public TInterval3D(TInterval3D original): base(original)
//         {
//             az = original.az;
//             bz = original.bz;
//         }
//
//         public Point3D getA() => new Point3D{x = a.x, y = a.y, z = az};
//
//         public Point3D getB() => new Point3D{x = b.x, y = b.y, z = bz};
//
//         public void setA(double x, double y, double z)
//         {
//             base.setA(x, y);
//             az = z;
//         }
//         
//         public void setB(double x, double y, double z)
//         {
//             base.setB(x, y);
//             bz = z;
//         }
//         
//         public static double GetLengthLine(Point3D a, Point3D b)
//         {
//             return Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.x - a.x), 2) + Math.Pow((b.z - a.z), 2));
//         }
//         
//         public Point3D GetMidlePoint()
//         {
//             Point3D p = default;
//             p.x = (a.x + b.x) / 2;
//             p.y = (a.y + b.y) / 2;
//             p.z = (az + bz) / 2;
//             return p;
//         }
//         
//         public bool isPointAtLine(Point3D p)
//         {
//             double apLength = GetLengthLine(getA(), p);
//             double bpLength = GetLengthLine(getB(), p);
//             double baLength = GetLengthLine(getA(), getB());
//             return Math.Abs(apLength + bpLength - baLength) < 0.001;
//         }
//         
//         
//         static double[] CrossProduct(double[] A, double[] B)
//         {
//             // Calculate the cross product of vectors A and B
//             double[] crossProduct = new double[3];
//             crossProduct[0] = A[1] * B[2] - A[2] * B[1];
//             crossProduct[1] = A[2] * B[0] - A[0] * B[2];
//             crossProduct[2] = A[0] * B[1] - A[1] * B[0];
//
//             // Return the cross product
//             return crossProduct;
//         }
//
//         static double DotProduct(double[] A, double[] B)
//         {
//             // Calculate the dot product of vectors A and B
//             double dotProduct = 0;
//             for (int i = 0; i < 3; i++)
//             {
//                 dotProduct += A[i] * B[i];
//             }
//
//             return dotProduct;
//         }
//
//         static double Magnitude(double[] A)
//         {
//             double magnitude = 0;
//
//             for (int i = 0; i < 3; i++)
//             {
//                 magnitude += A[i] * A[i];
//             }
//
//             return Math.Sqrt(magnitude);
//         }
//
//         public Intersection3D findIntersectionPoint(TInterval3D secondLineSegment)
//         {
//             // Initialize the array to store the intersection point
//             Intersection3D intersectionPoint = new Intersection3D();
//
//             // A = a
//             // B = b
//             // c = secondLineSegment.a
//             // d = secondLineSegment.b
//             
//             // Calculate the vectors AB and CD representing the segments
//             Point3D AB = new Point3D{x = b.x - a.x, y = b.y - a.y, z = bz - az};
//             Point3D CD = new Point3D
//             {
//                 x = secondLineSegment.b.x - secondLineSegment.a.x,
//                 y = secondLineSegment.b.y - secondLineSegment.a.y,
//                 z = secondLineSegment.bz - secondLineSegment.az
//             };
//             Point3D AC = new Point3D
//             {
//                 x = secondLineSegment.a.x - a.x,
//                 y = secondLineSegment.a.y - a.y,
//                 z = secondLineSegment.az - secondLineSegment.bz
//             };
//             double[] AC = new double[3];
//             
//             for (int i = 0; i < 3; i++)
//             {
//                 AB[i] = B[i] - A[i];
//                 CD[i] = D[i] - C[i];
//                 AC[i] = C[i] - A[i];
//             }
//
//             // Calculate the cross product of AB and CD
//             double[] crossProduct = CrossProduct(AB, CD);
//
//             // Calculate the dot product of AC and the cross product
//             double dotProduct = DotProduct(AC, crossProduct);
//
//             // Calculate the magnitude of the cross product
//             double crossProductMagnitude = Magnitude(crossProduct);
//
//             // Check if the segments are parallel
//             if (crossProductMagnitude == 0)
//             {
//                 return null;
//             }
//
//             // Calculate the parameter t that gives the intersection point
//             double t = dotProduct / crossProductMagnitude;
//
//             // Calculate the intersection point using the parameter t
//             for (int i = 0; i < 3; i++)
//             {
//                 intersectionPoint[i] = A[i] + t * AB[i];
//             }
//
//             // Return the intersection point
//             return intersectionPoint;
//         }
//     }
// }