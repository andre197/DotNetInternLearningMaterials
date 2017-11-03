namespace Graph
{
    using System.Collections.Generic;

    public class Djikstra
    {
        public string FindPath(List<Vertex> verteces, string startPoint)
        {
            Dictionary<string, int> vertecesNames = new Dictionary<string, int>();

            foreach (var item in verteces)
            {
                vertecesNames[item.Name] = int.MaxValue;
            }

            Queue<Vertex> edgesToOtherVerteces = new Queue<Vertex>();

            Vertex vertex = verteces.Find(v => v.Name == startPoint);

            while (true)
            {
                for (int i = 0; i < vertex.Edges.Count; i++)
                {
                    edgesToOtherVerteces.Enqueue(vertex.Edges[i]);
                }

            }

            return null;
        }
    }
}
