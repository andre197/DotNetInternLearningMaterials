namespace Graph
{
    using System.Collections.Generic;

    public class SimpleGraph
    {
        public List<Vertex> Verteces { get; set; } = new List<Vertex>();

        public Dictionary<string,int> FindShortestPaths(string startingVertexName)
        {
            Vertex vertex = this.Verteces.Find(v => v.Name == startingVertexName);

            Djikstra djikstra = new Djikstra();

            Dictionary<string, int> dic = djikstra.FindPaths(vertex, this.Verteces);

            return dic;
        }

        public void AddVertex(Vertex vertex)
        {
            this.Verteces.Add(vertex);
        }

        public void AddEdge(string nameVertexFrom, string nameVertexTo, int weight)
        {
            this.Verteces
                .Find(v => v.Name == nameVertexFrom)
                .AddEdge(this.Verteces
                    .Find(v => v.Name == nameVertexTo), weight);
        }

    }
}
