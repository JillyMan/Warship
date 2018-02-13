using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Warship
{
	public class Button
	{
		private Font font { get; }
		public readonly string text;
		public bool Click { get; private set; }
		public Dimension Size { get; private set; }

		public Button(Dimension size, Font font, string text)
		{
			this.Size = size;
			this.font = font;
			this.text = text;
			this.Click = false;
		}

		public void Render(Graphics g)
		{
			
		}

	}
}
