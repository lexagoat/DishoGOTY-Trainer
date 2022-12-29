using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000008 RID: 8
	[StandardModule]
	internal sealed class Helpers
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00004CDC File Offset: 0x00002EDC
		public static GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
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

		// Token: 0x06000015 RID: 21 RVA: 0x00004DEC File Offset: 0x00002FEC
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

		// Token: 0x06000016 RID: 22 RVA: 0x00004EC0 File Offset: 0x000030C0
		public static GraphicsPath DrawArrow(int x, int y, bool flip)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = 12;
			int num2 = 6;
			checked
			{
				if (flip)
				{
					graphicsPath.AddLine(x + 1, y, x + num + 1, y);
					graphicsPath.AddLine(x + num, y, x + num2, y + num2 - 1);
				}
				else
				{
					graphicsPath.AddLine(x, y + num2, x + num, y + num2);
					graphicsPath.AddLine(x + num, y + num2, x + num2, y);
				}
				graphicsPath.CloseFigure();
				return graphicsPath;
			}
		}

		// Token: 0x0400000B RID: 11
		internal static Graphics G;

		// Token: 0x0400000C RID: 12
		internal static Bitmap B;

		// Token: 0x0400000D RID: 13
		internal static Color _FlatColor = Color.FromArgb(35, 168, 109);

		// Token: 0x0400000E RID: 14
		internal static StringFormat NearSF = new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Near
		};

		// Token: 0x0400000F RID: 15
		internal static StringFormat CenterSF = new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};
	}
}
