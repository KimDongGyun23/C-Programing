using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SudokuDataLib;
using drawing_test;

namespace Sudoku_Play
{
    public partial class Sudoku : Form
    {
        GameBoard GameBoard;

        List<Label> cells = new List<Label>(); // form에 표시되는 cell 제어
        List<bool> isValid = new List<bool>(); // cell 유효성 저장

        int MAXINPUTVALUE = 9;      // 초기 9*9 기본 설정
        int MININPUTVALUE = 1;

        int nCount = 0;             // 타이머 시간변수
        int colorChange = 0;        // msg 타이머 시간변수

        int nAttCount = 0;          // 타임어택 모드 시간변수
        bool timeAttack = false;    // 타임어택 여부 변수
        string tmrText = "";        // 타임어택 시간을 라벨에 넘기기 위한 변수

        int mode = 0;               // 변형 스도쿠 모드 변수
        int level = 1;         // 출력될 힌트 개수
        int cell_edge_len = 40;     
        Point point = new Point(220, 139);  // 그리드 출력될 위치


        Color DEFAULTCOLOR = Color.White;
        Color SELECTEDCOLOR = Color.LightCyan;
        Color INVALIDCOLOR = Color.IndianRed;
        Color ODDCOLOR = Color.DarkGray;

        /// 난이도/mode    9*9    4*4   16*16   홀짝    사무라이     직쏘
        ///     EASY        40     5      95     40       130         40
        ///     MEDIUM      35     5      80     35       115         35
        ///     HARD        30     5      65     30       100         30
        int [,] fixedCnt = {
            {40, 5, 95, 40, 130, 40},
            {35, 5, 80, 35, 115, 35},
            {30, 5, 65, 30, 100, 30}
        };

        public Sudoku()
        {
            InitializeComponent();
        }

        private void Sudoku_Load(object sender, EventArgs e)
        {
            BtnCorrect.Enabled = false;
            BtnFinish.Enabled = false;
            BtnReset.Enabled = false;
            BtnUndo.Enabled = false;
        }

        // cell을 더블클릭 시 입력창이 나와 값을 수정할 수 있음.
        // 입력창은 enter와 esc에 반응함.
        private void Cell_DoubleClick(object? sender, EventArgs e)
        {
            Label? cell = (Label?)sender;
            TextBox inputCell = new TextBox();

            inputCell.BackColor = cell.BackColor;
            inputCell.TextAlign = HorizontalAlignment.Center;
            inputCell.BorderStyle = BorderStyle.None;
            inputCell.Width = cell.Width;
            inputCell.Top = 2 + cell.Height / 4;
            inputCell.Left = 0;

            inputCell.KeyPress += InputCell_KeyPress;
            inputCell.MouseEnter += InputCell_MouseEnter;
            inputCell.MouseLeave += InputCell_MouseLeave;

            cell.Controls.Add(inputCell);
            inputCell.Focus();
        }

        private void Cell_Enter(object? sender, EventArgs e)
        {
            Label? cell = (Label?)sender;
            cell.BackColor = SELECTEDCOLOR;

            if (cell.HasChildren)
            {
                int index = cell.Controls.Count - 1;
                cell.Controls[index].BackColor = SELECTEDCOLOR;
            }
        }

