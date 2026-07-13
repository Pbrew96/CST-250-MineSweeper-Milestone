namespace MinesweeperGUI
{
    partial class FrmGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlGameBoard = new Panel();
            label1 = new Label();
            lblStartTime = new Label();
            label3 = new Label();
            lblScore = new Label();
            btnRestart = new Button();
            btnShowBombs = new Button();
            SuspendLayout();
            // 
            // pnlGameBoard
            // 
            pnlGameBoard.AutoScroll = true;
            pnlGameBoard.BorderStyle = BorderStyle.FixedSingle;
            pnlGameBoard.Location = new Point(12, 12);
            pnlGameBoard.Name = "pnlGameBoard";
            pnlGameBoard.Size = new Size(545, 709);
            pnlGameBoard.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(600, 37);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 1;
            label1.Text = "Start Time:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(600, 52);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(49, 15);
            lblStartTime.TabIndex = 2;
            lblStartTime.Text = "00:00:00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(600, 117);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 3;
            label3.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(600, 132);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(13, 15);
            lblScore.TabIndex = 4;
            lblScore.Text = "0";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(662, 168);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(75, 23);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += BtnRestartClickEH;
            // 
            // btnShowBombs
            // 
            btnShowBombs.Location = new Point(662, 197);
            btnShowBombs.Name = "btnShowBombs";
            btnShowBombs.Size = new Size(75, 23);
            btnShowBombs.TabIndex = 6;
            btnShowBombs.Text = "Show Bombs";
            btnShowBombs.UseVisualStyleBackColor = true;
            btnShowBombs.Click += btnShowBombsEH;
            // 
            // FrmGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 733);
            Controls.Add(btnShowBombs);
            Controls.Add(btnRestart);
            Controls.Add(lblScore);
            Controls.Add(label3);
            Controls.Add(lblStartTime);
            Controls.Add(label1);
            Controls.Add(pnlGameBoard);
            Name = "FrmGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGameBoard;
        private Label label1;
        private Label lblStartTime;
        private Label label3;
        private Label lblScore;
        private Button btnRestart;
        private Button btnShowBombs;
    }
}
