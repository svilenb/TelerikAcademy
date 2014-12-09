namespace FriendOfPesho
{
    using System;
    using System.Collections.Generic;

    public class Node : IComparable
    {
        public Node(int id, bool isHospital)
        {
            this.Id = id;
            this.IsHospital = isHospital;
            this.DijkstraDistance = int.MaxValue;
            this.Edges = new List<Edge>();
        }

        public int Id { get; set; }

        public int DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public List<Edge> Edges { get; set; }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}
