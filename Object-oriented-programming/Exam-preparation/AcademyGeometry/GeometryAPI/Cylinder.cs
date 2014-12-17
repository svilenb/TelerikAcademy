namespace GeometryAPI
{
    using System;

    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public Cylinder(Vector3D topCenter, Vector3D bottomCenter, double radius)
            : base(topCenter, bottomCenter)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        public double GetArea()
        {
            double baseArea = Math.PI * this.Radius * this.Radius;
            double basePerimeter = 2 * Math.PI * this.Radius;
            double height = (this.vertices[0] - this.vertices[1]).Magnitude;
            double sideArea = basePerimeter * height;

            return baseArea * 2 + sideArea;
        }

        public double GetVolume()
        {
            return Math.PI * this.Radius * this.Radius * (this.vertices[0] - this.vertices[1]).Magnitude;
        }
    }
}
