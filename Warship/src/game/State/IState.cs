using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	public interface IState
	{
		void OnEvent(Event e);
		void NextState(IState game);
		void OnRender(System.Drawing.Graphics g);
	}
}
