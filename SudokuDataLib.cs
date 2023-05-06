﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

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

        private int min_val;
        private int max_val;

        private int col_group;
        private int row_group;
        private int area_group;

        //생성자
        internal Cell(int max_val = 9)
        {
            this.min_val = 0;
            this.max_val = max_val;
        }

        //셀 값 접근 속성
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

        //셀 그룹 접근 속성 
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
        private int size;
        private Cell[,] grid;

        private List<Cell>[] row_group;
        private List<Cell>[] col_group;
        private List<Cell>[] area_group;

        //생성자
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

                    SetCellGroup(n, m, area_group_array[n, m]);
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

        internal int Size
        {
            get { return size; }
        }

        //중복값 확인 메소드
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

        internal bool IsValidSudoku()
        {
            for (int i = 0; i < size; i++)
            {
                if (!IsValidRow(i))
                    return false;
                if (!IsValidColum(i))
                    return false;
                if (!IsValidArea(i))
                    return false;
            }

            if(!isFilled())
                return false;

            return true;
        }

        //현재 격자 값 배열을 생성하는 메소드
        internal int[,] GetGridValue()
        {
            int[,] result = new int[size, size];
            for (int n = 0; n < size; n++)
            {
                for (int m = 0; m < size; m++)
                    result[n, m] = grid[n, m].Value;
            }
            return result;
        }

        //중복값을 가진 셀의 위치를 리스트로 반환하는 메소드
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

        //메소드 구현을 위한 private 메소드
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

        private void SetCellGroup(int row, int col, int area)
        {
            grid[row, col].Row = row;
            grid[row, col].Colum = col;
            grid[row, col].Area = area;
        }

        private void FillCellGroup()
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
        private bool isFilled()
        {
            for(int i = 0; i < size; i++)
            {
                for(int  j = 0; j < size; j++)
                    if (grid[i,j].Value==0)
                        return false;
            }
            return true;
        }
        private List<Cell> FindWrongCells(List<Cell> target_group)
        {
            List<Cell> wrong_cell = new List<Cell>();

            int[] number_cnt = new int[size + 1];
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

            for (int n = 0; n < size; n++)
            {
                for (int m = 0; m < size; m++)
                {
                    if (cells.Contains(grid[n, m]))
                        result.Add(new Tuple<int, int>(n, m));
                }
            }

            return result;
        }
    }

    public class GameBorad
    {
        int size;

        SquareGrid grid;

        bool[,] fixed_cells;

        Stack<Tuple<int, int, int>> input_log;
        Stack<int[,]> grid_change_log;

        //생성자
        public GameBorad(int size = 9, int[,] area_group_array = null, bool[,] fixed_cells = null, int[,] init_grid = null)
        {
            grid = new SquareGrid(size,area_group_array);
            this.size = grid.Size;

            this.fixed_cells = new bool[9, 9];

            input_log = new Stack<Tuple<int, int, int>>();
            grid_change_log = new Stack<int[,]>();

            if (fixed_cells != null)
                SetFixedCells(fixed_cells);

            if (init_grid != null)
                InitGirdValue(init_grid);
        }

        //속성 및 인덱서
        public int this[int n, int m]
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
        public int Size
        {
            get { return size; }
        }

        //가장 최근에 입력한 셀의 위치와 이전 값을 반환하는 메소드
        public Tuple<int, int, int> Undo()
        {
            Tuple<int, int, int> undo_pos = input_log.Pop();
            int undo_value = grid_change_log.Pop()[undo_pos.Item1, undo_pos.Item2];

            grid[undo_pos.Item1, undo_pos.Item2] = undo_value;

            return new Tuple<int, int, int>(undo_pos.Item1, undo_pos.Item2, undo_value);
        }

        //중복값 확인 메소드
        public bool IsValidGroup(GroupType group_type, int group_num)
        {
            return grid.IsValidGroup(group_type, group_num);
        }

        public bool IsValidSudoku()
        {
            return grid.IsValidSudoku();
        }

        //중복값을 가진 셀의 위치를 리스트로 반환하는 메소드
        public List<Tuple<int, int>> FindWrongCells(GroupType group_type, int group_num)
        {
            return grid.FindWrongCells(group_type, group_num);
        }

        //메소드 구현을 위한 private 메소드
        private void SetFixedCells(bool[,] fixed_cells)
        {
            int rows = fixed_cells.GetLength(0);
            int cols = fixed_cells.GetLength(1);

            if (rows != size || cols != size)
            {
                Environment.FailFast("게임판에 맞는 배열을 입력하세요.");
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    this.fixed_cells[i, j] = fixed_cells[i, j];
            }
        }

        private void InitGirdValue(int[,] InitGird)
        {
            int rows = InitGird.GetLength(0);
            int cols = InitGird.GetLength(1);

            if (rows != size || cols != size)
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
    }
}