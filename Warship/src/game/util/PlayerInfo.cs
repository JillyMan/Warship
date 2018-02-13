using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	public class PlayerInfo
	{
		public int CountShip { get; set; }
		public int Score { get; set; }
		public string Name { get; }

		public PlayerInfo(string name)
		{
			this.Score = 0;
			this.Name = name;
			this.CountShip = 10;
		}
	}
}
