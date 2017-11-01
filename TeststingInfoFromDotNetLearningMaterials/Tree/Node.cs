namespace TreeProject
{
    using System;
    using System.Collections.Generic;

    public class Node<T>
    {
        private T value;

        private List<Node<T>> children;

        public Node(T value)
        {
            this.value = value;
            this.children = new List<Node<T>>();
        }

        public T Value => this.value;

        public IReadOnlyCollection<Node<T>> Children => this.children;

        public void AddChildren(Node<T> child)
        {
            if ( child != null)
            {
                this.children.Add(child);

                return;
            }

            throw new ArgumentNullException("The child cannot be null");
        }
    }
}
