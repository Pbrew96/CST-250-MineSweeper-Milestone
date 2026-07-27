/* Patrick Brewster
 * CST-250
 * Milestone 5
 * Minesweeper Game
 * 7/19/2026
 */

using Milestone1.MineSweeperClassLibrary.BusinessLogic;
using Milestone1.MineSweeperClassLibrary.Models;
using MineSweeperClassLibrary.Models;
using MineSweeperClassLibrary.Services.DataAccessLayer;
using System.IO;
namespace MinesweeperGUI


{
    public partial class FrmGame : Form
    {
        private int _boardSize;
        private int _difficulty;
        private BoardModel _board;
        private BoardLogic _boardLogic;
        private Button[,] _buttons;
        private DateTime _startTime;
        private int _score;
        private bool _rewardFound = false;
        private GameSaveDAO _gameSaveDAO;

        private Image img1 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper1.png"));

        private Image img2 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper2.png"));

        private Image img3 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper3.png"));

        private Image img4 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper4.png"));

        private Image img5 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper5.png"));

        private Image img6 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper6.png"));

        private Image img7 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper7.png"));

        private Image img8 = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeper8.png"));

        private Image imgBomb = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeperbomb.png"));

        private Image imgFlag = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeperflag.png"));

        private Image imgReward = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeperreward.png"));

        private Image imgSelected = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweepersel.png"));

        private Image imgUnselected = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Minesweeperunsel.png"));

        /// <summary>
        /// Creates the game form using the selected size and difficulty
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="difficulty"></param>
        public FrmGame(int boardSize, int difficulty)
        {
            InitializeComponent();

            // Save the values received from the start form
            _boardSize = boardSize;
            _difficulty = difficulty;

            // Create the board logic object
            _boardLogic = new BoardLogic();

            // Create the save/load object
            _gameSaveDAO = new GameSaveDAO();

            // Create the game board
            _board = new BoardModel(_boardSize);

            // Set the selected difficulty
            _board.Difficulty = _difficulty;

            // Place bombs and count neighboring bombs
            _boardLogic.SetupBombs(_board);
            _boardLogic.CountBombsNearby(_board);
            Random random = new Random();

            int rewardRow;
            int rewardCol;

            do
            {
                rewardRow = random.Next(_board.Size);
                rewardCol = random.Next(_board.Size);
            }
            while (_board.Cells[rewardRow, rewardCol].IsBomb);

            _board.Cells[rewardRow, rewardCol].HasSpecialReward = true;

            // Create the button array
            _buttons = new Button[_boardSize, _boardSize];

            //Create game board
            CreateButtonGrid();

            // Save the time the game started
            _startTime = DateTime.Now;

            // Initialize the score
            _score = 0;

            // Update the labels
            lblStartTime.Text = _startTime.ToString("hh:mm:ss tt");
            lblScore.Text = _score.ToString();
        }
        /// <summary>
        /// Creates the Minesweeper button grid
        /// </summary>
        private void CreateButtonGrid()
        {
            // Clear any existing buttons
            pnlGameBoard.Controls.Clear();

            int padding = 2;
            // Calculate the largest button size that fits in the panel
            int buttonWidth = pnlGameBoard.ClientSize.Width / _boardSize;
            int buttonHeight = pnlGameBoard.ClientSize.Height / _boardSize;

            // Use the smaller value so the buttons stay square
            int buttonSize = Math.Min(buttonWidth, buttonHeight);

            // Loop through each board row
            for (int row = 0; row < _boardSize; row++)
            {
                // Loop through each board column
                for (int col = 0; col < _boardSize; col++)
                {
                    // Create a new button
                    Button button = new Button();

                    // Set the button size
                    button.Width = buttonSize;
                    button.Height = buttonSize;

                    // Set the button position
                    button.Left = col * buttonSize;
                    button.Top = row * buttonSize;

                    // Store the row and column in the button
                    button.Tag = new Point(row, col);

                    // Connect the button click event
                    button.Click += CellButtonClickEH;
                    button.MouseDown += CellButtonMouseDownEH;

                    // Add the button to the array
                    _buttons[row, col] = button;

                    // Add the button to the panel
                    pnlGameBoard.Controls.Add(button);
                }
            }
            UpdateButtonFaces();
        }
        /// <summary>
        /// Click event handler for each Minesweeper cell button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellButtonClickEH(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                Point location = (Point)clickedButton.Tag;

                int row = location.X;
                int col = location.Y;

                CellModel selectedCell = _board.Cells[row, col];

                // Do not allow a flagged or previously visited cell
                if (selectedCell.IsFlagged || selectedCell.IsVisited)
                {
                    return;
                }

                // Count visited cells before the move
                int visitedBeforeMove = CountVisitedCells();

                // Use flood fill for an empty safe cell
                if (!selectedCell.IsBomb &&
                    selectedCell.NumberOfBombNeighbors == 0)
                {
                    _boardLogic.FloodFill(_board, row, col);
                }
                else
                {
                    // Reveal the selected cell
                    selectedCell.IsVisited = true;
                }

