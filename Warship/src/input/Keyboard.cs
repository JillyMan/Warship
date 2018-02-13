using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
    public class Keyboard
	{
		private static bool[] keys = new bool[200];

		public static bool IsKeyPressed(int vKey)
		{
			return keys[vKey];
		}

		public void KeyPressed(int vKey)
		{
			keys[vKey] = true;
		}

		public void KeyRelease(int vKey)
		{
			keys[vKey] = false;
		}
	}
}
