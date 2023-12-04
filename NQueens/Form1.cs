namespace NQueens
{
    public partial class Form1 : Form
    {
        ChessZone[,] board;
        int queens = 0;
        int queensPlaced = 0;
        public Form1()
        {
            InitializeComponent();
            queens = Convert.ToInt32(numericUpDown_queen.Value);
        }

        private void button_loadBoard_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            board = new ChessZone[queens, queens];
            for (int i = 0; i < queens; i++)
            {
                for (int j = 0; j < queens; j++)
                {
                    board[i, j] = new ChessZone();
                    board[i, j].rows = i;
                    board[i, j].columns = j;
                    board[i, j].zone.Size = new Size(30, 30);
                    board[i, j].zone.Location = new Point(3 + (i * 30), 3 + (j *30));
                    board[i, j].zone.FlatStyle = FlatStyle.Flat;
                    board[i, j].zone.Text = "";
                    board[i, j].zone.BackColor = Color.White;
                    board[i, j].zone.Click += OneChessZoneClick;
                    this.panel1.Controls.Add(board[i, j].zone);
                }
            }
        }

        private void OneChessZoneClick(object? sender, EventArgs e)
        {
            Button? button = sender as Button;
            if (button.BackColor == Color.Green)
            {
                button.BackColor = Color.White;
                queensPlaced--;
                BoardAutoFixing();
            }
            else if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Green;
                queensPlaced++;
                BoardAutoFixing();
            }

        }

        private void ClearRed()
        {
            for (int i = 0; i < queens; i++)
            {
                for (int j = 0; j < queens; j++)
                {
                    if ((board[i, j].zone.BackColor == Color.Red))
                    {
                        board[i, j].zone.BackColor = Color.White;
                        board[i, j].zone.Enabled = true;
                    }
                }
            }
        }
        private void BoardAutoFixing()
        {
            ClearRed();
            for (int i = 0; i < queens; i++)
            {
                for (int j = 0; j < queens; j++)
                {
                    if ((board[i, j].zone.BackColor == Color.Green))
                    {
                        QueenKill(board[i, j]);
                    }
                }
            }
        }
        private void QueenKill(ChessZone zone)
        {
            //kill column
            for (int a = 0; a < queens; a++)
            {
                if (board[a, zone.columns].zone.BackColor == Color.White)
                {
                    board[a, zone.columns].zone.BackColor = Color.Red;
                    board[a, zone.columns].zone.Enabled = false;
                }
            }

            //kill row

            for (int b = 0; b < queens; b++)
            {
                if (board[zone.rows, b].zone.BackColor == Color.White)
                {
                    board[zone.rows, b].zone.BackColor = Color.Red;
                    board[zone.rows, b].zone.Enabled = false;
                }
            }

            //kill cross

            for (int a = zone.rows, b = zone.columns; a >= 0 && a < queens && b >= 0 && b < queens; a++, b++)
            {

                if (board[a, b].zone.BackColor == Color.White)
                {
                    board[a, b].zone.BackColor = Color.Red;
                    board[a, b].zone.Enabled = false;
                }
            }

            for (int a = zone.rows, b = zone.columns; a >= 0 && a < queens && b >= 0 && b < queens; a--, b++)
            {

                if (board[a, b].zone.BackColor == Color.White)
                {
                    board[a, b].zone.BackColor = Color.Red;
                    board[a, b].zone.Enabled = false;
                }
            }
            for (int a = zone.rows, b = zone.columns; a >= 0 && a < queens && b >= 0 && b < queens; a++, b--)
            {

                if (board[a, b].zone.BackColor == Color.White)
                {
                    board[a, b].zone.BackColor = Color.Red;
                    board[a, b].zone.Enabled = false;
                }
            }
            for (int a = zone.rows, b = zone.columns; a >= 0 && a < queens && b >= 0 && b < queens; a--, b--)
            {

                if (board[a, b].zone.BackColor == Color.White)
                {
                    board[a, b].zone.BackColor = Color.Red;
                    board[a, b].zone.Enabled = false;
                }
            }
        }

        private void numericUpDown_queen_ValueChanged(object sender, EventArgs e)
        {
            queens = Convert.ToInt32(numericUpDown_queen.Value);
        }

        private void button_validate_Click(object sender, EventArgs e)
        {
            if (queens == queensPlaced)
            {
                MessageBox.Show("Problem solved");
            }
            else
            {
                MessageBox.Show("Problem unsolved");
            }
        }
    }
}