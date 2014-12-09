namespace _04.HashTableImplementation
{
    using System;
    using System.Collections.Generic;

    class HashTableImplementationTest
    {
        static void Main(string[] args)
        {
            MyHashTable<Point3D, int> dict = new MyHashTable<Point3D, int>(3, 0.9f);
            dict[new Point3D(1, 2, 3)] = 1;
            Console.WriteLine(dict[new Point3D(1, 2, 3)]);
            dict[new Point3D(1, 2, 3)] += 1;
            Console.WriteLine(dict[new Point3D(1, 2, 3)]);
            dict[new Point3D(3, 2, 2)] = 42;
            Console.WriteLine(dict[new Point3D(3, 2, 2)]);

            Console.WriteLine(dict[new Point3D(1, 2, 3)]);

            dict[new Point3D(4, 5, 6)] = 1111;
            Console.WriteLine(dict[new Point3D(4, 5, 6)]);

            dict.Remove(new Point3D(3, 2, 2));

            foreach (KeyValuePair<Point3D, int> entry in dict)
            {
                Console.WriteLine("Key: " + entry.Key + "; Value: " + entry.Value);
            }
        }
    }

    public class Point3D
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            Point3D other = obj as Point3D;

            if (other == null)
            {
                return false;
            }

            if (!this.X.Equals(other.X))
            {
                return false;
            }

            if (!this.Y.Equals(other.Y))
            {
                return false;
            }

            if (!this.Z.Equals(other.Z))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;
            unchecked
            {
                result = result * prime + X.GetHashCode();
                result = result * prime + Y.GetHashCode();
                result = result * prime + Z.GetHashCode();
            }

            return result;
        }
    }
}
