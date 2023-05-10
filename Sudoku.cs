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

namespace Sudoku_Play
{
    public partial class Sudoku : Form
    {
        GameBorad gameBoard = new GameBorad(); // sudoku gameboard
        List<Label> cells = new List<Label>(); // form에 표시되는 cell 제어
        List<bool> isValid = new List<bool>(); // cell 유효성 저장

        const int MAXINPUTVALUE = 9;
        const int MININPUTVALUE = 1;

        // 타이머 변수
        int nCount = 0;
        int colorChange = 0;

        Color DEFAULTCOLOR = Color.White;
        Color SELECTEDCOLOR = Color.LightCyan;
        Color INVALIDCOLOR = Color.IndianRed;

        int[,] answerArray = {
                { 8, 3, 9, 6, 5, 7, 2, 1, 4},
                { 6, 7, 2, 9, 4, 1, 5, 8, 3},
                { 1, 5, 4, 8, 3, 2, 9, 6, 7},
                { 5, 4, 1, 2, 8, 3, 7, 9, 6},
                { 2, 8, 7, 4, 9, 6, 3, 5, 1},
                { 9, 6, 3, 7, 1, 5, 4, 2, 8},
                { 7, 1, 8, 3, 2, 9, 6, 4, 5},
                { 3, 2, 5, 1, 6, 4, 8, 7, 9},
                { 4, 9, 6, 5, 7, 8, 1, 3, 2}
            };

        public Sudoku()
        {
            InitializeComponent();
        }

        // form 실행 시 동작. 현재는 9 * 9 기준으로 작성되어 있음.
        // 추후에 다른 형태도 구현할 시 형태 별로 따로 구현할 예정.
        private void Sudoku_Load(object sender, EventArgs e)
        {
            int cellWidth = 40;
            int cellHeight = 40;
            int cellTopValue = 7;

            // 숫자 비어있는 sudoku grid 생성
            for (int i = 0; i < gameBoard.Size; i++)
            {
                int cellLeftValue = 7;

                for (int j = 0; j < gameBoard.Size; j++)
                {
                    // create cell object
                    Label cell = new Label();

                    // set cell property
                    cell.Tag = 9 * i + j;
                    cell.BackColor = DEFAULTCOLOR;
                    cell.TextAlign = ContentAlignment.MiddleCenter;
                    cell.BorderStyle = BorderStyle.FixedSingle;
                    cell.Width = cellWidth;
                    cell.Height = cellHeight;
                    cell.Top = cellTopValue;
                    cell.Left = cellLeftValue;

                    cells.Add(cell);
                    isValid.Add(true);

                    sudokuGrid.Controls.Add(cell); // sudokuGrid에 cell 추가

                    // cell의 left value 갱신
                    cellLeftValue += cellWidth + ((j + 1) % 3 == 0 ? 7 : 0);
                }

                // cell의 top value 갱신
                cellTopValue += cellHeight + ((i + 1) % 3 == 0 ? 7 : 0);
            }
        }

