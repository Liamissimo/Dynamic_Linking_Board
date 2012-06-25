using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLiam
{
    public partial class Form1 : Form
    {
        static int x = 10;
        static int y = 10;
        static world w = new world(x, y);
        static Dictionary<int, field> dict = w.Fields;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x_offset = 0;
            int y_offset = 0;          
            System.Drawing.SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Graphics graphics = this.CreateGraphics();
            numericUpDown1.Maximum = x * y;
            numericUpDown1.Minimum = 0;
            for (int i = 0; i != dict.Count; i++)
            {
                field f = dict[i];
                if (i % x == 0 && i != 0)
                {
                    y_offset += 10;
                    x_offset = 0;
                }
                //if (f.Border_Ver && f.Border_Hor) {brush.Color = System.Drawing.Color.Blue;graphics.FillRectangle(brush, new Rectangle(x_offset, y_offset, 10, 10));}
                //else if (f.Border_Hor) { brush.Color = System.Drawing.Color.Blue; graphics.FillRectangle(brush, new Rectangle(x_offset, y_offset, 10, 10)); }
                //else if (f.Border_Ver) { brush.Color = System.Drawing.Color.Blue; graphics.FillRectangle(brush, new Rectangle(x_offset, y_offset, 10, 10)); }
                //else { brush.Color = System.Drawing.Color.Red; graphics.FillRectangle(brush, new Rectangle(x_offset, y_offset, 10, 10)); }
                if (f.Border_Ver && f.Border_Hor) { brush.Color = System.Drawing.Color.Blue; System.Drawing.Pen pen = new Pen(brush); graphics.DrawRectangle(pen, new Rectangle(x_offset, y_offset, 10, 10)); }
                else if (f.Border_Hor) { brush.Color = System.Drawing.Color.Blue; System.Drawing.Pen pen = new Pen(brush); graphics.DrawRectangle(pen, new Rectangle(x_offset, y_offset, 10, 10)); }
                else if (f.Border_Ver) { brush.Color = System.Drawing.Color.Blue; System.Drawing.Pen pen = new Pen(brush); graphics.DrawRectangle(pen, new Rectangle(x_offset, y_offset, 10, 10)); }
                else { brush.Color = System.Drawing.Color.Red; System.Drawing.Pen pen = new Pen(brush); graphics.DrawRectangle(pen, new Rectangle(x_offset, y_offset, 10, 10)); }
                x_offset += 10;
                
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int[] ids = new int[4];
            if (dict[(int)numericUpDown1.Value].Top != null) { ids[0] = dict[(int)numericUpDown1.Value].Top.Id; }
            if (dict[(int)numericUpDown1.Value].Right != null) { ids[1] = dict[(int)numericUpDown1.Value].Right.Id; }
            if (dict[(int)numericUpDown1.Value].Bottom != null) { ids[2] = dict[(int)numericUpDown1.Value].Bottom.Id; }
            if (dict[(int)numericUpDown1.Value].Left != null) { ids[3] = dict[(int)numericUpDown1.Value].Left.Id; }

            label1.Text = "Aktuelle ID ist die "+numericUpDown1.Value.ToString()+"\nOben ist die " + ids[0] + "\nRechts ist die " + ids[1] + "\nUnten ist die " + ids[2] + "\nLinks ist die " + ids[3];
        }

    }
}
