namespace MinesweeperGUI
{
    partial class FrmWinnerName
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
            label1 = new Label();
            txtPlayerName = new TextBox();
            btnOk = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter your name: ";
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(70, 27);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(161, 23);
            txtPlayerName.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(102, 82);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOkClickEH;
            // 
            // FrmWinnerName
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 117);
            Controls.Add(btnOk);
            Controls.Add(txtPlayerName);
            Controls.Add(label1);
            Name = "FrmWinnerName";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmWinnerName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPlayerName;
        private Button btnOk;
    }
}