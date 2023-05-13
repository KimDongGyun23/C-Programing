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
            components = new System.ComponentModel.Container();
            BtnCorrect = new Button();
            BtnStart = new Button();
            sudokuGrid = new DataGridView();
            lbltmr = new Label();
            tmr = new System.Windows.Forms.Timer(components);
            BtnFinish = new Button();
            BtnReset = new Button();
            lblText = new Label();
            msgTmr = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            난이도조절ToolStripMenuItem = new ToolStripMenuItem();
            그리드크기변경ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            숫자생성개수변화ToolStripMenuItem = new ToolStripMenuItem();
            eASYToolStripMenuItem = new ToolStripMenuItem();
            mEDIUMToolStripMenuItem = new ToolStripMenuItem();
            hARDToolStripMenuItem = new ToolStripMenuItem();
            타임어택ToolStripMenuItem = new ToolStripMenuItem();
            분ToolStripMenuItem = new ToolStripMenuItem();
            분ToolStripMenuItem1 = new ToolStripMenuItem();
            분ToolStripMenuItem2 = new ToolStripMenuItem();
            분ToolStripMenuItem3 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)sudokuGrid).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnCorrect
            // 
            BtnCorrect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnCorrect.BackColor = Color.FromArgb(192, 192, 255);
            BtnCorrect.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCorrect.Location = new Point(666, 186);
            BtnCorrect.Name = "BtnCorrect";
            BtnCorrect.Size = new Size(124, 47);
            BtnCorrect.TabIndex = 0;
            BtnCorrect.Text = "Correct";
            BtnCorrect.UseVisualStyleBackColor = false;
            BtnCorrect.Click += BtnCorrect_Click;
            // 
            // BtnStart
            // 
            BtnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnStart.BackColor = Color.FromArgb(192, 192, 255);
            BtnStart.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnStart.Location = new Point(40, 186);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(124, 47);
            BtnStart.TabIndex = 1;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = false;
            BtnStart.Click += BtnStart_Click;
            // 
            // sudokuGrid
            // 
            sudokuGrid.AllowUserToAddRows = false;
            sudokuGrid.AllowUserToDeleteRows = false;
            sudokuGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sudokuGrid.BackgroundColor = Color.LightGray;
            sudokuGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sudokuGrid.Location = new Point(220, 139);
            sudokuGrid.Margin = new Padding(4);
            sudokuGrid.Name = "sudokuGrid";
            sudokuGrid.ReadOnly = true;
            sudokuGrid.RowHeadersWidth = 51;
            sudokuGrid.RowTemplate.Height = 29;
            sudokuGrid.Size = new Size(390, 390);
            sudokuGrid.TabIndex = 1;
            // 
            // lbltmr
            // 
            lbltmr.AutoSize = true;
            lbltmr.Font = new Font("함초롬돋움", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lbltmr.Location = new Point(354, 38);
            lbltmr.Name = "lbltmr";
            lbltmr.Size = new Size(121, 35);
            lbltmr.TabIndex = 2;
            lbltmr.Text = "00:00:00";
            // 
            // tmr
            // 
            tmr.Interval = 1000;
            tmr.Tick += tmr_Tick;
            // 
            // BtnFinish
            // 
            BtnFinish.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnFinish.BackColor = Color.FromArgb(192, 192, 255);
            BtnFinish.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnFinish.Location = new Point(40, 278);
            BtnFinish.Name = "BtnFinish";
            BtnFinish.Size = new Size(124, 47);
            BtnFinish.TabIndex = 3;
            BtnFinish.Text = "Finish";
            BtnFinish.UseVisualStyleBackColor = false;
            BtnFinish.Click += BtnFinish_Click;
            // 
            // BtnReset
            // 
            BtnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnReset.BackColor = Color.FromArgb(192, 192, 255);
            BtnReset.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnReset.Location = new Point(666, 278);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(124, 47);
            BtnReset.TabIndex = 4;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = false;
            BtnReset.Click += BtnReset_Click;
            // 
            // lblText
            // 
            lblText.Font = new Font("휴먼엑스포", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblText.Location = new Point(240, 98);
            lblText.Name = "lblText";
            lblText.Size = new Size(350, 20);
            lblText.TabIndex = 5;
            lblText.Text = "게임을 시작해 주세요.";
            lblText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // msgTmr
            // 
            msgTmr.Interval = 1000;
            msgTmr.Tick += msgTmr_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 난이도조절ToolStripMenuItem, 타임어택ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(812, 28);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // 난이도조절ToolStripMenuItem
            // 
            난이도조절ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 그리드크기변경ToolStripMenuItem, 숫자생성개수변화ToolStripMenuItem });
            난이도조절ToolStripMenuItem.Name = "난이도조절ToolStripMenuItem";
            난이도조절ToolStripMenuItem.Size = new Size(103, 24);
            난이도조절ToolStripMenuItem.Text = "난이도 조절";
            // 
            // 그리드크기변경ToolStripMenuItem
            // 
            그리드크기변경ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            그리드크기변경ToolStripMenuItem.Name = "그리드크기변경ToolStripMenuItem";
            그리드크기변경ToolStripMenuItem.Size = new Size(227, 26);
            그리드크기변경ToolStripMenuItem.Text = "그리드 크기 변경";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(124, 26);
            toolStripMenuItem2.Text = "4 * 4";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(124, 26);
            toolStripMenuItem3.Text = "9 * 9";
            // 
            // 숫자생성개수변화ToolStripMenuItem
            // 
            숫자생성개수변화ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eASYToolStripMenuItem, mEDIUMToolStripMenuItem, hARDToolStripMenuItem });
            숫자생성개수변화ToolStripMenuItem.Name = "숫자생성개수변화ToolStripMenuItem";
            숫자생성개수변화ToolStripMenuItem.Size = new Size(227, 26);
            숫자생성개수변화ToolStripMenuItem.Text = "숫자 출력 개수 변경";
            숫자생성개수변화ToolStripMenuItem.Click += 숫자생성개수변화ToolStripMenuItem_Click;
            // 
            // eASYToolStripMenuItem
            // 
            eASYToolStripMenuItem.Name = "eASYToolStripMenuItem";
            eASYToolStripMenuItem.Size = new Size(154, 26);
            eASYToolStripMenuItem.Text = "EASY";
            // 
            // mEDIUMToolStripMenuItem
            // 
            mEDIUMToolStripMenuItem.Name = "mEDIUMToolStripMenuItem";
            mEDIUMToolStripMenuItem.Size = new Size(154, 26);
            mEDIUMToolStripMenuItem.Text = "MEDIUM";
            // 
            // hARDToolStripMenuItem
            // 
            hARDToolStripMenuItem.Name = "hARDToolStripMenuItem";
            hARDToolStripMenuItem.Size = new Size(154, 26);
            hARDToolStripMenuItem.Text = "HARD";
            // 
            // 타임어택ToolStripMenuItem
            // 
            타임어택ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 분ToolStripMenuItem, 분ToolStripMenuItem1, 분ToolStripMenuItem2, 분ToolStripMenuItem3 });
            타임어택ToolStripMenuItem.Name = "타임어택ToolStripMenuItem";
            타임어택ToolStripMenuItem.Size = new Size(83, 24);
            타임어택ToolStripMenuItem.Text = "타임어택";
            // 
            // 분ToolStripMenuItem
            // 
            분ToolStripMenuItem.Name = "분ToolStripMenuItem";
            분ToolStripMenuItem.Size = new Size(123, 26);
            분ToolStripMenuItem.Text = "10분";
            // 
            // 분ToolStripMenuItem1
            // 
            분ToolStripMenuItem1.Name = "분ToolStripMenuItem1";
            분ToolStripMenuItem1.Size = new Size(123, 26);
            분ToolStripMenuItem1.Text = "7분";
            // 
            // 분ToolStripMenuItem2
            // 
            분ToolStripMenuItem2.Name = "분ToolStripMenuItem2";
            분ToolStripMenuItem2.Size = new Size(123, 26);
            분ToolStripMenuItem2.Text = "5분";
            // 
            // 분ToolStripMenuItem3
            // 
            분ToolStripMenuItem3.Name = "분ToolStripMenuItem3";
            분ToolStripMenuItem3.Size = new Size(123, 26);
            분ToolStripMenuItem3.Text = "3분";
            // 
            // Sudoku
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(812, 553);
            Controls.Add(lblText);
            Controls.Add(BtnReset);
            Controls.Add(BtnFinish);
            Controls.Add(lbltmr);
            Controls.Add(sudokuGrid);
            Controls.Add(BtnStart);
            Controls.Add(BtnCorrect);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Sudoku";
            Text = "Sudoku";
            Load += Sudoku_Load;
            ((System.ComponentModel.ISupportInitialize)sudokuGrid).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Timer msgTmr;
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