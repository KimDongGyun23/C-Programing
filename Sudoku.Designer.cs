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
            this.lbltmr = new System.Windows.Forms.Label();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.BtnFinish = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.msgTmr = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.모드변경ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripRegular = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.RegularMode99 = new System.Windows.Forms.ToolStripMenuItem();
            this.RegularMode16 = new System.Windows.Forms.ToolStripMenuItem();
            this.StripOdd = new System.Windows.Forms.ToolStripMenuItem();
            this.StripSamurai = new System.Windows.Forms.ToolStripMenuItem();
            this.타임어택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.분ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.타임어택모드끄기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.난이도ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.StripHard = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnUndo = new System.Windows.Forms.Button();
            this.lblLevel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCorrect
            // 
            this.BtnCorrect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCorrect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnCorrect.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCorrect.Location = new System.Drawing.Point(666, 186);
            this.BtnCorrect.Name = "BtnCorrect";
            this.BtnCorrect.Size = new System.Drawing.Size(124, 47);
            this.BtnCorrect.TabIndex = 0;
            this.BtnCorrect.Text = "Correct";
            this.BtnCorrect.UseVisualStyleBackColor = false;
            this.BtnCorrect.Click += new System.EventHandler(this.BtnCorrect_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnStart.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnStart.Location = new System.Drawing.Point(40, 186);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(124, 47);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lbltmr
            // 
            this.lbltmr.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.BtnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnFinish.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFinish.Location = new System.Drawing.Point(40, 278);
            this.BtnFinish.Name = "BtnFinish";
            this.BtnFinish.Size = new System.Drawing.Size(124, 47);
            this.BtnFinish.TabIndex = 3;
            this.BtnFinish.Text = "Finish";
            this.BtnFinish.UseVisualStyleBackColor = false;
            this.BtnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnReset.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnReset.Location = new System.Drawing.Point(666, 278);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(124, 47);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblText.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblText.Location = new System.Drawing.Point(240, 98);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(350, 20);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "게임을 시작해 주세요.";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // msgTmr
            // 
            this.msgTmr.Interval = 1000;
            this.msgTmr.Tick += new System.EventHandler(this.msgTmr_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.모드변경ToolStripMenuItem,
            this.타임어택ToolStripMenuItem,
            this.난이도ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 모드변경ToolStripMenuItem
            // 
            this.모드변경ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripRegular,
            this.StripOdd,
            this.StripSamurai});
            this.모드변경ToolStripMenuItem.Name = "모드변경ToolStripMenuItem";
            this.모드변경ToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.모드변경ToolStripMenuItem.Text = "모드 변경";
            // 
            // StripRegular
            // 
            this.StripRegular.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.RegularMode99,
            this.RegularMode16});
            this.StripRegular.Name = "StripRegular";
            this.StripRegular.Size = new System.Drawing.Size(202, 26);
            this.StripRegular.Text = "기본";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(140, 26);
            this.toolStripMenuItem4.Text = "4 * 4";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // RegularMode99
            // 
            this.RegularMode99.Name = "RegularMode99";
            this.RegularMode99.Size = new System.Drawing.Size(140, 26);
            this.RegularMode99.Text = "9 * 9";
            this.RegularMode99.Click += new System.EventHandler(this.RegularMode99_Click);
            // 
            // RegularMode16
            // 
            this.RegularMode16.Name = "RegularMode16";
            this.RegularMode16.Size = new System.Drawing.Size(140, 26);
            this.RegularMode16.Text = "16 * 16";
            this.RegularMode16.Click += new System.EventHandler(this.RegularMode16_Click);
            // 
            // StripOdd
            // 
            this.StripOdd.Name = "StripOdd";
            this.StripOdd.Size = new System.Drawing.Size(202, 26);
            this.StripOdd.Text = "홀짝 스도쿠";
            this.StripOdd.Click += new System.EventHandler(this.StripOdd_Click);
            // 
            // StripSamurai
            // 
            this.StripSamurai.Name = "StripSamurai";
            this.StripSamurai.Size = new System.Drawing.Size(202, 26);
            this.StripSamurai.Text = "사무라이 스도쿠";
            this.StripSamurai.Click += new System.EventHandler(this.StripSamurai_Click);
            // 
            // 타임어택ToolStripMenuItem
            // 
            this.타임어택ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.분ToolStripMenuItem,
            this.분ToolStripMenuItem1,
            this.분ToolStripMenuItem2,
            this.분ToolStripMenuItem3,
            this.타임어택모드끄기ToolStripMenuItem});
            this.타임어택ToolStripMenuItem.Name = "타임어택ToolStripMenuItem";
            this.타임어택ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.타임어택ToolStripMenuItem.Text = "타임어택";
            // 
            // 분ToolStripMenuItem
            // 
            this.분ToolStripMenuItem.Name = "분ToolStripMenuItem";
            this.분ToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.분ToolStripMenuItem.Text = "10분";
            this.분ToolStripMenuItem.Click += new System.EventHandler(this.분ToolStripMenuItem_Click);
            // 
            // 분ToolStripMenuItem1
            // 
            this.분ToolStripMenuItem1.Name = "분ToolStripMenuItem1";
            this.분ToolStripMenuItem1.Size = new System.Drawing.Size(217, 26);
            this.분ToolStripMenuItem1.Text = "7분";
            this.분ToolStripMenuItem1.Click += new System.EventHandler(this.분ToolStripMenuItem1_Click);
            // 
            // 분ToolStripMenuItem2
            // 
            this.분ToolStripMenuItem2.Name = "분ToolStripMenuItem2";
            this.분ToolStripMenuItem2.Size = new System.Drawing.Size(217, 26);
            this.분ToolStripMenuItem2.Text = "5분";
            this.분ToolStripMenuItem2.Click += new System.EventHandler(this.분ToolStripMenuItem2_Click);
            // 
            // 분ToolStripMenuItem3
            // 
            this.분ToolStripMenuItem3.Name = "분ToolStripMenuItem3";
            this.분ToolStripMenuItem3.Size = new System.Drawing.Size(217, 26);
            this.분ToolStripMenuItem3.Text = "3분";
            this.분ToolStripMenuItem3.Click += new System.EventHandler(this.분ToolStripMenuItem3_Click);
            // 
            // 타임어택모드끄기ToolStripMenuItem
            // 
            this.타임어택모드끄기ToolStripMenuItem.Name = "타임어택모드끄기ToolStripMenuItem";
            this.타임어택모드끄기ToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.타임어택모드끄기ToolStripMenuItem.Text = "타임어택모드 끄기";
            this.타임어택모드끄기ToolStripMenuItem.Click += new System.EventHandler(this.타임어택모드끄기ToolStripMenuItem_Click);
            // 
            // 난이도ToolStripMenuItem
            // 
            this.난이도ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripEasy,
            this.StripMedium,
            this.StripHard});
            this.난이도ToolStripMenuItem.Name = "난이도ToolStripMenuItem";
            this.난이도ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.난이도ToolStripMenuItem.Text = "난이도";
            // 
            // StripEasy
            // 
            this.StripEasy.Name = "StripEasy";
            this.StripEasy.Size = new System.Drawing.Size(149, 26);
            this.StripEasy.Text = "Easy";
            this.StripEasy.Click += new System.EventHandler(this.StripEasy_Click);
            // 
            // StripMedium
            // 
            this.StripMedium.Name = "StripMedium";
            this.StripMedium.Size = new System.Drawing.Size(149, 26);
            this.StripMedium.Text = "Medium";
            this.StripMedium.Click += new System.EventHandler(this.StripMedium_Click);
            // 
            // StripHard
            // 
            this.StripHard.Name = "StripHard";
            this.StripHard.Size = new System.Drawing.Size(149, 26);
            this.StripHard.Text = "Hard";
            this.StripHard.Click += new System.EventHandler(this.StripHard_Click);
            // 
            // BtnUndo
            // 
            this.BtnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnUndo.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnUndo.Location = new System.Drawing.Point(666, 368);
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(124, 47);
            this.BtnUndo.TabIndex = 7;
            this.BtnUndo.Text = "Undo";
            this.BtnUndo.UseVisualStyleBackColor = false;
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("휴먼모음T", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLevel.Location = new System.Drawing.Point(25, 52);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(116, 17);
            this.lblLevel.TabIndex = 8;
            this.lblLevel.Text = "난이도 : Medium";
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(812, 553);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.BtnUndo);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnFinish);
            this.Controls.Add(this.lbltmr);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnCorrect);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sudoku";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Sudoku_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ToolStripMenuItem StripRegular;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem RegularMode99;
        private ToolStripMenuItem 난이도ToolStripMenuItem;
        private ToolStripMenuItem StripEasy;
        private ToolStripMenuItem StripMedium;
        private ToolStripMenuItem StripHard;
        private ToolStripMenuItem RegularMode16;
        private ToolStripMenuItem StripOdd;
        private ToolStripMenuItem StripSamurai;
        private Button BtnUndo;
        private Label lblLevel;
    }
}