namespace Graph
{
    using System.Collections.Generic;

    public class SimpleGraph
    {
        public List<Vertex> Verteces { get; set; } = new List<Vertex>();

        public void AddVertex(string name, int weight)
        {
            Vertex vertex = new Vertex()
            {
                Name = name,
                Weigtht = weight
            };

            this.Verteces.Add(vertex);
        }

        public void AddEdge(string nameVertexFrom, string nameVertexTo)
        {
            this.Verteces
                .Find(v => v.Name == nameVertexFrom)
                .Edges
                .Add(this.Verteces
                    .Find(v => v.Name == nameVertexTo));
        }


    }
}
