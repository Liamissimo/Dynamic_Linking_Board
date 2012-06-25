using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLiam
{
    class field
    {
        
        private field top = null;
        private field right_top = null;
        private field right = null;
        private field right_bottom = null;
        private field bottom = null;
        private field left_bottom = null;
        private field left = null;
        private field left_top = null;

        private bool living = false;
        private bool border_hor = false;
        private bool border_ver = false;
        private int id = -1;

        public bool Living
        {
            get { return living; }
        }
        public bool Border_Hor
        {
            get { return border_hor; }
            set { border_hor = value; }
        }
        public bool Border_Ver
        {
            get { return border_ver; }
            set { border_ver = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public void Birth()
        {
            living = true;
        }
        public void Kill()
        {
            living = false;
        }
        public field Top
        {
            get { return top; }
            set { top = value; }
        }
        public field Right_Top
        {
            get { return right_top; }
            set { right_top = value; }
        }
        public field Right
        {
            get { return right; }
            set { right = value; }
        }
        public field Right_Bottom
        {
            get { return right_bottom; }
            set { right_bottom = value; }
        }
        public field Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }
        public field Left_Bottom
        {
            get { return left_bottom; }
            set { left_bottom = value; }
        }
        public field Left
        {
            get { return left; }
            set { left = value; }
        }
        public field Left_Top
        {
            get { return left_top; }
            set { left_top = value; }
        }
    }
}
