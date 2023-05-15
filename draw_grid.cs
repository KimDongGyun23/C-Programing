using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Printing;

namespace drawing_test
{
    public static class draw_grid
    {
        public static int pen_width = 3;
        public static int input_edge_len = 0;

        public static Point[,] DrawBoard(int cell_edge_len, Point location, int[,] area_group_array, int grid_size, Form form)
        {
            Graphics g = form.CreateGraphics();

            Pen slim_pen = new Pen(Color.LightGray, pen_width);
            Pen thick_pen = new Pen(Color.Black, pen_width);

            int interval = (pen_width + 1) / 2;
            int right_extend_thick_pen = interval;
            int left_extend_thick_pen = interval-1;

            input_edge_len = cell_edge_len - 2 * interval;

            Point[,] cell_vertex = new Point[grid_size + 1, grid_size + 1];
            Point[,] input_box_pos = new Point[grid_size, grid_size];

            //cell_vertex 채우기
            for (int n = 0; n <= grid_size; n++)
            {
                for (int m = 0; m <= grid_size; m++)
                {
                    cell_vertex[n, m] = new Point(location.X + m * cell_edge_len, location.Y + n * cell_edge_len);
                }
            }

            //cell_vertex 채우기

            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    if (area_group_array[n, m] == -1)
                        continue;
                    input_box_pos[n, m] = new Point(cell_vertex[n, m].X + interval, cell_vertex[n, m].Y + interval);
                }
            }

            //폼 전체 지우기
            g.Clear(form.BackColor);

            //격자의 흐린 가로선 그리기
            for (int n = 0; n <= grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    int i = n - 1;
                    if (n != grid_size && i >= 0)
                    {
                        if (area_group_array[n, m] == area_group_array[i, m] && area_group_array[i, m] != -1)
                        {
                            g.DrawLine(slim_pen, cell_vertex[n, m], cell_vertex[n, m + 1]);
                        }

                    }
                }
            }

            //격자의 흐린 세로선 그리기
            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m <= grid_size; m++)
                {
                    int i = m - 1;

                    if (m != grid_size && i >= 0)
                    {
                        if (area_group_array[n, m] == area_group_array[n, i] && area_group_array[n, i] != -1)
                        {
                            g.DrawLine(slim_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                        }
                    }
                }
            }

            //격자의 진한 가로선 그리기
            for (int n = 0; n <= grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    int i = n - 1;
                    if (n == grid_size)//가장 오른쪽 테두리를 그리는 경우
                    {
                        if (area_group_array[i, m] == -1)
                            continue;
                        g.DrawLine(thick_pen, cell_vertex[n, m].X - left_extend_thick_pen, cell_vertex[n, m].Y, cell_vertex[n, m + 1].X + right_extend_thick_pen, cell_vertex[n, m + 1].Y);
                    }
                    else if (i >= 0)
                    {
                        if (area_group_array[n, m] != area_group_array[i, m])
                        {
                            g.DrawLine(thick_pen, cell_vertex[n, m].X - left_extend_thick_pen, cell_vertex[n, m].Y, cell_vertex[n, m + 1].X + right_extend_thick_pen, cell_vertex[n, m + 1].Y);
                        }
                    }
                    else//가장 왼쪽 테두리를 그리는 경우
                    {
                        if (area_group_array[n, m] == -1)
                            continue;
                        g.DrawLine(thick_pen, cell_vertex[n, m].X - left_extend_thick_pen, cell_vertex[n, m].Y, cell_vertex[n, m + 1].X + right_extend_thick_pen, cell_vertex[n, m + 1].Y);
                    }
                }
            }

            //격자의 진한 세로선 그리기
            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m <= grid_size; m++)
                {
                    int i = m - 1;
                    if (m == grid_size)//가장 아래 테두리를 그리는 경우
                    {
                        if (area_group_array[n, i] == -1)
                            continue;
                        g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                    }
                    else if (i >= 0)
                    {
                        if (area_group_array[n, m] != area_group_array[n, i])
                        {
                            g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                        }
                    }
                    else//가장 위 테두리를 그리는 경우
                    {
                        if (area_group_array[n, m] == -1)
                            continue;
                        g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                    }
                }
            }

            return input_box_pos;
        }
    }
}
