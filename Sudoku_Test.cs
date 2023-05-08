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

namespace Sudoku_Windows_Forms
{
    public partial class Sudoku_Test : Form
    {
        GameBorad gameBorad = new GameBorad(); // sudoku gameboard
        List<Label> cells = new List<Label>(); // form에 표시되는 cell 제어
        List<bool> isValid = new List<bool>(); // cell 유효성 저장

        const int MAXINPUTVALUE = 9;
        const int MININPUTVALUE = 1;

        Color DEFAULTCOLOR = Color.White;
        Color SELECTEDCOLOR = Color.LightCyan;
        Color INVALIDCOLOR = Color.IndianRed;

        int[,] testCaseArray =
            {
                {8, 5, 6, 9, 4, 1, 2, 7, 3},
                {4, 1, 9, 5, 6, 2, 7, 3, 8},
                {7, 2, 3, 3, 8, 4, 4, 1, 9},
                {9, 6, 5, 7, 3, 4, 8, 2, 1},
                {3, 7, 1, 2, 9, 8, 6, 5, 4},
                {2, 4, 8, 1, 5, 6, 9, 7, 7},
                {1, 9, 7, 4, 2, 3, 5, 8, 6},
                {5, 8, 2, 6, 7, 9, 1, 4, 3},
                {6, 3, 4, 8, 1, 5, 9, 6, 2}
            };


        public Sudoku_Test()
        {
            InitializeComponent();
        }

        // form 실행 시 동작. 현재는 9 * 9 기준으로 작성되어 있음.
        // 추후에 다른 형태도 구현할 시 형태 별로 따로 구현할 예정.
        private void Sudoku_Test_Load(object sender, EventArgs e)
        {
            int cellWidth = 40;
            int cellHeight = 40;
            int cellTopValue = 7;

            // 숫자 비어있는 sudoku grid 생성
            for (int i = 0; i < gameBorad.Size; i++)
            {
                int cellLeftValue = 7;

                for (int j = 0; j < gameBorad.Size; j++)
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

        // gameboard 유효성 검사
        private void BtnCorrect_Click(object sender, EventArgs e)
        {
            if (!gameBorad.IsValidSudoku())
            {
                // 행 유효성 검사
                for (int i = 0; i < gameBorad.Size; i++)
                {
                    if (!gameBorad.IsValidGroup(GroupType.Row, i))
                    {
                        foreach (Tuple<int, int> tuple in gameBorad.FindWrongCells(GroupType.Row, i))
                        {
                            isValid[9 * tuple.Item1 + tuple.Item2] = false;
                            cells[9 * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                        }
                    }
                }

                // 열 유효성 검사
                for (int i = 0; i < gameBorad.Size; i++)
                {
                    if (!gameBorad.IsValidGroup(GroupType.Colum, i))
                    {
                        foreach (Tuple<int, int> tuple in gameBorad.FindWrongCells(GroupType.Colum, i))
                        {
                            isValid[9 * tuple.Item1 + tuple.Item2] = false;
                            cells[9 * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                        }
                    }
                }

                // 그룹 유효성 검사
                for (int i = 0; i < gameBorad.Size; i++)
                {
                    if (!gameBorad.IsValidGroup(GroupType.Area, i))
                    {
                        foreach (Tuple<int, int> tuple in gameBorad.FindWrongCells(GroupType.Area, i))
                        {
                            isValid[9 * tuple.Item1 + tuple.Item2] = false;
                            cells[9 * tuple.Item1 + tuple.Item2].BackColor = INVALIDCOLOR;
                        }
                    }
                }
            }
        }

        // 생성된 sudoku gameboard를 form에 표시
        private void BtnStart_Click(object sender, EventArgs e)
        {
            ClearCells();

            for (int i = 0; i < gameBorad.Size; i++)
            {
                for (int j = 0; j < gameBorad.Size; j++)
                {
                    gameBorad[i, j] = testCaseArray[i, j];

                    Label cell = cells[9 * i + j];

                    // set cell value
                    cell.Text = testCaseArray[i, j].ToString();

                    // add cell event
                    cell.MouseDoubleClick += Cell_DoubleClick;
                    cell.MouseEnter += Cell_Enter;
                    cell.MouseLeave += Cell_Leave;
                }
            }
        }

        // cell을 더블클릭 시 입력창이 나와 값을 수정할 수 있음.
        // 입력창은 enter와 esc에 반응함.
        private void Cell_DoubleClick(object? sender, EventArgs e)
        {
            Label? cell = (Label?)sender;
            TextBox inputCell = new TextBox();

            inputCell.BackColor = (isValid[(int)cell.Tag] ? DEFAULTCOLOR : INVALIDCOLOR);
            inputCell.TextAlign = HorizontalAlignment.Center;
            inputCell.BorderStyle = BorderStyle.None;
            inputCell.Width = cell.Width;
            inputCell.Top = 2 + cell.Height / 4;
            inputCell.Left = 0;

            inputCell.KeyPress += InputCell_KeyPress;

            cell.Controls.Add(inputCell);
            inputCell.Focus();
        }

        // 마우스 커서가 cell 위에 들어갈 시 cell의 색이 변함.
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

                        gameBorad[cellX, cellY] = inputValue;
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
    }
}
