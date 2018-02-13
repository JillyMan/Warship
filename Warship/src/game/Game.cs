using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Warship
{
	public class Game
	{
		public GameWar WarState { get; }
		public BeginGame FillState { get; }
		public EndGame FinishGame { get; }
		private IState CurrentState;

		public Bot Bot { get; }
		public Player Player { get; }
		public RenderInfo RBot { get; }
		public RenderInfo RPlayer { get; }

		private int[] LenShip = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

		public Game(string PlayerName, RenderInfo ri1, string BotName, RenderInfo ri2, int[] len)
        {
			this.RBot = ri2;
			this.RPlayer = ri1;
			this.Bot = new Bot(BotName, len);
			this.Player = new Player(PlayerName);

			this.WarState = new GameWar(this);
			this.FillState = new BeginGame(this, len);
			this.FinishGame = new EndGame(this);

			this.CurrentState = FillState;
        }

		public void SetState(IState state)
		{
			CurrentState = state;
		}

        public void OnRender(Graphics g)
        {
			Player.Render(g, RPlayer);
			Bot.Render(g, RBot);
			CurrentState.OnRender(g);
		}

		public void OnEvent(Event e)
        {
            CurrentState.OnEvent(e);
        }
    }
}