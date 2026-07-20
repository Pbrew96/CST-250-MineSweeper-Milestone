namespace MinesweeperGUI
{
    partial class FrmStartGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            trbBoardSize = new TrackBar();
            lblBoardSize = new Label();
            lblDifficulty = new Label();
            trbDifficulty = new TrackBar();
            btnPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)trbBoardSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbDifficulty).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(145, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome to MineSweeper";
            // 
            // trbBoardSize
            // 
            trbBoardSize.Location = new Point(12, 76);
            trbBoardSize.Maximum = 20;
            trbBoardSize.Minimum = 4;
            trbBoardSize.Name = "trbBoardSize";
            trbBoardSize.Size = new Size(104, 45);
            trbBoardSize.TabIndex = 1;
            trbBoardSize.Value = 8;
            trbBoardSize.Scroll += trbBoardSize_Scroll;
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(12, 48);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(67, 15);
            lblBoardSize.TabIndex = 2;
            lblBoardSize.Text = "Board Size: ";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(12, 124);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(61, 15);
            lblDifficulty.TabIndex = 3;
            lblDifficulty.Text = "Difficulty: ";
            // 
            // trbDifficulty
            // 
            trbDifficulty.LargeChange = 1;
            trbDifficulty.Location = new Point(12, 155);
            trbDifficulty.Maximum = 3;
            trbDifficulty.Minimum = 1;
            trbDifficulty.Name = "trbDifficulty";
            trbDifficulty.Size = new Size(104, 45);
            trbDifficulty.TabIndex = 4;
            trbDifficulty.Value = 1;
            trbDifficulty.Scroll += trbDifficulty_Scroll;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(12, 206);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // FrmStartGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 397);
            Controls.Add(btnPlay);
            Controls.Add(trbDifficulty);
            Controls.Add(lblDifficulty);
            Controls.Add(lblBoardSize);
            Controls.Add(trbBoardSize);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmStartGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Start a New Game";
            ((System.ComponentModel.ISupportInitialize)trbBoardSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbDifficulty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TrackBar trbBoardSize;
        private Label lblBoardSize;
        private Label lblDifficulty;
        private TrackBar trbDifficulty;
        private Button btnPlay;
    }
}