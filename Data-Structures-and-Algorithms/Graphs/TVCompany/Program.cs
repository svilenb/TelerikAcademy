namespace TVCompany
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        public static void Main()
        {
            var priority = new SortedSet<Path>();
            const int numberOfHouses = 6;
            var used = new bool[numberOfHouses + 1];
            var mpdPaths = new List<Path>();
            var paths = new List<Path>();
            InitializeGraph(paths);

            foreach (Path edge in paths)
            {
                if (edge.StartHouse == paths[0].StartHouse)
                {
                    priority.Add(edge);
                }
            }

            used[paths[0].StartHouse] = true;

            FindMinimumSpanningTree(used, priority, mpdPaths, paths);

            PrintMinimumSpanningTree(mpdPaths);

            Console.WriteLine("Total wire length: {0}", mpdPaths.Sum(x => x.WireLength));
        }

        private static void PrintMinimumSpanningTree(IEnumerable<Path> mpdPaths)
        {
            foreach (Path path in mpdPaths)
            {
                Console.WriteLine("{0}", path);
            }
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<Path> priority, List<Path> mpdPaths, List<Path> edges)
        {
            while (priority.Count > 0)
            {
                Path path = priority.Min;
                priority.Remove(path);

                if (!used[path.EndHouse])
                {
                    used[path.EndHouse] = true; // we "visit" this node
                    mpdPaths.Add(path);
                    AddPaths(path, edges, mpdPaths, priority, used);
                }
            }
        }

        private static void AddPaths(Path path, List<Path> paths, List<Path> mpd, SortedSet<Path> priority, bool[] used)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                if (!mpd.Contains(paths[i]))
                {
                    if (path.EndHouse == paths[i].StartHouse && !used[paths[i].EndHouse])
                    {
                        priority.Add(paths[i]);
                    }
                }
            }
        }

        private static void InitializeGraph(List<Path> edges)
        {
            edges.Add(new Path(1, 3, 5));
            edges.Add(new Path(1, 2, 4));
            edges.Add(new Path(1, 4, 9));
            edges.Add(new Path(2, 4, 2));
            edges.Add(new Path(3, 4, 20));
            edges.Add(new Path(3, 5, 7));
            edges.Add(new Path(4, 5, 8));
            edges.Add(new Path(5, 6, 12));
        }
    }
}
