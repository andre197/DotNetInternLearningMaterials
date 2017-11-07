namespace Graph
{
    using System.Collections;
    using System.Collections.Generic;

    public class Vertex
    {
        public string Name { get; set; }

        public List<Edge> Edges { get; set; } = new List<Edge>();

        public bool IsVisited { get; set; }

        public void AddEdge(Vertex vertexTo, int weight)
        {
            this.Edges.Add(new Edge(weight, vertexTo));
        }
    }
}
