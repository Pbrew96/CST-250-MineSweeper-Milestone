/* Patrick Brewster
 * CST-250
 * Milestone 5
 * Minesweeper Game
 * 7/19/2026
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MineSweeperClassLibrary.BusinessLogic;
using MineSweeperClassLibrary.Models;

namespace MinesweeperGUI
{
    public partial class HighScores : Form
    {
        private readonly GameStatLogic _gameStatLogic;
        public HighScores()
        {
            InitializeComponent();

            _gameStatLogic = new GameStatLogic();

            _gameStatLogic.LoadGameStats();

            DisplayGameStats(_gameStatLogic.GetGameStats());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DisplayGameStats(List<GameStat> gameStats)
        {
            dgvHighScores.DataSource = null;
            dgvHighScores.DataSource = gameStats;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _gameStatLogic.SaveGameStats();

            MessageBox.Show(
                "High scores saved successfully.",
                "Save Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _gameStatLogic.LoadGameStats();

            DisplayGameStats(_gameStatLogic.GetGameStats());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayGameStats(_gameStatLogic.SortByName());

        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayGameStats(_gameStatLogic.SortByScore());
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayGameStats(_gameStatLogic.SortByDate());
        }
        public HighScores(GameStat gameStat)
        {
            InitializeComponent();

            _gameStatLogic = new GameStatLogic();

            _gameStatLogic.LoadGameStats();

            _gameStatLogic.AddGameStat(gameStat);

            _gameStatLogic.SaveGameStats();

            DisplayGameStats(_gameStatLogic.GetGameStats());
        }
    }
}
