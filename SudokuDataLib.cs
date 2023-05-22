<<<<<<< HEAD
﻿using System.Reflection.Metadata.Ecma335;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
>>>>>>> 2019203002

namespace SudokuDataLib
{
    public enum GroupType
    {
        Row,
        Colum,
        Area
    }

    internal class Cell
    {
        private int value;
<<<<<<< HEAD

=======
>>>>>>> 2019203002
        private int min_val;
        private int max_val;

        private int col_group;
        private int row_group;
        private int area_group;

<<<<<<< HEAD
        //생성자
        internal Cell(int max_val)
=======
        internal Cell(int max_val = 9)
>>>>>>> 2019203002
        {
            this.min_val = 0;
            this.max_val = max_val;
        }

<<<<<<< HEAD
        //셀 값 접근 속성
=======
>>>>>>> 2019203002
        internal int Value
        {
            get { return this.value; }
            set
            {
                if (min_val <= value && value <= max_val)
                    this.value = value;
                else
                    Environment.FailFast("셀에 잘못된 값을 입력하였습니다. 버그를 찾으세요.");
            }
        }

<<<<<<< HEAD
        //셀 그룹 접근 속성 
=======
>>>>>>> 2019203002
        internal int Colum
        {
            get { return this.col_group; }
            set { this.col_group = value; }
        }

        internal int Row
        {
            get { return this.row_group; }
            set { this.row_group = value; }
        }

        internal int Area
        {
            get { return this.area_group; }
            set { this.area_group = value; }
        }
    }

    internal class SquareGrid
    {
<<<<<<< HEAD
        private int grid_size;
        private int block_size;

        private Cell[,] grid;

=======
        private int size;
        private Cell[,] grid;
>>>>>>> 2019203002
        private List<Cell>[] row_group;
        private List<Cell>[] col_group;
        private List<Cell>[] area_group;

<<<<<<< HEAD
        //생성자
        internal SquareGrid(int block_size = 3, int[,] area_group_grid = null)
        {
            //default 값 설정
            if (area_group_grid == null)
            {
                area_group_grid = GridGenerator.GenerateDefaultAreaGrid(block_size);
            }

            this.block_size = block_size;

            grid_size = block_size * block_size;

            grid = new Cell[grid_size, grid_size];
            InitGrid(grid_size);

            AllocateGroupList(grid_size);

            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    grid[n, m] = new Cell(grid_size);

                    SetCellGroup(n, m, area_group_grid[n, m]);
                }
            }

            FillCellGroup();
        }

        //속성 및 인덱서
        internal int this[int n, int m]
        {
            get { return grid[n, m].Value; }
            set { grid[n, m].Value = value; }
        }

        internal int GridSize
        {
            get { return grid_size; }
        }

        internal int BlockSize
        {
            get { return block_size; }
        }

        //중복값 확인 메소드
