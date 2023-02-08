namespace OPPLab1
{
    public struct Point2D
    {
        public double x;
        public double y;
    }

    public struct Point3D
    {
        public double x;
        public double y;
        public double z;
    }
    
    public struct Intersection2D 
    {
        public bool isIntersection;
        public Point2D intersection;
    }
    
    public struct Intersection3D 
    {
        public bool isIntersection;
        public Point3D intersection;
    }
}