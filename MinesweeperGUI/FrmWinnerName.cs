using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmWinnerName : Form
    {
        public string PlayerName { get; private set; }

        public FrmWinnerName()
        {
            InitializeComponent();

            PlayerName = string.Empty;
        }

        private void BtnOkClickEH(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlayerName.Text))
            {
                MessageBox.Show(
                    "Please enter your name.",
                    "Name Required");

                return;
            }

            PlayerName = txtPlayerName.Text.Trim();

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
