namespace FriendOfPesho
{
    public class Edge
    {
        public Edge(int nodeId, int weight)
        {
            this.NodeId = nodeId;
            this.Weight = weight;
        }

        public int Weight { get; set; }

        public int NodeId { get; set; }
    }
}
