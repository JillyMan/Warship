using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

/*
	NEED DO:
-		4: Поправить РЕНДЕР
-		5: Проверка на убийство корабля
	и.т.д 
*/

namespace Warship
{
	public class GameWar : IState
	{
		private Game game;
		private DispatcherShots dispatcherShots;

		public GameWar(Game game)
		{
			this.game = game;
			this.dispatcherShots = new DispatcherShots(game.Player, game.Bot);
		}

		public void OnEvent(Event e)
		{
			if (e is MousePressedEvent)
			{
				OnPressed((MousePressedEvent)e);
			}
		}

		public void OnPressed(MousePressedEvent e)
		{
			if (Collisions.Contains(new Point(e.X, e.Y), game.RBot.MapDimension))
			{
				int TestX = e.X;
				int TestY = e.Y;
				RenderInfo.CalculateCoord(ref TestX, ref TestY, game.RBot);
				bool EndGame = dispatcherShots.DispatchShots(TestX, TestY);

				if (EndGame)
				{
					NextState(game.FinishGame);
				}

			}
		}

		public void OnRender(Graphics g)
		{
			string str1 = game.Player.InfoPlayer.Name.ToString() + ": " + game.Player.InfoPlayer.Score.ToString() + "\n";
			string str2 = game.Bot.InfoPlayer.Name.ToString() + ": " + game.Bot.InfoPlayer.Score.ToString() + "\n";

			g.DrawString(str1, game.RPlayer.Font, Brushes.White, new Point(game.RBot.MapDimension.X + game.RBot.MapDimension.Width, game.RBot.MapDimension.Y));
			g.DrawString(str2, game.RPlayer.Font, Brushes.White, new Point(game.RBot.MapDimension.X + game.RBot.MapDimension.Width, game.RBot.MapDimension.Y + 30));
		}

		public void NextState(IState state)
		{
			game.SetState(state);
		}
	}
}
