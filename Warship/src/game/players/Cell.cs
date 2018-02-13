using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	public enum TypeSurface
	{
		WATER,
		SHIP,
		HIT,
		WOUNDSHIP
	}


	public class Cell : ICloneable
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		public bool Visit { get; set; }
		public TypeSurface Type { get;  set; }

		public Cell(int x, int y, TypeSurface type = TypeSurface.WATER)
		{
			this.X = x;
			this.Y = y;
			this.Type = type;
			this.Visit = false;
		}
		
		public bool InRectangle(int x, int y, int weight, int height)
		{
			bool result = false;
			if (X >= x && Y >= y && this.X < weight && this.Y < height)
			{
				result = true;
			}

			return result;
		}

		public object Clone()
		{
			return new Cell(this.X, this.Y, this.Type);
		}

		public static bool operator != (Cell c1, Cell c2)
		{
			bool result = !(c1 == c2);
			return result;
		}

		public static bool operator == (Cell c1, Cell c2)
		{
			bool result = false;
			if(c1.X == c2.X && c1.Y == c2.Y && c1.Type == c2.Type)
			{
				result = true;
			}
			return result;
		}

	}
}
