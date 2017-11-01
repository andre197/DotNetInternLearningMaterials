namespace TreeProject
{
    using System;
    using System.Collections.Generic;

    public class Tree<T>
    {
        private Node<T> root;

        public Tree(T value)
        {
            this.root = new Node<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) 
            : this(value)
        {
            foreach (var child in children)
            {
                this.root.AddChildren(child.root);
            }
        }

        public Node<T> Root => this.root;

        public void PrintDFSTraverse(Node<T> root, string spaces)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            foreach (var child in this.root.Children)
            {
                PrintDFSTraverse(child, spaces + "  ");
            }
        }

        public void PrintBFSTraverse(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            var parentQueue = new Queue<Node<T>>();

            parentQueue.Enqueue(root);

            while (parentQueue.Count > 0)
            {
                var current = parentQueue.Dequeue();

                // TreeProject.Node`1[System.Int32] writes this. Dont know how to fix it :/
                Console.WriteLine(current.Value + " ");

                var childQueue = new Queue<Node<T>>(current.Children);

                foreach (var child in childQueue)
                {
                    parentQueue.Enqueue(child);
                }
            }
            
        }
    }
}
