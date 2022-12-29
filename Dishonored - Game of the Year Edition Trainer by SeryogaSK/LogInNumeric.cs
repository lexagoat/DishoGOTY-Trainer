using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000039 RID: 57
	public class LogInNumeric : Control
	{
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x000173BC File Offset: 0x000155BC
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x000173D4 File Offset: 0x000155D4
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value <= this._Maximum & value >= this._Minimum)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x0001740C File Offset: 0x0001560C
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00017424 File Offset: 0x00015624
		public long Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value > this._Minimum)
				{
					this._Maximum = value;
				}
				if (this._Value > this._Maximum)
				{
					this._Value = this._Maximum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00017468 File Offset: 0x00015668
		// (set) Token: 0x060003BB RID: 955 RVA: 0x00017480 File Offset: 0x00015680
		public long Minimum
		{
			get
			{
				return this._Minimum;
			}
			set
			{
				if (value < this._Maximum)
				{
					this._Minimum = value;
				}
				if (this._Value < this._Minimum)
				{
					this._Value = this.Minimum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000174C4 File Offset: 0x000156C4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.MouseXLoc = e.Location.X;
			this.MouseYLoc = e.Location.Y;
			base.Invalidate();
			if (e.X < checked(base.Width - 47))
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00017534 File Offset: 0x00015734
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			checked
			{
				if (this.MouseXLoc > base.Width - 47 && this.MouseXLoc < base.Width - 3)
				{
					if (this.MouseXLoc < base.Width - 23)
					{
						if (this.Value + 1L <= this._Maximum)
						{
							ref long ptr = ref this._Value;
							this._Value = ptr + 1L;
						}
					}
					else if (this.Value - 1L >= this._Minimum)
					{
						ref long ptr = ref this._Value;
						this._Value = ptr - 1L;
					}
				}
				else
				{
					this.BoolValue = !this.BoolValue;
					base.Focus();
				}
				base.Invalidate();
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00017608 File Offset: 0x00015808
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				if (this.BoolValue)
				{
					this._Value = Conversions.ToLong(Conversions.ToString(this._Value) + e.KeyChar.ToString());
				}
				if (this._Value > this._Maximum)
				{
					this._Value = this._Maximum;
				}
				base.Invalidate();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00017690 File Offset: 0x00015890
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Back)
			{
				this.Value = 0L;
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000039B8 File Offset: 0x00001BB8
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 24;
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x000176C0 File Offset: 0x000158C0
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x000039C9 File Offset: 0x00001BC9
		[Category("Colours")]
		public Color BaseColour
		{
			get
			{
				return this._BaseColour;
			}
			set
			{
				this._BaseColour = value;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x000176D8 File Offset: 0x000158D8
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x000039D2 File Offset: 0x00001BD2
		[Category("Colours")]
		public Color ButtonColour
		{
			get
			{
				return this._ButtonColour;
			}
			set
			{
				this._ButtonColour = value;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x000176F0 File Offset: 0x000158F0
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x000039DB File Offset: 0x00001BDB
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

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x00017708 File Offset: 0x00015908
		// (set) Token: 0x060003C8 RID: 968 RVA: 0x000039E4 File Offset: 0x00001BE4
		[Category("Colours")]
		public Color SecondBorderColour
		{
			get
			{
				return this._SecondBorderColour;
			}
			set
			{
				this._SecondBorderColour = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00017720 File Offset: 0x00015920
		// (set) Token: 0x060003CA RID: 970 RVA: 0x000039ED File Offset: 0x00001BED
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

		// Token: 0x060003CB RID: 971 RVA: 0x00017738 File Offset: 0x00015938
		public LogInNumeric()
		{
			this.State = MouseState.None;
			this._Minimum = 0L;
			this._Maximum = 9999999L;
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._ButtonColour = Color.FromArgb(47, 47, 47);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._SecondBorderColour = Color.FromArgb(0, 191, 255);
			this._FontColour = Color.FromArgb(255, 255, 255);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 10f);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000177FC File Offset: 0x000159FC
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			StringFormat stringFormat = new StringFormat();
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.Alignment = StringAlignment.Center;
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColour), rect);
			checked
			{
				graphics2.FillRectangle(new SolidBrush(this._ButtonColour), new Rectangle(base.Width - 48, 0, 48, base.Height));
				graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), rect);
				graphics2.DrawLine(new Pen(this._SecondBorderColour), new Point(base.Width - 48, 1), new Point(base.Width - 48, base.Height - 2));
				graphics2.DrawLine(new Pen(this._BorderColour), new Point(base.Width - 24, 1), new Point(base.Width - 24, base.Height - 2));
				graphics2.DrawLine(new Pen(this._FontColour), new Point(base.Width - 36, 7), new Point(base.Width - 36, 17));
				graphics2.DrawLine(new Pen(this._FontColour), new Point(base.Width - 31, 12), new Point(base.Width - 41, 12));
				graphics2.DrawLine(new Pen(this._FontColour), new Point(base.Width - 17, 13), new Point(base.Width - 7, 13));
				graphics2.DrawString(Conversions.ToString(this.Value), this.Font, new SolidBrush(this._FontColour), new Rectangle(5, 1, base.Width, base.Height), new StringFormat
				{
					LineAlignment = StringAlignment.Center
				});
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001E2 RID: 482
		private MouseState State;

		// Token: 0x040001E3 RID: 483
		private int MouseXLoc;

		// Token: 0x040001E4 RID: 484
		private int MouseYLoc;

		// Token: 0x040001E5 RID: 485
		private long _Value;

		// Token: 0x040001E6 RID: 486
		private long _Minimum;

		// Token: 0x040001E7 RID: 487
		private long _Maximum;

		// Token: 0x040001E8 RID: 488
		private bool BoolValue;

		// Token: 0x040001E9 RID: 489
		private Color _BaseColour;

		// Token: 0x040001EA RID: 490
		private Color _ButtonColour;

		// Token: 0x040001EB RID: 491
		private Color _BorderColour;

		// Token: 0x040001EC RID: 492
		private Color _SecondBorderColour;

		// Token: 0x040001ED RID: 493
		private Color _FontColour;
	}
}