                // Check whether the reward was revealed by this move
                if (!_rewardFound)
                {
                    for (int rewardRow = 0;
                         rewardRow < _board.Size;
                         rewardRow++)
                    {
                        for (int rewardCol = 0;
                             rewardCol < _board.Size;
                             rewardCol++)
                        {
                            CellModel cell =
                                _board.Cells[rewardRow, rewardCol];

                            if (cell.HasSpecialReward &&
                                cell.IsVisited)
                            {
                                ActivateSpecialReward(
                                    rewardRow,
                                    rewardCol);
                            }
                        }
                    }
                }

                // Count visited cells after the move
                int visitedAfterMove = CountVisitedCells();

                // Add points for newly revealed cells
                _score +=
                    visitedAfterMove - visitedBeforeMove;

                lblScore.Text = _score.ToString();

                // Update the appearance of the board
                UpdateButtonFaces();

                GameState state =
                    _boardLogic.DetermineGameState(_board);

                if (state == GameState.GameLost)
                {
                    MessageBox.Show(
                        "You hit a bomb. Game over.");

                    RevealBoard();
                    UpdateButtonFaces();
                }
                else if (state == GameState.GameWon)
                {
                    int finalScore =
                        _boardLogic.CalculateFinalScore(
                            _score,
                            _difficulty);

                    MessageBox.Show(
                        $"Congratulations! You won! Your score is {finalScore}.");

                    ShowWinnerAndHighScores(finalScore);
                }
            }
        }
        /// <summary>
        /// Updates the text and appearance of every game button
        /// </summary>
        private void UpdateButtonFaces()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    CellModel cell = _board.Cells[row, col];
                    Button button = _buttons[row, col];

                    button.Text = "";
                    button.BackgroundImageLayout = ImageLayout.Stretch;

                    if (cell.IsFlagged)
                    {
                        button.BackgroundImage = imgFlag;
                        button.BackColor = Color.LightBlue;
                        button.FlatStyle = FlatStyle.Standard;
                    }
                    else if (!cell.IsVisited)
                    {
                        // Hidden cell
                        button.BackgroundImage = imgUnselected;
                        button.BackColor = Color.DarkGray;
                        button.FlatStyle = FlatStyle.Standard;
                    }
                    else if (cell.HasSpecialReward && cell.IsVisited)
                    {
                        button.BackgroundImage = imgReward;
                        button.BackColor = Color.Gold;
                        button.FlatStyle = FlatStyle.Flat;
                    }
                                  
                    else if (cell.IsBomb)
                    {
                        button.BackgroundImage = imgBomb;
                        button.BackColor = Color.Gray;
                        button.FlatStyle = FlatStyle.Flat;
                    }

                    else
                    {
                        // Revealed or flood-filled cell
                        button.BackColor = Color.DarkGray;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 1;
                        button.FlatAppearance.BorderColor = Color.LightGray;

                        switch (cell.NumberOfBombNeighbors)
                        {
                            case 0:
                                button.BackgroundImage = null;
                                button.BackColor = Color.DarkGray;
                                button.FlatStyle = FlatStyle.Flat;
                                button.FlatAppearance.BorderSize = 1;
                                button.FlatAppearance.BorderColor = Color.Gray;
                                break;

                            case 1:
                                button.BackgroundImage = img1;
                                break;

                            case 2:
                                button.BackgroundImage = img2;
                                break;

                            case 3:
                                button.BackgroundImage = img3;
                                break;

                            case 4:
                                button.BackgroundImage = img4;
                                break;

                            case 5:
                                button.BackgroundImage = img5;
                                break;

                            case 6:
                                button.BackgroundImage = img6;
                                break;

                            case 7:
                                button.BackgroundImage = img7;
                                break;

                            case 8:
                                button.BackgroundImage = img8;
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Marks every cell as visited
        /// </summary>
        private void RevealBoard()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    _board.Cells[row, col].IsVisited = true;
                }
            }
        }

        /// <summary>
        /// Click event handler for the Restart button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRestartClickEH(object sender, EventArgs e)
        {
            // Create a new game board using the same settings
            _board = new BoardModel(_boardSize);
            _board.Difficulty = _difficulty;

            // Set up the new board
            _boardLogic.SetupBombs(_board);
            _boardLogic.CountBombsNearby(_board);

            // Randomly place a reward on a cell that is not a bomb
            Random random = new Random();

            int rewardRow;
            int rewardCol;

            do
            {
                rewardRow = random.Next(_board.Size);
                rewardCol = random.Next(_board.Size);
            }
            while (_board.Cells[rewardRow, rewardCol].IsBomb);

            _board.Cells[rewardRow, rewardCol].HasSpecialReward = true;

            // Reset reward tracking
            _rewardFound = false;

            // Reset the score and start time
            _score = 0;
            _startTime = DateTime.Now;

            // Update the labels
            lblScore.Text = _score.ToString();
            lblStartTime.Text = _startTime.ToString("hh:mm:ss tt");

            // Recreate the button grid
            CreateButtonGrid();
        }
        /// <summary>
        /// Counts the number of visited cells on the board
        /// </summary>
        /// <returns></returns>
        private int CountVisitedCells()
        {
            int visitedCells = 0;

            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    if (_board.Cells[row, col].IsVisited)
                    {
                        visitedCells++;
                    }
                }
            }

            return visitedCells;
        }
        /// <summary>
        /// Handles right-clicking a cell to add or remove a flag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellButtonMouseDownEH(object sender, MouseEventArgs e)
        {
            // Make sure the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                Button clickedButton = sender as Button;

                if (clickedButton != null)
                {
                    // Get the row and column from the button
                    Point location = (Point)clickedButton.Tag;

                    int row = location.X;
                    int col = location.Y;

                    CellModel selectedCell = _board.Cells[row, col];

                    // Do not flag an already visited cell
                    if (!selectedCell.IsVisited)
                    {
                        // Toggle the flag
                        selectedCell.IsFlagged = !selectedCell.IsFlagged;

                        // Update the board display
                        UpdateButtonFaces();
                    }
                }
            }
        }

        /// <summary>
        /// Temporarily shows all bomb locations for testing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowBombsEH(object sender, EventArgs e)
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    if (_board.Cells[row, col].IsBomb)
                    {
                        _buttons[row, col].BackgroundImage = imgBomb;
                        _buttons[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                        _buttons[row, col].Text = "";
                    }
                }
            }

        }
        private void ShowWinnerAndHighScores(int finalScore)
        {
            using (FrmWinnerName winnerNameForm = new FrmWinnerName())
            {
                if (winnerNameForm.ShowDialog() == DialogResult.OK)
                {
                    GameStat gameStat = new GameStat(
                        0,
                        winnerNameForm.PlayerName,
                        finalScore,
                        DateTime.Now);

                    using (HighScores highScoresForm = new HighScores(gameStat))
                    {
                        highScoresForm.ShowDialog();
                    }
                }
            }
        }
        private void TsmSaveGameClickEH(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog =
                new SaveFileDialog();

            saveFileDialog.Filter =
                "JSON File (*.json)|*.json";

            saveFileDialog.DefaultExt = "json";

            if (saveFileDialog.ShowDialog() ==
                DialogResult.OK)
            {
                // Create a normal list because a two-dimensional
                // array does not serialize reliably
                List<CellModel> savedCells =
                    new List<CellModel>();

                for (int row = 0; row < _board.Size; row++)
                {
                    for (int col = 0; col < _board.Size; col++)
                    {
                        savedCells.Add(_board.Cells[row, col]);
                    }
                }

                SavedGameModel savedGame =
                    new SavedGameModel(
                        _board.Size,
                        _board.Difficulty,
                        savedCells,
                        _score,
                        _startTime,
                        _rewardFound);

                string message =
                    _gameSaveDAO.SaveGame(
                        saveFileDialog.FileName,
                        savedGame);

                MessageBox.Show(message);
            }
        }
        private void TsmResumeGameClickEH(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog =
                new OpenFileDialog();

            openFileDialog.Filter =
                "JSON File (*.json)|*.json";

            if (openFileDialog.ShowDialog() ==
                DialogResult.OK)
            {
                try
                {
                    SavedGameModel savedGame =
                        _gameSaveDAO.LoadGame(
                            openFileDialog.FileName);

                    if (savedGame == null ||
                        savedGame.Cells == null)
                    {
                        MessageBox.Show(
                            "The saved game could not be loaded.");

                        return;
                    }

                    // Restore the saved settings
                    _boardSize = savedGame.BoardSize;
                    _difficulty = savedGame.Difficulty;

                    // Create a new board with a valid Cells array
                    _board = new BoardModel(_boardSize);
                    _board.Difficulty = _difficulty;

                    // Restore every saved cell
                    foreach (CellModel savedCell in savedGame.Cells)
                    {
                        _board.Cells[
                            savedCell.Row,
                            savedCell.Column] = savedCell;
                    }

                    // Restore the remaining game information
                    _score = savedGame.Score;
                    _startTime = savedGame.StartTime;
                    _rewardFound = savedGame.RewardFound;

                    lblScore.Text = _score.ToString();
                    lblStartTime.Text =
                        _startTime.ToString("hh:mm:ss tt");

                    // Rebuild the button grid
                    _buttons =
                        new Button[_boardSize, _boardSize];

                    CreateButtonGrid();

                    MessageBox.Show(
                        "The saved game was loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        /// <summary>
        /// Activates the reward and updates the game screen
        /// </summary>
        /// <param name="rewardRow"></param>
        /// <param name="rewardCol"></param>
        private void ActivateSpecialReward(
            int rewardRow,
            int rewardCol)
        {
            // Reveal the safe cells using the business logic layer
            _boardLogic.ActivateSpecialReward(
                _board,
                rewardRow,
                rewardCol);

            // Add the reward bonus
            _score += 10;

            // Mark the reward as used
            _rewardFound = true;

            // Update the score label
            lblScore.Text = _score.ToString();

            // Show the reward message
            MessageBox.Show(
                "You found the special reward! " +
                "Nearby safe cells were revealed and you earned 10 bonus points.");
        }
    }
}

