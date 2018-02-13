#define GAME_DEBUG

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Warship
{
	public class BeginGame : IState
	{
		private Game game;
		private Ship ship;
		private Rectangle rect;
		private ShipType shipType;

		private Dimension NewDimension;
		private Dimension StartDimension;
		
		private int px;
		private int py;
		private int[] LenghtShips;
		private int currentPointer;
		private bool dragging = false;

		public BeginGame(Game game, int[] len)
		{
			this.game = game;
			this.LenghtShips = len;
			this.currentPointer = 0;
			ResizeShip();
		}

		public void OnEvent(Event e)
		{
			if (e is MouseMotionEvent)
			{
				OnMoved((MouseMotionEvent)e);
			}

			if (e is MousePressedEvent)
			{
				OnPressed((MousePressedEvent)e);
			}

			if (e is MouseReleasedEvent)
			{
				OnReleased((MouseReleasedEvent)e);
			}
		}

		public void OnReleased(MouseReleasedEvent e)
		{
			dragging = false;

			if (Collisions.CheckCollisions(game.RPlayer.MapDimension, NewDimension))
			{
				int TestX = NewDimension.X;
				int TestY = NewDimension.Y;
				RenderInfo.CalculateCoord(ref TestX, ref TestY, game.RPlayer);

				ship = FabricShips.GetShip(LenghtShips[currentPointer], shipType, TestX, TestY);

				bool NextShip = game.Player.PushShip(ship);
				if (NextShip)
				{
					++currentPointer;
					if (currentPointer > 9)
					{
						NextState(game.WarState);
					}
					else
					{
						ResizeShip();
					}
				}
			}
			else
			{
				RelocationShip();
			}
		}

		public void OnPressed(MousePressedEvent e)
		{
			if (e.Buttons == System.Windows.Forms.MouseButtons.Right)
			{
				shipType = (shipType == ShipType.HORIZONTAL) ? ShipType.VERTICAL : ShipType.HORIZONTAL;
				Dimension.Swap(ref NewDimension.Width, ref NewDimension.Height);
				Dimension.Swap(ref StartDimension.Width, ref StartDimension.Height);
			}

			dragging = Collisions.Contains(new Point(e.X, e.Y), NewDimension);
		}

		private void ResizeShip()
		{
			int NewSize = LenghtShips[currentPointer];
			NewDimension = new Dimension(500, game.RBot.MapDimension.Y,
				game.RPlayer.SizeTileToPixel * NewSize,
				game.RPlayer.SizeTileToPixel);

			shipType = ShipType.HORIZONTAL; 
			StartDimension = new Dimension(NewDimension);
		}

		private void RelocationShip()
		{
			NewDimension = new Dimension(StartDimension);
		}

		public void OnMoved(MouseMotionEvent e)
		{
			if(dragging)
			{
				NewDimension.X += e.X - px;
				NewDimension.Y += e.Y - py;
			}
			px = e.X;
			py = e.Y;
		}

		public void OnRender(Graphics g)
		{
			rect = new Rectangle(NewDimension.X, NewDimension.Y, game.RPlayer.SizeTileToPixel - 1, game.RPlayer.SizeTileToPixel - 1);
			for (int i = 0; i < LenghtShips[currentPointer]; ++i)
			{
				g.FillRectangle(Brushes.Green, rect);
				if (shipType == ShipType.HORIZONTAL)
				{
					rect.X += game.RBot.SizeTileToPixel;
				}
				else
				{
					rect.Y += game.RBot.SizeTileToPixel;
				}
			}
		}

		public void NextState(IState state)
		{
			game.SetState(state);
		}
	}
}