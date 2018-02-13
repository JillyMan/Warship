using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Warship
{
	public class EndGame : IState
	{
		Game game;
		public EndGame(Game game)
		{
			this.game = game;
		}

		public void NextState(IState game)
		{
		}

		public void OnEvent(Event e)
		{
		}

		public void OnRender(Graphics g)
		{
			g.Clear(Color.Black);
			Player win = (game.Player.InfoPlayer.Score == 10) ? game.Player : game.Bot;

			g.DrawString(win.InfoPlayer.Name + " WIN !!!", game.RPlayer.Font, Brushes.White,
				new Point(250, 10));
		}
	}
}