        // 마우스 커서가 cell을 벗어날 시 cell의 색이 돌아옴.
        // 돌아오는 색은 cell의 유효성을 기준으로 판단함.
        private void Cell_Leave(object? sender, EventArgs e)
        {
            Label? cell = (Label?)sender;
            int cellNumber = (int)cell.Tag;

            if (isValid[(int)cell.Tag])
            {
                // 홀짝 모드 시 컬러 초기화
                if (mode == 3)
                {
                    int col = cellNumber / GameBoard.GridSize;
                    int row = cellNumber % GameBoard.GridSize;

                    if (GameBoard.GetColoredGrid()[col, row]) cell.BackColor = ODDCOLOR;
                    else cell.BackColor = DEFAULTCOLOR;
                }
                else
                {
                    cell.BackColor = DEFAULTCOLOR;
                    if (cell.HasChildren)
                    {
                        int index = cell.Controls.Count - 1;
                        cell.Controls[index].BackColor = DEFAULTCOLOR;
                    }
                }
            }
            else
            {
                cell.BackColor = INVALIDCOLOR;
                if (cell.HasChildren)
                {
                    int index = cell.Controls.Count - 1;
                    cell.Controls[index].BackColor = INVALIDCOLOR;
                }
            }
        }
        // cell 더블클릭 시 나오는 입력창 제어에 사용되는 이벤트.
        // enter: 1 ~ 9 사이의 값이 입력되었을 경우 해당하는 cell의 값을 변경함. (9 * 9 기준)
        // esc: 입력값에 상관없이 창을 닫음.
        private void InputCell_KeyPress(object? sender, KeyPressEventArgs e)
        {
            TextBox? inputCell = (TextBox?)sender;
            Label cell = (Label)inputCell.Parent;

            if (e.KeyChar == (char)Keys.Return)
            {
                if (inputCell.Text.Length != 0 && inputCell.Text.All(char.IsDigit)) // check text has non-numbers
                {
                    int inputValue = Int32.Parse(inputCell.Text);

                    int cellNumber = (int)cell.Tag; // cellNumber = 9 * cellX + cellY
                    int cellX = cellNumber / GameBoard.GridSize;
                    int cellY = cellNumber % GameBoard.GridSize;

                    if (inputValue >= MININPUTVALUE && inputValue <= MAXINPUTVALUE)
                    {
                        GameBoard[cellX, cellY] = inputValue;
                        cells[cellNumber].ForeColor = Color.Black;
                        cells[cellNumber].Font = new Font(cells[cellNumber].Font, FontStyle.Regular);
                        cells[cellNumber].Text = inputValue.ToString();
                    }
                    else if (inputValue == 0)
                    {
                        GameBoard[cellX, cellY] = 0;
                        cells[cellNumber].Text = "";
                    }
                }
                inputCell.MouseLeave -= InputCell_MouseLeave;
                cell.Controls.Remove(inputCell); // 입력창 제거
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                inputCell.MouseLeave -= InputCell_MouseLeave;
                cell.Controls.Remove(inputCell);
            }
        }

        // inputCell MouseEnter event handler.
        // parent와 child의 배경색을 동시에 변경한다.
        // parent의 event hanlder와 상호보완적으로 동작함.
        private void InputCell_MouseEnter(object? sender, EventArgs e)
        {
            TextBox? inputCell = (TextBox?)sender;
            Label cell = (Label)inputCell.Parent;

            cell.BackColor = SELECTEDCOLOR;
            inputCell.BackColor = SELECTEDCOLOR;
        }

        // inputCell MouseLeave event handler.
        // parent와 child의 배경색을 동시에 변경한다.
        // parent의 event handler와 상호보완적으로 동작함
        private void InputCell_MouseLeave(object? sender, EventArgs e)
        {
            TextBox? inputCell = (TextBox?)sender;
            Label cell = (Label)inputCell.Parent;

            int cellNumber = (int)cell.Tag;

            if (isValid[cellNumber])
            {
                if (mode == 3)
                {
                    int col = cellNumber / GameBoard.GridSize;
                    int row = cellNumber % GameBoard.GridSize;

                    if (GameBoard.GetColoredGrid()[col, row])
                    {
                        cell.BackColor = ODDCOLOR;
                        inputCell.BackColor = ODDCOLOR;

                    }
                    else
                    {
                        cell.BackColor = DEFAULTCOLOR;
                        inputCell.BackColor = DEFAULTCOLOR;
                    }

                }
                else
                {
                    cell.BackColor = DEFAULTCOLOR;
                    inputCell.BackColor = DEFAULTCOLOR;
                }
            }
            else
            {
                cell.BackColor = INVALIDCOLOR;
                inputCell.BackColor = INVALIDCOLOR;
            }
        }

        // cell에 설정되어 있는 property 초기화
        private void ClearCells()
        {
            foreach (Label cell in cells)
            {
                // reset cell properties
                cell.Text = null;
                cell.BackColor = DEFAULTCOLOR;

                // remove all events
                cell.MouseDoubleClick -= Cell_DoubleClick;
                cell.MouseEnter -= Cell_Enter;
                cell.MouseLeave -= Cell_Leave;
            }

            for (int i = 0; i < isValid.Count; i++)
            {
                isValid[i] = true;      // cell의 유효성 초기화
            }
        }

