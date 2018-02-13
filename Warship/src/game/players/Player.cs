using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Warship
{
	public enum TypeShot
	{
		MISS,
		WOUND, 
		KILL
	}

    public class Player
    {
		public BattleField Field { get; }
		public PlayerInfo InfoPlayer;
		public List<Ship> ships;

		public Player(string name)
		{
			this.Field = new BattleField();
			this.ships = new List<Ship>();
			this.InfoPlayer = new PlayerInfo(name);
		}

		public TypeShot TakeABlow(int TestX, int TestY)
		{
			TypeShot type = TypeShot.MISS;

			foreach (Ship ship in ships)
			{
				type = ship.TakeAHit(TestX, TestY);
				Field.PushShip(ship);

				if (type == TypeShot.KILL) 
				{
					Field.FillAround(ship);
					ships.Remove(ship);
					break;
				}
				else if(type == TypeShot.WOUND)
				{
					break;
				}
			}

			if (type == TypeShot.MISS)
			{
				Field.Hit(TestX, TestY, TypeSurface.HIT);
			}

			return type;
		}

		public bool PushShip(Ship ship)
		{
			for(int i = 0; i < ships.Count; ++i)
			{
				foreach(Cell cell in ship.Cells)
				{
					if(ships[i].Conteins(cell))
					{
						return false;
					}
				}
			}

			bool result = Field.PushShip(ship);
			if (result) 
			{
				ships.Add(ship);
			}
			return result;
		}

		protected virtual void Draw(Graphics g, Rectangle rect, int i, int j)
		{
			if (Field[i, j].Type == TypeSurface.WATER)
			{
				g.FillRectangle(Brushes.FloralWhite, rect);
			}
			else if (Field[i, j].Type == TypeSurface.SHIP)
			{
				g.FillRectangle(Brushes.Green, rect);
			}
			else if (Field[i, j].Type == TypeSurface.WOUNDSHIP)
			{
				g.FillRectangle(Brushes.Red, rect);
			}
			else
			{
				g.FillRectangle(Brushes.Yellow, rect);
			}
		}

		public void Render(Graphics g, RenderInfo renderInfo)
        {
            Rectangle rect = new Rectangle(renderInfo.MapDimension.X, renderInfo.MapDimension.Y, 
				renderInfo.SizeTileToPixel - 1, renderInfo.SizeTileToPixel - 1);

			g.DrawString(InfoPlayer.Name, renderInfo.Font, Brushes.White, 
				new Point(renderInfo.MapDimension.X, renderInfo.MapDimension.Y - renderInfo.SizeTileToPixel - 20));

            for (int i = 0; i < Field.Height; ++i)
            {
				string num = ((char)('0' + i)).ToString();
				string sim = ((char)('A' + i)).ToString();

				g.DrawString(sim, renderInfo.Font, Brushes.White,
					new Point(renderInfo.MapDimension.X + (Field.Height*(i + i) + i), renderInfo.MapDimension.Y - renderInfo.SizeTileToPixel));
				g.DrawString(num, renderInfo.Font, Brushes.White,
					new Point(renderInfo.MapDimension.X - 20, rect.Y));

				for (int j = 0; j < Field.Width; ++j)
                {
					Draw(g, rect, i, j);
                    rect.X += renderInfo.SizeTileToPixel;
                }

				rect.Y += renderInfo.SizeTileToPixel;
                rect.X = renderInfo.MapDimension.X;
			}
		}
    }
}