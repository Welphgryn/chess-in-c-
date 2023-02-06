using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the chess board
            char[,] board = new char[8, 8]
            {
                {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'},
                {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'},
                {'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r'},
            };

            // Display the chess board
            Console.WriteLine("Welcome to Chess!");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
            }

            // Check for checkmate
            bool checkmate = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 'K')
                    {
                        // Check if the king is in check
                        if (IsInCheck(board, i, j))
                        {
                            checkmate = true;
                            break;
                        }
                    }
                }
            }

            if (checkmate)
            {
                Console.WriteLine("\nCheckmate! White wins.");
            }
            else
            {
                Console.WriteLine("\nThe game continues.");
            }
            Console.ReadLine();
        }

        static bool IsInCheck(char[,] board, int row, int col)
        {
            // Check for attacks from black pawns
            if (row > 0 && col > 0 && board[row - 1, col - 1] == 'p')
            {
                return true;
            }
            if (row > 0 && col < 7 && board[row - 1, col + 1] == 'p')
            {
                return true;
            }

            // Check for attacks from black rooks, queens
            for (int i = row, j = col; i >= 0; i--)
            {
                if (board[i, col] == 'r' || board[i, col] == 'q')
                {
                    return true;
                }
                if (board[i, col] != ' ')
                {
                    break;
                }
            }
            for (int i = row, j = col; i < 8; i++)
            {
                if (board[i, col] == 'r' || board[i, col] == 'q')
                {
                    return true;
                }
                if (board[i, col] != ' ')
                {
                    break;
                }
            }
            for (int i = row, j = col; j >= 0; j--)
            {
                if (board[row, j] == 'r' || board[row, j] == 'q')
                {
                    return true;
                }
                if (board[row, j] != ' ')
                {
                    break;
                }
            }
            for (int i = row, j = col; j < 8; j++)
            {
                if (board[row, j] == 'r' || board[row, j] == 'q')
                {
                    return true;
                }
                if (board[row, j] != ' ')
                {
                    break;
                }
            }

            // Check for attacks from black bishops, queens
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 'b' || board[i, j] == 'q')
                {
                    return true;
                }
                if (board[i, j] != ' ')
                {
                    break;
                }
            }
            for (int i = row, j = col; i >= 0 && j < 8; i--, j++)
            {
                if (board[i, j] == 'b' || board[i, j] == 'q')
                {
                    return true;
                }
                if (board[i, j] != ' ')
                {
                    break;
                }
            }
            for (int i = row, j = col; i < 8 && j >= 0; i++, j--)
            {
                if (board[i, j] == 'b' || board[i, j] == 'q')
                {
                    return true;
                }
                if (board[i, j] != ' ')
                {
                    break;
                }
            }
            for (int i = row, j = col; i < 8 && j < 8; i++, j++)
            {
                if (board[i, j] == 'b' || board[i, j] == 'q')
                {
                    return true;
                }
                if (board[i, j] != ' ')
                {
                    break;
                }
            }

            // Check for attacks from black knights
            if (row > 1 && col > 0 && board[row - 2, col - 1] == 'n')
            {
                return true;
            }
            if (row > 1 && col < 7 && board[row - 2, col + 1] == 'n')
            {
                return true;
            }
            if (row > 0 && col > 1 && board[row - 1, col - 2] ==
                return true;
            }
            if (row > 0 && col < 6 && board[row - 1, col + 2] == 'n')
            {
                return true;
            }
            if (row < 6 && col > 0 && board[row + 2, col - 1] == 'n')
            {
                return true;
            }
            if (row < 6 && col < 7 && board[row + 2, col + 1] == 'n')
            {
                return true;
            }
            if (row < 7 && col > 1 && board[row + 1, col - 2] == 'n')
            {
                return true;
            }
            if (row < 7 && col < 6 && board[row + 1, col + 2] == 'n')
            {
                return true;
            }

            // Check for attacks from black pawns
            if (row > 0 && col > 0 && board[row - 1, col - 1] == 'p')
            {
                return true;
            }
            if (row > 0 && col < 7 && board[row - 1, col + 1] == 'p')
            {
                return true;
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            board.InitializeBoard();

            while (!board.IsCheckMate())
            {
                Console.WriteLine("Enter the move (ex: e2 e4): ");
                string move = Console.ReadLine();
                board.MovePiece(move);
                Console.WriteLine(board.ToString());
            }

            Console.WriteLine("Checkmate! Game over.");
            Console.ReadLine();
        }
    }
}
