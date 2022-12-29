using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000020 RID: 32
	internal class genesisTheme : ThemeContainer154
	{
		// Token: 0x060001E6 RID: 486 RVA: 0x00010180 File Offset: 0x0000E380
		public genesisTheme()
		{
			base.TransparencyKey = Color.Fuchsia;
			base.SetColor("BackColor", Color.FromArgb(33, 33, 33));
			base.SetColor("BorderColor", Color.Black);
			base.SetColor("InsetBorderColor", Color.FromArgb(72, 72, 72));
			base.SetColor("TextColor", Color.White);
			base.SetColor("TopGloss", Color.FromArgb(62, Color.White));
			base.SetColor("BottomGloss", Color.FromArgb(30, Color.White));
			this.BackColor = Color.FromArgb(33, 33, 33);
			this.ForeColor = Color.White;
			base.Sizable = false;
			this._ShowIcon = false;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00010244 File Offset: 0x0000E444
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("BackColor");
			this.C2 = base.GetColor("BorderColor");
			this.C3 = base.GetColor("InsetBorderColor");
			this.C4 = base.GetColor("TextColor");
			this.C5 = base.GetColor("TopGloss");
			this.C6 = base.GetColor("BottomGloss");
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000102B8 File Offset: 0x0000E4B8
		protected override void PaintHook()
		{
			this.G.Clear(Color.FromArgb(33, 33, 33));
			checked
			{
				this.G.FillRectangle(new SolidBrush(this.C1), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
				base.DrawBorders(new Pen(new SolidBrush(this.C3)), 1);
				base.DrawGradient(this.C5, this.C6, new Rectangle(1, 1, base.Width - 2, 13), 90f);
				base.DrawBorders(new Pen(new SolidBrush(this.C2)));
				base.DrawCorners(base.TransparencyKey);
				bool showIcon;
				if (showIcon = this._ShowIcon)
				{
					if (showIcon)
					{
						if (this._Icon != null)
						{
							this.G.DrawIcon(this._Icon, new Rectangle(8, 6, 12, 12));
						}
						base.DrawText(new SolidBrush(this.C4), HorizontalAlignment.Left, 24, 0);
					}
				}
				else
				{
					base.DrawText(new SolidBrush(this.C4), HorizontalAlignment.Left, 8, 0);
				}
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000103CC File Offset: 0x0000E5CC
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00002E0C File Offset: 0x0000100C
		public bool ShowIcon
		{
			get
			{
				return this._ShowIcon;
			}
			set
			{
				this._ShowIcon = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001EB RID: 491 RVA: 0x000103E0 File Offset: 0x0000E5E0
		// (set) Token: 0x060001EC RID: 492 RVA: 0x00002E1B File Offset: 0x0000101B
		public Icon Icon
		{
			get
			{
				return this._Icon;
			}
			set
			{
				this._Icon = value;
				base.Invalidate();
			}
		}

		// Token: 0x0400010C RID: 268
		private Color C1;

		// Token: 0x0400010D RID: 269
		private Color C2;

		// Token: 0x0400010E RID: 270
		private Color C3;

		// Token: 0x0400010F RID: 271
		private Color C4;

		// Token: 0x04000110 RID: 272
		private Color C5;

		// Token: 0x04000111 RID: 273
		private Color C6;

		// Token: 0x04000112 RID: 274
		private bool _ShowIcon;

		// Token: 0x04000113 RID: 275
		private Icon _Icon;
	}
}
