namespace TeststingInfoFromDotNetLearningMaterials.ImplementationOfGraphs
{
    using AdjencyMatrixImplementation;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateMatrix
    {
        private const int FreeCellValue = 0;
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

                if (verticesToConnect == "check")
                {
                    CheckIfTheRoomIsReachable();
                }

                ConnectVerticesInMatrix(verticesToConnect, vertices);

                PrintVertexData(vertex.Data);
            }
        }

        private bool CheckIfTheRoomIsReachable()
        {
            int[][] matrix = this.vertex.Data;

            int matrixColLength = matrix.Length;
            int matrixRowLength = matrix.Length;

            bool[][] visited = new bool[matrixColLength][];

            for (int i = 0; i < matrixColLength; i++)
            {
                visited[i] = new bool[matrixRowLength];
            }

            for (int i = 0; i < matrixRowLength; i++)
            {
                for (int j = 0; j < matrixColLength; j++)
                {
                    if (matrix[i][j] == FreeCellValue && !visited[i][j])
                    {
                        BFS(matrix, i, j, visited);
                    }
                }
            }

            throw new NotImplementedException();
        }

        private void BFS(int[][] matrix, int i, int j, bool[][] visited)
        {
            throw new NotImplementedException();
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

            this.vertex.Index = (indexOfFirstVertice, indexOfSecodnVertice);

            AddConnection(vertex);
        }

        private void AddConnection(MatrixVertex<int[][]> vertex)
        {
            this.vertex.Data[vertex.Index.Item1][vertex.Index.Item2] += 1;
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
