namespace _01.TreeOperations
{
    using System;
    using System.Collections.Generic;

    class TreeOperations
    {
        static IList<IList<TreeNode<int>>> paths;

        static void Main(string[] args)
        {
            var nodes = BuildTree();

            // a. Find the root node
            var root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            // b. Find all leafs
            var allLeafs = FindAllLeafs(nodes);
            Console.WriteLine("All leafs: " + string.Join(", ", allLeafs));

            // c. Find all middle nodes
            var middleNodes = FindAllMiddleNodes(nodes);
            Console.WriteLine("All middle nodes: " + string.Join(", ", middleNodes));

            // d. Find the longest path
            Console.WriteLine("Longest path: " + FindLongestPath(root));

            // e. Find all paths with given sum
            paths = new List<IList<TreeNode<int>>>();
            FindAllPathsWithSum(root, 9, 0, new List<TreeNode<int>>());
            Console.WriteLine("All paths with sum 9:");
            foreach (var path in paths)
            {
                Console.WriteLine(string.Join(", ", path));
            }

            // f.Find all subtrees with given sum
            Console.WriteLine("All subrees with sum 12:");
            FindAllSubtreesWithSum(nodes, 12);
        }

        private static IList<TreeNode<int>> BuildTree()
        {
            int inputRows = int.Parse(Console.ReadLine());
            var nodes = new List<TreeNode<int>>();

            for (int i = 0; i < inputRows; i++)
            {
                nodes.Add(new TreeNode<int>(i));
            }

            for (int i = 0; i < inputRows - 1; i++)
            {
                string[] currentNodes = Console.ReadLine().Split();
                int parentValue = int.Parse(currentNodes[0]);
                int childValue = int.Parse(currentNodes[1]);

                nodes[parentValue].AddChild(nodes[childValue]);
            }

            return nodes;
        }

        private static TreeNode<int> FindRoot(IList<TreeNode<int>> nodes)
        {
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("The tree has no root.");
        }

        private static List<TreeNode<int>> FindAllLeafs(IList<TreeNode<int>> nodes)
        {
            var leafs = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.ChildrenCount == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static List<TreeNode<int>> FindAllMiddleNodes(IList<TreeNode<int>> nodes)
        {
            var middleNodes = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static int FindLongestPath(TreeNode<int> root)
        {
            if (root.ChildrenCount == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static void FindAllPathsWithSum(TreeNode<int> node, int wantedSum, int achievedSum, IList<TreeNode<int>> path)
        {
            achievedSum += node.Value;
            path.Add(node);
            if (achievedSum == wantedSum)
            {
                paths.Add(path);
                return;
            }

            foreach (var item in node.Children)
            {
                FindAllPathsWithSum(item, wantedSum, achievedSum, new List<TreeNode<int>>(path));
            }
        }

        public static void FindAllSubtreesWithSum(IList<TreeNode<int>> nodes, int sum)
        {
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            int currentSum = 0;
            foreach (var node in nodes)
            {
                var currentSubtreeNodes = new List<TreeNode<int>>();
                stack.Push(node);
                currentSum = 0;
                while (stack.Count > 0)
                {
                    TreeNode<int> currentNode = stack.Pop();
                    currentSum = currentNode.Value + currentSum;
                    currentSubtreeNodes.Add(currentNode);
                    foreach (var item in currentNode.Children)
                    {
                        stack.Push(item);
                    }
                }

                if (currentSum == sum)
                {
                    Console.WriteLine(string.Join(", ", currentSubtreeNodes));
                }
            }
        }
    }
}
