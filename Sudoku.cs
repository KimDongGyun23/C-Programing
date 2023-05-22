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
        //GameBoard GameBoard = new RegularSudokuGameBoard(30,3); // sudoku GameBoard

        List<Label> cells = new List<Label>(); // form�� ǥ�õǴ� cell ����
        List<bool> isValid = new List<bool>(); // cell ��ȿ�� ����
        int[,] answerArray;

        int MAXINPUTVALUE = 9;
        int MININPUTVALUE = 1;

        int nCount = 0;             // Ÿ�̸� �ð�����
        int colorChange = 0;        // msg Ÿ�̸� �ð�����

        int nAttCount = 0;          // Ÿ�Ӿ��� ��� �ð�����
        bool timeAttack = false;    // Ÿ�Ӿ��� ���� ����
        string tmrText = "";        // Ÿ�Ӿ��� �ð��� �󺧿� �ѱ�� ���� ����



        int mode = 0;
        int cell_edge_len = 40;
        Point point = new Point(220, 139);




        Color DEFAULTCOLOR = Color.White;
        Color SELECTEDCOLOR = Color.LightCyan;
        Color INVALIDCOLOR = Color.IndianRed;

        public Sudoku()
        {
            InitializeComponent();
        }

        // form ���� �� ����. ����� 9 * 9 �������� �ۼ��Ǿ� ����.
        // ���Ŀ� �ٸ� ���µ� ������ �� ���� ���� ���� ������ ����.
        private void Sudoku_Load(object sender, EventArgs e)
        {
        }


        // cell�� ����Ŭ�� �� �Է�â�� ���� ���� ������ �� ����.
        // �Է�â�� enter�� esc�� ������.
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

            /// ����Ŭ�� ��, �ش� ���� �ؽ�Ʈ�� ��������� GameBoard ���� 0���� �����
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

        // ���콺 Ŀ���� cell�� ��� �� cell�� ���� ���ƿ�.
        // ���ƿ��� ���� cell�� ��ȿ���� �������� �Ǵ���.
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

        // cell ����Ŭ�� �� ������ �Է�â ��� ���Ǵ� �̺�Ʈ.
        // enter: 1 ~ 9 ������ ���� �ԷµǾ��� ��� �ش��ϴ� cell�� ���� ������. (9 * 9 ����)
        // esc: �Է°��� ������� â�� ����.
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
                cell.Controls.Remove(inputCell); // �Է�â ����
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                inputCell.MouseLeave -= InputCell_MouseLeave;
                cell.Controls.Remove(inputCell);
            }
        }

        // inputCell MouseEnter event handler.
        // parent�� child�� ������ ���ÿ� �����Ѵ�.
        // parent�� event hanlder�� ��ȣ���������� ������.
        private void InputCell_MouseEnter(object? sender, EventArgs e)
        {
            TextBox? inputCell = (TextBox?)sender;
            Label cell = (Label)inputCell.Parent;

            cell.BackColor = SELECTEDCOLOR;
            inputCell.BackColor = SELECTEDCOLOR;
        }

        // inputCell MouseLeave event handler.
        // parent�� child�� ������ ���ÿ� �����Ѵ�.
        // parent�� event handler�� ��ȣ���������� ������
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

            // Ÿ�Ӿ��� �ð� ���� ��, Ÿ�̸� ���� �� �� �ʱ�ȭ
            if (nCount < 0)
            {
                lbltmr.Text = "00:00:00";
                tmr.Stop();
                lblText.Text = "������ Ŭ���� ���� ���߽��ϴ�.";
            }
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
        /// ������ sudoku GameBoard�� form�� ǥ��
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //cells = new List<Label>();

            // Start ��ư ��Ȱ��ȭ
            BtnStart.Enabled = false;

            // Ÿ�̸� ���� �� ���䰪 ���� ����
            tmr.Start();
            lblText.Text = lblText.Text = "������ �����غ�����.";


            if (mode == 0)
            {
                GameBoard = new RegularSudokuGameBoard(20, 3);
                for (int i = 0; i < GameBoard.GridSize; i++)
                    for (int j = 0; j < GameBoard.GridSize; j++)
                        answerArray = GridGenerator.GenerateRegularSudokuGrid(3);
            }
            else if (mode == 1)
            {
                GameBoard = new RegularSudokuGameBoard(3, 2);
                for (int i = 0; i < GameBoard.GridSize; i++)
                    for (int j = 0; j < GameBoard.GridSize; j++)
                        answerArray = GridGenerator.GenerateRegularSudokuGrid(2);
            }

            Point[,] inputBoxPositions = draw_grid.DrawBoard(cell_edge_len, point, GameBoard.AreaGroup, GameBoard.GridSize, this);

            int cellSize = draw_grid.input_edge_len;
            int cellWidth = cellSize - 2;
            int cellHeight = cellSize - 2;
            int cellTopValue = point.Y;

            // ���� ����ִ� sudoku grid ����
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
                    cell.Width = cellWidth +2;
                    cell.Height = cellHeight +2;
                    cell.Top = inputBoxPositions[i,j].Y;
                    cell.Left = inputBoxPositions[i,j].X;

                    cells.Add(cell);
                    isValid.Add(true);
                    Controls.Add(cell);

                    // cell�� left value ����
                    cellLeftValue += cellSize;
                }
                // cell�� top value ����
                cellTopValue += cellSize;
            }

            for (int i = 0; i < GameBoard.GridSize; i++)
            {
                for (int j = 0; j < GameBoard.GridSize; j++)
                {
                    GameBoard[i, j] = answerArray[i, j];
                    Label cell = cells[GameBoard.GridSize * i + j];
                    
                    Random randObj1 = new Random();
                    
                    // set cell value
                    // �ڽ��� ������ +- 1��ŭ�� ������ �����Ͽ� �ش� ������ ������ ���� ��� ����ŷó��
                    // �������� �ش� ĭ�� ���ڰ� �������� ���� ��쿡�� ���� ���
                    // ������ ������ �����Ѵٸ� ���̵� ���� ������ ������ �����                    
                    
                    //if(GameBoard.IsFixed[i,j])
                    if (GameBoard[i, j] == randObj1.Next(GameBoard[i, j] - 1, GameBoard[i, j] + 1))
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

        // Correct ��ư ����
        private void BtnCorrect_Click(object sender, EventArgs e)
        {
            if (!GameBoard.IsValidAll())
            {
                lblText.Text = "Ʋ�� �κ��� �ֱ���. �ٽ� �����غ�����.";
                
                // ��ȿ�� �˻�
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
            if (GameBoard.IsValidSudoku())
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

            // Ÿ�Ӿ��� ��� ���ο� ���� Ÿ�̸ӿ� �� �ʱ�ȭ
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
            // Start ��ư Ȱ��ȭ
            BtnStart.Enabled = true;

            // �� �ؽ�Ʈ �ʱ�ȭ
            lblText.Text = "������ ������ �ּ���.";
        }

        private void ���ڻ���������ȭToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 10;
            nCount = nAttCount;
            tmrText = "00:10:00";
            lbltmr.Text = tmrText;
        }
        private void ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 7;
            nCount = nAttCount;
            tmrText = "00:07:00";
            lbltmr.Text = tmrText;
        }
        private void ��ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 5;
            nCount = nAttCount;
            tmrText = "00:05:00";
            lbltmr.Text = tmrText;
        }
        private void ��ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            timeAttack = true;
            nAttCount = 60 * 3;
            nCount = nAttCount;
            tmrText = "00:03:00";
            lbltmr.Text = tmrText;
        }
        private void Ÿ�Ӿ��ø�����ToolStripMenuItem_Click(object sender, EventArgs e)
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