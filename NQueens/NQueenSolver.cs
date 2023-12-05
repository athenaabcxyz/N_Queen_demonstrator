using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    public class NQueenSolver
    {
        int[,] board;
        List<int[,]> solutionList;

        public NQueenSolver(int n)
        {
            board = generateBoard(n);
            solutionList = new List<int[,]>();
        }
        public List<int[,]> solve(int n)
        {
            for (int i = 0; i < n; i++)
            {
                board[0, i] = 1;
                solveNQueens(reloadBoard(board, n), n, 1, 1);
                board[0, i] = 0;
                board = reloadBoard(board, n);
            }
            return solutionList;
        }
        int[,] generateBoard(int n)
        {
            int[,] board = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = 0;
                }
            }
            return board;
        }

        int[,] clearDeactive(int[,] board, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == -1)
                        board[i, j] = 0;
                }
            }
            return board;
        }

        int[,] reloadBoard(int[,] board, int n)
        {
            board = clearDeactive(board, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((board[i, j] == 1))
                    {
                        QueenKill(board, i, j, n);
                    }
                }
            }
            return board;
        }

        //Deactive all horizontal, vertical and diagonal zone when a queen is placed
        int[,] QueenKill(int[,] board, int row, int col, int n)
        {
            //Kill row
            for (int a = 0; a < n; a++)
            {
                if (board[row, a] != 1)
                    board[row, a] = -1;
            }

            //Kill column
            for (int a = 0; a < n; a++)
            {
                if (board[a, col] != 1)
                    board[a, col] = -1;
            }

            //Kill diagonally
            for (int a = row, b = col; a >= 0 && a < n && b >= 0 && b < n; a++, b++)
            {
                if (board[a, b] != 1)
                    board[a, b] = -1;
            }
            for (int a = row, b = col; a >= 0 && a < n && b >= 0 && b < n; a--, b++)
            {
                if (board[a, b] != 1)
                    board[a, b] = -1;
            }
            for (int a = row, b = col; a >= 0 && a < n && b >= 0 && b < n; a++, b--)
            {
                if (board[a, b] != 1)
                    board[a, b] = -1;
            }
            for (int a = row, b = col; a >= 0 && a < n && b >= 0 && b < n; a--, b--)
            {
                if (board[a, b] != 1)
                    board[a, b] = -1;
            }
            return board;
        }

        void solveNQueens(int[,] board, int n, int row, int queenPlaced)
        {

            if (queenPlaced == n)
            {
                PrintSolution(board, n);
                return;
            }
            else
            {
                if (row == n)
                {
                    return;
                }
                else
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            queenPlaced++;
                            board[row, col] = 1;
                            solveNQueens(reloadBoard(board, n), n, row + 1, queenPlaced);
                            board[row, col] = 0;
                            board = reloadBoard(board, n);
                            queenPlaced--;
                        }
                    }
                }
            }

        }
        int[,] CopyBoard(int[,] board, int n)
        {
            int[,] newboard = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newboard[i, j] = board[i, j];
                }
            }
            return newboard;
        }
        int[,] rotateMatrixByThreeHours(int[,] matrix, int n)
        {
            int[,] rotatebyquarter = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rotatebyquarter[i, j] = matrix[n - 1 - j, i];
                }
            }
            return rotatebyquarter;
        }
        int[,] reflectMatrixByX(int[,] matrix, int n)
        {
            int[,] refection = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    refection[i, j] = matrix[n - 1 - i, j];
                }
            }
            return refection;
        }

        int[,] reflectMatrixByY(int[,] matrix, int n)
        {
            int[,] refection = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    refection[i, j] = matrix[i, n - 1 - j];
                }
            }
            return refection;
        }

        bool isHasReflectionMatch(int[,] first, int[,] second, int n)
        {
            int[,] boardX = reflectMatrixByX(second, n);
            int[,] boardY = reflectMatrixByY(second, n);
            if (matrixEqualComapare(first, second, n) || matrixEqualComapare(first, boardY, n) || matrixEqualComapare(first, boardX, n))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        bool isSolutionExisted(int[,] board, int n)
        {
            int[,] board90 = rotateMatrixByThreeHours(board, n);
            int[,] board180 = rotateMatrixByThreeHours(board90, n);
            int[,] board270 = rotateMatrixByThreeHours(board180, n);

            for (int solution = 0; solution < solutionList.Count; solution++)
            {
                if (isHasReflectionMatch(solutionList[solution], board, n) || isHasReflectionMatch(solutionList[solution], board90, n) || isHasReflectionMatch(solutionList[solution], board180, n) || isHasReflectionMatch(solutionList[solution], board270, n))
                {
                    return true;
                }
            }
            return false;
        }
        bool matrixEqualComapare(int[,] a, int[,] b, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        void PrintSolution(int[,] board, int n)
        {
            if (!isSolutionExisted(board, n))
            {
                solutionList.Add(CopyBoard(board, n));
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (board[i, j] == 1) ;
                    }
                }
            }

        }
    }
}
