namespace Graph
{
    public class Edge
    {
        public Edge(int weight, Vertex to)
        {
            this.Weight = weight;
            this.VertexTo = to;
        }

        public int Weight { get; private set; }

        public Vertex VertexTo { get; private set; }
    }
}
