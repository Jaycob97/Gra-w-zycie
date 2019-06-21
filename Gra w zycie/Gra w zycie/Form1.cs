using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        bool draw = false;
        bool go = false;
        Grid board;
        int heightSpace = 0;
        int widthSpace = 0;
        int sizeOfSquare = 0;
        int speed = 501;
        private static System.Timers.Timer tt;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
            this.Text = "Gra w życie";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Size = new Size(1460, 825);
            sizeOfSquare = pictureBox1.Height / 10;
            if ((pictureBox1.Width / 10) < sizeOfSquare)
            {
                sizeOfSquare = pictureBox1.Width / 10;
            }
            heightSpace = (pictureBox1.Height - sizeOfSquare * 10) / 2;
            widthSpace = (pictureBox1.Width - sizeOfSquare * 10) / 2;
            board = new Grid(10, 10);
            draw = true;
            pictureBox1.Invalidate();
            tt = new System.Timers.Timer();
            tt.Interval = speed;
            tt.Elapsed += OnTimedEvent;
            tt.AutoReset = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           if(draw)
            {
                SolidBrush redBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
                SolidBrush greenBrush = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
                Pen blackPen = new Pen(Color.Black);
                blackPen.Width = 1;
                    for(int i = 0; i < board.gridHeight; i++)
                    {
                        for (int j = 0; j < board.gridWidth; j++)
                        {
                            if(board.grid[j,i].value)
                            {
                                e.Graphics.FillRectangle(greenBrush, (j * sizeOfSquare + widthSpace), (i * sizeOfSquare + heightSpace), sizeOfSquare, sizeOfSquare);
                            }
                            else
                            {
                                e.Graphics.FillRectangle(redBrush, (j * sizeOfSquare + widthSpace), (i * sizeOfSquare + heightSpace), sizeOfSquare, sizeOfSquare);
                            }
                        }
                    }
                    for (int i = 0; i <= board.gridHeight; i++)
                    {
                        e.Graphics.DrawLine(blackPen, widthSpace, (i * sizeOfSquare + heightSpace), (sizeOfSquare * board.gridWidth + widthSpace), (i * sizeOfSquare + heightSpace));
                    }
                    for (int i = 0; i <= board.gridWidth; i++)
                    {
                        e.Graphics.DrawLine(blackPen, (i * sizeOfSquare + widthSpace), heightSpace, (i * sizeOfSquare + widthSpace), (sizeOfSquare * board.gridHeight + heightSpace));
                    }
                if(go)
                {
                    board.checkGrid();
                }
            }
            go = false;
            draw = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tt.Enabled = true; 
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            draw = true;
            go = true;
            BeginInvoke(new Action(() =>
                {
                    pictureBox1.Invalidate();
                }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tt.Enabled = false;
            go = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool ok = true;
            int gridWidth = 0;
            int gridHeight = 0;
            try
            {
                gridWidth = int.Parse(textBox2.Text);
                gridHeight = int.Parse(textBox1.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                ok = false;
            }
            if (ok)
            {
                board = new Grid(gridWidth, gridHeight);
                int x = gridHeight / 2;
                int y = gridWidth / 2;
                board.grid[y,x-1].value = true;
                board.grid[y,x].value = true;
                board.grid[y,x+1].value = true;
                sizeOfSquare = pictureBox1.Height / board.gridHeight;
                if ((pictureBox1.Width / board.gridWidth) < sizeOfSquare)
                {
                    sizeOfSquare = pictureBox1.Width / board.gridWidth;
                }
                heightSpace = (pictureBox1.Height - sizeOfSquare * board.gridHeight) / 2;
                widthSpace = (pictureBox1.Width - sizeOfSquare * board.gridWidth) / 2;
                draw = true;
                pictureBox1.Invalidate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool ok = true;
            int gridWidth = 0;
            int gridHeight = 0;
            try
            {
                gridWidth = int.Parse(textBox2.Text);
                gridHeight = int.Parse(textBox1.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                ok = false;
            }
            if (ok)
            {
                board = new Grid(gridWidth, gridHeight);
                int x = gridHeight / 2;
                int y = gridWidth / 2;
                board.grid[y-1, x].value = true;
                board.grid[y+2, x].value = true;
                board.grid[y, x+1].value = true;
                board.grid[y + 1, x + 1].value = true;
                board.grid[y, x-1].value = true;
                board.grid[y + 1, x - 1].value = true;
                sizeOfSquare = pictureBox1.Height / board.gridHeight;
                if ((pictureBox1.Width / board.gridWidth) < sizeOfSquare)
                {
                    sizeOfSquare = pictureBox1.Width / board.gridWidth;
                }
                heightSpace = (pictureBox1.Height - sizeOfSquare * board.gridHeight) / 2;
                widthSpace = (pictureBox1.Width - sizeOfSquare * board.gridWidth) / 2;
                draw = true;
                pictureBox1.Invalidate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool ok = true;
            int gridWidth = 0;
            int gridHeight = 0;
            try
            {
                gridWidth = int.Parse(textBox2.Text);
                gridHeight = int.Parse(textBox1.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                ok = false;
            }
            if (ok)
            {
                board = new Grid(gridWidth, gridHeight);
                int x = gridHeight / 2;
                int y = gridWidth / 2;
                board.grid[y, x].value = true;
                board.grid[y-1, x].value = true;
                board.grid[y + 1, x + 1].value = true;
                board.grid[y + 1, x - 1].value = true;
                board.grid[y, x-1].value = true;
                sizeOfSquare = pictureBox1.Height / board.gridHeight;
                if ((pictureBox1.Width / board.gridWidth) < sizeOfSquare)
                {
                    sizeOfSquare = pictureBox1.Width / board.gridWidth;
                }
                heightSpace = (pictureBox1.Height - sizeOfSquare * board.gridHeight) / 2;
                widthSpace = (pictureBox1.Width - sizeOfSquare * board.gridWidth) / 2;
                draw = true;
                pictureBox1.Invalidate();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool ok = true;
            int gridWidth = 0;
            int gridHeight = 0;
            try
            {
                gridWidth = int.Parse(textBox2.Text);
                gridHeight = int.Parse(textBox1.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                ok = false;
            }
            if (ok)
            {
                board = new Grid(gridWidth, gridHeight);
                Random rand = new Random();
                for (int i = 0; i <gridHeight; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        int t = rand.Next(2);
                        if(t==1)
                        {
                            board.grid[j, i].value = true;
                        }
                    }
                }
                sizeOfSquare = pictureBox1.Height / board.gridHeight;
                if ((pictureBox1.Width / board.gridWidth) < sizeOfSquare)
                {
                    sizeOfSquare = pictureBox1.Width / board.gridWidth;
                }
                heightSpace = (pictureBox1.Height - sizeOfSquare * board.gridHeight) / 2;
                widthSpace = (pictureBox1.Width - sizeOfSquare * board.gridWidth) / 2;
                draw = true;
                pictureBox1.Invalidate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool ok = true;
            int gridWidth = 0;
            int gridHeight = 0;
            try
            {
                gridWidth = int.Parse(textBox2.Text);
                gridHeight = int.Parse(textBox1.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                ok = false;
            }
            if (ok)
            {
                board = new Grid(gridWidth, gridHeight);
                sizeOfSquare = pictureBox1.Height / board.gridHeight;
                if ((pictureBox1.Width / board.gridWidth) < sizeOfSquare)
                {
                    sizeOfSquare = pictureBox1.Width / board.gridWidth;
                }
                heightSpace = (pictureBox1.Height - sizeOfSquare * board.gridHeight) / 2;
                widthSpace = (pictureBox1.Width - sizeOfSquare * board.gridWidth) / 2;
                draw = true;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point position = me.Location;
            if((position.X>widthSpace) & (position.X < (pictureBox1.Width - widthSpace)) & (position.Y > heightSpace) & (position.Y < (pictureBox1.Height - heightSpace)) )
            {
                int x = (position.X - widthSpace) / sizeOfSquare;
                int y = (position.Y - heightSpace) / sizeOfSquare;
                board.grid[x, y].value = !board.grid[x, y].value;
                draw = true;
                pictureBox1.Invalidate();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(speed  > 1)
            {
                speed -= 50;
                tt.Interval = speed;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (speed < 1001)
            {
                speed += 50;
                tt.Interval = speed;
            }
        }
    }  
}
