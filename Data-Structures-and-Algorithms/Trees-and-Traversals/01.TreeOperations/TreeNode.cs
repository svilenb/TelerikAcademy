namespace _01.TreeOperations
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private IList<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
        }

        public IList<TreeNode<T>> Children
        {
            get
            {
                return new List<TreeNode<T>>(this.children);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Children", "Children cannot be null!");
                }

                this.children = value;
            }
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
