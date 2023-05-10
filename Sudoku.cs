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
        List<Label> cells = new List<Label>(); // form�� ǥ�õǴ� cell ����
        List<bool> isValid = new List<bool>(); // cell ��ȿ�� ����

        const int MAXINPUTVALUE = 9;
        const int MININPUTVALUE = 1;

        // Ÿ�̸� ����
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

        // form ���� �� ����. ����� 9 * 9 �������� �ۼ��Ǿ� ����.
        // ���Ŀ� �ٸ� ���µ� ������ �� ���� ���� ���� ������ ����.
        private void Sudoku_Load(object sender, EventArgs e)
        {
            int cellWidth = 40;
            int cellHeight = 40;
            int cellTopValue = 7;

            // ���� ����ִ� sudoku grid ����
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

                    sudokuGrid.Controls.Add(cell); // sudokuGrid�� cell �߰�

                    // cell�� left value ����
                    cellLeftValue += cellWidth + ((j + 1) % 3 == 0 ? 7 : 0);
                }

                // cell�� top value ����
                cellTopValue += cellHeight + ((i + 1) % 3 == 0 ? 7 : 0);
            }
        }

        // �� �׷�� �� 3���� �����Ѵٰ� ����
        // �׷��� ��ȣ�� �Է¹޾� �ش� �׷� ������ ������ ����, �׷캰�� ������ �ٽ� ����
        // groupNum : �ش��ϴ� �׷��� ù��° ��
        // groupNum = 0 : 0��, 1��, 2��
        // groupNum = 3 : 3��, 4��, 5��
        // groupNum = 6 : 6��, 7��, 8��
        private void SuffleRow(int groupNum, int n)
        {
            // n�� ��ŭ �ݺ�
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    // �׷� ������ ������ ������ ����
                    int temp1 = answerArray[j, groupNum];
                    int temp2 = answerArray[j, groupNum + 1];
                    int temp3 = answerArray[j, groupNum + 2];

                    answerArray[j, groupNum] = temp3;
                    answerArray[j, groupNum + 1] = temp1;
                    answerArray[j, groupNum + 2] = temp2;

                    // �׷� ���� ���� �ٲ�
                    // groupNum = 0 �� ������ groupNum = 3�� ����� ��ȯ
                    // groupNum = 3 �� ������ groupNum = 6�� ����� ��ȯ
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

        /// �� �׷�� �� 3���� �����Ѵٰ� ����        
        /// �׷��� ��ȣ�� �Է¹޾� �ش� �׷� ������ ����� ����, �׷캰�� ����� �ٽ� ����
        /// groupNum : �ش��ϴ� �׷��� ù��° ��
        /// groupNum = 0 : 0��, 1��, 2��
        /// groupNum = 3 : 3��, 4��, 5��
        /// groupNum = 6 : 6��, 7��, 8��

        private void SuffleCol(int groupNum, int n)
        {
            // n�� ��ŭ �ݺ�
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    // �׷� ������ ����� ������ ����
                    int temp1 = answerArray[groupNum, j];
                    int temp2 = answerArray[groupNum + 1, j];
                    int temp3 = answerArray[groupNum + 2, j];

                    answerArray[groupNum, j] = temp3;
                    answerArray[groupNum + 1, j] = temp1;
                    answerArray[groupNum + 2, j] = temp2;

                    // �׷� ���� ���� �ٲ�
                    // groupNum = 0 �� ����� groupNum = 3�� ���� ��ȯ
                    // groupNum = 3 �� ����� groupNum = 6�� ���� ��ȯ
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

        // ������ �����Ͽ� SuffleRow �� SuffleCol �Լ��� ����
        // ��� ���� ������ ���� ������ �پ��� �ʱ� �� ���� ����
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



        // cell�� ����Ŭ�� �� �Է�â�� ���� ���� ������ �� ����.
        // �Է�â�� enter�� esc�� ������.
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

            /// ����Ŭ�� ��, �ش� ���� �ؽ�Ʈ�� ��������� gameBoard ���� 0���� �����

        }

        private void Cell_Enter(object? sender, EventArgs e)
        {
            Label? cell = (Label?)sender;

            cell.BackColor = SELECTEDCOLOR;
        }

        // ���콺 Ŀ���� cell�� ��� �� cell�� ���� ���ƿ�.
        // ���ƿ��� ���� cell�� ��ȿ���� �������� �Ǵ���.
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

        // cell ����Ŭ�� �� ������ �Է�â ��� ���Ǵ� �̺�Ʈ.
        // enter: 1 ~ 9 ������ ���� �ԷµǾ��� ��� �ش��ϴ� cell�� ���� ������. (9 * 9 ����)
        // esc: �Է°��� ������� â�� ����.
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

                    cell.Controls.Remove(inputCell); // �Է�â ����
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                cell.Controls.Remove(inputCell);
            }
        }

        // cell�� �����Ǿ� �ִ� property �ʱ�ȭ
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
                // cell�� ��ȿ�� �ʱ�ȭ
                isValid[i] = true;
            }
        }

        // Ÿ�̸� ����
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
                // ��� �� �ٽ� �⺻ �������� ����
                foreach (Label cell in cells)
                {
                    cell.BackColor = DEFAULTCOLOR;
                }


                // label ���� �ٽ� �ʱ�ȭ
                msgTmr.Stop();
                colorChange = 0;
                lblText.Text = "������ �����غ�����.";
                BtnCorrect.Enabled = true;

                isValid.Clear();

                for(int i = 0; i < cells.Count; i++)
                    isValid.Add(true);
            }
        }


        /// START ��ư ����
        /// ������ sudoku gameboard�� form�� ǥ��
        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Start ��ư ��Ȱ��ȭ
            BtnStart.Enabled = false;

            // Ÿ�̸� ���� �� ���䰪 ���� ����
            tmr.Start();
            Rand_Num_Make();
            lblText.Text = lblText.Text = "������ �����غ�����.";


            for (int i = 0; i < gameBoard.Size; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    gameBoard[i, j] = answerArray[i, j];
                    Label cell = cells[9 * i + j];

                    Random randObj1 = new Random();

                    // set cell value

                    // �ڽ��� ������ +- 1��ŭ�� ������ �����Ͽ� �ش� ������ ������ ���� ��� ����ŷó��
                    // �������� �ش� ĭ�� ���ڰ� �������� ���� ��쿡�� ���� ���
                    // ������ ������ �����Ѵٸ� ���̵� ���� ������ ������ �����
                    // ���� ����

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

        // Correct ��ư ����
        private void BtnCorrect_Click(object sender, EventArgs e)
        {
            if (!gameBoard.IsValidSudoku())
            {
                lblText.Text = "Ʋ�� �κ��� �ֱ���. �ٽ� �����غ�����.";

                // �� ��ȿ�� �˻�
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

                // �� ��ȿ�� �˻�
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

                // �׷� ��ȿ�� �˻�
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
                lblText.Text = "�ùٸ��� �ԷµǾ����ϴ�.";
            }
            
            // 2�� �� ������ ������ ���ƿ����� ����
            // Correct ��ư ���� �Է� �����ϱ� ���� ��Ȱ��ȭ
            msgTmr.Start();
            BtnCorrect.Enabled = false;
        }

        /// Finish ��ư ����
        /// ���� ��� ������ �ԷµǾ��� ��Ģ�� ������������� ���� ���� ���
        /// ���� ��, Ÿ�̸� ����
        private void BtnFinish_Click(object sender, EventArgs e)
        {

            bool filled = true;    // ���� ��� ���� �ԷµǾ����� Ȯ��

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
                lblText.Text = "�����մϴ�. ������ Ŭ���� �߽��ϴ�.";
                tmr.Stop();
            }
            else
            {
                lblText.Text = "Ʋ�� ���� �ֱ���! �ٽ� �����غ�����.";
                msgTmr.Start();
            }
        }

        /// Reset ��ư ����
        /// ���� ������ ��� ����� Ÿ�̸� �ʱ�ȭ
        /// Start ��ư Ȱ��ȭ �� �� �ؽ�Ʈ �ʱ�ȭ
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Finish ��ư���� Reset ��ư�� ���� ������ ��� �����Ͽ� Ÿ�̸� ����
            tmr.Stop();

            // ���� ���� ��� ����
            ClearCells();

            // Ÿ�̸� �ʱ�ȭ
            nCount = 0;
            lbltmr.Text = "00:00:00";

            // Start ��ư Ȱ��ȭ
            BtnStart.Enabled = true;

            // �� �ؽ�Ʈ �ʱ�ȭ
            lblText.Text = "������ ������ �ּ���.";
        }

        private void ���ڻ���������ȭToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}