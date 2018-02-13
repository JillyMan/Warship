using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	public class Ship
	{
	    private bool alive = true;
		public List<Cell> Cells { get; private set; }
		public int Size { get { return Cells.Count; }}

		public bool Alive
		{
			get
			{
				if (alive) 
				{
					alive = CheckAlive();
				}
				return alive;
			}
		}

		public Ship(List<Cell> cells)
		{
			Cells = new List<Cell>();
			foreach(Cell cell in cells)
			{
				this.AddCell(cell);
			}
		}
		
		public bool Conteins(Cell cell)
		{
			bool result = false;
			for(int i = 0; i < Size; ++i)
			{
				if(cell == Cells[i])
				{
					result = true;
					break;
				}
			}

			return result;
		}

		public TypeShot TakeAHit(int TestX, int TestY)
		{
			TypeShot typeShot = TypeShot.MISS;

			foreach (Cell cell in Cells)
			{
				if (cell.X == TestX && cell.Y == TestY && !cell.Visit)
				{
					cell.Type = TypeSurface.WOUNDSHIP;
					cell.Visit = true;
					typeShot = TypeShot.WOUND;
				}
			}

			if (!this.Alive && typeShot == TypeShot.WOUND)
			{
				typeShot = TypeShot.KILL;
			}

			return typeShot;
		}

		private void AddCell(Cell cell)
		{
			this.Cells.Add((Cell)cell.Clone());
		}

		private bool CheckAlive()
		{
			foreach(Cell c in Cells) 
			{
				if(!c.Visit)
				{
					return true;
				}
			}
			return false;
		}
	}
}