        // 타이머 동작
        private void tmr_Tick(object sender, EventArgs e)
        {
            if (timeAttack)
                nCount--;
            else
                nCount++;

            int hour = 0, min = 0, sec = 0;

            if (nCount < 60)
                sec = nCount;
            else if (nCount < 3600)
            {
                min = nCount / 60;
                sec = nCount % 60;
            }
            else
            {
                hour = nCount / 3600;
                min = (nCount % 3600) / 60;
                sec = ((nCount % 3600) % 60);
            }
            lbltmr.Text = hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");

            // 타임어택 시간 종료 시, 타이머 정지 및 라벨 초기화
            if (nCount < 0)
            {
                lbltmr.Text = "00:00:00";
                tmr.Stop();
                lblText.Text = "게임을 클리어 하지 못했습니다.";
            }
        }

        private void msgTmr_Tick(object sender, EventArgs e)
        {
            ++colorChange;
            if (colorChange == 2)
            {
                // 모든 셀 다시 기본 색상으로 변경
                if (mode == 3)
                {
                    for (int i = 0; i < GameBoard.GridSize; i++)
                    {
                        for (int j = 0; j < GameBoard.GridSize; j++)
                        {
                            if (GameBoard.GetColoredGrid()[i, j])
                                cells[GameBoard.GridSize * i + j].BackColor = ODDCOLOR;
                            else
                                cells[GameBoard.GridSize * i + j].BackColor = DEFAULTCOLOR;
                        }
                    }
                }
                else
                {
                    foreach (Label cell in cells)
                    {
                        cell.BackColor = DEFAULTCOLOR;
                    }
                }

                // label 문구 다시 초기화
                msgTmr.Stop();
                colorChange = 0;
                lblText.Text = "끝까지 도전해보세요.";
                BtnCorrect.Enabled = true;

                isValid.Clear();

                for (int i = 0; i < cells.Count; i++)
                    isValid.Add(true);
            }
        }

        /// START 버튼 구현
        /// 생성된 sudoku GameBoard를 form에 표시
        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Start 버튼 비활성화
            BtnStart.Enabled = false;
            BtnCorrect.Enabled = true;
            BtnFinish.Enabled = true;
            BtnReset.Enabled = true;
            BtnUndo.Enabled = true;

            // 타이머 시작 및 정답값 랜덤 생성
            tmr.Start();
            lblText.Text = lblText.Text = "끝까지 도전해보세요.";

            // 9 * 9
            if (mode == 0)
            {
                GameBoard = new RegularSudokuGameBoard(fixedCnt[level,mode], 3);
            }
            // 4 * 4
            else if (mode == 1)
            {
                GameBoard = new RegularSudokuGameBoard(fixedCnt[level, mode], 2);
            }
            //16 * 16
            else if (mode == 2)
            {
                GameBoard = new RegularSudokuGameBoard(fixedCnt[level, mode], 4);
            }
            // 홀짝 스도쿠
            else if (mode == 3)
            {
                GameBoard = new OddEvenSudokuGameBoard(fixedCnt[level, mode], 3);
            }
            // 사무라이 스도쿠
            else if (mode == 4)
            {
                GameBoard = new SamuraiSudokuGameBoard(fixedCnt[level, mode]);
            }
            // 직쏘 스도쿠
            else if (mode == 5)
            {
                GameBoard = new JigsawSudokuGameBoard(fixedCnt[level, mode],3);
            }

            GameBoard.ResetSudoku();
            Point[,] inputBoxPositions = draw_grid.DrawBoard(cell_edge_len, point, GameBoard.AreaGroup, GameBoard.GridSize, this);

            int cellSize = draw_grid.input_edge_len;
            int cellWidth = cellSize;
            int cellHeight = cellSize;
            int cellTopValue = point.Y;

            // 숫자 비어있는 sudoku grid 생성
            for (int i = 0; i < GameBoard.GridSize; i++)
            {
                int cellLeftValue = point.X;
                for (int j = 0; j < GameBoard.GridSize; j++)
                {
                    // create cell object
                    Label cell = new Label();

                    // set cell property
                    cell.Tag = GameBoard.GridSize * i + j;
                    cell.BackColor = DEFAULTCOLOR;
                    cell.TextAlign = ContentAlignment.MiddleCenter;
                    cell.BorderStyle = BorderStyle.None;
                    cell.Width = cellWidth;
                    cell.Height = cellHeight;
                    cell.Location = inputBoxPositions[i, j];

                    cells.Add(cell);
                    isValid.Add(true);
                    Controls.Add(cell);
                    
                    cellLeftValue += cellSize;      // cell의 left value 갱신
                }
                cellTopValue += cellSize;           // cell의 top value 갱신
            }

