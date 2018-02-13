using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
	public class RenderInfo
	{
		public int SizeTileToPixel { get; }
		public System.Drawing.Font Font { get; }
		public Dimension MapDimension { get; }

		public RenderInfo(int sizeTIleToPixel, Dimension dm)
		{
			this.SizeTileToPixel = sizeTIleToPixel;
			MapDimension = dm;
			Font = new System.Drawing.Font("Times New Roman", 13);
		}

		public static void CalculateCoord(ref int TestX, ref int TestY, RenderInfo InfoMap)
		{
			TestX = (TestX - InfoMap.MapDimension.X) / InfoMap.SizeTileToPixel;
			TestY = (TestY - InfoMap.MapDimension.Y) / InfoMap.SizeTileToPixel;
		}
	}
}
