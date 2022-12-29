using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200002B RID: 43
	internal class insomniaButton : ThemeControl151
	{
		// Token: 0x060002CE RID: 718 RVA: 0x000034BE File Offset: 0x000016BE
		public insomniaButton()
		{
			base.SetColor("BackColor", Color.White);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000034D6 File Offset: 0x000016D6
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("BackColor");
			this.P1 = new Pen(Color.FromArgb(50, 50, 50));
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00013F6C File Offset: 0x0001216C
		protected override void PaintHook()
		{
			this.G.Clear(this.C1);
			if (this.State == MouseState.Over)
			{
				base.DrawGradient(Color.FromArgb(30, 30, 30), Color.FromArgb(50, 50, 50), 0, 0, base.Width, base.Height);
			}
			else if (this.State == MouseState.Down)
			{
				base.DrawGradient(Color.FromArgb(118, 118, 118), Color.FromArgb(110, 110, 110), 0, 0, base.Width, base.Height);
			}
			else
			{
				base.DrawGradient(Color.FromArgb(50, 50, 50), Color.FromArgb(30, 30, 30), 0, 0, base.Width, base.Height);
			}
			base.DrawBorders(this.P1, base.ClientRectangle);
			base.DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
		}

		// Token: 0x04000189 RID: 393
		private Color C1;

		// Token: 0x0400018A RID: 394
		private Pen P1;

		// Token: 0x0400018B RID: 395
		private SolidBrush B2;
	}
}