            for (int i = 0; i < GameBoard.GridSize; i++)
            {
                for (int j = 0; j < GameBoard.GridSize; j++)
                {
                    Label cell = cells[GameBoard.GridSize * i + j];

                    if (!GameBoard.IsFixed[i, j])
                    {
                        cell.Text = "";
                        cell.MouseDoubleClick += Cell_DoubleClick;
                    }
                    else
                    {
                        cell.ForeColor = Color.Green;
                        cell.Font = new Font(cell.Font, FontStyle.Bold);
                        cell.Text = GameBoard[i, j].ToString();
                        
                    }
                    if (mode == 3)
                    {
                        if (GameBoard.GetColoredGrid()[i, j])
                            cells[GameBoard.GridSize * i + j].BackColor = ODDCOLOR;
                        cell.MouseDoubleClick += Cell_DoubleClick;
                    }
                    // add cell event
                    cell.MouseEnter += Cell_Enter;
                    cell.MouseLeave += Cell_Leave;
                }
            }
        }

        // Correct 버튼 구현
        private void BtnCorrect_Click(object sender, EventArgs e)
        {
            if (!GameBoard.IsValidAll())
            {
                lblText.Text = "틀린 부분이 있군요. 다시 생각해보세요.";

                for (int i = 0; i < GameBoard.GridSize; i++)
                {
                    for (int j = 0; j < GameBoard.GridSize; j++)
                    {
                        // 유효성 검사
                        foreach (Tuple<int, int> tuple in GameBoard.FindWrongCells(i, j))
                        {
                            isValid[GameBoard.GridSize * tuple.Item1 + tuple.Item2] = false;
                            cells[GameBoard.GridSize * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                        }
                    }
                    /*// 유효성 검사 -> 함수 사용 잘못함
                    foreach (Tuple<int, int> tuple in GameBoard.FindWrongCells())
                    {
                        isValid[GameBoard.GridSize * tuple.Item1 + tuple.Item2] = false;
                        cells[GameBoard.GridSize * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                    }*/
                }
            }
            else
            {
                lblText.Text = "올바르게 입력되었습니다.";
            }

            msgTmr.Start();                 // 2초 뒤 원래의 색으로 돌아오도록 설정
            BtnCorrect.Enabled = false;     // Correct 버튼 연속 입력 방지하기 위해 비활성화
        }

        /// Finish 버튼 구현
        /// 셀에 모든 값들이 입력되었고 규칙에 위배되지않으면 성공 문구 출력
        /// 성공 시, 타이머 정지
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (GameBoard.IsValidSudoku())
            {
                lblText.Text = "축하합니다. 게임을 클리어 했습니다.";
                tmr.Stop();
            }
            else
            {
                lblText.Text = "틀린 곳이 있군요! 다시 수정해보세요.";
                msgTmr.Start();
            }
        }

