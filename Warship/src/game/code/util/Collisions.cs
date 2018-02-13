using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
    public class Collisions
    {
        public static bool CheckCollisions(Dimension d1, Dimension d2)
        {
            bool result = false;

            if(d2.X >= d1.X - 5 && 
                d2.X + d2.Width - 10 <= d1.X + d1.Width && 
                d1.Y <= d2.Y + 5 && 
                d2.Y + d2.Height - 5 <= d1.Y + d1.Height)
            {
                result = true;
            }

            return result;
        }

		public static bool Contains(System.Drawing.Point p, Dimension d)
        {
            bool result = false;

            if(p.X >= d.X && p.X <= d.X + d.Width &&
               p.Y >= d.Y && p.Y <= d.Y + d.Height)
            {
                result = true;
            }

            return result;
        }
    }
}