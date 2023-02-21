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
            bz = z2;
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
        
        public static double determinantMatrix(double[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                   matrix[1, 0] * matrix[2, 1] * matrix[0, 2] +
                   matrix[2, 0] * matrix[0, 1] * matrix[1, 2] -
                   matrix[2, 0] * matrix[1, 1] * matrix[0, 2] -
                   matrix[1, 0] * matrix[0, 1] * matrix[2, 2] -
                   matrix[0, 0] * matrix[2, 1] * matrix[1, 2];
        }

        public static bool isDotsInOneSpace(Point3D a, Point3D b, Point3D c, Point3D d)
        {
            double[,] spaceMatrix = new double[3, 3]
            {
                {d.x - a.x, d.y - a.y, d.z - a.z},
                {b.x - a.x, b.y - a.y, b.z - a.z},
                {c.x - a.x, c.y - a.y, d.z - a.z}
            };
            
            return determinantMatrix(spaceMatrix) == 0;
        }
        
        public Intersection3D findIntersectionPoint(TInterval3D secondLineSegment)  
        {
            Intersection3D answer = default;

            if (!isDotsInOneSpace(
                    new Point3D { x = a.x, y = a.y, z = az },
                    new Point3D { x = b.x, y = b.y, z = bz },
                    new Point3D { x = secondLineSegment.a.x, y = secondLineSegment.a.y, z = secondLineSegment.az },
                    new Point3D { x = secondLineSegment.b.x, y = secondLineSegment.b.y, z = secondLineSegment.bz }
                ))
            {
                answer.isIntersection = false;
                return answer;
            }
            
            TInterval2D firstLineXY = new TInterval2D(a.x, a.y, b.x, b.y);
            TInterval2D firstLineZY = new TInterval2D(az, a.y, bz, b.y);
            TInterval2D firstLineXZ = new TInterval2D(a.x, az, b.x, bz);
            
            TInterval2D secondLineXY = new TInterval2D(secondLineSegment.a.x, secondLineSegment.a.y, secondLineSegment.b.x, secondLineSegment.b.y);
            TInterval2D secondLineZY = new TInterval2D(secondLineSegment.az, secondLineSegment.a.y, secondLineSegment.bz, secondLineSegment.b.y);
            TInterval2D secondLineXZ = new TInterval2D(secondLineSegment.a.x, secondLineSegment.az, secondLineSegment.b.x, secondLineSegment.bz);

            Intersection2D interXY = firstLineXY.findIntersectionPoint(secondLineXY);
            Intersection2D interYZ = firstLineZY.findIntersectionPoint(secondLineZY);
            Intersection2D interXZ = firstLineXZ.findIntersectionPoint(secondLineXZ);

            int intersectionCounter = 0;
            if (interXY.isIntersection) intersectionCounter++;
            if (interYZ.isIntersection) intersectionCounter++;
            if (interXZ.isIntersection) intersectionCounter++;
            if (isLineIncludeAnotherLine(firstLineXY, secondLineXY)) intersectionCounter++;
            if (isLineIncludeAnotherLine(firstLineZY, secondLineZY)) intersectionCounter++;
            if (isLineIncludeAnotherLine(firstLineXZ, secondLineXZ)) intersectionCounter++;
            
            if (intersectionCounter == 3)
            {
                answer.isIntersection = true;
                answer.intersection = new Point3D { };
                answer.intersection.x = interXZ.isIntersection ? interXZ.intersection.x : interXY.intersection.x;
                answer.intersection.y = interXY.isIntersection ? interXY.intersection.y : interYZ.intersection.x;
                answer.intersection.z = interYZ.isIntersection ? interYZ.intersection.y : interXZ.intersection.y;
                
                return answer;
            }
            answer.isIntersection = false;
            return answer;
        }

        public static TInterval3D operator +(TInterval3D line1, TInterval3D line2) =>
            new TInterval3D(line1.a.x, line1.a.y, line2.b.x, line2.b.y, line1.az, line2.bz);

        public static TInterval3D operator *(TInterval3D line, double k)
        {
            TInterval2D line2D = (new TInterval2D(line.a.x, line.a.y, line.b.x, line.b.y)) * k;
            double bz = line.az + (line.bz - line.az) * k;
            return new TInterval3D(line2D.getA().x, line2D.getA().y, line2D.getB().x, line2D.getB().y, line.az, bz);
        }
    }
}