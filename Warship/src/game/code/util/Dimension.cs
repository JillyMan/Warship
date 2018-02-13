using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
    public class Dimension 
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public Dimension(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public Dimension(Dimension dimension)
        {
            this.X = dimension.X;
            this.Y = dimension.Y;
            this.Width = dimension.Width;
            this.Height = dimension.Height;
        }

        public static void Swap(Dimension d1, Dimension d2)
        {
            Dimension temp = new Dimension(d2);
            d2 = new Dimension(d1);
            d1 = new Dimension(temp);
        }

        public static void Swap(ref int p1, ref int p2)
        {
            int temp = p1;
            p1 = p2;
            p2 = temp;
        }

		public static Dimension operator << (Dimension d1, int shift)
		{
			Dimension result = new Dimension(d1);
			result.X -= shift;
			result.Y -= shift;
			return result;
		}

		public static Dimension operator >> (Dimension d1, int shift)
		{
			Dimension result = new Dimension(d1);
			result.X += shift;
			result.Y += shift;
			return result;
		}
	}
}
