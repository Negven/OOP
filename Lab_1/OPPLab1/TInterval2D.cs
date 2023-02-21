using System;

namespace OPPLab1


{

    public class TInterval2D
    {
        protected Point2D a;
        protected Point2D b;
        
        public TInterval2D()
        {
            a.x = 0;
            a.y = 0;
            
            b.x = 0;
            b.y = 0;
        }
        
        public TInterval2D(double x1, double y1, double x2, double y2) 
        {
            a.x = x1;
            a.y = y1;
            
            b.x = x2;
            b.y = y2;
        }
        
        public TInterval2D(TInterval2D original) 
        {
            a = original.a;
            b = original.b;
        }
        
        public Point2D getA() {
            return a;
        }
        
        public Point2D getB() {
            return b;
        }

        public void setA(double x, double y)
        {
            a.x = x;
            a.x = y;
        }
        
        public void setB(double x, double y)
        {
            b.x = x;
            b.x = y;
        }

        public double GetLength()
        {
            return GetLengthLine(a, b);
        }
        public static double GetLengthLine(Point2D a, Point2D b)
        {
            return Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.x - a.x), 2));
        }

        public Point2D GetMidlePoint()
        {
            Point2D p = default;
            p.x = (a.x + b.x) / 2;
            p.y = (a.y + b.y) / 2;
            return p;
        }
        
        public bool isPointAtLine(Point2D p)
        {
            double apLength = GetLengthLine(a, p);
            double bpLength = GetLengthLine(b, p);
            double baLength = GetLengthLine(a, b);
            return Math.Abs(apLength + bpLength - baLength) < 0.001;

        }

        public static bool isLineIncludeAnotherLine(TInterval2D line1, TInterval2D line2)
        {
            double k1, k2;
            if (line1.a.x - line1.b.x != 0)
            {
                k1 = (line1.a.y - line1.b.y) / (line1.a.x - line1.b.x);
                if (line2.a.x - line2.b.x != 0)
                {
                    if (line1.a.x > line1.b.x) Program.SwapPoints(ref line1.a, ref line1.b);
                    if (line2.a.x > line2.b.x) Program.SwapPoints(ref line2.a, ref line2.b);
                    k2 = (line2.a.y - line2.b.y) / (line2.a.x - line2.b.x);
                    if (Math.Abs(k2 - k1) < 0.001)
                    {
                        if ((line2.a.x > line1.a.x && line2.a.x < line1.b.x) ||
                            (line1.a.x > line2.a.x && line1.a.x < line2.b.x))
                        {
                            return true;
                        } 
                    }
                }
            }
            else
            {
                if (line2.a.x - line2.b.x != 0 || line1.a.x != line2.a.x) 
                    return false;
                if (line1.b.y > line1.a.y) Program.SwapPoints(ref line1.a, ref line1.b);
                if (line2.b.y > line2.a.y) Program.SwapPoints(ref line2.a, ref line2.b);
                if ((line2.a.y > line1.a.y && line2.b.y < line1.a.y) ||
                    (line1.a.y > line2.a.y && line1.b.y < line2.a.y))
                {
                    return true;
                }    
            }
            return false;
        }
        
        public Intersection2D findIntersectionPoint(TInterval2D secondLineSegment)
        {
            double n;
            Point2D intersectionPoint = default;
            Intersection2D answer = new Intersection2D();
            
            if (b.y - a.y != 0)
            {
                double q = (b.x - a.x) / (a.y - b.y);   
                double sn = (secondLineSegment.a.x - secondLineSegment.b.x) + (secondLineSegment.a.y - secondLineSegment.b.y) * q;
                if (sn == 0)
                {
                    answer.isIntersection = false;
                    return answer;
                }  
                double fn = (secondLineSegment.a.x - a.x) + (secondLineSegment.a.y - a.y) * q;   
                n = fn / sn;
            }
            else {
                if ((secondLineSegment.a.y - secondLineSegment.b.y) == 0)
                {
                    answer.isIntersection = false;
                    return answer;
                }
                n = (secondLineSegment.a.y - a.y) / (secondLineSegment.a.y - secondLineSegment.b.y);  
            }
            intersectionPoint.x = secondLineSegment.a.x + (secondLineSegment.b.x - secondLineSegment.a.x) * n;
            intersectionPoint.y = secondLineSegment.a.y + (secondLineSegment.b.y - secondLineSegment.a.y) * n;
            
            if(!(isPointAtLine(intersectionPoint) && secondLineSegment.isPointAtLine(intersectionPoint)))
            {
                answer.isIntersection = false;
                return answer;
            }
            answer.intersection = intersectionPoint;
            answer.isIntersection = true;
            return answer;
        }

        public static TInterval2D operator +(TInterval2D line1, TInterval2D line2) => new TInterval2D(line1.a.x, line1.a.y, line2.b.x, line2.b.y);
        public static TInterval2D operator *(TInterval2D line, double k)
        {
            double x = line.getA().x + (line.getB().x - line.getA().x) * k;
            double y = line.getA().y + (line.getB().y - line.getA().y) * k;
            TInterval2D newLine = new TInterval2D(line.getA().x, line.getA().y, x, y );
            return newLine;
        }
    }
}