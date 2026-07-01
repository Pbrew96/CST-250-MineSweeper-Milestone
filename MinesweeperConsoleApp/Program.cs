using Milestone1.MineSweeperClassLibrary.BusinessLogic;
using Milestone1.MineSweeperClassLibrary.Models;

namespace MinesweeperConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        // Display a welcome message.
        Console.WriteLine("Hello, welcome to Minesweeper\n");

        // Create the game logic object.
        BoardLogic boardLogic = new BoardLogic();

        // Create a 4x4 game board and set the difficulty.
        BoardModel board = new BoardModel(4);
        board.Difficulty = 1;

        // Place bombs on the board and calculate neighboring bomb counts.
        boardLogic.SetupBombs(board);
        boardLogic.CountBombsNearby(board);

        Random random = new Random();

        int rewardRow;
        int rewardCol;

        // Randomly place one reward on a cell that is not a bomb.
        do
        {
            rewardRow = random.Next(0, board.Size);
            rewardCol = random.Next(0, board.Size);
        }
        while (board.Cells[rewardRow, rewardCol].IsBomb);

        board.Cells[rewardRow, rewardCol].HasSpecialReward = true;

        // Display the answer key for testing purposes.
        Console.WriteLine("Here is the answer key for the first board");
        PrintAnswers(board);

        // Start the game.
        GameState state = GameState.StillPlaying;

        // Continue playing until the player wins or loses.
        while (state == GameState.StillPlaying)
        {
            // Display the current game board.
            PrintBoard(board);

            int row;
            Console.WriteLine("Enter the row number:");

            // Validate the row input.
            while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row >= board.Size)
            {
                Console.WriteLine("Invalid row. Enter a number between 0 and " + (board.Size - 1));
            }

            int col;
            Console.WriteLine("Enter the column number:");

            // Validate the column input.
            while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col >= board.Size)
            {
                Console.WriteLine("Invalid column. Enter a number between 0 and " + (board.Size - 1));
            }

            int move;
            Console.WriteLine("Enter 1 to visit the cell, 2 to flag the cell, 3 to use a reward:");

            // Validate the player's move selection.
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 3)
            {
                Console.WriteLine("Invalid move. Enter 1, 2, or 3.");
            }

            // Visit the selected cell.
            if (move == 1)
            {
                board.Cells[row, col].IsVisited = true;

                // Award a reward if one is found.
                if (board.Cells[row, col].HasSpecialReward)
                {
                    board.RewardsRemaining++;
                    Console.WriteLine("You found a reward!");
                }
            }
            // Place a flag on the selected cell.
            else if (move == 2)
            {
                board.Cells[row, col].IsFlagged = true;
            }
            // Use a reward to reveal if a selected cell is a bomb.
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

            // Check if the game has been won or lost.
            state = boardLogic.DetermineGameState(board);
        }

        // Display the completed board.
        PrintBoard(board);

        // Display the final game result.
        if (state == GameState.GameWon)
        {
            Console.WriteLine("Congratulations! You won!");
        }
        else
        {
            Console.WriteLine("You hit a bomb. Game over.");
        }
    }

    /// <summary>
    /// Displays the answer key showing bombs, rewards, and neighboring bomb counts.
    /// </summary>
    public static void PrintAnswers(BoardModel board)
    {
        // Print column labels and the top border.
        PrintColumnNumbers(board.Size);
        PrintDividerLine(board.Size);

        // Loop through every cell on the board.
        for (int row = 0; row < board.Size; row++)
        {
            Console.Write(row.ToString().PadLeft(2) + " ");

            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("| ");

                CellModel cell = board.Cells[row, col];

                // Display rewards, bombs, numbers, or empty spaces.
                if (cell.HasSpecialReward)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("R");
                    Console.ResetColor();
                }
                else if (cell.IsBomb)
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

    /// <summary>
    /// Prints the column numbers across the top of the board.
    /// </summary>
    private static void PrintColumnNumbers(int size)
    {
        Console.Write("   ");

        for (int col = 0; col < size; col++)
        {
            Console.Write("  " + col + " ");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Prints the divider line between rows.
    /// </summary>
    private static void PrintDividerLine(int size)
    {
        Console.Write("   ");

        for (int col = 0; col < size; col++)
        {
            Console.Write("+---");
        }

        Console.WriteLine("+");
    }

    /// <summary>
    /// Sets a different console color for each neighboring bomb count.
    /// </summary>
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

    /// <summary>
    /// Displays the current game board that the player sees.
    /// </summary>
    public static void PrintBoard(BoardModel board)
    {
        Console.WriteLine("Here is the current board");

        PrintColumnNumbers(board.Size);
        PrintDividerLine(board.Size);

        // Loop through every cell and display its current state.
        for (int row = 0; row < board.Size; row++)
        {
            Console.Write(row.ToString().PadLeft(2) + " ");

            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("| ");

                CellModel cell = board.Cells[row, col];

                // Display flags, hidden cells, bombs, numbers, or empty cells.
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
    }
}