using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000036 RID: 54
	public class LogInButtonWithProgress : Control
	{
		// Token: 0x0600038D RID: 909 RVA: 0x000038DB File Offset: 0x00001ADB
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600038E RID: 910 RVA: 0x000038F1 File Offset: 0x00001AF1
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00003907 File Offset: 0x00001B07
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000391D File Offset: 0x00001B1D
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000391 RID: 913 RVA: 0x00016868 File Offset: 0x00014A68
		// (set) Token: 0x06000392 RID: 914 RVA: 0x00003933 File Offset: 0x00001B33
		[Category("Colours")]
		public Color ProgressColour
		{
			get
			{
				return this._ProgressColour;
			}
			set
			{
				this._ProgressColour = value;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00016880 File Offset: 0x00014A80
		// (set) Token: 0x06000394 RID: 916 RVA: 0x0000393C File Offset: 0x00001B3C
		[Category("Colours")]
		public Color BorderColour
		{
			get
			{
				return this._BorderColour;
			}
			set
			{
				this._BorderColour = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00016898 File Offset: 0x00014A98
		// (set) Token: 0x06000396 RID: 918 RVA: 0x00003945 File Offset: 0x00001B45
		[Category("Colours")]
		public Color FontColour
		{
			get
			{
				return this._FontColour;
			}
			set
			{
				this._FontColour = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000397 RID: 919 RVA: 0x000168B0 File Offset: 0x00014AB0
		// (set) Token: 0x06000398 RID: 920 RVA: 0x0000394E File Offset: 0x00001B4E
		[Category("Colours")]
		public Color BaseColour
		{
			get
			{
				return this._MainColour;
			}
			set
			{
				this._MainColour = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000399 RID: 921 RVA: 0x000168C8 File Offset: 0x00014AC8
		// (set) Token: 0x0600039A RID: 922 RVA: 0x00003957 File Offset: 0x00001B57
		[Category("Colours")]
		public Color HoverColour
		{
			get
			{
				return this._HoverColour;
			}
			set
			{
				this._HoverColour = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600039B RID: 923 RVA: 0x000168E0 File Offset: 0x00014AE0
		// (set) Token: 0x0600039C RID: 924 RVA: 0x00003960 File Offset: 0x00001B60
		[Category("Colours")]
		public Color PressedColour
		{
			get
			{
				return this._PressedColour;
			}
			set
			{
				this._PressedColour = value;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600039D RID: 925 RVA: 0x000168F8 File Offset: 0x00014AF8
		// (set) Token: 0x0600039E RID: 926 RVA: 0x00016910 File Offset: 0x00014B10
		[Category("Control")]
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value < this._Value)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00016940 File Offset: 0x00014B40
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00016964 File Offset: 0x00014B64
		[Category("Control")]
		public int Value
		{
			get
			{
				int value = this._Value;
				int result;
				if (value != 0)
				{
					result = this._Value;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				int num = value;
				if (num > this._Maximum)
				{
					value = this._Maximum;
					base.Invalidate();
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00003969 File Offset: 0x00001B69
		public void Increment(int Amount)
		{
			checked
			{
				this.Value += Amount;
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0001699C File Offset: 0x00014B9C
		public LogInButtonWithProgress()
		{
			this._Value = 0;
			this._Maximum = 100;
			this._Font = new Font("Segoe UI", 9f);
			this._ProgressColour = Color.FromArgb(0, 191, 255);
			this._BorderColour = Color.FromArgb(25, 25, 25);
			this._FontColour = Color.FromArgb(255, 255, 255);
			this._MainColour = Color.FromArgb(42, 42, 42);
			this._HoverColour = Color.FromArgb(52, 52, 52);
			this._PressedColour = Color.FromArgb(47, 47, 47);
			this.State = MouseState.None;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(75, 30);
			this.BackColor = Color.Transparent;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00016A80 File Offset: 0x00014C80
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			new GraphicsPath();
			new GraphicsPath();
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			checked
			{
				switch (this.State)
				{
				case MouseState.None:
					graphics2.FillRectangle(new SolidBrush(this._MainColour), new Rectangle(0, 0, base.Width, base.Height - 4));
					graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), new Rectangle(0, 0, base.Width, base.Height - 4));
					graphics2.DrawString(this.Text, this._Font, Brushes.White, new Point((int)Math.Round((double)base.Width / 2.0), (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
					break;
				case MouseState.Over:
					graphics2.FillRectangle(new SolidBrush(this._HoverColour), new Rectangle(0, 0, base.Width, base.Height - 4));
					graphics2.DrawRectangle(new Pen(this._BorderColour, 1f), new Rectangle(1, 1, base.Width - 2, base.Height - 5));
					graphics2.DrawString(this.Text, this._Font, Brushes.White, new Point((int)Math.Round((double)base.Width / 2.0), (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
					break;
				case MouseState.Down:
					graphics2.FillRectangle(new SolidBrush(this._PressedColour), new Rectangle(0, 0, base.Width, base.Height - 4));
					graphics2.DrawRectangle(new Pen(this._BorderColour, 1f), new Rectangle(1, 1, base.Width - 2, base.Height - 5));
					graphics2.DrawString(this.Text, this._Font, Brushes.White, new Point((int)Math.Round((double)base.Width / 2.0), (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
					break;
				}
				int value = this._Value;
				if (value != 0)
				{
					if (value == this._Maximum)
					{
						graphics2.FillRectangle(new SolidBrush(this._ProgressColour), new Rectangle(0, base.Height - 4, base.Width, base.Height - 4));
						graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), new Rectangle(0, 0, base.Width, base.Height));
					}
					else
					{
						graphics2.FillRectangle(new SolidBrush(this._ProgressColour), new Rectangle(0, base.Height - 4, (int)Math.Round(unchecked((double)base.Width / (double)this._Maximum * (double)this._Value)), base.Height - 4));
						graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), new Rectangle(0, 0, base.Width, base.Height));
					}
				}
				base.OnPaint(e);
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001D1 RID: 465
		private int _Value;

		// Token: 0x040001D2 RID: 466
		private int _Maximum;

		// Token: 0x040001D3 RID: 467
		private Font _Font;

		// Token: 0x040001D4 RID: 468
		private Color _ProgressColour;

		// Token: 0x040001D5 RID: 469
		private Color _BorderColour;

		// Token: 0x040001D6 RID: 470
		private Color _FontColour;

		// Token: 0x040001D7 RID: 471
		private Color _MainColour;

		// Token: 0x040001D8 RID: 472
		private Color _HoverColour;

		// Token: 0x040001D9 RID: 473
		private Color _PressedColour;

		// Token: 0x040001DA RID: 474
		private MouseState State;
	}
}
