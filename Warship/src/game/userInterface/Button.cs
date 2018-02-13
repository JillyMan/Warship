using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Warship
{
	public class Button
	{
		public Dimension dimension { get; private set; }
		public Font font { get; }
		public string Info { get; }

		public Button(Dimension d, Font font)
		{
			this.dimension = d;
			this.font = font;
		}
	}
}
