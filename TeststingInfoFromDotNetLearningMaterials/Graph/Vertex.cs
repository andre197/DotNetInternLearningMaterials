namespace Graph
{
    using System.Collections.Generic;

    public class Vertex
    {
        public string Name { get; set; }

        public int Weigtht { get; set; }

        public List<Vertex> Edges { get; set; } = new List<Vertex>();

        public void AddEdge(Vertex vertex)
        {
            this.Edges.Add(vertex);
        }
    }
}