=======
        private void AllocateGroupArray(int size)
        {
            row_group = new List<Cell>[size];
            col_group = new List<Cell>[size];
            area_group = new List<Cell>[size];

            for (int i = 0; i < size; i++)
            {
                row_group[i] = new List<Cell>();
                col_group[i] = new List<Cell>();
                area_group[i] = new List<Cell>();
            }

        }

        private void SetCellGroup()
        {
            for (int n = 0; n < size; n++)
            {
                for (int m = 0; m < size; m++)
                {
                    row_group[grid[n, m].Row].Add(grid[n, m]);
                    col_group[grid[n, m].Colum].Add(grid[n, m]);
                    area_group[grid[n, m].Area].Add(grid[n, m]);
                }
            }
        }

        internal SquareGrid(int size = 9, int[,] area_group_array = null)
        {
            //default 값 설정
            if (area_group_array == null)
            {
                area_group_array = new int[,]{
                    { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
                    { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
                    { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
                    { 3, 3, 3, 4, 4, 4, 5, 5, 5 },
                    { 3, 3, 3, 4, 4, 4, 5, 5, 5 },
                    { 3, 3, 3, 4, 4, 4, 5, 5, 5 },
                    { 6, 6, 6, 7, 7, 7, 8, 8, 8 },
                    { 6, 6, 6, 7, 7, 7, 8, 8, 8 },
                    { 6, 6, 6, 7, 7, 7, 8, 8, 8 }
                    };
            }

            this.size = size;
            grid = new Cell[size, size];
            AllocateGroupArray(size);

            for (int n = 0; n < size; n++)
            {
                for (int m = 0; m < size; m++)
                {
                    grid[n, m] = new Cell(size);

                    grid[n, m].Row = n;
                    grid[n, m].Colum = m;
                    grid[n, m].Area = area_group_array[n, m];
                }
            }

            SetCellGroup();
        }

        private bool IsValidRow(int row)
        {
            bool[] bools = new bool[size + 1];
            Array.Fill(bools, false);

            foreach (Cell cell in row_group[row])
            {
                if (cell.Value == 0)
                    continue;
                else if (bools[cell.Value])
                    return false;
                else
                    bools[cell.Value] = true;
            }

            return true;
        }

        private bool IsValidColum(int col)
        {
            bool[] bools = new bool[size + 1];
            Array.Fill(bools, false);

            foreach (Cell cell in col_group[col])
            {
                if (cell.Value == 0)
                    continue;
                else if (bools[cell.Value])
                    return false;
                else
                    bools[cell.Value] = true;
            }

            return true;
        }

        private bool IsValidArea(int area)
        {
            bool[] bools = new bool[size + 1];
            Array.Fill(bools, false);

            foreach (Cell cell in area_group[area])
            {
                if (cell.Value == 0)
                    continue;
                else if (bools[cell.Value])
                    return false;
                else
                    bools[cell.Value] = true;
            }

            return true;
        }

>>>>>>> 2019203002
        internal bool IsValidGroup(GroupType group_type, int group_num)
        {
            bool result;

            switch (group_type)
            {
                case GroupType.Area:
                    result = IsValidArea(group_num);
                    break;
                case GroupType.Row:
                    result = IsValidRow(group_num);
                    break;
                case GroupType.Colum:
                    result = IsValidColum(group_num);
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }
<<<<<<< HEAD

        internal bool IsValidAll()
        {
            for (int i = 0; i < grid_size; i++)
=======
        internal bool IsValidSudoku()
        {
            for (int i = 0; i < size; i++)
>>>>>>> 2019203002
            {
                if (!IsValidRow(i))
                    return false;
                if (!IsValidColum(i))
                    return false;
                if (!IsValidArea(i))
                    return false;
            }
<<<<<<< HEAD

            return true;
        }

        internal bool IsValidSudoku()
        {
            if (isFilled() && IsValidAll())
                return true;
            else
                return false;
        }

        //현재 격자 값 배열을 생성하는 메소드
        internal int[,] GetGridValue()
        {
            int[,] result = new int[grid_size, grid_size];
            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
=======
            return true;
        }

        internal int[,] GetGridValue()
        {
            int[,] result = new int[size, size];
            for (int n = 0; n < size; n++)
            {
                for (int m = 0; m < size; m++)
>>>>>>> 2019203002
                    result[n, m] = grid[n, m].Value;
            }
            return result;
        }

<<<<<<< HEAD
        //중복값을 가진 셀의 위치를 리스트로 반환하는 메소드
=======
        internal int this[int n, int m]
        {
            get { return grid[n, m].Value; }
            set { grid[n, m].Value = value; }
        }

        internal int Size
        {
            get { return size; }
        }

        private List<Cell> FindWrongCells(List<Cell> target_group)
        {
            List<Cell> wrong_cell = new List<Cell>();

            int[] number_cnt=new int[size + 1];
            Array.Fill(number_cnt, 0);

            foreach(Cell cell in target_group)
                number_cnt[cell.Value]++;

            foreach (Cell cell in target_group)
            {
                if (cell.Value != 0 && number_cnt[cell.Value]>1)
                   wrong_cell.Add(cell);
            }
                
            return wrong_cell;
        }

        private List<Tuple<int,int>> FindCellPos(List<Cell> cells)
        {
            List < Tuple<int, int> > result = new List<Tuple<int, int>>();

            for (int n=0; n<size; n++)
            {
                for(int m=0; m<size; m++) 
                {
                    if (cells.Contains(grid[n,m]))
                        result.Add(new Tuple<int, int>(n,m));
                }
            }

            return result;
        }

>>>>>>> 2019203002
        internal List<Tuple<int, int>> FindWrongCells(GroupType group_type, int group_num)
        {
            List<Tuple<int, int>> result;

            switch (group_type)
            {
                case GroupType.Area:
                    result = FindCellPos(FindWrongCells(area_group[group_num]));
                    break;
                case GroupType.Row:
                    result = FindCellPos(FindWrongCells(row_group[group_num]));
                    break;
                case GroupType.Colum:
                    result = FindCellPos(FindWrongCells(col_group[group_num]));
                    break;
                default:
                    result = new List<Tuple<int, int>>();
                    result.Clear();
                    break;
            }

            return result;
        }
<<<<<<< HEAD

        //메소드 구현을 위한 private 메소드
        private void AllocateGroupList(int grid_size)
        {
            row_group = new List<Cell>[grid_size];
            col_group = new List<Cell>[grid_size];
            area_group = new List<Cell>[grid_size];

            for (int i = 0; i < grid_size; i++)
            {
                row_group[i] = new List<Cell>();
                col_group[i] = new List<Cell>();
                area_group[i] = new List<Cell>();
            }

        }

        private void InitGrid(int grid_size)
        {
            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    grid[n, m] = new Cell(grid_size);
                }
            }
        }

        private void SetCellGroup(int row, int col, int area)
        {
            grid[row, col].Row = row;
            grid[row, col].Colum = col;
            grid[row, col].Area = area;
        }

        private void FillCellGroup()
        {
            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    row_group[grid[n, m].Row].Add(grid[n, m]);
                    col_group[grid[n, m].Colum].Add(grid[n, m]);
                    area_group[grid[n, m].Area].Add(grid[n, m]);
                }
            }
        }

        private bool IsValidRow(int row)
        {
            bool[] bools = new bool[grid_size + 1];
            Array.Fill(bools, false);

            foreach (Cell cell in row_group[row])
            {
                if (cell.Value == 0)
                    continue;
                else if (bools[cell.Value])
                    return false;
                else
                    bools[cell.Value] = true;
            }

            return true;
        }

        private bool IsValidColum(int col)
        {
            bool[] bools = new bool[grid_size + 1];
            Array.Fill(bools, false);

            foreach (Cell cell in col_group[col])
            {
                if (cell.Value == 0)
                    continue;
                else if (bools[cell.Value])
                    return false;
                else
                    bools[cell.Value] = true;
            }

            return true;
        }

        private bool IsValidArea(int area)
        {
            bool[] bools = new bool[grid_size + 1];
            Array.Fill(bools, false);

            foreach (Cell cell in area_group[area])
            {
                if (cell.Value == 0)
                    continue;
                else if (bools[cell.Value])
                    return false;
                else
                    bools[cell.Value] = true;
            }

            return true;
        }

        private bool isFilled()
        {
            for (int i = 0; i < grid_size; i++)
            {
                for (int j = 0; j < grid_size; j++)
                    if (grid[i, j].Value == 0)
                        return false;
            }
            return true;
        }

        private List<Cell> FindWrongCells(List<Cell> target_group)
        {
            List<Cell> wrong_cell = new List<Cell>();

            int[] number_cnt = new int[grid_size + 1];
            Array.Fill(number_cnt, 0);

            foreach (Cell cell in target_group)
                number_cnt[cell.Value]++;

            foreach (Cell cell in target_group)
            {
                if (cell.Value != 0 && number_cnt[cell.Value] > 1)
                    wrong_cell.Add(cell);
            }

            return wrong_cell;
        }

        private List<Tuple<int, int>> FindCellPos(List<Cell> cells)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    if (cells.Contains(grid[n, m]))
                        result.Add(new Tuple<int, int>(n, m));
                }
            }

            return result;
        }
    }

    public abstract class GameBoard
    {
        public abstract int this[int n, int m]
        {
            get;
            set;
        }

        public abstract int BlockSize
        {
            get;
        }

        public abstract int GridSize
        {
            get;
        }

        public abstract int[,] AreaGroup
        {
            get;
        }

        public abstract bool[,] IsFixed
        {
            get;
        }

        public abstract bool CanUndo();

        public abstract Tuple<int, int, int> Undo();

        public abstract bool IsValidAll();

        public abstract bool IsValidSudoku();

        public abstract List<Tuple<int, int>> FindWrongCells();

        public abstract List<Tuple<int, int>> FindWrongCells(int n, int m);

        public abstract void ResetSudoku();

        public virtual bool[,] GetColoredGrid()
        {
            return null;
        }
    }

    public class RegularSudokuGameBoard : GameBoard
    {
        int block_size;
        int grid_size;
        int fixed_cnt;
=======
    }

    public class GameBorad
    {
        int size;
>>>>>>> 2019203002

        SquareGrid grid;

        bool[,] fixed_cells;
<<<<<<< HEAD
        int[,] area_group_grid;
=======
>>>>>>> 2019203002

        Stack<Tuple<int, int, int>> input_log;
        Stack<int[,]> grid_change_log;

<<<<<<< HEAD
        //생성자
        public RegularSudokuGameBoard(int fixed_cnt, int block_size)
        {
            //영역 정보 초기화
            this.area_group_grid = GridGenerator.GenerateDefaultAreaGrid(block_size);

            //격자 객체 생성
            grid = new SquareGrid(block_size, this.area_group_grid);

            this.block_size = grid.BlockSize;
            this.grid_size = grid.GridSize;
            this.fixed_cnt = fixed_cnt;

            fixed_cells = new bool[grid_size, grid_size];
=======
        public GameBorad(bool[,] fixed_cells=null)
        {
            grid = new SquareGrid();
            size = grid.Size;

            if (fixed_cells == null)
            {
                this.fixed_cells = new bool[9, 9];
            }

>>>>>>> 2019203002
            input_log = new Stack<Tuple<int, int, int>>();
            grid_change_log = new Stack<int[,]>();
        }

<<<<<<< HEAD
        //속성 및 인덱서
        public override int this[int n, int m]
=======
        public int this[int n, int m]
>>>>>>> 2019203002
        {
            get
            {
                return grid[n, m];
            }
            set
            {
                if (fixed_cells[n, m])
                    return;
                else
                    grid[n, m] = value;

                input_log.Push(new Tuple<int, int, int>(n, m, value));
                grid_change_log.Push(grid.GetGridValue());
            }
        }

<<<<<<< HEAD
        public override bool[,] IsFixed
        {
            get { return fixed_cells;}
        }

        public override int BlockSize
        {
            get { return block_size; }
        }

        public override int GridSize
        {
            get { return grid_size; }
        }

        public override int[,] AreaGroup
        {
            get { return area_group_grid; }
        }


        //가장 최근에 입력한 셀의 위치와 이전 값을 반환하는 메소드
        public override bool CanUndo()
        {
            if (input_log.Count == 0)
                return false;

            return true;
        }

        public override Tuple<int, int, int> Undo()
        {
            Tuple<int, int, int> undo_pos = input_log.Pop();
            int undo_value = grid_change_log.Pop()[undo_pos.Item1, undo_pos.Item2];

            grid[undo_pos.Item1, undo_pos.Item2] = undo_value;
=======
        public Tuple<int, int, int> Undo()
        {
            Tuple<int,int,int> undo_pos=input_log.Pop();
            int undo_value = grid_change_log.Pop()[undo_pos.Item1, undo_pos.Item2];

            grid[undo_pos.Item1, undo_pos.Item2]=undo_value;
>>>>>>> 2019203002

            return new Tuple<int, int, int>(undo_pos.Item1, undo_pos.Item2, undo_value);
        }

<<<<<<< HEAD
        public override bool IsValidAll()
        {
            return grid.IsValidAll();
        }

        public override bool IsValidSudoku()
        {
            return grid.IsValidSudoku();
        }

        //새로운 스도쿠 생성
        public override void ResetSudoku()
        {
            input_log.Clear();
            grid_change_log.Clear();

            this.fixed_cells = GridGenerator.GenerateRandomFixedCellGrid(grid_size, fixed_cnt);

            FillGirdValue(GridGenerator.GenerateRegularSudokuGrid(this.BlockSize));

            ResetNonFixedCells();
        }

        public override List<Tuple<int, int>> FindWrongCells(int n, int m)
        {
            List<Tuple<int, int>> return_obj = new List<Tuple<int, int>>();
            return_obj.AddRange(FindWrongCells(GroupType.Row, n));
            return_obj.AddRange(FindWrongCells(GroupType.Colum, m));
            return_obj.AddRange(FindWrongCells(GroupType.Area, area_group_grid[n, m]));
            return return_obj;
        }

        public override List<Tuple<int, int>> FindWrongCells()
        {
            List<Tuple<int, int>> return_obj = new List<Tuple<int, int>>();
            for(int i = 0; i < grid_size; i++)
            {
                return_obj.AddRange(FindWrongCells(GroupType.Row, i));
            }
            return return_obj;
        }
        //중복값 확인 메소드
        public bool IsValidGroup(GroupType group_type, int group_num)
=======
        internal bool IsValidGroup(GroupType group_type, int group_num)
>>>>>>> 2019203002
        {
            return grid.IsValidGroup(group_type, group_num);
        }

<<<<<<< HEAD
        public bool IsValidInput(int n, int m)
        {
            if (!IsValidGroup(GroupType.Row, n))
                return false;
            if (!IsValidGroup(GroupType.Colum, m))
                return false;
            if (!IsValidGroup(GroupType.Area, area_group_grid[n, m]))
                return false;
            return true;
        }

       

        //중복값을 가진 셀의 위치를 리스트로 반환하는 메소드
        public List<Tuple<int, int>> FindWrongCells(GroupType group_type, int group_num)
        {
            return grid.FindWrongCells(group_type, group_num);
        }

        //메소드 구현을 위한 private 메소드

        private void FillGirdValue(int[,] InitGird)
        {
            int rows = InitGird.GetLength(0);
            int cols = InitGird.GetLength(1);

            if (rows != grid_size || cols != grid_size)
            {
                Environment.FailFast("게임판에 맞는 배열을 입력하세요.");
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    grid[i, j] = InitGird[i, j];
            }
        }

        private void ResetNonFixedCells()
        {
            for (int i = 0; i < this.GridSize; i++)
            {
                for (int j = 0; j < this.GridSize; j++)
                {
                    if (fixed_cells[i, j])
                    {

                    }
                    else
                    {
                        grid[i, j] = 0;
                    }
                }
            }
        }
    }

    public class OddEvenSudokuGameBoard : RegularSudokuGameBoard
    {
        //홀수면 true 저장
        bool[,] odd_grid;

        public OddEvenSudokuGameBoard(int fixed_cnt, int block_size) :base(fixed_cnt, block_size)
        {
            odd_grid = new bool[base.GridSize, base.GridSize];
        }

        public override void ResetSudoku()
        {
            base.ResetSudoku();

            for(int i=0; i<base.GridSize; i++)
            {
                for(int j=0; j<base.GridSize; j++)
                {
                    if (base[i,j] % 2==1)
                        odd_grid[i,j] = true;
                }
            }
        }

        public override bool[,] GetColoredGrid()
        {
            return odd_grid;
        }
    }

    public class SamuraiSudokuGameBoard : GameBoard
    {
        const int grid_size = 21;
        const int block_size = 3;
        int[,] entire_grid;

        const int grid_cnt = 5;
        SquareGrid[] grid;

        int fixed_cnt;
        bool[,] fixed_cells;

        int[,] area_group_grid;

        Stack<Tuple<int, int, int>> input_log;
        Stack<int[,]> grid_change_log;

        //생성자
        public SamuraiSudokuGameBoard(int fixed_cnt)
        {
            area_group_grid = GridGenerator.GenerateSamuraiAreaGrid();

            //격자 객체 생성
            grid = new SquareGrid[grid_cnt];
            for(int i = 0; i < grid_cnt; i++)
            {
                grid[i] = new SquareGrid();
            }

            entire_grid = new int[grid_size, grid_size];

            this.fixed_cnt = fixed_cnt;
            this.fixed_cells = new bool[grid_size, grid_size];

            input_log = new Stack<Tuple<int, int, int>>();
            grid_change_log = new Stack<int[,]>();
        }

        //속성 및 인덱서
        public override int this[int n, int m]
        {
            get
            {
                if (n < grid_size && m < grid_size)
                {
                    var coordinate = ConvertCoordinate(n, m);
                    if (coordinate.Count == 0)
                        return 0;
                    int row = coordinate[0].Item1;
                    int col = coordinate[0].Item2;
                    int grid_num = coordinate[0].Item3;
                    
                    return grid[coordinate[0].Item3][row, col];
                }
                else
                {
                    Environment.FailFast("격자에 벗어난 공간에 접근했습니다.");
                    return 0;
                }                     
            }
            set
            {               
                if (fixed_cells[n, m])
                    return;
                else
                {
                    SetValue(n, m, value);                   
                }

                input_log.Push(new Tuple<int, int, int>(n, m, value));
                grid_change_log.Push(GetGridValue());
            }
        }

        public override bool[,] IsFixed
        {
            get { return fixed_cells; }
        }

        public override int BlockSize
        {
            get { return block_size; }
        }

        public override int GridSize
        {
            get { return grid_size; }
        }

        public override int[,] AreaGroup
        {
            get
            {
                return area_group_grid;
            }
        }

        //가장 최근에 입력한 셀의 위치와 이전 값을 반환하는 메소드
        public override bool CanUndo()
        {
            if (input_log.Count == 0)
                return false;

            return true;
        }

        public override Tuple<int, int, int> Undo()
        {
            Tuple<int, int, int> undo_pos = input_log.Pop();
            int undo_value = grid_change_log.Pop()[undo_pos.Item1, undo_pos.Item2];

            SetValue(undo_pos.Item1, undo_pos.Item2,  undo_value);

            return new Tuple<int, int, int>(undo_pos.Item1, undo_pos.Item2, undo_value);
        }

        public override bool IsValidAll()
        {
            bool _switch = true;
            for (int i = 0; i < grid_cnt; i++)
            {
                _switch = _switch && grid[i].IsValidAll();
            }
            return _switch;
        }

        public override bool IsValidSudoku()
        {
            bool _switch = true;
            for (int i = 0; i < grid_cnt; i++)
            {
                _switch = _switch && grid[i].IsValidSudoku();
            }
            return _switch;
        }

        //중복값을 가진 셀의 위치를 리스트로 반환하는 메소드
        public override List<Tuple<int, int>> FindWrongCells(int n, int m)
        {
            int[,] tem_area_info = GridGenerator.GenerateDefaultAreaGrid(3);

            HashSet<Tuple<int, int>> return_obj = new HashSet<Tuple<int, int>>();

            var coordinates = ConvertCoordinate(n, m);
            foreach (var coordinate in coordinates)
            {
                var wrong_cell = grid[coordinate.Item3].FindWrongCells(GroupType.Row, coordinate.Item1);
                foreach (var cell in wrong_cell)
                {
                    return_obj.Add(ConvertCoordinate(new Tuple<int, int, int>(coordinate.Item3, cell.Item1, cell.Item2)));
                }

                wrong_cell = grid[coordinate.Item3].FindWrongCells(GroupType.Colum, coordinate.Item2);
                foreach (var cell in wrong_cell)
                {
                    return_obj.Add(ConvertCoordinate(new Tuple<int, int, int>(coordinate.Item3, cell.Item1, cell.Item2)));
                }

                wrong_cell = grid[coordinate.Item3].FindWrongCells(GroupType.Area, tem_area_info[coordinate.Item1, coordinate.Item2]);
                foreach (var cell in wrong_cell)
                {
                    return_obj.Add(ConvertCoordinate(new Tuple<int, int, int>(coordinate.Item3, cell.Item1, cell.Item2)));
                }
            }

            return return_obj.ToList();
        }

        public override List<Tuple<int, int>> FindWrongCells()
        {
            HashSet<Tuple<int, int>> return_obj = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < grid_cnt; i++)
            {
                for (int j = 0; j < grid[i].GridSize; j++)
                {
                    var list = grid[i].FindWrongCells(GroupType.Row, j);
                    foreach (var cell in list)
                    {
                        return_obj.Add(cell);
                    }
                }
            }
            return return_obj.ToList();
        }

        //새로운 스도쿠 생성
        public override void ResetSudoku()
        {
            input_log.Clear();
            grid_change_log.Clear();

            this.fixed_cells = GridGenerator.GenerateRandomFixedCellSamuraiGrid(fixed_cnt);

            FillGirdValue(GridGenerator.GenerateSamuraiSudokuGrid());

            ResetNonFixedCells();
        }

        //중복값 확인 메소드

        public bool IsValidInput(int n, int m)
        {
            int[,] tem_area_info = GridGenerator.GenerateDefaultAreaGrid(3);
            var coordinates = ConvertCoordinate(n, m);
            foreach (var coordinate in coordinates)
            {
                if(!grid[coordinate.Item3].IsValidGroup(GroupType.Row, coordinate.Item1))
                    return false;
                if (!grid[coordinate.Item3].IsValidGroup(GroupType.Colum, coordinate.Item2))
                    return false;
                if (!grid[coordinate.Item3].IsValidGroup(GroupType.Area, tem_area_info[coordinate.Item1, coordinate.Item2]))
                    return false;
            }
            return true;
        }

        //메소드 구현을 위한 private 메소드

        private List<Tuple<int, int, int>> ConvertCoordinate(int n, int m)
        {
            List<Tuple<int, int, int>> return_obj = new List<Tuple<int, int, int>>();
            Tuple<int, int>[] coordinate = new Tuple<int, int>[5];
            coordinate[0] = new Tuple<int, int>(n, m);
            coordinate[1] = new Tuple<int, int>(n-12, m);
            coordinate[2] = new Tuple<int, int>(n, m-12);
            coordinate[3] = new Tuple<int, int>(n - 12, m - 12);
            coordinate[4] = new Tuple<int, int>(n - 6, m - 6);
            for(int i=0;i<grid_cnt;i++)
            {
                if (coordinate[i].Item1 >= 0 && coordinate[i].Item2 >= 0 && coordinate[i].Item1 < 9 && coordinate[i].Item2 < 9)
                {
                    return_obj.Add(new Tuple<int, int, int>(coordinate[i].Item1, coordinate[i].Item2, i));
                }
            }

            return return_obj;
        }

        private Tuple<int, int> ConvertCoordinate(Tuple<int, int, int> coodinate)
        {
            switch (coodinate.Item3)
            {
                case 0:
                    return new Tuple<int, int>(coodinate.Item1, coodinate.Item2);
                case 1:
                    return new Tuple<int, int>(coodinate.Item1 - 12, coodinate.Item2);
                case 2:
                    return new Tuple<int, int>(coodinate.Item1, coodinate.Item2 - 12);
                case 3:
                    return new Tuple<int, int>(coodinate.Item1 - 12, coodinate.Item2 - 12);
                case 4:
                    return new Tuple<int, int>(coodinate.Item1 - 6, coodinate.Item2 - 6);
                default:
                    break;
            }
            return null;
        }
        private void SetValue(int n, int m, int value)
        {
            var coordinates = ConvertCoordinate(n, m);
            foreach (var coordinate in coordinates)
            {
                int i = coordinate.Item1;
                int j = coordinate.Item2;
                int grid_number = coordinate.Item3;
                grid[grid_number][i, j] = value;
            }
            entire_grid[n, m] = value;
        }

        private int[,] GetGridValue()
        {
            int[,] return_obj = new int[grid_size, grid_size];
            for(int i = 0; i < grid_size; i++)
            {
                for(int j=0; j < grid_size; j++)
                {
                    return_obj[i, j] = entire_grid[i, j];
                }
            }
            return return_obj;
        }

        private void FillGirdValue(int[,] InitGird)
        {
            int rows = InitGird.GetLength(0);
            int cols = InitGird.GetLength(1);

            if (rows != grid_size || cols != grid_size)
            {
                Environment.FailFast("게임판에 맞는 배열을 입력하세요.");
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    SetValue(i, j, InitGird[i, j]);               
            }
        }

        private void ResetNonFixedCells()
        {
            for (int i = 0; i < this.GridSize; i++)
            {
                for (int j = 0; j < this.GridSize; j++)
                {
                    if (fixed_cells[i, j])
                    {

                    }
                    else
                    {
                        SetValue(i, j, 0);
                    }
                }
            }
        }
    }

    public class JigsawSudokuGameBoard : GameBoard
    {
        int block_size;
        int grid_size;
        int fixed_cnt;

        SquareGrid grid;

        bool[,] fixed_cells;
        int[,] area_group_grid;

        Stack<Tuple<int, int, int>> input_log;
        Stack<int[,]> grid_change_log;

        //생성자
        public JigsawSudokuGameBoard(int fixed_cnt, int block_size, int[,] area_group_grid)
        {
            //영역 정보 초기화
            this.area_group_grid = area_group_grid;

            //격자 객체 생성
            grid = new SquareGrid(block_size, area_group_grid);

            this.block_size = grid.BlockSize;
            this.grid_size = grid.GridSize;
            this.fixed_cnt = fixed_cnt;

            this.fixed_cells = new bool[grid_size, grid_size];

            input_log = new Stack<Tuple<int, int, int>>();
            grid_change_log = new Stack<int[,]>();
        }

        public JigsawSudokuGameBoard(int fixed_cnt, int block_size)
        {
            //영역 정보 초기화
            this.area_group_grid = GridGenerator.GenerateDefaultAreaGrid(block_size);

            //격자 객체 생성
            grid = new SquareGrid(block_size, this.area_group_grid);

            this.block_size = grid.BlockSize;
            this.grid_size = grid.GridSize;
            this.fixed_cnt = fixed_cnt;

            this.fixed_cells = GridGenerator.GenerateRandomFixedCellGrid(grid_size, fixed_cnt);

            input_log = new Stack<Tuple<int, int, int>>();
            grid_change_log = new Stack<int[,]>();
        }

        //속성 및 인덱서
        public override int this[int n, int m]
        {
            get
            {
                return grid[n, m];
            }
            set
            {
                if (fixed_cells[n, m])
                    return;
                else
                    grid[n, m] = value;

                input_log.Push(new Tuple<int, int, int>(n, m, value));
                grid_change_log.Push(grid.GetGridValue());
            }
        }

        public override bool[,] IsFixed
        {
            get { return fixed_cells; }
        }

        public override int BlockSize
        {
            get { return block_size; }
        }

        public override int GridSize
        {
            get { return grid_size; }
        }

        public override int[,] AreaGroup
        {
            get { return area_group_grid; }
        }

        //가장 최근에 입력한 셀의 위치와 이전 값을 반환하는 메소드
        public override bool CanUndo()
        {
            if (input_log.Count == 0)
                return false;

            return true;
        }

        public override Tuple<int, int, int> Undo()
        {
            Tuple<int, int, int> undo_pos = input_log.Pop();
            int undo_value = grid_change_log.Pop()[undo_pos.Item1, undo_pos.Item2];

            grid[undo_pos.Item1, undo_pos.Item2] = undo_value;

            return new Tuple<int, int, int>(undo_pos.Item1, undo_pos.Item2, undo_value);
        }

        public override bool IsValidAll()
        {
            return grid.IsValidAll();
        }

        public override bool IsValidSudoku()
=======
        public bool IsValidSudoku()
>>>>>>> 2019203002
        {
            return grid.IsValidSudoku();
        }

<<<<<<< HEAD
        public override List<Tuple<int, int>> FindWrongCells(int n, int m)
        {
            List<Tuple<int, int>> return_obj = new List<Tuple<int, int>>();
            return_obj.AddRange(FindWrongCells(GroupType.Row, n));
            return_obj.AddRange(FindWrongCells(GroupType.Colum, m));
            return_obj.AddRange(FindWrongCells(GroupType.Area, area_group_grid[n, m]));
            return return_obj;
        }

        public override List<Tuple<int, int>> FindWrongCells()
        {
            List<Tuple<int, int>> return_obj = new List<Tuple<int, int>>();
            for (int i = 0; i < grid_size; i++)
            {
                return_obj.AddRange(FindWrongCells(GroupType.Row, i));
            }
            return return_obj;
        }

        //새로운 스도쿠 생성
        public override void ResetSudoku()
        {
            input_log.Clear();
            grid_change_log.Clear();

            this.fixed_cells = GridGenerator.GenerateRandomFixedCellGrid(grid_size, fixed_cnt);

            ResetNonFixedCells();
        }

        //중복값 확인 메소드
        public bool IsValidGroup(GroupType group_type, int group_num)
        {
            return grid.IsValidGroup(group_type, group_num);
        }

        public bool IsValidInput(int n, int m)
        {
            if (!IsValidGroup(GroupType.Row, n))
                return false;
            if (!IsValidGroup(GroupType.Colum, m))
                return false;
            if (!IsValidGroup(GroupType.Area, area_group_grid[n, m]))
                return false;
            return true;
        }

        //중복값을 가진 셀의 위치를 리스트로 반환하는 메소드
=======
        public int Size
        {
            get { return size; }
        }

>>>>>>> 2019203002
        public List<Tuple<int, int>> FindWrongCells(GroupType group_type, int group_num)
        {
            return grid.FindWrongCells(group_type, group_num);
        }
<<<<<<< HEAD

        //해당 셀이 고정됬는지 확인하는 메소드
        public bool IsFixedCell(int n, int m)
        {
            return fixed_cells[n, m];
        }
        
        //메소드 구현을 위한 private 메소드

        private void FillGirdValue(int[,] InitGird)
        {
            int rows = InitGird.GetLength(0);
            int cols = InitGird.GetLength(1);

            if (rows != grid_size || cols != grid_size)
            {
                Environment.FailFast("게임판에 맞는 배열을 입력하세요.");
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    grid[i, j] = InitGird[i, j];
            }
        }

        private void InitGridValue()
        {
            for (int i = 0; i < this.GridSize; i++)
                for (int j = 0; j < this.GridSize; j++)
                    grid[i, j] = 0;
        }

        private void ResetNonFixedCells()
        {
            for (int i = 0; i < this.GridSize; i++)
            {
                for (int j = 0; j < this.GridSize; j++)
                {
                    if (fixed_cells[i, j])
                    {

                    }
                    else
                    {
                        grid[i, j] = 0;
                    }
                }
            }
        }
    }

    public static class GridGenerator
    {
        public static bool[,] GenerateRandomFixedCellGrid(int grid_size, int fixed_num)
        {
            bool[,] return_grid = new bool[grid_size, grid_size];

            List<(int, int)> pos_set = new List<(int, int)>();
            Random random = new Random();

            while (pos_set.Count < fixed_num)
            {
                int x = random.Next(0, grid_size);
                int y = random.Next(0, grid_size);
                var pos = (x, y);

                // 중복된 좌표가 생성되지 않도록 확인
                if (!pos_set.Contains(pos))
                {
                    pos_set.Add(pos);
                }
            }

            for (int i = 0; i < grid_size; i++)
            {
                for (int j = 0; j < grid_size; j++)
                {
                    if (pos_set.Contains((i, j)))
                        return_grid[i, j] = true;
                    else
                        return_grid[i, j] = false;
                }
            }

            return return_grid;
        }

        public static bool[,] GenerateRandomFixedCellSamuraiGrid(int fixed_num)
        {
            int grid_size = 21;
            int[,] answerArray =
            {
                {8, 9, 1, 2, 3, 4, 7, 6, 5, 0, 0, 0, 2, 8, 1, 6, 9, 5, 4, 7, 3},
                {2, 4, 7, 1, 6, 5, 8, 9, 3, 0, 0, 0, 3, 5, 7, 1, 2, 4, 6, 9, 8},
                {5, 6, 3, 9, 7, 8, 4, 2, 1, 0, 0, 0, 4, 9, 6, 3, 8, 7, 1, 5, 2},
                {1, 3, 4, 6, 5, 2, 9, 8, 7, 0, 0, 0, 5, 1, 9, 4, 3, 6, 8, 2, 7},
                {7, 2, 9, 3, 8, 1, 6, 5, 4, 0, 0, 0, 8, 2, 4, 9, 7, 1, 5, 3, 6},
                {6, 8, 5, 7, 4, 9, 1, 3, 2, 0, 0, 0, 6, 7, 3, 2, 5, 8, 9, 1, 4},
                {9, 1, 8, 4, 2, 3, 5, 7, 6, 2, 1, 3, 9, 4, 8, 7, 1, 3, 2, 6, 5},
                {3, 5, 6, 8, 1, 7, 2, 4, 9, 8, 7, 6, 1, 3, 5, 8, 6, 2, 7, 4, 9},
                {4, 7, 2, 5, 9, 6, 3, 1, 8, 4, 5, 9, 7, 6, 2, 5, 4, 9, 3, 8, 1},
                {0, 0, 0, 0, 0, 0, 8, 6, 7, 5, 2, 1, 3, 9, 4, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 4, 5, 1, 3, 9, 7, 8, 2, 6, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 9, 2, 3, 6, 8, 4, 5, 7, 1, 0, 0, 0, 0, 0, 0},
                {1, 4, 7, 3, 9, 2, 6, 8, 5, 7, 3, 2, 4, 1, 9, 2, 8, 5, 7, 6, 3},
                {9, 6, 2, 8, 5, 7, 1, 3, 4, 9, 6, 5, 2, 8, 7, 9, 6, 3, 4, 1, 5},
                {8, 5, 3, 6, 1, 4, 7, 9, 2, 1, 4, 8, 6, 5, 3, 7, 1, 4, 2, 9, 8},
                {6, 3, 9, 1, 8, 5, 4, 2, 7, 0, 0, 0, 8, 4, 2, 6, 3, 9, 5, 7, 1},
                {5, 7, 4, 2, 6, 3, 9, 1, 8, 0, 0, 0, 9, 7, 5, 4, 2, 1, 3, 8, 6},
                {2, 8, 1, 4, 7, 9, 3, 5, 6, 0, 0, 0, 3, 6, 1, 8, 5, 7, 9, 2, 4},
                {3, 9, 6, 5, 4, 8, 2, 7, 1, 0, 0, 0, 7, 3, 8, 5, 9, 6, 1, 4, 2},
                {4, 2, 5, 7, 3, 1, 8, 6, 9, 0, 0, 0, 1, 2, 4, 3, 7, 8, 6, 5, 9},
                {7, 1, 8, 9, 2, 6, 5, 4, 3, 0, 0, 0, 5, 9, 6, 1, 4, 2, 8, 3, 7}
            };

            bool[,] return_grid = new bool[grid_size, grid_size];

            List<(int, int)> pos_set = new List<(int, int)>();
            Random random = new Random();

            while (pos_set.Count < fixed_num)
            {
                int x = random.Next(0, grid_size);
                int y = random.Next(0, grid_size);
                var pos = (x, y);

                // 중복된 좌표가 생성되지 않도록 확인
                if (!pos_set.Contains(pos) && answerArray[x,y]!=0)
                {
                    pos_set.Add(pos);
                }
            }

            for (int i = 0; i < grid_size; i++)
            {
                for (int j = 0; j < grid_size; j++)
                {
                    if (pos_set.Contains((i, j)))
                        return_grid[i, j] = true;
                    else
                        return_grid[i, j] = false;
                }
            }

            return return_grid;
        }

        public static int[,] GenerateRegularSudokuGrid(int block_size)
        {
            int grid_size = block_size * block_size;
            int[,] answerArray3 = {
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
            int[,] answerArray4 = {
                {9, 1, 6, 10, 7, 4, 2, 14, 3, 11, 5, 12, 15, 16, 8, 13},
                {13, 15, 16, 7, 11, 5, 10, 3, 6, 2, 8, 1, 9, 4, 12, 14},
                {5, 2, 14, 12, 8, 1, 13, 9, 16, 15, 4, 7, 10, 11, 3, 6},
                {4, 11, 3, 8, 16, 6, 12, 15, 14, 9, 10, 13, 7, 2, 5, 1},
                {15, 16, 7, 9, 14, 8, 3, 4, 11, 10, 2, 6, 13, 12, 1, 5},
                {12, 14, 5, 6, 13, 2, 1, 11, 4, 8, 15, 9, 3, 7, 16, 10},
                {11, 3, 10, 13, 9, 12, 15, 7, 1, 5, 14, 16, 4, 6, 2, 8},
                {1, 4, 8, 2, 10, 16, 5, 6, 13, 12, 7, 3, 11, 14, 15, 9},
                {14, 13, 2, 16, 3, 10, 11, 12, 8, 6, 9, 15, 1, 5, 7, 4},
                {8, 6, 12, 15, 1, 9, 14, 5, 7, 4, 3, 2, 16, 13, 10, 11},
                {7, 10, 4, 11, 2, 15, 16, 8, 5, 1, 13, 14, 6, 3, 9, 12},
                {3, 9, 1, 5, 6, 7, 4, 13, 10, 16, 12, 11, 2, 8, 14, 15},
                {6, 7, 11, 4, 12, 3, 8, 16, 9, 14, 1, 10, 5, 15, 13, 2},
                {16, 5, 13, 1, 15, 14, 6, 10, 2, 7, 11, 8, 12, 9, 4, 3},
                {10, 12, 9, 14, 4, 13, 7, 2, 15, 3, 6, 5, 8, 1, 11, 16},
                {2, 8, 15, 3, 5, 11, 9, 1, 12, 13, 16, 4, 14, 10, 6, 7}
            };

            int[,] answerArray=new int[grid_size,grid_size];

            if (block_size == 3)
            {
                answerArray = answerArray3;
            }
            else if(block_size == 4)
            {
                answerArray = answerArray4;
            }

            var suffle_row = () =>
            {
                Random randObj = new Random();
                int groupNum = randObj.Next(0,block_size)*block_size;
                int randNum1 = 0;
                int randNum2 = 0;

                var rand = () =>
                {
                    randNum1 = randObj.Next(0, block_size);
                    randNum2 = randObj.Next(0, block_size);
                    while (randNum1 == randNum2)
                        randNum2 = randObj.Next(0, block_size);
                };

                rand();
                for (int j = 0; j < grid_size; j++)
                {
                    // 그룹 내에서 열들의 순서를 변경                    
                    int temp = answerArray[j, groupNum + randNum1];
                    answerArray[j, groupNum + randNum1] = answerArray[j, groupNum + randNum2];
                    answerArray[j, groupNum + randNum2] = temp;
                }

                rand();
                for (int j = 0; j < grid_size; j++)
                {                  
                    for (int k = 0; k < block_size; k++)
                    {
                        int temp = answerArray[j, randNum1*block_size+k];
                        answerArray[j, randNum1 * block_size + k] = answerArray[j, randNum2 * block_size + k];
                        answerArray[j, randNum2 * block_size + k] = temp;
                    }
                }
            };

            var suffle_col = ( ) =>
            {
                Random randObj = new Random();
                int groupNum = randObj.Next(0, block_size) * block_size;
                int randNum1 = 0;
                int randNum2 = 0;

                var rand = () =>
                {
                    randNum1 = randObj.Next(0, block_size);
                    randNum2 = randObj.Next(0, block_size);
                    while (randNum1 == randNum2)
                        randNum2 = randObj.Next(0, block_size);
                };

                rand();
                for (int j = 0; j < grid_size; j++)
                {
                    // 그룹 내에서 열들의 순서를 변경                    
                    int temp = answerArray[groupNum + randNum1, j];
                    answerArray[groupNum + randNum1, j] = answerArray[groupNum + randNum2, j];
                    answerArray[groupNum + randNum2, j] = temp;
                }

                rand();
                for (int j = 0; j < grid_size; j++)
                {
                    for (int k = 0; k < block_size; k++)
                    {
                        int temp = answerArray[randNum1 * block_size + k,j];
                        answerArray[randNum1 * block_size + k,j] = answerArray[randNum2 * block_size + k, j];
                        answerArray[randNum2 * block_size + k, j] = temp;
                    }
                }
            };

            for (int i = 0; i < grid_size; i++)
            {
                suffle_row();
                suffle_col();
            }
            
            return answerArray;
        }

        public static int[,] GenerateSamuraiSudokuGrid()
        {
            int grid_size = 21;
            int[,] answerArray =
            {
                {8, 9, 1, 2, 3, 4, 7, 6, 5, 0, 0, 0, 2, 8, 1, 6, 9, 5, 4, 7, 3},
                {2, 4, 7, 1, 6, 5, 8, 9, 3, 0, 0, 0, 3, 5, 7, 1, 2, 4, 6, 9, 8},
                {5, 6, 3, 9, 7, 8, 4, 2, 1, 0, 0, 0, 4, 9, 6, 3, 8, 7, 1, 5, 2},
                {1, 3, 4, 6, 5, 2, 9, 8, 7, 0, 0, 0, 5, 1, 9, 4, 3, 6, 8, 2, 7},
                {7, 2, 9, 3, 8, 1, 6, 5, 4, 0, 0, 0, 8, 2, 4, 9, 7, 1, 5, 3, 6},
                {6, 8, 5, 7, 4, 9, 1, 3, 2, 0, 0, 0, 6, 7, 3, 2, 5, 8, 9, 1, 4},
                {9, 1, 8, 4, 2, 3, 5, 7, 6, 2, 1, 3, 9, 4, 8, 7, 1, 3, 2, 6, 5},
                {3, 5, 6, 8, 1, 7, 2, 4, 9, 8, 7, 6, 1, 3, 5, 8, 6, 2, 7, 4, 9},
                {4, 7, 2, 5, 9, 6, 3, 1, 8, 4, 5, 9, 7, 6, 2, 5, 4, 9, 3, 8, 1},
                {0, 0, 0, 0, 0, 0, 8, 6, 7, 5, 2, 1, 3, 9, 4, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 4, 5, 1, 3, 9, 7, 8, 2, 6, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 9, 2, 3, 6, 8, 4, 5, 7, 1, 0, 0, 0, 0, 0, 0},
                {1, 4, 7, 3, 9, 2, 6, 8, 5, 7, 3, 2, 4, 1, 9, 2, 8, 5, 7, 6, 3},
                {9, 6, 2, 8, 5, 7, 1, 3, 4, 9, 6, 5, 2, 8, 7, 9, 6, 3, 4, 1, 5},
                {8, 5, 3, 6, 1, 4, 7, 9, 2, 1, 4, 8, 6, 5, 3, 7, 1, 4, 2, 9, 8},
                {6, 3, 9, 1, 8, 5, 4, 2, 7, 0, 0, 0, 8, 4, 2, 6, 3, 9, 5, 7, 1},
                {5, 7, 4, 2, 6, 3, 9, 1, 8, 0, 0, 0, 9, 7, 5, 4, 2, 1, 3, 8, 6},
                {2, 8, 1, 4, 7, 9, 3, 5, 6, 0, 0, 0, 3, 6, 1, 8, 5, 7, 9, 2, 4},
                {3, 9, 6, 5, 4, 8, 2, 7, 1, 0, 0, 0, 7, 3, 8, 5, 9, 6, 1, 4, 2},
                {4, 2, 5, 7, 3, 1, 8, 6, 9, 0, 0, 0, 1, 2, 4, 3, 7, 8, 6, 5, 9},
                {7, 1, 8, 9, 2, 6, 5, 4, 3, 0, 0, 0, 5, 9, 6, 1, 4, 2, 8, 3, 7}
            };

            var suffle_row = (int groupNum, int n) =>
            {
                // 한 그룹당 열 3개를 포함한다고 생각
                // 그룹의 번호를 입력받아 해당 그룸 내에서 열들을 섞고, 그룹별로 열들을 다시 섞음
                // groupNum : 해당하는 그룹의 첫번째 열()
                // groupNum = 0 : 0열, 1열, 2열
                // groupNum = 3 : 3열, 4열, 5열
                // groupNum = 6 : 6열, 7열, 8열

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < grid_size; j++)
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
                        if (groupNum == 0 || groupNum ==  15)
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
            };

            var suffle_col = (int groupNum, int n) =>
            {
                /// 한 그룹당 행 3개를 포함한다고 생각        
                /// 그룹의 번호를 입력받아 해당 그룸 내에서 행들을 섞고, 그룹별로 행들을 다시 섞음
                /// groupNum : 해당하는 그룹의 첫번째 행
                /// groupNum = 0 : 0행, 1행, 2행
                /// groupNum = 3 : 3행, 4행, 5행
                /// groupNum = 6 : 6행, 7행, 8행

                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < grid_size; j++)
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
                        if (groupNum == 0 || groupNum == 15)
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
            };

            Random randObj = new Random();
            for (int i = 0; i < 3; i++)
            {
                int randNum = randObj.Next(0, 10);

                suffle_row(3 * i, randNum);
                suffle_col(3 * i, randNum);
            }
            return answerArray;
        }

        public static int[,] GenerateDefaultAreaGrid(int block_size)
        {
            int[,] area_grid = new int[block_size * block_size, block_size * block_size];
            for (int i = 0; i < block_size; i++)
            {
                for (int j = 0; j < block_size; j++)
                {
                    int n = i * block_size;
                    int m = j * block_size;
                    for (int k = 0; k < block_size; k++)
                    {
                        for (int p = 0; p < block_size; p++)
                        {
                            area_grid[n + k, m + p] = block_size * i + j;
                        }
                    }
                }
            }
            return area_grid;
        }

        public static int[,] GenerateSamuraiAreaGrid()
        {
            int[,] area_grid =
            {
                {0, 0, 0, 1, 1, 1, 2, 2, 2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2},
                {0, 0, 0, 1, 1, 1, 2, 2, 2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2},
                {0, 0, 0, 1, 1, 1, 2, 2, 2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2},
                {3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5},
                {3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5},
                {3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5},
                {6, 6, 6, 7, 7, 7, 0, 0, 0, 1, 1, 1, 2, 2, 2, 7, 7, 7, 8, 8, 8},
                {6, 6, 6, 7, 7, 7, 0, 0, 0, 1, 1, 1, 2, 2, 2, 7, 7, 7, 8, 8, 8},
                {6, 6, 6, 7, 7, 7, 0, 0, 0, 1, 1, 1, 2, 2, 2, 7, 7, 7, 8, 8, 8},
                {-1, -1, -1, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, -1, -1, -1},
                {-1, -1, -1, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, -1, -1, -1},
                {-1, -1, -1, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, -1, -1, -1},
                {6, 6, 6, 7, 7, 7, 8, 8, 8, 7, 7, 7, 6, 6, 6, 7, 7, 7, 8, 8, 8},
                {6, 6, 6, 7, 7, 7, 8, 8, 8, 7, 7, 7, 6, 6, 6, 7, 7, 7, 8, 8, 8},
                {6, 6, 6, 7, 7, 7, 8, 8, 8, 7, 7, 7, 6, 6, 6, 7, 7, 7, 8, 8, 8},
                {0, 0, 0, 1, 1, 1, 2, 2, 2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2},
                {0, 0, 0, 1, 1, 1, 2, 2, 2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2},
                {0, 0, 0, 1, 1, 1, 2, 2, 2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2},
                {3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5},
                {3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5},
                {3, 3, 3, 4, 4, 4, 5, 5, 5, -1, -1, -1, 3, 3, 3, 4, 4, 4, 5, 5, 5}
            };
            return area_grid;
        }
    }
   
}
=======
    }
}


//메모: 어느 셀이 잘못됬는지 알려주는 기능, 게임판의 초기화 기능에 대한 기능에 대해 생각해보고 추가하기
>>>>>>> 2019203002
