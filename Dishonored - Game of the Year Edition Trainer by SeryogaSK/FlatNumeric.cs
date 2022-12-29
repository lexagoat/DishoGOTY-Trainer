using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000018 RID: 24
	internal class FlatNumeric : Control
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000FC RID: 252 RVA: 0x000093A4 File Offset: 0x000075A4
		// (set) Token: 0x060000FD RID: 253 RVA: 0x000093BC File Offset: 0x000075BC
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value <= this._Max & value >= this._Min)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000FE RID: 254 RVA: 0x000093F4 File Offset: 0x000075F4
		// (set) Token: 0x060000FF RID: 255 RVA: 0x0000940C File Offset: 0x0000760C
		public long Maximum
		{
			get
			{
				return this._Max;
			}
			set
			{
				if (value > this._Min)
				{
					this._Max = value;
				}
				if (this._Value > this._Max)
				{
					this._Value = this._Max;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00009450 File Offset: 0x00007650
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00009468 File Offset: 0x00007668
		public long Minimum
		{
			get
			{
				return this._Min;
			}
			set
			{
				if (value < this._Max)
				{
					this._Min = value;
				}
				if (this._Value < this._Min)
				{
					this._Value = this.Minimum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000094AC File Offset: 0x000076AC
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.Location.X;
			this.y = e.Location.Y;
			base.Invalidate();
			if (e.X < checked(base.Width - 23))
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000951C File Offset: 0x0000771C
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			checked
			{
				if (this.x > base.Width - 21 && this.x < base.Width - 3)
				{
					if (this.y < 15)
					{
						if (this.Value + 1L <= this._Max)
						{
							ref long ptr = ref this._Value;
							this._Value = ptr + 1L;
						}
					}
					else if (this.Value - 1L >= this._Min)
					{
						ref long ptr = ref this._Value;
						this._Value = ptr - 1L;
					}
				}
				else
				{
					this.Bool = !this.Bool;
					base.Focus();
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000095E8 File Offset: 0x000077E8
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				if (this.Bool)
				{
					this._Value = Conversions.ToLong(Conversions.ToString(this._Value) + e.KeyChar.ToString());
				}
				if (this._Value > this._Max)
				{
					this._Value = this._Max;
				}
				base.Invalidate();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00009670 File Offset: 0x00007870
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Back)
			{
				this.Value = 0L;
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000287E File Offset: 0x00000A7E
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 30;
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000107 RID: 263 RVA: 0x000096A0 File Offset: 0x000078A0
		// (set) Token: 0x06000108 RID: 264 RVA: 0x0000288F File Offset: 0x00000A8F
		[Category("Colors")]
		public Color BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000096B8 File Offset: 0x000078B8
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00002898 File Offset: 0x00000A98
		[Category("Colors")]
		public Color ButtonColor
		{
			get
			{
				return this._ButtonColor;
			}
			set
			{
				this._ButtonColor = value;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000096D0 File Offset: 0x000078D0
		public FlatNumeric()
		{
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(60, 60, 60);
			this._ButtonColor = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 10f);
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.ForeColor = Color.White;
			this._Min = 0L;
			this._Max = 9999999L;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00009774 File Offset: 0x00007974
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			g.FillRectangle(new SolidBrush(this._BaseColor), rect);
			checked
			{
				g.FillRectangle(new SolidBrush(this._ButtonColor), new Rectangle(base.Width - 24, 0, 24, this.H));
				g.DrawString("+", new Font("Segoe UI", 12f), Brushes.White, new Point(base.Width - 12, 8), Helpers.CenterSF);
				g.DrawString("-", new Font("Segoe UI", 10f, FontStyle.Bold), Brushes.White, new Point(base.Width - 12, 22), Helpers.CenterSF);
				g.DrawString(Conversions.ToString(this.Value), this.Font, Brushes.White, new Rectangle(5, 1, this.W, this.H), new StringFormat
				{
					LineAlignment = StringAlignment.Center
				});
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x04000084 RID: 132
		private int W;

		// Token: 0x04000085 RID: 133
		private int H;

		// Token: 0x04000086 RID: 134
		private MouseState State;

		// Token: 0x04000087 RID: 135
		private int x;

		// Token: 0x04000088 RID: 136
		private int y;

		// Token: 0x04000089 RID: 137
		private long _Value;

		// Token: 0x0400008A RID: 138
		private long _Min;

		// Token: 0x0400008B RID: 139
		private long _Max;

		// Token: 0x0400008C RID: 140
		private bool Bool;

		// Token: 0x0400008D RID: 141
		private Color _BaseColor;

		// Token: 0x0400008E RID: 142
		private Color _ButtonColor;
	}
}
