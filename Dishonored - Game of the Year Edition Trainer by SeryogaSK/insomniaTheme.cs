using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200002A RID: 42
	internal class insomniaTheme : ThemeContainer154
	{
		// Token: 0x060002CB RID: 715 RVA: 0x0000349B File Offset: 0x0000169B
		public insomniaTheme()
		{
			base.SetColor("BackColor", Color.White);
			base.TransparencyKey = Color.Fuchsia;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00013C58 File Offset: 0x00011E58
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("BackColor");
			this.C2 = Color.FromArgb(60, 60, 60);
			this.C3 = Color.FromArgb(50, 50, 50);
			this.B1 = new SolidBrush(Color.DarkSlateGray);
			this.B2 = new SolidBrush(Color.FromArgb(45, Color.White));
			this.P1 = new Pen(Color.FromArgb(138, 138, 138));
			this.P2 = new Pen(Color.FromArgb(158, 183, 85));
			this.P2 = new Pen(Brushes.Black);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00013D0C File Offset: 0x00011F0C
		protected override void PaintHook()
		{
			this.G.Clear(this.C1);
			base.DrawGradient(Color.FromArgb(30, 255, 255, 255), Color.FromArgb(95, 3, 35, 58), 10, 20, base.Width, base.Height, 90f);
			base.DrawGradient(this.C2, this.C3, 0, 0, base.Width, base.Height);
			this.G.FillRectangle(this.B2, 0, 0, base.Width, 4);
			this.G.DrawLine(this.P1, 30, 30, 30, 30);
			checked
			{
				this.G.DrawLine(this.P1, base.Width - 1, 0, base.Width - 1, 25);
				this.G.DrawLine(this.P2, 0, 0, 0, base.Height);
				this.G.DrawLine(this.P2, base.Width - 1, 0, base.Width - 1, base.Height);
				this.G.DrawLine(this.P2, 0, base.Height - 1, base.Width, base.Height - 1);
				HatchBrush brush = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(95, 3, 35, 58), Color.FromArgb(95, 3, 35, 58));
				this.G.FillRectangle(brush, 10, 20, base.Width - 20, base.Height - 30);
				this.G.DrawLine(this.P2, 0, 0, base.Width, 0);
				base.DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
				HatchBrush brush2 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(25, 25, 25), Color.FromArgb(90, 35, 35, 35));
				this.G.FillRectangle(brush2, 10, 20, base.Width - 20, base.Height - 30);
				this.G.DrawRectangle(Pens.Black, 10, 20, base.Width - 20, base.Height - 30);
				new HatchBrush(HatchStyle.Trellis, Color.FromArgb(95, 40, 142, 172), Color.FromArgb(90, 40, 142, 172));
				this.G.FillRectangle(this.B2, 0, base.Height - 5, base.Width, 4);
			}
		}

		// Token: 0x04000182 RID: 386
		private Color C1;

		// Token: 0x04000183 RID: 387
		private Color C2;

		// Token: 0x04000184 RID: 388
		private Color C3;

		// Token: 0x04000185 RID: 389
		private SolidBrush B1;

		// Token: 0x04000186 RID: 390
		private SolidBrush B2;

		// Token: 0x04000187 RID: 391
		private Pen P1;

		// Token: 0x04000188 RID: 392
		private Pen P2;
	}
}
