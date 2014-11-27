namespace _5.Sorting
{
    using System;
    using System.Collections.Generic;

    public class FewestNumberOfOperationsFinder
    {
        public FewestNumberOfOperationsFinder(byte[] startArray, int k)
        {
            this.StartArr = startArray;
            this.K = k;
            this.AllNodesStr = new HashSet<string>();
        }

        public byte[] StartArr { get; set; }

        public int K { get; set; }

        public HashSet<string> AllNodesStr { get; set; }

        public int Find()
        {
            int result = this.BFS(this.StartArr);
            return result;
        }

        private static bool IsSorted(byte[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }

            return true;
        }

        private int BFS(byte[] startArr)
        {
            int operations = 0;
            Queue<byte[]> nodesQueue = new Queue<byte[]>();
            nodesQueue.Enqueue((byte[])startArr.Clone());
            while (nodesQueue.Count > 0)
            {
                Queue<byte[]> nextLevelNodes = new Queue<byte[]>();
                operations++;
                while (nodesQueue.Count > 0)
                {
                    byte[] node = nodesQueue.Dequeue();
                    if (IsSorted(node))
                    {
                        return operations - 1;
                    }

                    for (int i = 0; i < node.Length - this.K + 1; i++)
                    {
                        byte[] newArr = (byte[])node.Clone();
                        Array.Reverse(newArr, i, this.K);
                        var nodeStr = string.Join(string.Empty, newArr);
                        if (!this.AllNodesStr.Contains(nodeStr))
                        {
                            nextLevelNodes.Enqueue(newArr);
                            this.AllNodesStr.Add(nodeStr);
                        }
                    }
                }

                nodesQueue = nextLevelNodes;
            }

            return -1;
        }
    }
}