        // 한 그룹당 열 3개를 포함한다고 생각
        // 그룹의 번호를 입력받아 해당 그룸 내에서 열들을 섞고, 그룹별로 열들을 다시 섞음
        // groupNum : 해당하는 그룹의 첫번째 열
        // groupNum = 0 : 0열, 1열, 2열
        // groupNum = 3 : 3열, 4열, 5열
        // groupNum = 6 : 6열, 7열, 8열
        private void SuffleRow(int groupNum, int n)
        {
            // n번 만큼 반복
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    // 그룹 내에서 열들의 순서를 변경
                    int temp1 = answerArray[j, groupNum];
                    int temp2 = answerArray[j, groupNum + 1];
                    int temp3 = answerArray[j, groupNum + 2];

                    answerArray[j, groupNum] = temp3;
                    answerArray[j, groupNum + 1] = temp1;
                    answerArray[j, groupNum + 2] = temp2;

                    // 그룹 별로 열을 바꿈
                    // groupNum = 0 인 열들을 groupNum = 3인 열들과 교환
                    // groupNum = 3 인 열들을 groupNum = 6인 열들과 교환
                    if (groupNum != 6)
                    {
                        answerArray[j, groupNum] = answerArray[j, groupNum + 4];
                        answerArray[j, groupNum + 1] = answerArray[j, groupNum + 5];
                        answerArray[j, groupNum + 2] = answerArray[j, groupNum + 3];

                        answerArray[j, groupNum + 3] = temp2;
                        answerArray[j, groupNum + 4] = temp1;
                        answerArray[j, groupNum + 5] = temp3;
                    }
                }
            }
        }

        /// 한 그룹당 행 3개를 포함한다고 생각        
        /// 그룹의 번호를 입력받아 해당 그룸 내에서 행들을 섞고, 그룹별로 행들을 다시 섞음
        /// groupNum : 해당하는 그룹의 첫번째 행
        /// groupNum = 0 : 0행, 1행, 2행
        /// groupNum = 3 : 3행, 4행, 5행
        /// groupNum = 6 : 6행, 7행, 8행

        private void SuffleCol(int groupNum, int n)
        {
            // n번 만큼 반복
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    // 그룹 내에서 행들의 순서를 변경
                    int temp1 = answerArray[groupNum, j];
                    int temp2 = answerArray[groupNum + 1, j];
                    int temp3 = answerArray[groupNum + 2, j];

                    answerArray[groupNum, j] = temp3;
                    answerArray[groupNum + 1, j] = temp1;
                    answerArray[groupNum + 2, j] = temp2;

                    // 그룹 별로 행을 바꿈
                    // groupNum = 0 인 행들을 groupNum = 3인 행들과 교환
                    // groupNum = 3 인 행들을 groupNum = 6인 행들과 교환
                    if (groupNum != 6)
                    {
                        answerArray[groupNum, j] = answerArray[groupNum + 4, j];
                        answerArray[groupNum + 1, j] = answerArray[groupNum + 5, j];
                        answerArray[groupNum + 2, j] = answerArray[groupNum + 3, j];

                        answerArray[groupNum + 3, j] = temp2;
                        answerArray[groupNum + 4, j] = temp1;
                        answerArray[groupNum + 5, j] = temp3;
                    }

                }
            }
        }

        // 난수를 생성하여 SuffleRow 와 SuffleCol 함수에 전달
        // 행과 열을 여러번 섞기 때문에 다양한 초기 값 생성 가능
        private void Rand_Num_Make()
        {
            Random randObj = new Random();
            int randNum = randObj.Next(0, 10);

            SuffleRow(0, randNum);
            SuffleCol(0, randNum);
            SuffleRow(3, randNum);
            SuffleCol(3, randNum);
            SuffleRow(6, randNum);
            SuffleCol(6, randNum);
        }



        // cell을 더블클릭 시 입력창이 나와 값을 수정할 수 있음.
        // 입력창은 enter와 esc에 반응함.
        private void Cell_DoubleClick(object? sender, EventArgs e)
        {
            Label? cell = (Label?)sender;
            TextBox inputCell = new TextBox();

            inputCell.BackColor = DEFAULTCOLOR;
            
            // inputCell.BackColor = (isValid[(int)cell.Tag] ? DEFAULTCOLOR : INVALIDCOLOR);

            inputCell.TextAlign = HorizontalAlignment.Center;
            inputCell.BorderStyle = BorderStyle.None;
            inputCell.Width = cell.Width;
            inputCell.Top = 2 + cell.Height / 4;
            inputCell.Left = 0;

            inputCell.KeyPress += InputCell_KeyPress;

            cell.Controls.Add(inputCell);
            inputCell.Focus();

            /// 더블클릭 후, 해당 셀에 텍스트가 비어있으면 gameBoard 값을 0으로 만들기

        }

        private void Cell_Enter(object? sender, EventArgs e)
        {
            Label? cell = (Label?)sender;

            cell.BackColor = SELECTEDCOLOR;
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
            }
            else
            {
                cell.BackColor = INVALIDCOLOR;
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
                if (!inputCell.Text.Equals("")) // not input any numbers
                {
                    int inputValue = Int32.Parse(inputCell.Text);

                    if (inputValue >= MININPUTVALUE && inputValue <= MAXINPUTVALUE)
                    {
                        int cellNumber = (int)cell.Tag; // cellNumber = 9 * cellX + cellY
                        int cellX = cellNumber / 9;
                        int cellY = cellNumber % 9;

                        gameBoard[cellX, cellY] = inputValue;
                        cells[cellNumber].Text = inputValue.ToString();
                    }

                    cell.Controls.Remove(inputCell); // 입력창 제거
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                cell.Controls.Remove(inputCell);
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

                for(int i = 0; i < cells.Count; i++)
                    isValid.Add(true);
            }
        }


        /// START 버튼 구현
        /// 생성된 sudoku gameboard를 form에 표시
        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Start 버튼 비활성화
            BtnStart.Enabled = false;

            // 타이머 시작 및 정답값 랜덤 생성
            tmr.Start();
            Rand_Num_Make();
            lblText.Text = lblText.Text = "끝까지 도전해보세요.";


            for (int i = 0; i < gameBoard.Size; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    gameBoard[i, j] = answerArray[i, j];
                    Label cell = cells[9 * i + j];

                    Random randObj1 = new Random();

                    // set cell value

                    // 자신의 값보다 +- 1만큼의 난수를 생성하여 해당 난수와 동일한 값일 경우 마스킹처리
                    // 랜덤값과 해당 칸의 숫자가 동일하지 않은 경우에만 값을 출력
                    // 난수의 범위를 지정한다면 난이도 조절 가능할 것으로 예상됨
                    // 추후 구현

                    if (gameBoard[i, j] == randObj1.Next(gameBoard[i, j] - 1, gameBoard[i, j] + 1))
                    {
                        gameBoard[i, j] = 0;
                        cell.Text = "";
                    }
                    else
                    {
                        cell.Text = gameBoard[i, j].ToString();
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
            if (!gameBoard.IsValidSudoku())
            {
                lblText.Text = "틀린 부분이 있군요. 다시 생각해보세요.";

                // 행 유효성 검사
                for (int i = 0; i < gameBoard.Size; i++)
                {
                    if (!gameBoard.IsValidGroup(GroupType.Row, i))
                    {
                        foreach (Tuple<int, int> tuple in gameBoard.FindWrongCells(GroupType.Row, i))
                        {
                            isValid[9 * tuple.Item1 + tuple.Item2] = false;
                            cells[9 * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                        }
                    }
                }

                // 열 유효성 검사
                for (int i = 0; i < gameBoard.Size; i++)
                {
                    if (!gameBoard.IsValidGroup(GroupType.Colum, i))
                    {
                        foreach (Tuple<int, int> tuple in gameBoard.FindWrongCells(GroupType.Colum, i))
                        {
                            isValid[9 * tuple.Item1 + tuple.Item2] = false;
                            cells[9 * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                        }
                    }
                }

                // 그룹 유효성 검사
                for (int i = 0; i < gameBoard.Size; i++)
                {
                    if (!gameBoard.IsValidGroup(GroupType.Area, i))
                    {
                        foreach (Tuple<int, int> tuple in gameBoard.FindWrongCells(GroupType.Area, i))
                        {
                            isValid[9 * tuple.Item1 + tuple.Item2] = false;
                            cells[9 * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                        }
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

            bool filled = true;    // 셀에 모든 수가 입력되었는지 확인

            for (int i = 0; i < gameBoard.Size; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    if (gameBoard[i, j] == 0)
                        filled = false;
                }
            }


            if (gameBoard.IsValidSudoku() && filled)
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

            // 타이머 초기화
            nCount = 0;
            lbltmr.Text = "00:00:00";

            // Start 버튼 활성화
            BtnStart.Enabled = true;

            // 라벨 텍스트 초기화
            lblText.Text = "게임을 시작해 주세요.";
        }

        private void 숫자생성개수변화ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}