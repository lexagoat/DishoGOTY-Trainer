using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000046 RID: 70
	[DefaultEvent("Scroll")]
	public class LogInHorizontalScrollBar : Control
	{
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0001B7E0 File Offset: 0x000199E0
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x00003F69 File Offset: 0x00002169
		[Category("Colours")]
		public Color ThumbBorder
		{
			get
			{
				return this._ThumbBorder;
			}
			set
			{
				this._ThumbBorder = value;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0001B7F8 File Offset: 0x000199F8
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x00003F72 File Offset: 0x00002172
		[Category("Colours")]
		public Color LineColour
		{
			get
			{
				return this._LineColour;
			}
			set
			{
				this._LineColour = value;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0001B810 File Offset: 0x00019A10
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x00003F7B File Offset: 0x0000217B
		[Category("Colours")]
		public Color ArrowColour
		{
			get
			{
				return this._ArrowColour;
			}
			set
			{
				this._ArrowColour = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0001B828 File Offset: 0x00019A28
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00003F84 File Offset: 0x00002184
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

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0001B840 File Offset: 0x00019A40
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00003F8D File Offset: 0x0000218D
		[Category("Colours")]
		public Color ThumbColour
		{
			get
			{
				return this._ThumbColour;
			}
			set
			{
				this._ThumbColour = value;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0001B858 File Offset: 0x00019A58
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x00003F96 File Offset: 0x00002196
		[Category("Colours")]
		public Color ThumbSecondBorder
		{
			get
			{
				return this._ThumbSecondBorder;
			}
			set
			{
				this._ThumbSecondBorder = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0001B870 File Offset: 0x00019A70
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x00003F9F File Offset: 0x0000219F
		[Category("Colours")]
		public Color FirstBorder
		{
			get
			{
				return this._FirstBorder;
			}
			set
			{
				this._FirstBorder = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0001B888 File Offset: 0x00019A88
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00003FA8 File Offset: 0x000021A8
		[Category("Colours")]
		public Color SecondBorder
		{
			get
			{
				return this._SecondBorder;
			}
			set
			{
				this._SecondBorder = value;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060004DA RID: 1242 RVA: 0x0001B8A0 File Offset: 0x00019AA0
		// (remove) Token: 0x060004DB RID: 1243 RVA: 0x0001B8D8 File Offset: 0x00019AD8
		public event LogInHorizontalScrollBar.ScrollEventHandler Scroll;

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x0001B910 File Offset: 0x00019B10
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x0001B928 File Offset: 0x00019B28
		public int Minimum
		{
			get
			{
				return this._Minimum;
			}
			set
			{
				this._Minimum = value;
				if (value > this._Value)
				{
					this._Value = value;
				}
				if (value > this._Maximum)
				{
					this._Maximum = value;
				}
				this.InvalidateLayout();
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x0001B968 File Offset: 0x00019B68
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x0001B980 File Offset: 0x00019B80
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
				if (value < this._Minimum)
				{
					this._Minimum = value;
				}
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0001B9B4 File Offset: 0x00019BB4
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0001B9CC File Offset: 0x00019BCC
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value != this._Value)
				{
					if (value < this._Minimum)
					{
						this._Value = this._Minimum;
					}
					else if (value > this._Maximum)
					{
						this._Value = this._Maximum;
					}
					else
					{
						this._Value = value;
					}
					this.InvalidatePosition();
					LogInHorizontalScrollBar.ScrollEventHandler scrollEvent = this.ScrollEvent;
					if (scrollEvent != null)
					{
						scrollEvent(this);
					}
				}
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0001BA38 File Offset: 0x00019C38
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x0001BA50 File Offset: 0x00019C50
		public int SmallChange
		{
			get
			{
				return this._SmallChange;
			}
			set
			{
				if (value < 1 || value <= ((-(((this._SmallChange == value) > false) ? 1 : 0)) ? 1 : 0))
				{
				}
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0001BA78 File Offset: 0x00019C78
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x0001BA90 File Offset: 0x00019C90
		public int LargeChange
		{
			get
			{
				return this._LargeChange;
			}
			set
			{
				if (value >= 1)
				{
					this._LargeChange = value;
				}
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0001BAAC File Offset: 0x00019CAC
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x0001BAC4 File Offset: 0x00019CC4
		public int ButtonSize
		{
			get
			{
				return this._ButtonSize;
			}
			set
			{
				if (value < 16)
				{
					this._ButtonSize = 16;
				}
				else
				{
					this._ButtonSize = value;
				}
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00003FB1 File Offset: 0x000021B1
		protected override void OnSizeChanged(EventArgs e)
		{
			this.InvalidateLayout();
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0001BAEC File Offset: 0x00019CEC
		private void InvalidateLayout()
		{
			this.LSA = new Rectangle(0, 1, 0, base.Height);
			checked
			{
				this.Shaft = new Rectangle(this.LSA.Right + 1, 0, base.Width - 3, base.Height);
				this.ShowThumb = (this._Maximum - this._Minimum != 0);
				this.Thumb = new Rectangle(0, 1, this._ThumbSize, base.Height - 3);
				LogInHorizontalScrollBar.ScrollEventHandler scrollEvent = this.ScrollEvent;
				if (scrollEvent != null)
				{
					scrollEvent(this);
				}
				this.InvalidatePosition();
			}
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0001BB7C File Offset: 0x00019D7C
		private void InvalidatePosition()
		{
			this.Thumb.X = checked((int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(checked(this.Shaft.Width - this._ThumbSize)) + 1.0)));
			base.Invalidate();
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0001BBDC File Offset: 0x00019DDC
		protected override void OnMouseDown(MouseEventArgs e)
		{
			checked
			{
				if (e.Button == MouseButtons.Left && this.ShowThumb)
				{
					if (this.LSA.Contains(e.Location))
					{
						this.ThumbMovement = this._Value - this._SmallChange;
					}
					else if (this.RSA.Contains(e.Location))
					{
						this.ThumbMovement = this._Value + this._SmallChange;
					}
					else
					{
						if (this.Thumb.Contains(e.Location))
						{
							this.ThumbDown = true;
							return;
						}
						if (e.X < this.Thumb.X)
						{
							this.ThumbMovement = this._Value - this._LargeChange;
						}
						else
						{
							this.ThumbMovement = this._Value + this._LargeChange;
						}
					}
					this.Value = Math.Min(Math.Max(this.ThumbMovement, this._Minimum), this._Maximum);
					this.InvalidatePosition();
				}
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0001BCD8 File Offset: 0x00019ED8
		protected override void OnMouseMove(MouseEventArgs e)
		{
			checked
			{
				if (this.ThumbDown && this.ShowThumb)
				{
					int num = e.X - this.LSA.Width - this._ThumbSize / 2;
					int num2 = this.Shaft.Width - this._ThumbSize;
					this.ThumbMovement = (int)Math.Round(unchecked((double)num / (double)num2 * (double)(checked(this._Maximum - this._Minimum)))) + this._Minimum;
					this.Value = Math.Min(Math.Max(this.ThumbMovement, this._Minimum), this._Maximum);
					this.InvalidatePosition();
				}
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00003FB9 File Offset: 0x000021B9
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.ThumbDown = false;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0001BD78 File Offset: 0x00019F78
		public LogInHorizontalScrollBar()
		{
			this._ThumbSize = 24;
			this._Minimum = 0;
			this._Maximum = 100;
			this._Value = 0;
			this._SmallChange = 1;
			this._ButtonSize = 16;
			this._LargeChange = 10;
			this._ThumbBorder = Color.FromArgb(35, 35, 35);
			this._LineColour = Color.FromArgb(23, 119, 151);
			this._ArrowColour = Color.FromArgb(37, 37, 37);
			this._BaseColour = Color.FromArgb(47, 47, 47);
			this._ThumbColour = Color.FromArgb(55, 55, 55);
			this._ThumbSecondBorder = Color.FromArgb(65, 65, 65);
			this._FirstBorder = Color.FromArgb(55, 55, 55);
			this._SecondBorder = Color.FromArgb(35, 35, 35);
			this.ThumbDown = false;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Height = 18;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0001BE70 File Offset: 0x0001A070
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Width);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(Color.FromArgb(47, 47, 47));
			checked
			{
				Point[] points = new Point[]
				{
					new Point(5, (int)Math.Round((double)base.Height / 2.0)),
					new Point(13, (int)Math.Round((double)base.Height / 4.0)),
					new Point(13, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))),
					new Point(base.Width - 13, (int)Math.Round(unchecked((double)base.Height / 2.0 - 2.0))),
					new Point(base.Width - 13, (int)Math.Round((double)base.Height / 4.0)),
					new Point(base.Width - 5, (int)Math.Round((double)base.Height / 2.0)),
					new Point(base.Width - 13, (int)Math.Round(unchecked((double)base.Height - (double)base.Height / 4.0 - 1.0))),
					new Point(base.Width - 13, (int)Math.Round(unchecked((double)base.Height / 2.0 + 2.0))),
					new Point(13, (int)Math.Round(unchecked((double)base.Height / 2.0 + 2.0))),
					new Point(13, (int)Math.Round(unchecked((double)base.Height - (double)base.Height / 4.0 - 1.0)))
				};
				graphics2.FillPolygon(new SolidBrush(this._ArrowColour), points);
				graphics2.FillRectangle(new SolidBrush(this._ThumbColour), this.Thumb);
				graphics2.DrawRectangle(new Pen(this._ThumbBorder), this.Thumb);
				graphics2.DrawRectangle(new Pen(this._ThumbSecondBorder), this.Thumb.X + 1, this.Thumb.Y + 1, this.Thumb.Width - 2, this.Thumb.Height - 2);
				graphics2.DrawLine(new Pen(this._LineColour, 2f), new Point(this.Thumb.X + 4, (int)Math.Round(unchecked((double)this.Thumb.Height / 2.0 + 1.0))), new Point(this.Thumb.Right - 4, (int)Math.Round(unchecked((double)this.Thumb.Height / 2.0 + 1.0))));
				graphics2.DrawRectangle(new Pen(this._FirstBorder), 0, 0, base.Width - 1, base.Height - 1);
				graphics2.DrawRectangle(new Pen(this._SecondBorder), 1, 1, base.Width - 3, base.Height - 3);
				base.OnPaint(e);
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x04000251 RID: 593
		private int ThumbMovement;

		// Token: 0x04000252 RID: 594
		private Rectangle LSA;

		// Token: 0x04000253 RID: 595
		private Rectangle RSA;

		// Token: 0x04000254 RID: 596
		private Rectangle Shaft;

		// Token: 0x04000255 RID: 597
		private Rectangle Thumb;

		// Token: 0x04000256 RID: 598
		private bool ShowThumb;

		// Token: 0x04000257 RID: 599
		private bool ThumbPressed;

		// Token: 0x04000258 RID: 600
		private int _ThumbSize;

		// Token: 0x04000259 RID: 601
		private int _Minimum;

		// Token: 0x0400025A RID: 602
		private int _Maximum;

		// Token: 0x0400025B RID: 603
		private int _Value;

		// Token: 0x0400025C RID: 604
		private int _SmallChange;

		// Token: 0x0400025D RID: 605
		private int _ButtonSize;

		// Token: 0x0400025E RID: 606
		private int _LargeChange;

		// Token: 0x0400025F RID: 607
		private Color _ThumbBorder;

		// Token: 0x04000260 RID: 608
		private Color _LineColour;

		// Token: 0x04000261 RID: 609
		private Color _ArrowColour;

		// Token: 0x04000262 RID: 610
		private Color _BaseColour;

		// Token: 0x04000263 RID: 611
		private Color _ThumbColour;

		// Token: 0x04000264 RID: 612
		private Color _ThumbSecondBorder;

		// Token: 0x04000265 RID: 613
		private Color _FirstBorder;

		// Token: 0x04000266 RID: 614
		private Color _SecondBorder;

		// Token: 0x04000267 RID: 615
		private bool ThumbDown;

		// Token: 0x02000068 RID: 104
		// (Invoke) Token: 0x060006BD RID: 1725
		public delegate void ScrollEventHandler(object sender);
	}
}
