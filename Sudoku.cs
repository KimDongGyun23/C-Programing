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
        int[,] answerArray;

        int MAXINPUTVALUE = 9;
        int MININPUTVALUE = 1;

        int nCount = 0;             // 타이머 시간변수
        int colorChange = 0;        // msg 타이머 시간변수

        int nAttCount = 0;          // 타임어택 모드 시간변수
        bool timeAttack = false;    // 타임어택 여부 변수
        string tmrText = "";        // 타임어택 시간을 라벨에 넘기기 위한 변수



        int mode = 0;
        int cell_edge_len = 40;
        Point point = new Point(220, 139);




        Color DEFAULTCOLOR = Color.White;
        Color SELECTEDCOLOR = Color.LightCyan;
        Color INVALIDCOLOR = Color.IndianRed;

        public Sudoku()
        {
            InitializeComponent();

            //기본적인 GameBoard 초기화가 없어서 추가합니다.
            GameBoard = new RegularSudokuGameBoard(20,3);
        }

        // form 실행 시 동작. 현재는 9 * 9 기준으로 작성되어 있음.
        // 추후에 다른 형태도 구현할 시 형태 별로 따로 구현할 예정.
        private void Sudoku_Load(object sender, EventArgs e)
        {
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

            /// 더블클릭 후, 해당 셀에 텍스트가 비어있으면 GameBoard 값을 0으로 만들기
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
                cell.BackColor = DEFAULTCOLOR;

                if (cell.HasChildren)
                {
                    int index = cell.Controls.Count - 1;

                    cell.Controls[index].BackColor = DEFAULTCOLOR;
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
                if (inputCell.Text.All(char.IsDigit)) // check text has non-numbers
                {
                    int inputValue = Int32.Parse(inputCell.Text);

                    int cellNumber = (int)cell.Tag; // cellNumber = 9 * cellX + cellY
                    int cellX = cellNumber / 9;
                    int cellY = cellNumber % 9;

                    if (inputValue >= MININPUTVALUE && inputValue <= MAXINPUTVALUE)
                    {
                        GameBoard[cellX, cellY] = inputValue;
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
                cell.BackColor = DEFAULTCOLOR;
                inputCell.BackColor = DEFAULTCOLOR;
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
                // cell의 유효성 초기화
                isValid[i] = true;
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
                foreach (Label cell in cells)
                {
                    cell.BackColor = DEFAULTCOLOR;
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
            //cells = new List<Label>();

            // Start 버튼 비활성화
            BtnStart.Enabled = false;

            // 타이머 시작 및 정답값 랜덤 생성
            tmr.Start();
            lblText.Text = lblText.Text = "끝까지 도전해보세요.";


            if (mode == 0)
            {
                GameBoard = new RegularSudokuGameBoard(20, 3);
            }
            else if (mode == 1)
            {
                GameBoard = new RegularSudokuGameBoard(3, 2);
            }

            //새 스도쿠를 생성하는 버튼
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
                    //cell위치는 그냥 Location으로 설정하면 됩니다.
                    //cell.Top = inputBoxPositions[i, j].Y;
                    //cell.Left = inputBoxPositions[i, j].X;
                    cell.Location = inputBoxPositions[i, j];

                    cells.Add(cell);
                    isValid.Add(true);
                    Controls.Add(cell);

                    // cell의 left value 갱신
                    cellLeftValue += cellSize;
                }
                // cell의 top value 갱신
                cellTopValue += cellSize;
            }

            for (int i = 0; i < GameBoard.GridSize; i++)
            {
                for (int j = 0; j < GameBoard.GridSize; j++)
                {
                    //이미 클래스 내부에서 랜덤으로 빈칸을 만들기 때문에 랜덤관련 부분은 삭제했습니다.
                    Label cell = cells[GameBoard.GridSize * i + j];

                    if (!GameBoard.IsFixed[i, j])
                    {
                        GameBoard[i, j] = 0;
                        cell.Text = "";
                    }
                    else
                    {
                        cell.Text = GameBoard[i, j].ToString();
                    }

                    // add cell event
                    cell.MouseDoubleClick += Cell_DoubleClick;
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

                // 유효성 검사
                if (!GameBoard.IsValidAll())
                {
                    foreach (Tuple<int, int> tuple in GameBoard.FindWrongCells())
                    {
                        isValid[9 * tuple.Item1 + tuple.Item2] = false;
                        cells[9 * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                    }
                }
            }
            else
            {
                lblText.Text = "올바르게 입력되었습니다.";
            }

            // 2초 뒤 원래의 색으로 돌아오도록 설정
            // Correct 버튼 연속 입력 방지하기 위해 비활성화
            msgTmr.Start();
            BtnCorrect.Enabled = false;
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
            // Finish 버튼보다 Reset 버튼을 먼저 누르는 경우 방지하여 타이머 정지
            tmr.Stop();

            // 셀의 값을 모두 지움
            ClearCells();

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
            // Start 버튼 활성화
            BtnStart.Enabled = true;

            // 라벨 텍스트 초기화
            lblText.Text = "게임을 시작해 주세요.";
        }

        private void 숫자생성개수변화ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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


        private void RegularMode99_Click(object sender, EventArgs e)
        {
            ClearCells();
            mode = 0;
            point.X = 220;
            point.Y = 139;
            int MAXINPUTVALUE = 9;

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ClearCells();
            mode = 1;
            point.X = 220;
            point.Y = 139;
            int MAXINPUTVALUE = 4;
        }
    }
}