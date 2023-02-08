using System;

namespace OPPLab1
{
    public class TInterval3D: TInterval2D
    {
        private double az;
        private double bz;

        public TInterval3D(): base()
        {
            az = 0;
            bz = 0;
        }

        public TInterval3D(double x1, double y1, double x2, double y2, double z1, double z2) : base(x1, y1, x2, y2)
        {
            az = z1;
            bz = z1;
        }

        public TInterval3D(TInterval3D original): base(original)
        {
            az = original.az;
            bz = original.bz;
        }

        public Point3D getA() => new Point3D{x = a.x, y = a.y, z = az};

        public Point3D getB() => new Point3D{x = b.x, y = b.y, z = bz};

        public void setA(double x, double y, double z)
        {
            base.setA(x, y);
            az = z;
        }
        
        public void setB(double x, double y, double z)
        {
            base.setB(x, y);
            bz = z;
        }
        
        public static double GetLengthLine(Point3D a, Point3D b)
        {
            return Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.x - a.x), 2) + Math.Pow((b.z - a.z), 2));
        }
        
        public Point3D GetMidlePoint()
        {
            Point3D p = default;
            p.x = (a.x + b.x) / 2;
            p.y = (a.y + b.y) / 2;
            p.z = (az + bz) / 2;
            return p;
        }
        
        public bool isPointAtLine(Point3D p)
        {
            double apLength = GetLengthLine(getA(), p);
            double bpLength = GetLengthLine(getB(), p);
            double baLength = GetLengthLine(getA(), getB());
            return Math.Abs(apLength + bpLength - baLength) < 0.001;
        }

        public Intersection3D findIntersectionPoint(TInterval3D secondLineSegment)
        {
            Intersection3D answer = default;
            
            TInterval2D firstLineXY = new TInterval2D(a.x, a.y, b.x, b.y);
            TInterval2D firstLineZY = new TInterval2D(az, a.y, bz, b.y);
            TInterval2D firstLineXZ = new TInterval2D(a.x, az, b.x, bz);
            
            TInterval2D secondLineXY = new TInterval2D(secondLineSegment.a.x, secondLineSegment.a.y, secondLineSegment.b.x, secondLineSegment.b.y);
            TInterval2D secondLineZY = new TInterval2D(secondLineSegment.az, secondLineSegment.a.y, secondLineSegment.bz, secondLineSegment.b.y);
            TInterval2D secondLineXZ = new TInterval2D(secondLineSegment.a.x, secondLineSegment.az, secondLineSegment.b.x, secondLineSegment.bz);

            Intersection2D interXY = firstLineXY.findIntersectionPoint(secondLineXY);
            Intersection2D interYZ = firstLineZY.findIntersectionPoint(secondLineZY);
            Intersection2D interXZ = firstLineXZ.findIntersectionPoint(secondLineXZ);

            if (interXY.isIntersection && interYZ.isIntersection && interXZ.isIntersection)
            {
                answer.isIntersection = true;
                answer.intersection = new Point3D
                    { x = interXZ.intersection.x, y = interXY.intersection.y, z = interYZ.intersection.y };
                return answer;
            }
            answer.isIntersection = false;
            return answer;
        }
    }
}