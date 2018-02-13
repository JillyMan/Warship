using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	public class BattleField
	{
		private Cell[,] Field;
		public readonly int Width;
		public readonly int Height;

        public Cell this[int i, int j]
        {
            get { return Field[i, j]; }
        }

        public BattleField()
        {
			this.Width = this.Height = 10;
            this.Field = new Cell[Height, Width];
			for(int i = 0; i < Height; ++i)
			{
				for(int j = 0; j < Width; ++j)
				{
					Field[i, j] = new Cell(j, i);
				}
			}
        }

		public void Hit(int TestX, int TestY, TypeSurface type)
		{
			if(Field[TestY, TestX].Type == TypeSurface.WATER)
			{
				Field[TestY, TestX].Type = type;
			}
		}

		public bool PushShip(Ship ship)
		{
			bool result = AssistantInPosition(ship);

			if (result)
			{	
				foreach (Cell cell in ship.Cells)
				{
					Field[cell.Y, cell.X] = cell;
				}
			}

			return result;
        }

		private List<Cell> FindAdjency(Ship ship)
		{
			List<Cell> cells = new List<Cell>();

			foreach (Cell cell in ship.Cells)
			{
				for (int i = 0; i < 8; ++i)
				{
					Cell helpCell = new Cell(cell.X + CoordinatesShift.dX[i], cell.Y + CoordinatesShift.dY[i]);
					if (helpCell.InRectangle(0, 0, Width, Height))
					{
						Cell newCell = Field[helpCell.Y, helpCell.X];

						if(!cells.Contains(newCell))
						{
							cells.Add(newCell);
						}
					}
				}
			}

			return cells;
		}

		private bool AssistantInPosition(Ship ship)
		{
			bool result = true;

			List<Cell> cells = FindAdjency(ship);

			foreach (Cell cell in cells)
			{
				if(cell.Type == TypeSurface.SHIP)
				{
					result = false;
					break;
				}
			}

			return result;
		}

		public void FillAround(Ship ship)
		{
			List<Cell> cells = FindAdjency(ship);

			foreach(Cell cell in cells)
			{
				if(!ship.Conteins(cell))
				{
					Hit(cell.X, cell.Y, TypeSurface.HIT);
				}
			}
		}
    }
}
