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
                string verticesToConnect = Console.ReadLine();

                if (verticesToConnect == "end")
                {
                    break;
                }

                if (verticesToConnect == "check")
                {
                    Console.WriteLine(CheckIfAllRoomsAreAccessible());
                }
                else
                {
                    ConnectVerticesInMatrix(verticesToConnect, vertices);
                }

                PrintVertexData(vertex.Data);
            }
        }

        private bool CheckIfAllRoomsAreAccessible()
        {
            int[][] matrix = this.vertex.Data;

            int matrixRowLength = matrix.Length;
            int matrixColLength = matrix[0].Length;

            bool[][] visited = new bool[matrixRowLength][];

            for (int i = 0; i < matrixRowLength; i++)
            {
                visited[i] = new bool[matrixColLength];
            }

            bool isBroken = false;

            for (int i = 0; i < matrixRowLength; i++)
            {
                for (int j = 0; j < matrixColLength; j++)
                {
                    if (matrix[i][j] == 0 && !visited[i][j])
                    {
                        Dfs(matrix, i, j, visited);

                        isBroken = true;

                        break;
                    }
                }

                if (isBroken)
                {
                    break;
                }
            }
            for (int i = 0; i < matrixRowLength; i++)
            {
                for (int j = 0; j < matrixColLength; j++)
                {
                    if (matrix[i][j] == 0 && !visited[i][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Dfs(int[][] matrix, int row, int col, bool[][] visited)
        {
            int[] rowNumber = new int[] { -1, 1, 0, 0 };
            int[] colNumber = new int[] { 0, 0, 1, -1 };

            visited[row][col] = true;

            for (int i = 0; i < rowNumber.Length; i++)
            {
                int newRow = row + rowNumber[i];
                int newCol = col + colNumber[i];

                if (CanGo(matrix, newRow, newCol, visited))
                {
                    Dfs(matrix, newRow, newCol, visited);
                }
            }
        }

        private bool CanGo(int[][] matrix, int newRow, int newCol, bool[][] visited)
        {
            int matrixRowLength = matrix.Length;
            int matrixColLength = matrix[0].Length;

            return ((0 <= newRow && newRow < matrixRowLength)
                    && (0 <= newCol && newCol < matrixColLength)
                    && matrix[newRow][newCol] == 0
                    && !visited[newRow][newCol]);
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
