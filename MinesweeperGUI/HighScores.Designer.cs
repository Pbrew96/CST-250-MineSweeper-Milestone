namespace MinesweeperGUI
{
    partial class HighScores
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
            btnOk = new Button();
            lblHighScores = new Label();
            dgvHighScores = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            sortToolStripMenuItem = new ToolStripMenuItem();
            nameToolStripMenuItem = new ToolStripMenuItem();
            scoreToolStripMenuItem = new ToolStripMenuItem();
            dateToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.FlatAppearance.BorderColor = Color.Black;
            btnOk.FlatAppearance.BorderSize = 2;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOk.Location = new Point(713, 415);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 33);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblHighScores
            // 
            lblHighScores.AutoSize = true;
            lblHighScores.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHighScores.Location = new Point(342, 9);
            lblHighScores.Name = "lblHighScores";
            lblHighScores.Size = new Size(149, 32);
            lblHighScores.TabIndex = 2;
            lblHighScores.Text = "High Scores";
            // 
            // dgvHighScores
            // 
            dgvHighScores.AllowUserToAddRows = false;
            dgvHighScores.AllowUserToDeleteRows = false;
            dgvHighScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHighScores.BackgroundColor = Color.White;
            dgvHighScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHighScores.Location = new Point(12, 46);
            dgvHighScores.MultiSelect = false;
            dgvHighScores.Name = "dgvHighScores";
            dgvHighScores.ReadOnly = true;
            dgvHighScores.RowHeadersVisible = false;
            dgvHighScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHighScores.Size = new Size(776, 363);
            dgvHighScores.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, sortToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 29);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 25);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(114, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(114, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(114, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nameToolStripMenuItem, scoreToolStripMenuItem, dateToolStripMenuItem });
            sortToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(51, 25);
            sortToolStripMenuItem.Text = "Sort";
            // 
            // nameToolStripMenuItem
            // 
            nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            nameToolStripMenuItem.Size = new Size(180, 26);
            nameToolStripMenuItem.Text = "Name";
            nameToolStripMenuItem.Click += nameToolStripMenuItem_Click;
            // 
            // scoreToolStripMenuItem
            // 
            scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            scoreToolStripMenuItem.Size = new Size(180, 26);
            scoreToolStripMenuItem.Text = "Score";
            scoreToolStripMenuItem.Click += scoreToolStripMenuItem_Click;
            // 
            // dateToolStripMenuItem
            // 
            dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            dateToolStripMenuItem.Size = new Size(180, 26);
            dateToolStripMenuItem.Text = "Date";
            dateToolStripMenuItem.Click += dateToolStripMenuItem_Click;
            // 
            // HighScores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvHighScores);
            Controls.Add(lblHighScores);
            Controls.Add(btnOk);
            Controls.Add(menuStrip1);
            Name = "HighScores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HighScores";
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnOk;
        private Label lblHighScores;
        private DataGridView dgvHighScores;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem nameToolStripMenuItem;
        private ToolStripMenuItem scoreToolStripMenuItem;
        private ToolStripMenuItem dateToolStripMenuItem;
    }
}