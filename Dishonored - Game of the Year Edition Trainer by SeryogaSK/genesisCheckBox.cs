using System;
using System.ComponentModel;
using System.Drawing;

namespace trainer_template
{
	// Token: 0x02000024 RID: 36
	[DefaultEvent("CheckedChanged")]
	internal class genesisCheckBox : ThemeControl154
	{
		// Token: 0x06000200 RID: 512 RVA: 0x000110A8 File Offset: 0x0000F2A8
		public genesisCheckBox()
		{
			this.BackColor = Color.FromArgb(37, 37, 37);
			base.LockWidth = 50;
			base.LockHeight = 20;
			this.Checked = false;
			base.SetColor("OnGradientA", Color.FromArgb(63, 83, 100));
			base.SetColor("OnGradientB", Color.FromArgb(87, 127, 151));
			base.SetColor("OffGradientA", Color.FromArgb(23, 23, 23));
			base.SetColor("OffGradientB", Color.FromArgb(33, 33, 33));
			base.SetColor("SwitchColor", Color.FromArgb(25, 25, 25));
			base.SetColor("TopGloss", Color.FromArgb(62, Color.White));
			base.SetColor("BottomGloss", Color.FromArgb(30, Color.White));
			base.SetColor("SwitchBorder", Color.Black);
			base.SetColor("SwitchInsetBorder", Color.FromArgb(47, 47, 47));
			base.SetColor("BorderColor", Color.Black);
			base.SetColor("TopInset", Color.FromArgb(45, 45, 45));
			base.SetColor("BottomInset", Color.FromArgb(70, 70, 70));
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000111E4 File Offset: 0x0000F3E4
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("OnGradientA");
			this.C2 = base.GetColor("OnGradientB");
			this.C3 = base.GetColor("OffGradientA");
			this.C4 = base.GetColor("OffGradientB");
			this.C5 = base.GetColor("SwitchColor");
			this.C6 = base.GetColor("TopGloss");
			this.C7 = base.GetColor("BottomGloss");
			this.C8 = base.GetColor("SwitchBorder");
			this.C9 = base.GetColor("SwitchInsetBorder");
			this.C10 = base.GetColor("BorderColor");
			this.C11 = base.GetColor("TopInset");
			this.C12 = base.GetColor("BottomInset");
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000112C0 File Offset: 0x0000F4C0
		protected override void PaintHook()
		{
			this.G.Clear(this.BackColor);
			checked
			{
				bool @checked;
				if (@checked = this.Checked)
				{
					if (@checked)
					{
						base.DrawGradient(this.C1, this.C2, base.ClientRectangle, 90f);
						this.G.FillRectangle(new SolidBrush(this.C5), new Rectangle(base.Width - 19, 1, 17, base.Height - 4));
						this.G.DrawRectangle(new Pen(new SolidBrush(this.C8)), new Rectangle(base.Width - 20, 0, 20, base.Height - 1));
						this.G.DrawRectangle(new Pen(new SolidBrush(this.C9)), new Rectangle(base.Width - 19, 1, 16, base.Height - 4));
						base.DrawGradient(this.C6, this.C7, new Rectangle(base.Width - 19, 2, 17, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), 90f);
						this.G.DrawString("ON", this.Font, Brushes.White, 6f, 3f);
					}
				}
				else
				{
					base.DrawGradient(this.C3, this.C4, base.ClientRectangle, 90f);
					this.G.FillRectangle(new SolidBrush(this.C5), new Rectangle(1, 1, 20, base.Height - 1));
					this.G.DrawRectangle(new Pen(new SolidBrush(this.C8)), new Rectangle(0, 0, 20, base.Height - 1));
					this.G.DrawRectangle(new Pen(new SolidBrush(this.C9)), new Rectangle(2, 2, 17, base.Height - 5));
					base.DrawGradient(this.C6, this.C7, new Rectangle(1, 1, 19, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), 90f);
					this.G.DrawString("OFF", this.Font, Brushes.White, 22f, 3f);
				}
				base.DrawCorners(this.BackColor, new Rectangle(1, 2, base.Width - 1, base.Height - 4));
				this.G.DrawLine(new Pen(new SolidBrush(this.C11)), 0, 0, base.Width, 0);
				this.G.DrawLine(new Pen(new SolidBrush(this.C11)), 0, 0, 0, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C11)), base.Width - 1, 0, base.Width - 1, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C12)), 0, base.Height - 1, base.Width, base.Height - 1);
				base.DrawBorders(new Pen(new SolidBrush(this.C10)), 1);
				base.DrawCorners(this.BackColor);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00011610 File Offset: 0x0000F810
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00002E80 File Offset: 0x00001080
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00011624 File Offset: 0x0000F824
		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			genesisCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
			if (checkedChangedEvent != null)
			{
				checkedChangedEvent(this);
			}
			base.OnClick(e);
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000206 RID: 518 RVA: 0x00011658 File Offset: 0x0000F858
		// (remove) Token: 0x06000207 RID: 519 RVA: 0x00011690 File Offset: 0x0000F890
		public event genesisCheckBox.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x0400012E RID: 302
		private Color C1;

		// Token: 0x0400012F RID: 303
		private Color C2;

		// Token: 0x04000130 RID: 304
		private Color C3;

		// Token: 0x04000131 RID: 305
		private Color C4;

		// Token: 0x04000132 RID: 306
		private Color C5;

		// Token: 0x04000133 RID: 307
		private Color C6;

		// Token: 0x04000134 RID: 308
		private Color C7;

		// Token: 0x04000135 RID: 309
		private Color C8;

		// Token: 0x04000136 RID: 310
		private Color C9;

		// Token: 0x04000137 RID: 311
		private Color C10;

		// Token: 0x04000138 RID: 312
		private Color C11;

		// Token: 0x04000139 RID: 313
		private Color C12;

		// Token: 0x0400013A RID: 314
		private bool _Checked;

		// Token: 0x0200005C RID: 92
		// (Invoke) Token: 0x060006A5 RID: 1701
		public delegate void CheckedChangedEventHandler(object sender);
	}
}
