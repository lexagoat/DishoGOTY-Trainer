using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200002C RID: 44
	internal class insomniaButton2 : ThemeControl151
	{
		// Token: 0x060002D1 RID: 721 RVA: 0x000034BE File Offset: 0x000016BE
		public insomniaButton2()
		{
			base.SetColor("BackColor", Color.White);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00014044 File Offset: 0x00012244
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("BackColor");
			this.C2 = Color.FromArgb(50, 50, 50);
			this.C3 = Color.FromArgb(70, 70, 70);
			this.P1 = new Pen(Color.Black);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00014094 File Offset: 0x00012294
		protected override void PaintHook()
		{
			this.G.Clear(this.C1);
			if (this.State == MouseState.Over)
			{
				base.DrawGradient(this.C2, this.C3, 0, 0, base.Width, base.Height);
			}
			else if (this.State == MouseState.Down)
			{
				base.DrawGradient(this.C3, this.C2, 0, 0, base.Width, base.Height);
			}
			else
			{
				base.DrawGradient(this.C3, this.C2, 0, 0, base.Width, base.Height);
			}
			base.DrawBorders(this.P1, base.ClientRectangle);
			base.DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
		}

		// Token: 0x0400018C RID: 396
		private Color C1;

		// Token: 0x0400018D RID: 397
		private Color C2;

		// Token: 0x0400018E RID: 398
		private Color C3;

		// Token: 0x0400018F RID: 399
		private Pen P1;
	}
}
