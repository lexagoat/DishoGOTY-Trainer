using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000021 RID: 33
	internal class genesisButton : ThemeControl154
	{
		// Token: 0x060001ED RID: 493 RVA: 0x000103F8 File Offset: 0x0000E5F8
		public genesisButton()
		{
			this.BackColor = Color.FromArgb(33, 33, 33);
			base.SetColor("ButtonFillColor", Color.FromArgb(47, 47, 47));
			base.SetColor("ButtonClickColor", Color.FromArgb(44, 44, 44));
			base.SetColor("InsetBorderColor", Color.FromArgb(72, 72, 72));
			base.SetColor("TopGloss", Color.FromArgb(62, Color.White));
			base.SetColor("BottomGloss", Color.FromArgb(30, Color.White));
			base.SetColor("TopInset", Color.FromArgb(45, 45, 45));
			base.SetColor("BottomInset", Color.FromArgb(70, 70, 70));
			base.SetColor("BorderColor", Color.Black);
			base.SetColor("TextColor", Color.White);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000104D8 File Offset: 0x0000E6D8
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("ButtonFillColor");
			this.C2 = base.GetColor("InsetBorderColor");
			this.C3 = base.GetColor("TopGloss");
			this.C4 = base.GetColor("BottomGloss");
			this.C5 = base.GetColor("TopInset");
			this.C6 = base.GetColor("BottomInset");
			this.C7 = base.GetColor("BorderColor");
			this.C8 = base.GetColor("TextColor");
			this.C9 = base.GetColor("ButtonClickColor");
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00010580 File Offset: 0x0000E780
		protected override void PaintHook()
		{
			this.G.Clear(this.BackColor);
			checked
			{
				switch (this.State)
				{
				case MouseState.None:
					this.G.FillRectangle(new SolidBrush(this.C1), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
					base.DrawBorders(new Pen(new SolidBrush(this.C2)), 2);
					base.DrawGradient(this.C3, this.C4, new Rectangle(1, 1, base.Width - 2, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), 90f);
					break;
				case MouseState.Over:
					this.G.FillRectangle(new SolidBrush(this.C1), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
					base.DrawBorders(new Pen(new SolidBrush(this.C2)), 2);
					base.DrawGradient(this.C3, this.C4, new Rectangle(1, 1, base.Width - 2, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), 90f);
					break;
				case MouseState.Down:
					this.G.FillRectangle(new SolidBrush(this.C9), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
					base.DrawBorders(new Pen(new SolidBrush(this.C2)), 2);
					base.DrawGradient(this.C4, this.C4, new Rectangle(1, 1, base.Width - 2, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), 90f);
					break;
				}
				base.DrawBorders(new Pen(new SolidBrush(this.C7)), 1);
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), 0, 0, base.Width, 0);
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), 0, 0, 0, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), base.Width - 1, 0, base.Width - 1, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C6)), 0, base.Height - 1, base.Width, base.Height - 1);
				base.DrawCorners(this.BackColor);
				base.DrawCorners(this.BackColor, new Rectangle(1, 1, base.Width - 2, base.Height - 2));
				base.DrawText(new SolidBrush(this.C8), HorizontalAlignment.Center, 0, 0);
			}
		}

		// Token: 0x04000114 RID: 276
		private Color C1;

		// Token: 0x04000115 RID: 277
		private Color C2;

		// Token: 0x04000116 RID: 278
		private Color C3;

		// Token: 0x04000117 RID: 279
		private Color C4;

		// Token: 0x04000118 RID: 280
		private Color C5;

		// Token: 0x04000119 RID: 281
		private Color C6;

		// Token: 0x0400011A RID: 282
		private Color C7;

		// Token: 0x0400011B RID: 283
		private Color C8;

		// Token: 0x0400011C RID: 284
		private Color C9;
	}
}
