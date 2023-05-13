namespace drawing_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[,] area_group_array ={
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
            draw_grid.DrawBoard(100, new Point(10, 10), area_group_array, 9,this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] area_group_array ={
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
            draw_grid.DrawBoard(50, new Point(50, 50), area_group_array, 9, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,] area_group_array ={
                    { 0, 0, 0, 0, 1, 2, 2, 2, 2 },
                    { 0, 0, 1, 1, 1, 1, 1, 2, 2 },
                    { 0, 0, 3, 1, 1, 1, 2, 2, 2 },
                    { 3, 0, 3, 4, 4, 5, 5, 5, 5 },
                    { 3, 3, 3, 4, 4, 4, 4, 5, 5 },
                    { 3, 3, 3, 4, 4, 4, 5, 5, 8 },
                    { 6, 7, 7, 7, 7, 7, 8, 5, 8 },
                    { 6, 6, 6, 6, 6, 7, 8, 8, 8 },
                    { 6, 6, 6, 7, 7, 7, 8, 8, 8 }
                    };
            draw_grid.DrawBoard(50, new Point(50, 50), area_group_array, 9, this);
        }
    }
}