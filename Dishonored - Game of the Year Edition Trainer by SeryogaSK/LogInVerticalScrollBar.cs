using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000045 RID: 69
	[DefaultEvent("Scroll")]
	public class LogInVerticalScrollBar : Control
	{
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0001AD9C File Offset: 0x00018F9C
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x00003F10 File Offset: 0x00002110
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

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0001ADB4 File Offset: 0x00018FB4
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x00003F19 File Offset: 0x00002119
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

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0001ADCC File Offset: 0x00018FCC
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00003F22 File Offset: 0x00002122
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

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0001ADE4 File Offset: 0x00018FE4
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x00003F2B File Offset: 0x0000212B
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

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0001ADFC File Offset: 0x00018FFC
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x00003F34 File Offset: 0x00002134
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

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0001AE14 File Offset: 0x00019014
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x00003F3D File Offset: 0x0000213D
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

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0001AE2C File Offset: 0x0001902C
		// (set) Token: 0x060004B1 RID: 1201 RVA: 0x00003F46 File Offset: 0x00002146
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

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x0001AE44 File Offset: 0x00019044
		// (set) Token: 0x060004B3 RID: 1203 RVA: 0x00003F4F File Offset: 0x0000214F
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

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060004B4 RID: 1204 RVA: 0x0001AE5C File Offset: 0x0001905C
		// (remove) Token: 0x060004B5 RID: 1205 RVA: 0x0001AE94 File Offset: 0x00019094
		public event LogInVerticalScrollBar.ScrollEventHandler Scroll;

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0001AECC File Offset: 0x000190CC
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x0001AEE4 File Offset: 0x000190E4
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

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0001AF24 File Offset: 0x00019124
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0001AF3C File Offset: 0x0001913C
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

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x0001AF70 File Offset: 0x00019170
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x0001AF88 File Offset: 0x00019188
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
					LogInVerticalScrollBar.ScrollEventHandler scrollEvent = this.ScrollEvent;
					if (scrollEvent != null)
					{
						scrollEvent(this);
					}
				}
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x0001AFF4 File Offset: 0x000191F4
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x0001B00C File Offset: 0x0001920C
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

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0001B034 File Offset: 0x00019234
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x0001B04C File Offset: 0x0001924C
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

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0001B068 File Offset: 0x00019268
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x0001B080 File Offset: 0x00019280
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

		// Token: 0x060004C2 RID: 1218 RVA: 0x00003F58 File Offset: 0x00002158
		protected override void OnSizeChanged(EventArgs e)
		{
			this.InvalidateLayout();
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0001B0A8 File Offset: 0x000192A8
		private void InvalidateLayout()
		{
			this.TSA = new Rectangle(0, 1, base.Width, 0);
			checked
			{
				this.Shaft = new Rectangle(0, this.TSA.Bottom - 1, base.Width, base.Height - 3);
				this.ShowThumb = (this._Maximum - this._Minimum != 0);
				if (this.ShowThumb)
				{
					this.Thumb = new Rectangle(1, 0, base.Width - 3, this._ThumbSize);
				}
				LogInVerticalScrollBar.ScrollEventHandler scrollEvent = this.ScrollEvent;
				if (scrollEvent != null)
				{
					scrollEvent(this);
				}
				this.InvalidatePosition();
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0001B140 File Offset: 0x00019340
		private void InvalidatePosition()
		{
			this.Thumb.Y = checked((int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(checked(this.Shaft.Height - this._ThumbSize)) + 1.0)));
			base.Invalidate();
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0001B1A0 File Offset: 0x000193A0
		protected override void OnMouseDown(MouseEventArgs e)
		{
			checked
			{
				if (e.Button == MouseButtons.Left && this.ShowThumb)
				{
					if (this.TSA.Contains(e.Location))
					{
						this.ThumbMovement = this._Value - this._SmallChange;
					}
					else if (this.BSA.Contains(e.Location))
					{
						this.ThumbMovement = this._Value + this._SmallChange;
					}
					else
					{
						if (this.Thumb.Contains(e.Location))
						{
							this.ThumbPressed = true;
							return;
						}
						if (e.Y < this.Thumb.Y)
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

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001B29C File Offset: 0x0001949C
		protected override void OnMouseMove(MouseEventArgs e)
		{
			checked
			{
				if (this.ThumbPressed && this.ShowThumb)
				{
					int num = e.Y - this.TSA.Height - this._ThumbSize / 2;
					int num2 = this.Shaft.Height - this._ThumbSize;
					this.ThumbMovement = (int)Math.Round(unchecked((double)num / (double)num2 * (double)(checked(this._Maximum - this._Minimum)))) + this._Minimum;
					this.Value = Math.Min(Math.Max(this.ThumbMovement, this._Minimum), this._Maximum);
					this.InvalidatePosition();
				}
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00003F60 File Offset: 0x00002160
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.ThumbPressed = false;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0001B33C File Offset: 0x0001953C
		public LogInVerticalScrollBar()
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
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(24, 50);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0001B434 File Offset: 0x00019634
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Height, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this._BaseColour);
			checked
			{
				Point[] points = new Point[]
				{
					new Point((int)Math.Round((double)base.Width / 2.0), 5),
					new Point((int)Math.Round((double)base.Width / 4.0), 13),
					new Point((int)Math.Round(unchecked((double)base.Width / 2.0 - 2.0)), 13),
					new Point((int)Math.Round(unchecked((double)base.Width / 2.0 - 2.0)), base.Height - 13),
					new Point((int)Math.Round((double)base.Width / 4.0), base.Height - 13),
					new Point((int)Math.Round((double)base.Width / 2.0), base.Height - 5),
					new Point((int)Math.Round(unchecked((double)base.Width - (double)base.Width / 4.0 - 1.0)), base.Height - 13),
					new Point((int)Math.Round(unchecked((double)base.Width / 2.0 + 2.0)), base.Height - 13),
					new Point((int)Math.Round(unchecked((double)base.Width / 2.0 + 2.0)), 13),
					new Point((int)Math.Round(unchecked((double)base.Width - (double)base.Width / 4.0 - 1.0)), 13)
				};
				graphics2.FillPolygon(new SolidBrush(this._ArrowColour), points);
				graphics2.FillRectangle(new SolidBrush(this._ThumbColour), this.Thumb);
				graphics2.DrawRectangle(new Pen(this._ThumbBorder), this.Thumb);
				graphics2.DrawRectangle(new Pen(this._ThumbSecondBorder), this.Thumb.X + 1, this.Thumb.Y + 1, this.Thumb.Width - 2, this.Thumb.Height - 2);
				graphics2.DrawLine(new Pen(this._LineColour, 2f), new Point((int)Math.Round(unchecked((double)this.Thumb.Width / 2.0 + 1.0)), this.Thumb.Y + 4), new Point((int)Math.Round(unchecked((double)this.Thumb.Width / 2.0 + 1.0)), this.Thumb.Bottom - 4));
				graphics2.DrawRectangle(new Pen(this._FirstBorder), 0, 0, base.Width - 1, base.Height - 1);
				graphics2.DrawRectangle(new Pen(this._SecondBorder), 1, 1, base.Width - 3, base.Height - 3);
				base.OnPaint(e);
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x0400023A RID: 570
		private int ThumbMovement;

		// Token: 0x0400023B RID: 571
		private Rectangle TSA;

		// Token: 0x0400023C RID: 572
		private Rectangle BSA;

		// Token: 0x0400023D RID: 573
		private Rectangle Shaft;

		// Token: 0x0400023E RID: 574
		private Rectangle Thumb;

		// Token: 0x0400023F RID: 575
		private bool ShowThumb;

		// Token: 0x04000240 RID: 576
		private bool ThumbPressed;

		// Token: 0x04000241 RID: 577
		private int _ThumbSize;

		// Token: 0x04000242 RID: 578
		private int _Minimum;

		// Token: 0x04000243 RID: 579
		private int _Maximum;

		// Token: 0x04000244 RID: 580
		private int _Value;

		// Token: 0x04000245 RID: 581
		private int _SmallChange;

		// Token: 0x04000246 RID: 582
		private int _ButtonSize;

		// Token: 0x04000247 RID: 583
		private int _LargeChange;

		// Token: 0x04000248 RID: 584
		private Color _ThumbBorder;

		// Token: 0x04000249 RID: 585
		private Color _LineColour;

		// Token: 0x0400024A RID: 586
		private Color _ArrowColour;

		// Token: 0x0400024B RID: 587
		private Color _BaseColour;

		// Token: 0x0400024C RID: 588
		private Color _ThumbColour;

		// Token: 0x0400024D RID: 589
		private Color _ThumbSecondBorder;

		// Token: 0x0400024E RID: 590
		private Color _FirstBorder;

		// Token: 0x0400024F RID: 591
		private Color _SecondBorder;

		// Token: 0x02000067 RID: 103
		// (Invoke) Token: 0x060006B9 RID: 1721
		public delegate void ScrollEventHandler(object sender);
	}
}
