using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JigsawSudokuGenerator
{
    public static class JigsawSudokuGenerator
    {
        private static readonly int block_size = 3;
        private static readonly int grid_size = block_size * block_size;
        private static readonly int maximum_loop = 800000;

        private static int[,] init_grid;
        private static int[,] area_group_grid;
        private static HashSet<int>[] row_group;
        private static HashSet<int>[] col_group;
        private static HashSet<int>[] area_group;
        private static List<Tuple<int, int>>[] area_set;

        public static int[,] CreateRandomSudoku(int[,] area_group_grid)
        {
            int loop_cnt = 0;
            init_grid=new int[grid_size, grid_size];
            Stack<HashSet<int>> set_stack = new Stack<HashSet<int>>();
            InitGenerator(area_group_grid);
            Random random = new Random();

            for (int i = 0; i < grid_size; i++)
            {
                for (int j = 0; j < grid_size; j++)
                {
                    loop_cnt++;
                    if (loop_cnt > maximum_loop)
                    {
                        return null;
                    }
                    HashSet<int> set;
                    if (set_stack.Count == (i * grid_size + j))
                    {
                        set = new HashSet<int>(row_group[i]);
                        set.IntersectWith(col_group[j]);
                        set.IntersectWith(area_group[area_group_grid[i, j]]);
                        set_stack.Push(set);
                    }
                    else
                    {
                        set = set_stack.Peek();
                    }

                    while (set.Count != 0)
                    {
                        int random_element = set.ElementAt(random.Next(set.Count));
                        set.Remove(random_element);
                        InputValue(i, j, random_element);

                        if (IsPromise(i, j))
                        {
                            break;
                        }
                        else
                        {
                            UndoInputValue(i, j, random_element);
                        }
                    }

                    if (set.Count == 0 && init_grid[i, j] == 0)
                    {
                        set_stack.Pop();

                        if (j == 0)
                        {
                            i--;
                            j = grid_size - 2;
                        }
                        else
                        {
                            j -= 2;
                        }
                        UndoInputValue(i, j + 1, init_grid[i, j + 1]);
                    }
                }
            }
            return init_grid;
        }

        public static int[,] GenerateRandomAreaGrid()
        {
            int swap_cnt = 0;
            Random random = new Random();
            int[,] area_group_array = GenerateDefaultAreaGrid(block_size);

            Func<Tuple<int, int>, bool> check_piece = (Tuple<int, int> coordinate) =>
            {
                int piece_type = area_group_array[coordinate.Item1, coordinate.Item2];
                int piece_size = 1;
                Queue<Tuple<int, int>> tuples = new Queue<Tuple<int, int>>();
                HashSet<Tuple<int, int>> check_visit = new HashSet<Tuple<int, int>>();
                tuples.Enqueue(coordinate);
                check_visit.Add(coordinate);
                while (tuples.Count != 0)
                {
                    var next_coordinate = tuples.Dequeue();
                    int row = next_coordinate.Item1;
                    int col = next_coordinate.Item2;
                    //위
                    if (row != 0)
                        if (area_group_array[row - 1, col] == piece_type)
                            if (!check_visit.Contains(new Tuple<int, int>(row - 1, col)))
                            {
                                check_visit.Add(new Tuple<int, int>(row - 1, col));
                                tuples.Enqueue(new Tuple<int, int>(row - 1, col));
                                piece_size++;
                            }
                    //아래
                    if (row != grid_size - 1)
                        if (area_group_array[row + 1, col] == piece_type)
                            if (!check_visit.Contains(new Tuple<int, int>(row + 1, col)))
                            {
                                check_visit.Add(new Tuple<int, int>(row + 1, col));
                                tuples.Enqueue(new Tuple<int, int>(row + 1, col));
                                piece_size++;
                            }
                    //왼쪽
                    if (col != 0)
                        if (area_group_array[row, col - 1] == piece_type)
                            if (!check_visit.Contains(new Tuple<int, int>(row, col - 1)))
                            {
                                check_visit.Add(new Tuple<int, int>(row, col - 1));
                                tuples.Enqueue(new Tuple<int, int>(row, col - 1));
                                piece_size++;
                            }
                    //오른쪽
                    if (col != grid_size -1)
                        if (area_group_array[row, col + 1] == piece_type)
                            if (!check_visit.Contains(new Tuple<int, int>(row, col + 1)))
                            {
                                check_visit.Add(new Tuple<int, int>(row, col + 1));
                                tuples.Enqueue(new Tuple<int, int>(row, col + 1));
                                piece_size++;
                            }
                }
                return piece_size == grid_size;
            };

            while (swap_cnt != 1000)
            {
                int x1 = random.Next(0, grid_size);
                int y1 = random.Next(0, grid_size);
                int x2 = random.Next(0, grid_size);
                int y2 = random.Next(0, grid_size);
                var coordinate1 = new Tuple<int, int>(x1, y1);
                var coordinate2 = new Tuple<int, int>(x2, y2);
                if (area_group_array[x1, y1] == area_group_array[x2, y2])
                    continue;
                else
                {
                    (area_group_array[x2, y2], area_group_array[x1, y1]) = (area_group_array[x1, y1], area_group_array[x2, y2]);
                }
                if (check_piece(coordinate1) && check_piece(coordinate2))
                {
                    swap_cnt++;
                }
                else
                {
                    (area_group_array[x2, y2], area_group_array[x1, y1]) = (area_group_array[x1, y1], area_group_array[x2, y2]);
                }
            }
            return area_group_array;
        }

        private static void InitGenerator(int[,] area_group_grid)
        {
            JigsawSudokuGenerator.area_group_grid = area_group_grid;
            init_grid = new int[grid_size, grid_size];

            row_group = new HashSet<int>[grid_size];
            col_group = new HashSet<int>[grid_size];
            area_group = new HashSet<int>[grid_size];

            for (int i = 0; i < grid_size; i++)
            {

                row_group[i] = new HashSet<int>();
                col_group[i] = new HashSet<int>();
                area_group[i] = new HashSet<int>();
                for (int n = 1; n <= grid_size; n++)
                {
                    row_group[i].Add(n);
                    col_group[i].Add(n);
                    area_group[i].Add(n);
                }

            }

            area_set = new List<Tuple<int, int>>[grid_size];

            for (int i = 0; i < grid_size; i++)
            {
                area_set[i] = new List<Tuple<int, int>>();
            }

            for (int i = 0; i < grid_size; i++)
            {
                for (int j = 0; j < grid_size; j++)
                {
                    area_set[area_group_grid[i, j]].Add(new Tuple<int, int>(i, j));
                }
            }
        }

        private static void UndoInputValue(int n, int m, int value)
        {

            row_group[n].Add(value);
            col_group[m].Add(value);

            int area_num = area_group_grid[n, m];
            area_group[area_num].Add(value);
            init_grid[n, m] = 0;
        }

        private static void InputValue(int n, int m, int value)
        {
            int area_num = area_group_grid[n, m];
            row_group[n].Remove(value);
            col_group[m].Remove(value);
            area_group[area_num].Remove(value);
            init_grid[n, m] = value;
        }

        private static bool IsIntersectEmpty(HashSet<int> set1, HashSet<int> set2, HashSet<int> set3)
        {
            bool hasNoIntersection = true;

            HashSet<int> smallestSet = set1.Count <= set2.Count ? set1 : set2;
            HashSet<int> largestSet = set1.Count > set2.Count ? set1 : set2;

            foreach (int element in smallestSet)
            {
                if (largestSet.Contains(element))
                {
                    hasNoIntersection = false;
                    break;
                }
            }

            if (hasNoIntersection)
            {
                return true;
            }
            else
            {
                HashSet<int> intersection = new HashSet<int>(smallestSet);
                intersection.IntersectWith(set3);

                if (intersection.Count > 0)
                {
                    hasNoIntersection = false;
                }
            }

            if (hasNoIntersection)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsPromise(int n, int m)
        {
            int area = area_group_grid[n, m];
            for (int i = 0; i < grid_size; i++)
            {
                if (init_grid[n, i] == 0)
                {
                    if (IsIntersectEmpty(row_group[n], col_group[i], area_group[area_group_grid[n, i]]))
                        return false;
                }

                if (init_grid[i, m] == 0)
                {
                    if (IsIntersectEmpty(row_group[i], col_group[m], area_group[area_group_grid[i, m]]))
                        return false;
                }


                int row = area_set[area][i].Item1;
                int col = area_set[area][i].Item2;
                if (init_grid[row, col] == 0)
                {
                    if (IsIntersectEmpty(row_group[row], col_group[col], area_group[area]))
                        return false;
                }
            }

            return true;
        }

        private static int[,] GenerateDefaultAreaGrid(int block_size)
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
    }

    public static class JigsawSudokuFileOpener
    {
        public static void WriteFile(List<JigsawSudokuData> game_data)
        {
            if (game_data.Count > 0)
            {               
                if (File.Exists("jigsaw_sudoku_data.xml"))
                {
                    game_data.AddRange(ReadFile());
                }

                FileStream stream = new FileStream("jigsaw_sudoku_data.xml", FileMode.Create);

                DataContractSerializer serializer = new DataContractSerializer(typeof(List<JigsawSudokuData>));
                StreamWriter stream_writer = new StreamWriter(stream);
                XmlWriter writer = XmlWriter.Create(stream_writer, new XmlWriterSettings { Indent = true });

                serializer.WriteObject(writer, game_data);
                writer.Flush();
                stream_writer.Flush();

                writer.Close();
                stream_writer.Close();
                stream.Close();
            }
        }
        public static List<JigsawSudokuData> ReadFile()
        {
            List<JigsawSudokuData> game_data_list = new List<JigsawSudokuData>();

            if (File.Exists("jigsaw_sudoku_data.xml"))
            {
                FileStream stream = new FileStream("jigsaw_sudoku_data.xml", FileMode.Open);
                DataContractSerializer serializer = new DataContractSerializer(typeof(JigsawSudokuData));
                XmlReader reader = XmlReader.Create(stream);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "JigsawSudokuData")
                    {
                        JigsawSudokuData gameData = (JigsawSudokuData)serializer.ReadObject(reader);
                        game_data_list.Add(gameData);
                    }
                }

                reader.Close();
                stream.Close();

            }
            return game_data_list;
        }
    }

    [DataContract]
    public class JigsawSudokuData
    {
        private static readonly int block_size = 3;
        private static readonly int grid_size = block_size * block_size;

        [DataMember]
        private int[][] area_group_array;

        [DataMember]
        private int[][] grid_value_array;

        public JigsawSudokuData(int[,] area_group_array, int[,] grid_value_array)
        {
            this.area_group_array = new int[grid_size][];
            this.grid_value_array = new int[grid_size][];
            for(int i=0; i<grid_size; i++)
            {
                this.area_group_array[i] = new int[grid_size];
                this.grid_value_array[i] =new int[grid_size];
            }
            for(int  j=0; j < grid_size; j++)
            {
                for(int  k=0; k<grid_size; k++)
                {
                    this.area_group_array[j][k] = area_group_array[j, k];
                    this.grid_value_array[j][k] = grid_value_array[j, k];
                }
            }
        }

        public int[,] AreaGroupArray
        {
            get 
            {
                int[,] area_group_array = new int[grid_size, grid_size];
                for (int j = 0; j < grid_size; j++)
                {
                    for (int k = 0; k < grid_size; k++)
                    {
                        area_group_array[j, k] = this.area_group_array[j][k];
                        
                    }
                }
                return area_group_array; 
            }
        }

        public int[,] GridValueArray
        {
            get 
            {
                int[,] grid_value_array = new int[grid_size, grid_size];
                for (int j = 0; j < grid_size; j++)
                {
                    for (int k = 0; k < grid_size; k++)
                    {
                        grid_value_array[j, k] = this.grid_value_array[j][k];

                    }
                }               
                return grid_value_array; 
            }
        }
    }

    
}
