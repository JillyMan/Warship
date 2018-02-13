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
		public static Ship GetShip(int size, ShipType type, int offsetX, int offsetY)
		{
			List<Cell> cells = new List<Cell>(size);

			switch(type)
			{
				case ShipType.HORIZONTAL:
				{
					for (int i = 0; i < size; i++)
					{
						cells.Add(new Cell(i + offsetX, offsetY, TypeSurface.SHIP));
					}
				}
				break;
				case ShipType.VERTICAL:
				{
					for (int i = 0; i < size; i++)
					{
						cells.Add(new Cell(offsetX, i + offsetY, TypeSurface.SHIP));
					}
				}
				break;
			}

			return new Ship(cells);

		}
	}
}
