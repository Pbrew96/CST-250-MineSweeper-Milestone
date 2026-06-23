using Milestone1.MineSweeperClassLibrary.BusinessLogic;
using Milestone1.MineSweeperClassLibrary.Models;

namespace MinesweeperConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to Minesweeper\n");

        BoardLogic boardLogic = new BoardLogic();

        Console.WriteLine("Here is the answer key for the first board");

        BoardModel board1 = new BoardModel(10);
        board1.Difficulty = 1;

        boardLogic.SetupBombs(board1);
        boardLogic.CountBombsNearby(board1);

        PrintAnswers(board1);

        Console.WriteLine();

        Console.WriteLine("Here is the answer key for the second board");

        BoardModel board2 = new BoardModel(15);
        board2.Difficulty = 1;

        boardLogic.SetupBombs(board2);
        boardLogic.CountBombsNearby(board2);

        PrintAnswers(board2);
    
    }

        /*    GameState state = GameState.StillPlaying;

            while (state == GameState.StillPlaying)
            {
                PrintBoard(board);

                int row;
                Console.WriteLine("Enter the row number:");

                while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row >= board.Size)
                {
                    Console.WriteLine("Invalid row. Enter a number between 0 and " + (board.Size - 1));
                }

                int col;
                Console.WriteLine("Enter the column number:");

                while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col >= board.Size)
                {
                    Console.WriteLine("Invalid column. Enter a number between 0 and " + (board.Size - 1));
                }

                int move;
                Console.WriteLine("Enter 1 to visit the cell, 2 to flag the cell, 3 to use a reward:");

                while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 3)
                {
                    Console.WriteLine("Invalid move. Enter 1, 2, or 3.");
                }

                if (move == 1)
                {
                    board.Cells[row, col].IsVisited = true;

                    if (board.Cells[row, col].HasSpecialReward)
                    {
                        board.RewardsRemaining++;
                        Console.WriteLine("You found a reward!");
                    }
                }
                else if (move == 2)
                {
                    board.Cells[row, col].IsFlagged = true;
                }
                else if (move == 3)
                {
                    if (board.RewardsRemaining > 0)
                    {
                        Console.WriteLine($"Is it a bomb? {board.Cells[row, col].IsBomb}");
                        board.RewardsRemaining--;
                    }
                    else
                    {
                        Console.WriteLine("You do not have any rewards to use.");
                    }
                }

                state = boardLogic.DetermineGameState(board);
            }

            PrintBoard(board);

            if (state == GameState.GameWon)
            {
                Console.WriteLine("Congratulations! You won!");
            }
            else
            {
                Console.WriteLine("You hit a bomb. Game over.");
            }
       */
    


    public static void PrintAnswers(BoardModel board)
    {
        PrintColumnNumbers(board.Size);
        PrintDividerLine(board.Size);

        for (int row = 0; row < board.Size; row++)
        {
            Console.Write(row.ToString().PadLeft(2) + " ");

            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("| ");

                CellModel cell = board.Cells[row, col];

                if (cell.IsBomb)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("B");
                    Console.ResetColor();
                }
                else if (cell.NumberOfBombNeighbors > 0)
                {
                    SetNumberColor(cell.NumberOfBombNeighbors);
                    Console.Write(cell.NumberOfBombNeighbors);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(".");
                }

                Console.Write(" ");
            }

            Console.WriteLine("|");
            PrintDividerLine(board.Size);
        }

        Console.WriteLine();
    }

    private static void PrintColumnNumbers(int size)
    {
        Console.Write("   ");

        for (int col = 0; col < size; col++)
        {
            Console.Write("  " + col + " ");
        }

        Console.WriteLine();
    }

    private static void PrintDividerLine(int size)
    {
        Console.Write("   ");

        for (int col = 0; col < size; col++)
        {
            Console.Write("+---");
        }

        Console.WriteLine("+");
    }

    private static void SetNumberColor(int number)
    {
        if (number == 1)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        else if (number == 2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (number == 3)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
    public static void PrintBoard(BoardModel board)
    {
        Console.WriteLine("Here is the current board");

        PrintColumnNumbers(board.Size);
        PrintDividerLine(board.Size);

        for (int row = 0; row < board.Size; row++)
        {
            Console.Write(row.ToString().PadLeft(2) + " ");

            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("| ");

                CellModel cell = board.Cells[row, col];

                if (cell.IsFlagged)
                {
                    Console.Write("F");
                }
                else if (!cell.IsVisited)
                {
                    Console.Write("?");
                }
                else if (cell.IsBomb)
                {
                    Console.Write("B");
                }
                else if (cell.NumberOfBombNeighbors > 0)
                {
                    Console.Write(cell.NumberOfBombNeighbors);
                }
                else
                {
                    Console.Write(".");
                }

                Console.Write(" ");
            }

            Console.WriteLine("|");
            PrintDividerLine(board.Size);
        }
    }
}

