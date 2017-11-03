namespace GraphsProject
{
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
                string[] input = Console.ReadLine().Split();

                if (input[0] == "end")
                {
                    break;
                }

                if (input[0] == "check")
                {
                    MatrixAccessabilityChecker checker = new MatrixAccessabilityChecker();

                    Console.WriteLine(checker.CheckIfAllRoomsAreAccessibleUsingDFS(this.vertex.Data));
                }
                else if (input[0] == "find")
                {
                    string from = Console.ReadLine();
                    string to = Console.ReadLine();

                    DijkstrasAlgorithmImplementation dai = new DijkstrasAlgorithmImplementation();

                    string result = dai.FindShortestPathToVertex(this.vertex.Data, from, to, vertices);

                    Console.WriteLine(result);
                }
                else
                {
                    int value = 0;

                    if (input.Length == 2)
                    {
                        value = int.Parse(input[1]);
                    }

                    ConnectVerticesInMatrix(input[0], vertices, value);
                }

                PrintVertexData(vertex.Data);
            }
        }

        //private bool CheckIfAllRoomsAreAccessible(int[][] matrix)
        //{
        //    int matrixRowLength = matrix.Length;
        //    int matrixColLength = matrix[0].Length;

        //    bool[][] visited = new bool[matrixRowLength][];

        //    for (int i = 0; i < matrixRowLength; i++)
        //    {
        //        visited[i] = new bool[matrixColLength];
        //    }

        //    bool isBroken = false;

        //    for (int i = 0; i < matrixRowLength; i++)
        //    {
        //        for (int j = 0; j < matrixColLength; j++)
        //        {
        //            if (matrix[i][j] == 0 && !visited[i][j])
        //            {
        //                Dfs(matrix, i, j, visited);

        //                isBroken = true;

        //                break;
        //            }
        //        }

        //        if (isBroken)
        //        {
        //            break;
        //        }
        //    }
        //    for (int i = 0; i < matrixRowLength; i++)
        //    {
        //        for (int j = 0; j < matrixColLength; j++)
        //        {
        //            if (matrix[i][j] == 0 && !visited[i][j])
        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    return true;
        //}

        //private void Dfs(int[][] matrix, int row, int col, bool[][] visited)
        //{
        //    int[] rowNumber = new int[] { -1, 1, 0, 0 };
        //    int[] colNumber = new int[] { 0, 0, 1, -1 };

        //    visited[row][col] = true;

        //    for (int i = 0; i < rowNumber.Length; i++)
        //    {
        //        int newRow = row + rowNumber[i];
        //        int newCol = col + colNumber[i];

        //        if (CanGo(matrix, newRow, newCol, visited))
        //        {
        //            Dfs(matrix, newRow, newCol, visited);
        //        }
        //    }
        //}

        //private bool CanGo(int[][] matrix, int newRow, int newCol, bool[][] visited)
        //{
        //    int matrixRowLength = matrix.Length;
        //    int matrixColLength = matrix[0].Length;

        //    return ((0 <= newRow && newRow < matrixRowLength)
        //            && (0 <= newCol && newCol < matrixColLength)
        //            && matrix[newRow][newCol] == 0
        //            && !visited[newRow][newCol]);
        //}

        private int[][] CreateTheMatrix(int rowsAndCols)
        {
            int[][] arr = new int[rowsAndCols][];

            for (int i = 0; i < rowsAndCols; i++)
            {
                arr[i] = new int[rowsAndCols];

                for (int j = 0; j < rowsAndCols; j++)
                {
                    arr[i][j] = -1;
                }
            }

            return arr;
        }

        private void ConnectVerticesInMatrix(string verticesToConnect, string vertices, int value = 0)
        {

            int indexOfFirstVertice = vertices.IndexOf(verticesToConnect[0]);
            int indexOfSecodnVertice = vertices.IndexOf(verticesToConnect[1]);

            vertex.Index = (indexOfFirstVertice, indexOfSecodnVertice);

            AddConnection(vertex, value);
        }

        private void AddConnection(MatrixVertex<int[][]> vertex, int value = 0)
        {
            vertex.Data[vertex.Index.Item1][vertex.Index.Item2] = value;
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
