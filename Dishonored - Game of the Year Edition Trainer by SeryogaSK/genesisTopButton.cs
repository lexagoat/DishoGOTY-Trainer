using System;
using System.Drawing;

namespace trainer_template
{
	// Token: 0x02000022 RID: 34
	internal class genesisTopButton : ThemeControl154
	{
		// Token: 0x060001F0 RID: 496 RVA: 0x00010870 File Offset: 0x0000EA70
		public genesisTopButton()
		{
			this.BackColor = Color.FromArgb(33, 33, 33);
			base.Size = new Size(20, 20);
			base.LockHeight = 20;
			base.LockWidth = 20;
			base.SetColor("BackColor", Color.FromArgb(47, 47, 47));
			base.SetColor("BorderColor", Color.FromArgb(70, 70, 70));
			base.SetColor("InsetBorderColor2", Color.FromArgb(72, 72, 72));
			base.SetColor("InsetBorderColor", Color.Black);
			base.SetColor("TopGloss", Color.FromArgb(62, Color.White));
			base.SetColor("BottomGloss", Color.FromArgb(30, Color.White));
			base.SetColor("TopInset", Color.FromArgb(45, 45, 45));
			base.SetColor("ButtonClickColor", Color.FromArgb(44, 44, 44));
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00010960 File Offset: 0x0000EB60
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("BackColor");
			this.C2 = base.GetColor("InsetBorderColor2");
			this.C3 = base.GetColor("TopGloss");
			this.C4 = base.GetColor("BottomGloss");
			this.C5 = base.GetColor("BorderColor");
			this.C6 = base.GetColor("InsetBorderColor");
			this.C7 = base.GetColor("TopInset");
			this.C8 = base.GetColor("ButtonClickColor");
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x000109F8 File Offset: 0x0000EBF8
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
					this.G.FillRectangle(new SolidBrush(this.C8), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
					base.DrawBorders(new Pen(new SolidBrush(this.C2)), 2);
					base.DrawGradient(this.C4, this.C4, new Rectangle(1, 1, base.Width - 2, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), 90f);
					break;
				}
				base.DrawBorders(new Pen(new SolidBrush(this.C6)), 1);
				base.DrawBorders(new Pen(new SolidBrush(this.C5)));
				this.G.DrawLine(new Pen(new SolidBrush(this.C7)), 0, base.Height / 2, 0, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C7)), base.Width - 1, base.Height / 2, base.Width - 1, base.Height);
				base.DrawCorners(this.BackColor, new Rectangle(1, 1, base.Width - 2, base.Height - 2));
			}
		}

		// Token: 0x0400011D RID: 285
		private Color C1;

		// Token: 0x0400011E RID: 286
		private Color C2;

		// Token: 0x0400011F RID: 287
		private Color C3;

		// Token: 0x04000120 RID: 288
		private Color C4;

		// Token: 0x04000121 RID: 289
		private Color C5;

		// Token: 0x04000122 RID: 290
		private Color C6;

		// Token: 0x04000123 RID: 291
		private Color C7;

		// Token: 0x04000124 RID: 292
		private Color C8;
	}
}
