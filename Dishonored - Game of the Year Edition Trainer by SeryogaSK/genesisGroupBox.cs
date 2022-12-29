using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000027 RID: 39
	internal class genesisGroupBox : ThemeContainer154
	{
		// Token: 0x06000212 RID: 530 RVA: 0x00011EE8 File Offset: 0x000100E8
		public genesisGroupBox()
		{
			base.ControlMode = true;
			this.Dock = DockStyle.None;
			base.Size = new Size(180, 200);
			this.BackColor = Color.FromArgb(37, 37, 37);
			base.SetColor("BackColor", Color.FromArgb(37, 37, 37));
			base.SetColor("HeaderColor", Color.FromArgb(32, 32, 32));
			base.SetColor("TextColor", Color.White);
			base.SetColor("BorderColor", Color.Black);
			base.SetColor("TopInset", Color.FromArgb(45, 45, 45));
			base.SetColor("BottomInset", Color.FromArgb(70, 70, 70));
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00011FA8 File Offset: 0x000101A8
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("BackColor");
			this.C2 = base.GetColor("HeaderColor");
			this.C3 = base.GetColor("TextColor");
			this.C4 = base.GetColor("BorderColor");
			this.C5 = base.GetColor("TopInset");
			this.C6 = base.GetColor("BottomInset");
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0001201C File Offset: 0x0001021C
		protected override void PaintHook()
		{
			this.G.Clear(Color.FromArgb(37, 37, 37));
			checked
			{
				this.G.FillRectangle(new SolidBrush(this.C1), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
				this.G.FillRectangle(new SolidBrush(this.C2), new Rectangle(1, 1, base.Width - 2, 20));
				this.G.DrawLine(Pens.Black, 0, 21, base.Width, 21);
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), 0, 22, base.Width, 22);
				base.DrawBorders(new Pen(new SolidBrush(this.C4)), 1);
				base.DrawBorders(new Pen(new SolidBrush(this.C6)));
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), 0, 0, base.Width, 0);
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), 0, 0, 0, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), base.Width - 1, 0, base.Width - 1, base.Height);
				base.DrawCorners(this.BackColor);
				base.DrawCorners(this.BackColor, new Rectangle(1, 1, base.Width - 2, base.Height - 2));
				base.DrawText(new SolidBrush(this.C3), HorizontalAlignment.Center, 0, 0);
			}
		}

		// Token: 0x04000144 RID: 324
		private Color C1;

		// Token: 0x04000145 RID: 325
		private Color C2;

		// Token: 0x04000146 RID: 326
		private Color C3;

		// Token: 0x04000147 RID: 327
		private Color C4;

		// Token: 0x04000148 RID: 328
		private Color C5;

		// Token: 0x04000149 RID: 329
		private Color C6;
	}
}
