#define GAME_DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Warship
{
	public class Bot : Player
	{
		private Random r;

		public Bot(string name, int[] LenShip) : base(name)
		{
			r = new Random();
			CreateShip(LenShip);
		}

		protected override void Draw(Graphics g, Rectangle rect, int i, int j)
		{
			if (Field[i, j].Type == TypeSurface.HIT)
			{
				g.FillRectangle(Brushes.Yellow, rect);
			}
			//else if (Field[i, j].Type == TypeSurface.SHIP)
			//{
			//	g.FillRectangle(Brushes.LightGray, rect);
			//}
			else if(Field[i, j].Type == TypeSurface.WOUNDSHIP)
			{
				g.FillRectangle(Brushes.Red, rect);
			}
			else
			{
				g.FillRectangle(Brushes.FloralWhite, rect);
			}
		}

		private void CreateShip(int[] len)
		{
			Random r = new Random();
			int countShip = len.Length;
			int countCreate = 0;

			while (countCreate < countShip)
			{
				int x = r.Next(10);
				int y = r.Next(10);
				ShipType pos = (r.Next(2) == 1) ? ShipType.HORIZONTAL : ShipType.VERTICAL;

				Ship ship = FabricShips.GetShip(len[countCreate], pos, x, y);

				if(x + ship.Size < Field.Width && y + ship.Size < Field.Height)
				{
					bool result = PushShip(ship);

					if(result)
					{
						++countCreate;
					}
				}
			}
		}
	}
}
