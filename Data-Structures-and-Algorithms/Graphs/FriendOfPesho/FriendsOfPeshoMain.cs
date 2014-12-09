namespace FriendOfPesho
{
    using System;
    using System.Collections.Generic;
    
    using Wintellect.PowerCollections;

    class FriendsOfPeshoMain
    {
        static void DijkstraAlgorithm(Node[] graph, Node source)
        {
            var priority = new OrderedBag<Node>();

            for (int i = 1; i < graph.Length; i++)
            {
                graph[i].DijkstraDistance = int.MaxValue;
            }

            source.DijkstraDistance = 0;
            priority.Add(source);

            while (priority.Count != 0)
            {
                Node currentNode = priority.RemoveFirst();

                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                for (int i = 0; i < currentNode.Edges.Count; i++)
                {
                    int potDistance = currentNode.DijkstraDistance + currentNode.Edges[i].Weight;

                    if (potDistance < graph[currentNode.Edges[i].NodeId].DijkstraDistance)
                    {
                        graph[currentNode.Edges[i].NodeId].DijkstraDistance = potDistance;
                        priority.Add(graph[currentNode.Edges[i].NodeId]);
                    }
                }
            }
        }

        internal static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int h = int.Parse(input[2]);
            string[] hospitalIds = Console.ReadLine().Split(' ');
            var nodes = new Node[n + 1];

            for (int i = 0; i < h; i++)
            {
                nodes[int.Parse(hospitalIds[i])] = new Node(int.Parse(hospitalIds[i]), true);
            }

            for (int i = 0; i < m; i++)
            {
                string[] street = Console.ReadLine().Split(' ');
                if (nodes[int.Parse(street[0])] == null)
                {
                    nodes[int.Parse(street[0])] = new Node(int.Parse(street[0]), false);
                }

                nodes[int.Parse(street[0])].Edges.Add(new Edge(int.Parse(street[1]), int.Parse(street[2])));
                if (nodes[int.Parse(street[1])] == null)
                {
                    nodes[int.Parse(street[1])] = new Node(int.Parse(street[1]), false);
                }

                nodes[int.Parse(street[1])].Edges.Add(new Edge(int.Parse(street[0]), int.Parse(street[2])));
            }

            int minimalDistance = int.MaxValue;
            for (int i = 1; i < n + 1; i++)
            {
                if (nodes[i].IsHospital)
                {
                    DijkstraAlgorithm(nodes, nodes[i]);
                    var currentDistance = 0;
                    for (int j = 1; j < nodes.Length; j++)
                    {
                        if (!nodes[j].IsHospital)
                        {
                            currentDistance += nodes[j].DijkstraDistance;
                        }
                    }

                    minimalDistance = Math.Min(minimalDistance, currentDistance);
                }
            }

            Console.WriteLine(minimalDistance);
        }
    }
}
