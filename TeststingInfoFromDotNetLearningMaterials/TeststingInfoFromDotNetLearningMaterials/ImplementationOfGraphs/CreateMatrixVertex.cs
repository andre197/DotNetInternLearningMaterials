namespace TeststingInfoFromDotNetLearningMaterials.ImplementationOfGraphs
{
    using AdjencyMatrixImplementation;
    using System;

    public class CreateMatrix
    {
        private MatrixVertex<int[][]> vertex = new MatrixVertex<int[][]>();

        public void CreateMatrixVertex(string vertices)
        {
            int matrixSize = vertices.Length;

            vertex.Data = CreateTheMatrix(matrixSize);

            PrintVertexData(vertex.Data);

            while (true)
            {
                string verticesToConnect = Console.ReadLine();

                if (verticesToConnect == "end")
                {
                    break;
                }

                ConnectVerticesInMatrix(verticesToConnect, vertices);

                PrintVertexData(vertex.Data);
            }
        }

        private int[][] CreateTheMatrix(int rowsAndCols)
        {
            int[][] arr = new int[rowsAndCols][];

            for (int i = 0; i < rowsAndCols; i++)
            {
                arr[i] = new int[rowsAndCols];
            }

            return arr;
        }

        private void ConnectVerticesInMatrix(string verticesToConnect, string vertices)
        {

            int indexOfFirstVertice = vertices.IndexOf(verticesToConnect[0]);
            int indexOfSecodnVertice = vertices.IndexOf(verticesToConnect[1]);

            vertex.Index = (indexOfFirstVertice, indexOfSecodnVertice);

            AddConnection(vertex);
        }

        private void AddConnection(MatrixVertex<int[][]> vertex)
        {
            vertex.Data[vertex.Index.Item1][vertex.Index.Item2] += 1;
        }

        private void PrintVertexData(int[][] data)
        {
            foreach (var row in data)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
