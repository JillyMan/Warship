using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	static class CoordinatesShift
	{
		static public int[] dX = new int[] { 1, -1, 1, -1, -1, 1, 0, 0 };
		static public int[] dY = new int[] { 1, -1, -1, 1,  0, 0, -1, 1 };
	}
}
