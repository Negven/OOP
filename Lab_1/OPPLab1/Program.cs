using System;

namespace OPPLab1
{
    internal class Program
    {
        public static void SwapPoints(Point2D p1, Point2D p2){
            var c = p1.x;
            p1.x = p2.x;
            p2.x = c;

            c = p1.y;
            p1.y = p2.y;
            p2.y = c;
        }
        public static void ConsoleOutPoint(Point2D a)
        {
            Console.WriteLine("x: " + a.x);
            Console.WriteLine("y: " + a.y);
        }
        
        public static void ConsoleOutPoint(Point3D a)
        {
            Console.WriteLine("x: " + a.x);
            Console.WriteLine("y: " + a.y);
            Console.WriteLine("z: " + a.z);
        }

        public static void Main(string[] args)
        {
            // TInterval2D segment1 = new TInterval2D(0, 1, 4, 5);
            // TInterval2D segment2 = new TInterval2D(1, 4, 5, 0);
            TInterval2D segment1 = new TInterval2D(0, 1, 4, 5);
            TInterval2D segment2 = new TInterval2D(1, 2, 5, 6);
            // TInterval2D s1Copy = new TInterval2D(segment1);
            // TInterval3D segment1 = new TInterval3D(0, 1, 4, 5, 0, 0);
            // TInterval3D segment2 = new TInterval3D(1, 4, 5, 0, 0, 0);
            // TInterval2D mul = segment1 * 2;
            // ConsoleOutPoint(mul.getA());
            // ConsoleOutPoint(mul.getB());
            // segment1.setA(0, -1);
            // ConsoleOutPoint(segment2.GetMidlePoint());
            Intersection2D i = default;
            i = segment1.findIntersectionPoint(segment2);
            if (i.isIntersection)
            {
                ConsoleOutPoint(i.intersection);
            }
            else
            {
                Console.WriteLine("not");
            }
            // ConsoleOutPoint(s1Copy.getA());
        }
    }
}