using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	enum ShipType
	{
		VERTICAL,
		HORIZONTAL
	}

	static class FabricShips
	{
		public static Ship GetShip(int size, ShipType type, int shiftX, int shiftY)
		{
			List<Cell> cells = new List<Cell>(size);

			switch(type)
			{
				case ShipType.HORIZONTAL:
				{
					for (int i = 0; i < size; i++)
					{
						cells.Add(new Cell(i + shiftX, shiftY, TypeSurface.SHIP));
					}
				}
				break;
				case ShipType.VERTICAL:
				{
					for (int i = 0; i < size; i++)
					{
						cells.Add(new Cell(shiftX, i + shiftY, TypeSurface.SHIP));
					}
				}
				break;
			}

			return new Ship(cells);

		}
	}
}
