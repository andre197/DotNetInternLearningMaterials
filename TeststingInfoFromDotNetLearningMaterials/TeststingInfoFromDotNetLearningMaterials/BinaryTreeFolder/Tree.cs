
namespace TeststingInfoFromDotNetLearningMaterials.BinaryTreeFolder
{
    using System;
    using System.Text;

    public class BinaryTree
    {
        public Node InsertNode(int value, Node node)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value > node.Value)
            {
                node.Left = InsertNode(value, node.Left);
            }
            else
            {
                node.Right = InsertNode(value, node.Right);
            }

            return node;

        }

        public void TraverseDFS(Node tree, string spaces)
        {
            if (tree == null)
            {
                return;
            }

            Console.WriteLine(spaces + tree.Value.ToString());

            TraverseDFS(tree.Left, spaces + "    ");
            TraverseDFS(tree.Right, spaces + "     ");
        }
    }
}
