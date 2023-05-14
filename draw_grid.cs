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
        public static void DrawBoard(int cell_edge_len, Point location, int[,] area_group_array, int grid_size, Form form)
        {
            Graphics g = form.CreateGraphics();

            Pen slim_pen = new Pen(Color.DarkGray, 2);
            Pen thick_pen = new Pen(Color.Black, 2);

            Point[,] cell_vertex = new Point[grid_size + 1, grid_size + 1];

            //cell_vertex 채우기
            for(int n = 0; n <= grid_size; n++)
            {
                for(int m = 0; m<= grid_size; m++)
                {
                    cell_vertex[n, m] = new Point(location.X + m * cell_edge_len, location.Y + n * cell_edge_len);
                }
            }

            //폼 전체 지우기
            g.Clear(form.BackColor);

            //격자의 가로선 그리기
            for (int n = 0; n <= grid_size; n++)
            {
                for (int m = 0; m < grid_size; m++)
                {
                    int i = n - 1;
                    if (n == grid_size)//가장 왼쪽 테두리를 그리는 경우
                    {
                        g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n, m + 1]);
                    }
                    else if (i >= 0)
                    {
                        if (area_group_array[n, m] == area_group_array[i, m])
                        {
                            g.DrawLine(slim_pen, cell_vertex[n, m], cell_vertex[n, m + 1]);
                        }
                        else
                        {
                            g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n, m + 1]);
                        }
                    }
                    else//가장 오른쪽 테두리를 그리는 경우
                    {
                        g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n, m + 1]);
                    }
                }
            }

            //격자의 세로선 그리기
            for (int n = 0; n < grid_size; n++)
            {
                for (int m = 0; m <= grid_size; m++)
                {
                    int i = m - 1;
                    if(m== grid_size)//가장 아래 테두리를 그리는 경우
                    {
                        g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                    }
                    else if (i >= 0)
                    {
                        if (area_group_array[n, m] == area_group_array[n, i])
                        {
                            g.DrawLine(slim_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                        }
                        else
                        {
                            g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                        }
                    }
                    else
                    {
                        g.DrawLine(thick_pen, cell_vertex[n, m], cell_vertex[n + 1, m]);
                    }
                }
            }
        }
    }
}
