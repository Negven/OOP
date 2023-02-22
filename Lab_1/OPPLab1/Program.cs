using System;

namespace OPPLab1
{
    internal class Program
    {
        public static void SwapPoints(ref Point2D p1, ref Point2D p2){
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
            int answerNumber = 1;
            string spaceName = "";
            Console.WriteLine();
            Console.WriteLine("2D or 3D?");
            spaceName = Console.ReadLine();
            while (spaceName != "2D" && spaceName != "3D")
            {
                Console.WriteLine("Enter correct variant");
                spaceName = Console.ReadLine();
            }

            if (spaceName == "2D")
            {
                TInterval2D[] intervals = { new TInterval2D(), new TInterval2D() };
                for (int intervalCounter = 1; intervalCounter < 3; intervalCounter++)
                {
                    Console.WriteLine("Interval " + intervalCounter);
                    double x1, y1, x2, y2;
                    Console.Write("x1: ");
                    x1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("y1: ");
                    y1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("x2: ");
                    x2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("y2: ");
                    y2 = Convert.ToDouble(Console.ReadLine());
                    intervals[intervalCounter - 1] = new TInterval2D(x1, y1, x2, y2);
                }
                Intersection2D intersection2D = intervals[0].findIntersectionPoint(intervals[1]);
                if (intersection2D.isIntersection)
                {
                    Console.WriteLine("Intersection: ");
                    ConsoleOutPoint(intersection2D.intersection);
                }
                else
                {
                    if (TInterval2D.isLineIncludeAnotherLine(intervals[0], intervals[1]))
                    {
                        Console.WriteLine("One line include part");

                    }
                    Console.WriteLine("They haven`t got intersection");
                }
                
                Console.WriteLine("Interval 1 length: " + intervals[0].GetLength());
                Console.WriteLine("Interval 2 length: " + intervals[1].GetLength());
                
                Console.WriteLine("Interval 1 centre point: ");
                ConsoleOutPoint(intervals[0].GetMidlePoint());
                Console.WriteLine("Interval 2 centre point: ");
                ConsoleOutPoint(intervals[1].GetMidlePoint());

                Console.WriteLine("Sum of intervals");
                TInterval2D sum = intervals[0] + intervals[1];
                ConsoleOutPoint(sum.getA());
                ConsoleOutPoint(sum.getB());

                double k;
                Console.WriteLine("Multiply intervals");
                Console.Write("Enter k: ");
                k = Convert.ToDouble(Console.ReadLine());
                TInterval2D mul = intervals[0] * k;
                ConsoleOutPoint(mul.getA());
                ConsoleOutPoint(mul.getB());
            }
            else
            {
                 TInterval3D[] intervals = { new TInterval3D(), new TInterval3D() };
                for (int intervalCounter = 1; intervalCounter < 3; intervalCounter++)
                {
                    Console.WriteLine("Interval " + intervalCounter);
                    double x1, y1, x2, y2, z1, z2;
                    Console.Write("x1: ");
                    x1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("y1: ");
                    y1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("x2: ");
                    x2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("y2: ");
                    y2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("z1: ");
                    z1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("z2: ");
                    z2 = Convert.ToDouble(Console.ReadLine());
                    intervals[intervalCounter - 1] = new TInterval3D(x1, y1, x2, y2, z1, z2);
                }
                
                Intersection3D intersection3D = intervals[0].findIntersectionPoint(intervals[1]);
                if (intersection3D.isIntersection)
                {
                    Console.WriteLine("Intersection: ");
                    ConsoleOutPoint(intersection3D.intersection);
                }
                else
                {
                    Console.WriteLine("They haven`t got intersection");
                }
                
                Console.WriteLine("Interval 1 length: " + intervals[0].GetLength());
                Console.WriteLine("Interval 2 length: " + intervals[1].GetLength());
                
                Console.WriteLine("Interval 1 centre point: ");
                ConsoleOutPoint(intervals[0].GetMidlePoint());
                Console.WriteLine("Interval 2 centre point: ");
                ConsoleOutPoint(intervals[1].GetMidlePoint());

                Console.WriteLine("Sum of intervals");
                TInterval3D sum = intervals[0] + intervals[1];
                ConsoleOutPoint(sum.getA());
                ConsoleOutPoint(sum.getB());

                double k;
                Console.WriteLine("Multiply intervals");
                Console.Write("Enter k: ");
                k = Convert.ToDouble(Console.ReadLine());
                TInterval3D mul = intervals[0] * k;
                ConsoleOutPoint(mul.getA());
                ConsoleOutPoint(mul.getB());
            }
            // TInterval2D segment1 = new TInterval2D(0, 1, 4, 5);
            // TInterval2D segment2 = new TInterval2D(1, 4, 5, 0);
        }
    }
}