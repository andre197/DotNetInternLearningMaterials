namespace GraphsProject
{
    public class MatrixAccessabilityChecker
    {
        public bool CheckIfAllRoomsAreAccessibleUsingDFS(int[][] matrix)
        {
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
                    if (matrix[i][j] >= 0 && !visited[i][j])
                    {
                        CellStepsChecker(matrix, i, j, visited);

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

        private void CellStepsChecker(int[][] matrix, int row, int col, bool[][] visited)
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
                    CellStepsChecker(matrix, newRow, newCol, visited);
                }
            }
        }

        private bool CanGo(int[][] matrix, int newRow, int newCol, bool[][] visited)
        {
            int matrixRowLength = matrix.Length;
            int matrixColLength = matrix[0].Length;

            return ((0 <= newRow && newRow < matrixRowLength)
                    && (0 <= newCol && newCol < matrixColLength)
                    && matrix[newRow][newCol] >= 0
                    && !visited[newRow][newCol]);
        }
    }
}
