using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x0200001B RID: 27
	[DefaultEvent("Scroll")]
	internal class FlatTrackBar : Control
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00009E20 File Offset: 0x00008020
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				this.Val = checked((int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(checked(base.Width - 11)))));
				this.Track = new Rectangle(this.Val, 0, 10, 20);
				this.Bool = this.Track.Contains(e.Location);
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00009EA4 File Offset: 0x000080A4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			checked
			{
				if (this.Bool && e.X > -1 && e.X < base.Width + 1)
				{
					this.Value = this._Minimum + (int)Math.Round(unchecked((double)(checked(this._Maximum - this._Minimum)) * ((double)e.X / (double)base.Width)));
				}
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000298C File Offset: 0x00000B8C
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Bool = false;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00009F10 File Offset: 0x00008110
		// (set) Token: 0x06000122 RID: 290 RVA: 0x0000299C File Offset: 0x00000B9C
		public FlatTrackBar._Style Style
		{
			get
			{
				return this.Style_;
			}
			set
			{
				this.Style_ = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00009F28 File Offset: 0x00008128
		// (set) Token: 0x06000124 RID: 292 RVA: 0x000029A5 File Offset: 0x00000BA5
		[Category("Colors")]
		public Color TrackColor
		{
			get
			{
				return this._TrackColor;
			}
			set
			{
				this._TrackColor = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00009F40 File Offset: 0x00008140
		// (set) Token: 0x06000126 RID: 294 RVA: 0x000029AE File Offset: 0x00000BAE
		[Category("Colors")]
		public Color HatchColor
		{
			get
			{
				return this._HatchColor;
			}
			set
			{
				this._HatchColor = value;
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000127 RID: 295 RVA: 0x00009F58 File Offset: 0x00008158
		// (remove) Token: 0x06000128 RID: 296 RVA: 0x00009F90 File Offset: 0x00008190
		public event FlatTrackBar.ScrollEventHandler Scroll;

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00009FC8 File Offset: 0x000081C8
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00009FD8 File Offset: 0x000081D8
		public int Minimum
		{
			get
			{
				return 0;
			}
			set
			{
				if (value >= 0)
				{
				}
				this._Minimum = value;
				if (value > this._Value)
				{
					this._Value = value;
				}
				if (value > this._Maximum)
				{
					this._Maximum = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600012B RID: 299 RVA: 0x0000A01C File Offset: 0x0000821C
		// (set) Token: 0x0600012C RID: 300 RVA: 0x0000A034 File Offset: 0x00008234
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value >= 0)
				{
				}
				this._Maximum = value;
				if (value < this._Value)
				{
					this._Value = value;
				}
				if (value < this._Minimum)
				{
					this._Minimum = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600012D RID: 301 RVA: 0x0000A078 File Offset: 0x00008278
		// (set) Token: 0x0600012E RID: 302 RVA: 0x0000A090 File Offset: 0x00008290
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
					if (value <= this._Maximum && value >= this._Minimum)
					{
					}
					this._Value = value;
					base.Invalidate();
					FlatTrackBar.ScrollEventHandler scrollEvent = this.ScrollEvent;
					if (scrollEvent != null)
					{
						scrollEvent(this);
					}
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600012F RID: 303 RVA: 0x0000A0E0 File Offset: 0x000082E0
		// (set) Token: 0x06000130 RID: 304 RVA: 0x000029B7 File Offset: 0x00000BB7
		public bool ShowValue
		{
			get
			{
				return this._ShowValue;
			}
			set
			{
				this._ShowValue = value;
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000A0F4 File Offset: 0x000082F4
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			checked
			{
				if (e.KeyCode == Keys.Subtract)
				{
					if (this.Value != 0)
					{
						this.Value--;
					}
				}
				else if (e.KeyCode == Keys.Add && this.Value != this._Maximum)
				{
					this.Value++;
				}
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000029C0 File Offset: 0x00000BC0
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 23;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000A15C File Offset: 0x0000835C
		public FlatTrackBar()
		{
			this._Maximum = 10;
			this._ShowValue = false;
			this.BaseColor = Color.FromArgb(60, 60, 60);
			this._TrackColor = Color.FromArgb(0, 170, 220);
			this.SliderColor = Color.FromArgb(75, 75, 75);
			this._HatchColor = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Height = 18;
			this.BackColor = Color.FromArgb(50, 50, 50);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000A1F8 File Offset: 0x000083F8
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				Rectangle rect = new Rectangle(1, 6, this.W - 2, 8);
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				this.Val = (int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(checked(this.W - 10))));
				this.Track = new Rectangle(this.Val, 0, 10, 20);
				this.Knob = new Rectangle(this.Val, 4, 11, 14);
				graphicsPath.AddRectangle(rect);
				g.SetClip(graphicsPath);
				g.FillRectangle(new SolidBrush(this.BaseColor), new Rectangle(0, 7, this.W, 8));
				g.FillRectangle(new SolidBrush(this._TrackColor), new Rectangle(0, 7, this.Track.X + this.Track.Width, 8));
				g.ResetClip();
				HatchBrush brush = new HatchBrush(HatchStyle.Plaid, this.HatchColor, this._TrackColor);
				g.FillRectangle(brush, new Rectangle(-10, 7, this.Track.X + this.Track.Width, 8));
				FlatTrackBar._Style style = this.Style;
				if (style != FlatTrackBar._Style.Slider)
				{
					if (style == FlatTrackBar._Style.Knob)
					{
						graphicsPath2.AddEllipse(this.Knob);
						g.FillPath(new SolidBrush(this.SliderColor), graphicsPath2);
					}
				}
				else
				{
					graphicsPath2.AddRectangle(this.Track);
					g.FillPath(new SolidBrush(this.SliderColor), graphicsPath2);
				}
				if (this.ShowValue)
				{
					g.DrawString(Conversions.ToString(this.Value), new Font("Segoe UI", 8f), Brushes.White, new Rectangle(1, 6, this.W, this.H), new StringFormat
					{
						Alignment = StringAlignment.Far,
						LineAlignment = StringAlignment.Far
					});
				}
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x04000093 RID: 147
		private int W;

		// Token: 0x04000094 RID: 148
		private int H;

		// Token: 0x04000095 RID: 149
		private int Val;

		// Token: 0x04000096 RID: 150
		private bool Bool;

		// Token: 0x04000097 RID: 151
		private Rectangle Track;

		// Token: 0x04000098 RID: 152
		private Rectangle Knob;

		// Token: 0x04000099 RID: 153
		private FlatTrackBar._Style Style_;

		// Token: 0x0400009B RID: 155
		private int _Minimum;

		// Token: 0x0400009C RID: 156
		private int _Maximum;

		// Token: 0x0400009D RID: 157
		private int _Value;

		// Token: 0x0400009E RID: 158
		private bool _ShowValue;

		// Token: 0x0400009F RID: 159
		private Color BaseColor;

		// Token: 0x040000A0 RID: 160
		private Color _TrackColor;

		// Token: 0x040000A1 RID: 161
		private Color SliderColor;

		// Token: 0x040000A2 RID: 162
		private Color _HatchColor;

		// Token: 0x0200005A RID: 90
		[Flags]
		public enum _Style
		{
			// Token: 0x0400030E RID: 782
			Slider = 0,
			// Token: 0x0400030F RID: 783
			Knob = 1
		}

		// Token: 0x0200005B RID: 91
		// (Invoke) Token: 0x060006A1 RID: 1697
		public delegate void ScrollEventHandler(object sender);
	}
}
