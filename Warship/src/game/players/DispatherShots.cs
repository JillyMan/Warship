using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	public class DispatcherShots
	{
		private Player Bot;
		private Player Player;
		private Random r;

		public DispatcherShots(Player Player, Bot Bot)
		{
			this.Bot = Bot;
			this.Player = Player;

			r = new Random();
		}

		public bool DispatchShots(int TestX, int TestY)
		{
			bool result = false;
			TypeShot th = Bot.TakeABlow(TestX, TestY);

			if(th == TypeShot.MISS)
			{
				int rx;
				int ry;
				do
				{
					rx = r.Next(10);
					ry = r.Next(10);
					th = Player.TakeABlow(rx, ry);
					if(th == TypeShot.KILL)
					{
						++Bot.InfoPlayer.Score;
					}
				} while (th != TypeShot.MISS);
			}
			else if(th == TypeShot.KILL)
			{
				++Player.InfoPlayer.Score;
			}

			if (Player.InfoPlayer.Score == 10 || Bot.InfoPlayer.Score == 10)
			{
				result = true;
			}

			return result;
		}
	}
}
