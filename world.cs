using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLiam
{
    class world
    {
        private Dictionary<int, field> fields = new Dictionary<int, field>();

        public world(int x, int y)
        {
            int[] border_x = new int[4*4];
            //calculate a'*b' and subtract from a*b
            int a = x;
            int b = y;

            int borders = 0;
            if (a <= 2 || b <= 2) { borders = a * b; } //There can't be any surface that isn't a border
            else
            {
                b-=2; //upper and bottom line subtracted
                a-=2; //left and right line subtracted
                borders = x * y - a * b;
            }
            //Populate the dictionary with all fields + index
            for (int index = 0; index < (x * y); index++)
            {
                field f = new field();
                f.Id = index;
                fields.Add(f.Id, f);
            }
            //Mark all borders (script is hard as hell, it is 3:05am)
            int border_index = 0;
            for (int _y = 0; _y < y; _y++)
            {
                for (int _x = 0; _x < x; _x++)
                {
                    //MessageBox.Show("X = "+_x+" und Y: "+_y);
                    if (_x == 0) { /*MessageBox.Show("Border!");*/ fields[border_index].Border_Ver = true; }
                    else if (_x == x-1) { /*MessageBox.Show("Border!");*/ fields[border_index].Border_Ver = true; }
                    if (_y == 0) { /*MessageBox.Show("Border!");*/ fields[border_index].Border_Hor = true; }
                    else if (_y == y - 1) { /*MessageBox.Show("Border!");*/ fields[border_index].Border_Hor = true; }
                    border_index++;
                }
            }
            //Loop through every field and add fields
            for (int i = 0; i < x*y; i++)
            {
                if (fields[i].Border_Hor && fields[i].Border_Ver)
                {
                    //check which of the four borders it is
                    if (i == 0) { fields[i].Right = fields[i + 1]; fields[i].Bottom = fields[i + x]; }     //upper left. No field above, none to the left
                    else if (i == x-1) { fields[i].Left = fields[i - 1]; fields[i].Bottom = fields[i + x]; }     //upper right. No field above, none to the right
                    else if (i == (x * y)-1) { fields[i].Left = fields[i + 1]; fields[i].Top = fields[i - x]; }     //bottom right. No field below, none to the right
                    else if (i == x * y - x) { fields[i].Right = fields[i + 1]; fields[i].Top = fields[i - x]; }   //bottom left. No field below, none to the left
                }
                else if (fields[i].Border_Hor)
                {
                    //check if bottom border or top border
                    if (i < x) { fields[i].Right = fields[i + 1]; fields[i].Bottom = fields[i + x]; fields[i].Left = fields[i - 1]; } //the first row. No field above
                    else if (i > x * y - x) { fields[i].Right = fields[i + 1]; fields[i].Top = fields[i - x]; fields[i].Left = fields[i - 1]; } //the last row. No field below
                }
                else if (fields[i].Border_Ver)
                {
                    //check if...you know
                    if (i % x == 0) { fields[i].Right = fields[i + 1]; fields[i].Bottom = fields[i + x]; fields[i].Top = fields[i - x]; } //left border. No field to the left.
                    else if (i % x == (x - 1)) { fields[i].Left = fields[i - 1]; fields[i].Bottom = fields[i + x]; fields[i].Top = fields[i - x]; } //right border. No field to the right.
                }
                else
                {
                    //damn normal field, set all four fields
                    fields[i].Right = fields[i + 1];
                    fields[i].Left = fields[i - 1]; 
                    fields[i].Bottom = fields[i + x]; 
                    fields[i].Top = fields[i - x];
                }
            }
        }
        public Dictionary<int, field> Fields
        {
            get { return fields; }
        }
    }
}
