namespace Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Djikstra
    {
        public Dictionary<string, int> FindPaths(Vertex vertex, List<Vertex> verteces)
        {
            Dictionary<string, int> pathToVerteces = new Dictionary<string, int>();

            foreach (var v in verteces)
            {
                pathToVerteces[v.Name] = int.MaxValue;
            }

            pathToVerteces[vertex.Name] = 0;

            Vertex currentVertex = vertex;

            Stack<Edge> vertexEdges = new Stack<Edge>(currentVertex.Edges);

            while (vertexEdges.Count > 0)
            {
                foreach (var currentEdge in vertexEdges)
                {
                    if ((currentEdge.Weight + pathToVerteces[currentVertex.Name]) < pathToVerteces[currentEdge.VertexTo.Name])
                    {
                        pathToVerteces[currentEdge.VertexTo.Name] = currentEdge.Weight + pathToVerteces[currentVertex.Name];
                    }
                }

                currentVertex = vertexEdges.Pop().VertexTo;

                for (int i = 0; i < currentVertex.Edges.Count; i++)
                {
                    vertexEdges.Push(currentVertex.Edges[i]);
                }
            }

            //while (currentVertex.Edges.Count > 0)
            //{
            //    List<Edge> currentVertexEdges = new List<Edge>(currentVertex.Edges.OrderBy(e => e.Weight));

            //    for (int i = 0; i < currentVertexEdges.Count; i++)
            //    {
            //        var currentEdge = currentVertexEdges[i];

            //        if ((currentEdge.Weight + pathToVerteces[currentVertex.Name]) < pathToVerteces[currentEdge.VertexTo.Name])
            //        {
            //            pathToVerteces[currentEdge.VertexTo.Name] = currentEdge.Weight + pathToVerteces[currentVertex.Name];
            //        }
            //    }

            //    var nexVertexEdge = currentVertexEdges
            //                    .OrderBy(e => e.Weight)
            //                    .Where(e => e.VertexTo != null
            //                        && e.VertexTo.Edges.Count > 0)
            //                    .FirstOrDefault();

            //    if (nexVertexEdge != null)
            //    {
            //        currentVertex = nexVertexEdge.VertexTo;

            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            return pathToVerteces;
        }
    }
}

//if ((currentEdge.Weight + pathToVerteces[currentVertex.Name]) < pathToVerteces[currentEdge.VertexTo.Name])
//                {
//                    pathToVerteces[currentEdge.VertexTo.Name] = currentEdge.Weight + pathToVerteces[currentVertex.Name];
//                }