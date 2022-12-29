using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000023 RID: 35
	internal class genesisTextBox : ThemeControl154
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00002E2A File Offset: 0x0000102A
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00010C94 File Offset: 0x0000EE94
		private virtual TextBox txtbox
		{
			[CompilerGenerated]
			get
			{
				return this._txtbox;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = delegate(object sender, EventArgs e)
				{
					this.TextChngTxtBox();
				};
				TextBox txtbox = this._txtbox;
				if (txtbox != null)
				{
					txtbox.TextChanged -= value2;
				}
				this._txtbox = value;
				txtbox = this._txtbox;
				if (txtbox != null)
				{
					txtbox.TextChanged += value2;
				}
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00010CD8 File Offset: 0x0000EED8
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00002E32 File Offset: 0x00001032
		public bool UsePasswordMask
		{
			get
			{
				return this._PassMask;
			}
			set
			{
				this._PassMask = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00010CEC File Offset: 0x0000EEEC
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00002E41 File Offset: 0x00001041
		public int MaxCharacters
		{
			get
			{
				return this._maxchars;
			}
			set
			{
				this._maxchars = value;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00010D04 File Offset: 0x0000EF04
		public genesisTextBox()
		{
			base.TextChanged += delegate(object sender, EventArgs e)
			{
				this.TextChng();
			};
			this.txtbox = new TextBox();
			this.txtbox.TextAlign = HorizontalAlignment.Center;
			this.txtbox.BorderStyle = BorderStyle.None;
			this.txtbox.Location = new Point(5, 6);
			this.txtbox.Font = new Font("Verdana", 7.25f);
			base.Controls.Add(this.txtbox);
			this.BackColor = Color.FromArgb(37, 37, 37);
			this.Text = "";
			this.txtbox.Text = "";
			base.Size = new Size(135, 35);
			base.SetColor("BackColor", Color.FromArgb(37, 37, 37));
			base.SetColor("TextColor", Color.White);
			base.SetColor("TopInset", Color.FromArgb(45, 45, 45));
			base.SetColor("BottomInset", Color.FromArgb(70, 70, 70));
			base.SetColor("TextBoxShadow", Color.FromArgb(31, 31, 31));
			base.SetColor("BorderColor", Color.Black);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00010E40 File Offset: 0x0000F040
		protected override void ColorHook()
		{
			this.C1 = base.GetColor("BackColor");
			this.C2 = base.GetColor("TextColor");
			this.C3 = base.GetColor("TopInset");
			this.C4 = base.GetColor("BottomInset");
			this.C5 = base.GetColor("TextBoxShadow");
			this.C6 = base.GetColor("BorderColor");
			this.txtbox.ForeColor = this.C2;
			this.txtbox.BackColor = this.C1;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00010ED8 File Offset: 0x0000F0D8
		protected override void PaintHook()
		{
			this.G.Clear(this.BackColor);
			bool usePasswordMask;
			if (usePasswordMask = this.UsePasswordMask)
			{
				if (usePasswordMask)
				{
					this.txtbox.UseSystemPasswordChar = true;
				}
			}
			else
			{
				this.txtbox.UseSystemPasswordChar = false;
			}
			base.Size = new Size(base.Width, 25);
			this.txtbox.Font = this.Font;
			checked
			{
				this.txtbox.Size = new Size(base.Width - 10, this.txtbox.Height - 10);
				this.txtbox.MaxLength = this.MaxCharacters;
				this.G.FillRectangle(new SolidBrush(this.C1), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
				base.DrawBorders(new Pen(new SolidBrush(this.C6)), 1);
				base.DrawBorders(new Pen(new SolidBrush(this.C4)));
				this.G.DrawLine(new Pen(new SolidBrush(this.C3)), 0, 0, base.Width, 0);
				this.G.DrawLine(new Pen(new SolidBrush(this.C3)), 0, 0, 0, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C3)), base.Width - 1, 0, base.Width - 1, base.Height);
				this.G.DrawLine(new Pen(new SolidBrush(this.C5)), 2, 2, base.Width - 3, 2);
				base.DrawCorners(this.BackColor);
				base.DrawCorners(this.BackColor, new Rectangle(1, 1, base.Width - 2, base.Height - 2));
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00002E4A File Offset: 0x0000104A
		public void TextChngTxtBox()
		{
			this.Text = this.txtbox.Text;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00002E5D File Offset: 0x0000105D
		public void TextChng()
		{
			this.txtbox.Text = this.Text;
		}

		// Token: 0x04000126 RID: 294
		private bool _PassMask;

		// Token: 0x04000127 RID: 295
		private int _maxchars;

		// Token: 0x04000128 RID: 296
		private Color C1;

		// Token: 0x04000129 RID: 297
		private Color C2;

		// Token: 0x0400012A RID: 298
		private Color C3;

		// Token: 0x0400012B RID: 299
		private Color C4;

		// Token: 0x0400012C RID: 300
		private Color C5;

		// Token: 0x0400012D RID: 301
		private Color C6;
	}
}
