namespace Sudoku_Windows_Forms
{
    partial class Sudoku_Test
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
            BtnCorrect = new Button();
            sudokuGrid = new DataGridView();
            BtnStart = new Button();
            ((System.ComponentModel.ISupportInitialize)sudokuGrid).BeginInit();
            SuspendLayout();
            // 
            // BtnCorrect
            // 
            BtnCorrect.Location = new Point(685, 86);
            BtnCorrect.Name = "BtnCorrect";
            BtnCorrect.Size = new Size(75, 23);
            BtnCorrect.TabIndex = 0;
            BtnCorrect.Text = "Correct";
            BtnCorrect.UseVisualStyleBackColor = true;
            BtnCorrect.Click += BtnCorrect_Click;
            // 
            // sudokuGrid
            // 
            sudokuGrid.AllowUserToAddRows = false;
            sudokuGrid.AllowUserToDeleteRows = false;
            sudokuGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sudokuGrid.Location = new Point(205, 35);
            sudokuGrid.Name = "sudokuGrid";
            sudokuGrid.ReadOnly = true;
            sudokuGrid.RowTemplate.Height = 25;
            sudokuGrid.Size = new Size(389, 389);
            sudokuGrid.TabIndex = 1;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(37, 86);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(75, 23);
            BtnStart.TabIndex = 2;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // Sudoku_Test
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnStart);
            Controls.Add(sudokuGrid);
            Controls.Add(BtnCorrect);
            Name = "Sudoku_Test";
            Text = "Sudoku_Test";
            Load += Sudoku_Test_Load;
            ((System.ComponentModel.ISupportInitialize)sudokuGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnCorrect;
        private DataGridView sudokuGrid;
        private Button BtnStart;
    }
}