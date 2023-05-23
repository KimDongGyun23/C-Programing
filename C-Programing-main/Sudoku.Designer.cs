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
            lbltmr = new Label();
            tmr = new System.Windows.Forms.Timer(components);
            BtnFinish = new Button();
            BtnReset = new Button();
            lblText = new Label();
            msgTmr = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            모드변경ToolStripMenuItem = new ToolStripMenuItem();
            기본ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            RegularMode99 = new ToolStripMenuItem();
            타임어택ToolStripMenuItem = new ToolStripMenuItem();
            분ToolStripMenuItem = new ToolStripMenuItem();
            분ToolStripMenuItem1 = new ToolStripMenuItem();
            분ToolStripMenuItem2 = new ToolStripMenuItem();
            분ToolStripMenuItem3 = new ToolStripMenuItem();
            타임어택모드끄기ToolStripMenuItem = new ToolStripMenuItem();
            난이도ToolStripMenuItem = new ToolStripMenuItem();
            StripEasy = new ToolStripMenuItem();
            StripMedium = new ToolStripMenuItem();
            StripHard = new ToolStripMenuItem();
            BtnUndo = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnCorrect
            // 
            BtnCorrect.BackColor = Color.FromArgb(192, 192, 255);
            BtnCorrect.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCorrect.Location = new Point(740, 232);
            BtnCorrect.Margin = new Padding(3, 4, 3, 4);
            BtnCorrect.Name = "BtnCorrect";
            BtnCorrect.Size = new Size(138, 59);
            BtnCorrect.TabIndex = 0;
            BtnCorrect.Text = "Correct";
            BtnCorrect.UseVisualStyleBackColor = false;
            BtnCorrect.Click += BtnCorrect_Click;
            // 
            // BtnStart
            // 
            BtnStart.BackColor = Color.FromArgb(192, 192, 255);
            BtnStart.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnStart.Location = new Point(44, 232);
            BtnStart.Margin = new Padding(3, 4, 3, 4);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(138, 59);
            BtnStart.TabIndex = 1;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = false;
            BtnStart.Click += BtnStart_Click;
            // 
            // lbltmr
            // 
            lbltmr.AutoSize = true;
            lbltmr.Font = new Font("함초롬돋움", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lbltmr.Location = new Point(393, 48);
            lbltmr.Name = "lbltmr";
            lbltmr.Size = new Size(146, 41);
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
            BtnFinish.BackColor = Color.FromArgb(192, 192, 255);
            BtnFinish.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnFinish.Location = new Point(44, 348);
            BtnFinish.Margin = new Padding(3, 4, 3, 4);
            BtnFinish.Name = "BtnFinish";
            BtnFinish.Size = new Size(138, 59);
            BtnFinish.TabIndex = 3;
            BtnFinish.Text = "Finish";
            BtnFinish.UseVisualStyleBackColor = false;
            BtnFinish.Click += BtnFinish_Click;
            // 
            // BtnReset
            // 
            BtnReset.BackColor = Color.FromArgb(192, 192, 255);
            BtnReset.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnReset.Location = new Point(740, 348);
            BtnReset.Margin = new Padding(3, 4, 3, 4);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(138, 59);
            BtnReset.TabIndex = 4;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = false;
            BtnReset.Click += BtnReset_Click;
            // 
            // lblText
            // 
            lblText.Font = new Font("휴먼엑스포", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblText.Location = new Point(267, 122);
            lblText.Name = "lblText";
            lblText.Size = new Size(389, 25);
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { 모드변경ToolStripMenuItem, 타임어택ToolStripMenuItem, 난이도ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(902, 33);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // 모드변경ToolStripMenuItem
            // 
            모드변경ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 기본ToolStripMenuItem });
            모드변경ToolStripMenuItem.Name = "모드변경ToolStripMenuItem";
            모드변경ToolStripMenuItem.Size = new Size(106, 29);
            모드변경ToolStripMenuItem.Text = "모드 변경";
            // 
            // 기본ToolStripMenuItem
            // 
            기본ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem4, RegularMode99 });
            기본ToolStripMenuItem.Name = "기본ToolStripMenuItem";
            기본ToolStripMenuItem.Size = new Size(150, 34);
            기본ToolStripMenuItem.Text = "기본";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(154, 34);
            toolStripMenuItem4.Text = "4 * 4";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // RegularMode99
            // 
            RegularMode99.Name = "RegularMode99";
            RegularMode99.Size = new Size(154, 34);
            RegularMode99.Text = "9 * 9";
            RegularMode99.Click += RegularMode99_Click;
            // 
            // 타임어택ToolStripMenuItem
            // 
            타임어택ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 분ToolStripMenuItem, 분ToolStripMenuItem1, 분ToolStripMenuItem2, 분ToolStripMenuItem3, 타임어택모드끄기ToolStripMenuItem });
            타임어택ToolStripMenuItem.Name = "타임어택ToolStripMenuItem";
            타임어택ToolStripMenuItem.Size = new Size(100, 29);
            타임어택ToolStripMenuItem.Text = "타임어택";
            // 
            // 분ToolStripMenuItem
            // 
            분ToolStripMenuItem.Name = "분ToolStripMenuItem";
            분ToolStripMenuItem.Size = new Size(264, 34);
            분ToolStripMenuItem.Text = "10분";
            분ToolStripMenuItem.Click += 분ToolStripMenuItem_Click;
            // 
            // 분ToolStripMenuItem1
            // 
            분ToolStripMenuItem1.Name = "분ToolStripMenuItem1";
            분ToolStripMenuItem1.Size = new Size(264, 34);
            분ToolStripMenuItem1.Text = "7분";
            분ToolStripMenuItem1.Click += 분ToolStripMenuItem1_Click;
            // 
            // 분ToolStripMenuItem2
            // 
            분ToolStripMenuItem2.Name = "분ToolStripMenuItem2";
            분ToolStripMenuItem2.Size = new Size(264, 34);
            분ToolStripMenuItem2.Text = "5분";
            분ToolStripMenuItem2.Click += 분ToolStripMenuItem2_Click;
            // 
            // 분ToolStripMenuItem3
            // 
            분ToolStripMenuItem3.Name = "분ToolStripMenuItem3";
            분ToolStripMenuItem3.Size = new Size(264, 34);
            분ToolStripMenuItem3.Text = "3분";
            분ToolStripMenuItem3.Click += 분ToolStripMenuItem3_Click;
            // 
            // 타임어택모드끄기ToolStripMenuItem
            // 
            타임어택모드끄기ToolStripMenuItem.Name = "타임어택모드끄기ToolStripMenuItem";
            타임어택모드끄기ToolStripMenuItem.Size = new Size(264, 34);
            타임어택모드끄기ToolStripMenuItem.Text = "타임어택모드 끄기";
            타임어택모드끄기ToolStripMenuItem.Click += 타임어택모드끄기ToolStripMenuItem_Click;
            // 
            // 난이도ToolStripMenuItem
            // 
            난이도ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { StripEasy, StripMedium, StripHard });
            난이도ToolStripMenuItem.Name = "난이도ToolStripMenuItem";
            난이도ToolStripMenuItem.Size = new Size(82, 29);
            난이도ToolStripMenuItem.Text = "난이도";
            // 
            // StripEasy
            // 
            StripEasy.Name = "StripEasy";
            StripEasy.Size = new Size(182, 34);
            StripEasy.Text = "Easy";
            StripEasy.Click += StripEasy_Click;
            // 
            // StripMedium
            // 
            StripMedium.Name = "StripMedium";
            StripMedium.Size = new Size(182, 34);
            StripMedium.Text = "Medium";
            StripMedium.Click += StripMedium_Click;
            // 
            // StripHard
            // 
            StripHard.Name = "StripHard";
            StripHard.Size = new Size(182, 34);
            StripHard.Text = "Hard";
            StripHard.Click += StripHard_Click;
            // 
            // BtnUndo
            // 
            BtnUndo.BackColor = Color.FromArgb(192, 192, 255);
            BtnUndo.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BtnUndo.Location = new Point(740, 462);
            BtnUndo.Margin = new Padding(3, 4, 3, 4);
            BtnUndo.Name = "BtnUndo";
            BtnUndo.Size = new Size(138, 59);
            BtnUndo.TabIndex = 7;
            BtnUndo.Text = "Undo";
            BtnUndo.UseVisualStyleBackColor = false;
            BtnUndo.Click += BtnUndo_Click;
            // 
            // Sudoku
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(902, 691);
            Controls.Add(BtnUndo);
            Controls.Add(lblText);
            Controls.Add(BtnReset);
            Controls.Add(BtnFinish);
            Controls.Add(lbltmr);
            Controls.Add(BtnStart);
            Controls.Add(BtnCorrect);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Sudoku";
            Text = "Sudoku";
            Load += Sudoku_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCorrect;
        private Button BtnStart;
        private Label lbltmr;
        private System.Windows.Forms.Timer tmr;
        private Button BtnFinish;
        private Button BtnReset;
        private Label lblText;
        private System.Windows.Forms.Timer msgTmr;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 타임어택ToolStripMenuItem;
        private ToolStripMenuItem 분ToolStripMenuItem;
        private ToolStripMenuItem 분ToolStripMenuItem1;
        private ToolStripMenuItem 분ToolStripMenuItem2;
        private ToolStripMenuItem 분ToolStripMenuItem3;
        private ToolStripMenuItem 타임어택모드끄기ToolStripMenuItem;
        private ToolStripMenuItem 모드변경ToolStripMenuItem;
        private ToolStripMenuItem 기본ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem RegularMode99;
        private ToolStripMenuItem 난이도ToolStripMenuItem;
        private ToolStripMenuItem StripEasy;
        private ToolStripMenuItem StripMedium;
        private ToolStripMenuItem StripHard;
        private Button BtnUndo;
    }
}