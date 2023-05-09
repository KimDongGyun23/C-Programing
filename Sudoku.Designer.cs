namespace Sudoku_Play
{
    partial class Sudoku
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
            this.components = new System.ComponentModel.Container();
            this.BtnCorrect = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.sudokuGrid = new System.Windows.Forms.DataGridView();
            this.lbltmr = new System.Windows.Forms.Label();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.BtnFinish = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.colorTmr = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.난이도조절ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그리드크기변경ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.숫자생성개수변화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eASYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mEDIUMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hARDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.타임어택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sudokuGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCorrect
            // 
            this.BtnCorrect.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCorrect.Location = new System.Drawing.Point(666, 186);
            this.BtnCorrect.Name = "BtnCorrect";
            this.BtnCorrect.Size = new System.Drawing.Size(124, 47);
            this.BtnCorrect.TabIndex = 0;
            this.BtnCorrect.Text = "Correct";
            this.BtnCorrect.UseVisualStyleBackColor = true;
            this.BtnCorrect.Click += new System.EventHandler(this.BtnCorrect_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnStart.Location = new System.Drawing.Point(40, 186);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(124, 47);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // sudokuGrid
            // 
            this.sudokuGrid.AllowUserToAddRows = false;
            this.sudokuGrid.AllowUserToDeleteRows = false;
            this.sudokuGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sudokuGrid.Location = new System.Drawing.Point(220, 139);
            this.sudokuGrid.Margin = new System.Windows.Forms.Padding(4);
            this.sudokuGrid.Name = "sudokuGrid";
            this.sudokuGrid.ReadOnly = true;
            this.sudokuGrid.RowHeadersWidth = 51;
            this.sudokuGrid.RowTemplate.Height = 29;
            this.sudokuGrid.Size = new System.Drawing.Size(390, 390);
            this.sudokuGrid.TabIndex = 1;
            // 
            // lbltmr
            // 
            this.lbltmr.AutoSize = true;
            this.lbltmr.Font = new System.Drawing.Font("함초롬돋움", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbltmr.Location = new System.Drawing.Point(354, 38);
            this.lbltmr.Name = "lbltmr";
            this.lbltmr.Size = new System.Drawing.Size(121, 35);
            this.lbltmr.TabIndex = 2;
            this.lbltmr.Text = "00:00:00";
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // BtnFinish
            // 
            this.BtnFinish.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFinish.Location = new System.Drawing.Point(40, 278);
            this.BtnFinish.Name = "BtnFinish";
            this.BtnFinish.Size = new System.Drawing.Size(124, 47);
            this.BtnFinish.TabIndex = 3;
            this.BtnFinish.Text = "Finish";
            this.BtnFinish.UseVisualStyleBackColor = true;
            this.BtnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnReset.Location = new System.Drawing.Point(666, 278);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(124, 47);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(265, 98);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(300, 20);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "열심히 도전하세요.";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorTmr
            // 
            this.colorTmr.Interval = 1000;
            this.colorTmr.Tick += new System.EventHandler(this.colorTmr_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.난이도조절ToolStripMenuItem,
            this.타임어택ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 난이도조절ToolStripMenuItem
            // 
            this.난이도조절ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.그리드크기변경ToolStripMenuItem,
            this.숫자생성개수변화ToolStripMenuItem});
            this.난이도조절ToolStripMenuItem.Name = "난이도조절ToolStripMenuItem";
            this.난이도조절ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.난이도조절ToolStripMenuItem.Text = "난이도 조절";
            // 
            // 그리드크기변경ToolStripMenuItem
            // 
            this.그리드크기변경ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.그리드크기변경ToolStripMenuItem.Name = "그리드크기변경ToolStripMenuItem";
            this.그리드크기변경ToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.그리드크기변경ToolStripMenuItem.Text = "그리드 크기 변경";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem2.Text = "4 * 4";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem3.Text = "9 * 9";
            // 
            // 숫자생성개수변화ToolStripMenuItem
            // 
            this.숫자생성개수변화ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eASYToolStripMenuItem,
            this.mEDIUMToolStripMenuItem,
            this.hARDToolStripMenuItem});
            this.숫자생성개수변화ToolStripMenuItem.Name = "숫자생성개수변화ToolStripMenuItem";
            this.숫자생성개수변화ToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.숫자생성개수변화ToolStripMenuItem.Text = "숫자 출력 개수 변경";
            this.숫자생성개수변화ToolStripMenuItem.Click += new System.EventHandler(this.숫자생성개수변화ToolStripMenuItem_Click);
            // 
            // eASYToolStripMenuItem
            // 
            this.eASYToolStripMenuItem.Name = "eASYToolStripMenuItem";
            this.eASYToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.eASYToolStripMenuItem.Text = "EASY";
            // 
            // mEDIUMToolStripMenuItem
            // 
            this.mEDIUMToolStripMenuItem.Name = "mEDIUMToolStripMenuItem";
            this.mEDIUMToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mEDIUMToolStripMenuItem.Text = "MEDIUM";
            // 
            // hARDToolStripMenuItem
            // 
            this.hARDToolStripMenuItem.Name = "hARDToolStripMenuItem";
            this.hARDToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.hARDToolStripMenuItem.Text = "HARD";
            // 
            // 타임어택ToolStripMenuItem
            // 
            this.타임어택ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.분ToolStripMenuItem,
            this.분ToolStripMenuItem1,
            this.분ToolStripMenuItem2,
            this.분ToolStripMenuItem3});
            this.타임어택ToolStripMenuItem.Name = "타임어택ToolStripMenuItem";
            this.타임어택ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.타임어택ToolStripMenuItem.Text = "타임어택";
            // 
            // 분ToolStripMenuItem
            // 
            this.분ToolStripMenuItem.Name = "분ToolStripMenuItem";
            this.분ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.분ToolStripMenuItem.Text = "10분";
            // 
            // 분ToolStripMenuItem1
            // 
            this.분ToolStripMenuItem1.Name = "분ToolStripMenuItem1";
            this.분ToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.분ToolStripMenuItem1.Text = "7분";
            // 
            // 분ToolStripMenuItem2
            // 
            this.분ToolStripMenuItem2.Name = "분ToolStripMenuItem2";
            this.분ToolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.분ToolStripMenuItem2.Text = "5분";
            // 
            // 분ToolStripMenuItem3
            // 
            this.분ToolStripMenuItem3.Name = "분ToolStripMenuItem3";
            this.분ToolStripMenuItem3.Size = new System.Drawing.Size(224, 26);
            this.분ToolStripMenuItem3.Text = "3분";
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 553);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnFinish);
            this.Controls.Add(this.lbltmr);
            this.Controls.Add(this.sudokuGrid);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnCorrect);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sudoku";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Sudoku_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sudokuGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnCorrect;
        private Button BtnStart;
        private DataGridView sudokuGrid;
        private Label lbltmr;
        private System.Windows.Forms.Timer tmr;
        private Button BtnFinish;
        private Button BtnReset;
        private Label lblText;
        private System.Windows.Forms.Timer colorTmr;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 난이도조절ToolStripMenuItem;
        private ToolStripMenuItem 그리드크기변경ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem 숫자생성개수변화ToolStripMenuItem;
        private ToolStripMenuItem eASYToolStripMenuItem;
        private ToolStripMenuItem mEDIUMToolStripMenuItem;
        private ToolStripMenuItem hARDToolStripMenuItem;
        private ToolStripMenuItem 타임어택ToolStripMenuItem;
        private ToolStripMenuItem 분ToolStripMenuItem;
        private ToolStripMenuItem 분ToolStripMenuItem1;
        private ToolStripMenuItem 분ToolStripMenuItem2;
        private ToolStripMenuItem 분ToolStripMenuItem3;
    }
}