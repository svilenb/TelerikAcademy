namespace GeometryAPI
{
    using System;

    public class Circle : Figure, IFlat, IAreaMeasurable
    {
        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }

        public Vector3D GetNormal()
        {
            return new Vector3D(0, 0, 1);
        }

        public double GetArea()
        {
            return this.Radius * this.Radius * Math.PI;
        }
    }
}