        /// Reset 버튼 구현
        /// 셀의 값들을 모두 지우고 타이머 초기화
        /// Start 버튼 활성화 및 라벨 텍스트 초기화
        private void BtnReset_Click(object sender, EventArgs e)
        {
            tmr.Stop();     // Finish 버튼보다 Reset 버튼을 먼저 누르는 경우 방지하여 타이머 정지
            ClearCells();   // 셀의 값을 모두 지움

            // 타임어택 모드 여부에 따라 타이머와 라벨 초기화
            if (timeAttack)
            {
                nCount = nAttCount;
                lbltmr.Text = tmrText;
            }
            else
            {
                nCount = 0;
                lbltmr.Text = "00:00:00";
            }
            BtnStart.Enabled = true;                     // Start 버튼 활성화
            lblText.Text = "게임을 시작해 주세요.";      // 라벨 텍스트 초기화
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if(GameBoard.CanUndo()){
                var retrun_value = GameBoard.Undo();
                int cellNumber = retrun_value.Item1 * GameBoard.GridSize + retrun_value.Item2;
                if (retrun_value.Item3 != 0)
                {
                    cells[cellNumber].Text = retrun_value.Item3.ToString();
                }
                else
                {
                    cells[cellNumber].Text = "";
                }
            }
        }
        private void 분ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 10;
            nCount = nAttCount;
            tmrText = "00:10:00";
            lbltmr.Text = tmrText;
        }
        private void 분ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 7;
            nCount = nAttCount;
            tmrText = "00:07:00";
            lbltmr.Text = tmrText;
        }
        private void 분ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 5;
            nCount = nAttCount;
            tmrText = "00:05:00";
            lbltmr.Text = tmrText;
        }
        private void 분ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 3;
            nCount = nAttCount;
            tmrText = "00:03:00";
            lbltmr.Text = tmrText;
        }
        private void 타임어택모드끄기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timeAttack = false;
            nCount = 0;
            lbltmr.Text = "00:00:00";
        }

        // 9 * 9
        private void RegularMode99_Click(object sender, EventArgs e)
        {
            mode = 0;
            foreach (Label cell in cells)
                Controls.Remove(cell);  // 셀을 지움

            Invalidate();               // 그리드 그래픽 지움

            this.Width = 830;           // 폼 크기 변경
            this.Height = 600;

            cells = new List<Label>();  // 셀 초기화
            point.X = 220;
            point.Y = 139;
            MAXINPUTVALUE = 9;
        }

        // 4 * 4
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            mode = 1; 
            foreach (Label cell in cells)
                Controls.Remove(cell);  // 셀을 지움

            Invalidate();               // 그리드 그래픽 지움

            this.Width = 830;           // 폼 크기 변경
            this.Height = 600;

            cells = new List<Label>();  // 셀 초기화
            point.X = 325;
            point.Y = 180;
            MAXINPUTVALUE = 4;
        }

        // 16 * 16
        private void RegularMode16_Click(object sender, EventArgs e)
        {
            mode = 2;
            foreach (Label cell in cells)
                Controls.Remove(cell);  // 셀을 지움

            Invalidate();               // 그리드 그래픽 지움

            this.Width = 1100;          // 폼 크기 변경
            this.Height = 900;

            cells = new List<Label>();  // 셀 초기화

            point.X = 220;
            point.Y = 139;
            MAXINPUTVALUE = 16;
        }
        
        // 홀짝 스도쿠
        private void StripOdd_Click(object sender, EventArgs e)
        {
            mode = 3;
            foreach (Label cell in cells)
                Controls.Remove(cell);  // 셀을 지움

            Invalidate();               // 그리드 그래픽 지움

            this.Width = 830;           // 폼 크기 변경
            this.Height = 600;

            cells = new List<Label>();  // 셀 초기화
            point.X = 220;
            point.Y = 139;

            MAXINPUTVALUE = 9;

        }
        
        // 사무라이 스도쿠
        private void StripSamurai_Click(object sender, EventArgs e)
        {
            mode = 4;
            foreach (Label cell in cells)
                Controls.Remove(cell);  // 셀 지움

            Invalidate();               // 그리드 그래픽 지움

            this.Width = 1300;          // 폼 크기 변경
            this.Height = 1100;

            cells = new List<Label>();  // 셀 초기화

            point.X = 220;
            point.Y = 139;
            MAXINPUTVALUE = 9;
        }

        // 직쏘 스도쿠
        private void StripJigsaw_Click(object sender, EventArgs e)
        {
            mode = 5;
            foreach (Label cell in cells)
                Controls.Remove(cell);  // 셀 지움

            Invalidate();               // 그리드 그래픽 지움

            this.Width = 830;           // 폼 크기 변경
            this.Height = 600;

            cells = new List<Label>();  // 셀 초기화
            point.X = 220;
            point.Y = 139;
            MAXINPUTVALUE = 9;

        }

        // 난이도 Easy 모드
        private void StripEasy_Click(object sender, EventArgs e)
        {
            level = 0;
            lblLevel.Text = "난이도 : Easy";
        }

        // 난이도 Medium 모드
        private void StripMedium_Click(object sender, EventArgs e)
        {
            level = 1;
            lblLevel.Text = "난이도 : Medium";
        }

        // 난이도 Hard 모드
        private void StripHard_Click(object sender, EventArgs e)
        {
            level = 2;
            lblLevel.Text = "난이도 : Hard";
        }
    }
}