using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x0200002D RID: 45
	[StandardModule]
	internal sealed class DrawHelpers
	{
		// Token: 0x060002D4 RID: 724 RVA: 0x00004CDC File Offset: 0x00002EDC
		public static GraphicsPath RoundRectangle(Rectangle Rectangle, int Curve)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			checked
			{
				int num = Curve * 2;
				graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
				graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
				graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 0f, 90f);
				graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 90f, 90f);
				graphicsPath.AddLine(new Point(Rectangle.X, Rectangle.Height - num + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
				return graphicsPath;
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00004DEC File Offset: 0x00002FEC
		public static GraphicsPath RoundRect(float x, float y, float w, float h, float r = 0.3f, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
		{
			float num = Math.Min(w, h) * r;
			float num2 = x + w;
			float num3 = y + h;
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath graphicsPath2 = graphicsPath;
			if (TL)
			{
				graphicsPath2.AddArc(x, y, num, num, 180f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(x, y, x, y);
			}
			if (TR)
			{
				graphicsPath2.AddArc(num2 - num, y, num, num, 270f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(num2, y, num2, y);
			}
			if (BR)
			{
				graphicsPath2.AddArc(num2 - num, num3 - num, num, num, 0f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(num2, num3, num2, num3);
			}
			if (BL)
			{
				graphicsPath2.AddArc(x, num3 - num, num, num, 90f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(x, num3, x, num3);
			}
			graphicsPath2.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x04000190 RID: 400
		private static int Height;

		// Token: 0x04000191 RID: 401
		private static int Width;

		// Token: 0x0200005D RID: 93
		public enum MouseState : byte
		{
			// Token: 0x04000311 RID: 785
			None,
			// Token: 0x04000312 RID: 786
			Over,
			// Token: 0x04000313 RID: 787
			Down,
			// Token: 0x04000314 RID: 788
			Block
		}
	}
}
