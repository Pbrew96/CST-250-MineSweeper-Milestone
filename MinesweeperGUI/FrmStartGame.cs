using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmStartGame : Form
    {
        public FrmStartGame()
        {
            InitializeComponent();

            lblBoardSize.Text = $"Board Size: {trbBoardSize.Value}";
            UpdateDifficultyLabel();
        }

        private void trbBoardSize_Scroll(object sender, EventArgs e)
        {
            lblBoardSize.Text = $"Board Size: {trbBoardSize.Value}";
        }

        private void trbDifficulty_Scroll(object sender, EventArgs e)
        {
            UpdateDifficultyLabel();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Get the selected board size
            int boardSize = trbBoardSize.Value;

            // Get the selected difficulty
            int difficulty = trbDifficulty.Value;

            // Create the game form
            FrmGame frmGame = new FrmGame(boardSize, difficulty);

            // Hide the start form
            Hide();

            // Show the game form
            frmGame.ShowDialog();

            // Show the start form again when the game closes
            Show();
        }
        /// <summary>
        /// Updates the difficulty label based on the TrackBar value
        /// </summary>
        private void UpdateDifficultyLabel()
        {
            if (trbDifficulty.Value == 1)
            {
                lblDifficulty.Text = "Difficulty: Easy";
            }
            else if (trbDifficulty.Value == 2)
            {
                lblDifficulty.Text = "Difficulty: Medium";
            }
            else
            {
                lblDifficulty.Text = "Difficulty: Hard";
            }
        }
    }
}
