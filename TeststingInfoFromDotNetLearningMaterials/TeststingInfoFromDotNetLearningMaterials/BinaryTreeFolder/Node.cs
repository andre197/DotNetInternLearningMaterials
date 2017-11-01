namespace TeststingInfoFromDotNetLearningMaterials.BinaryTreeFolder
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Left = this.Right = null;
        }

        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}
