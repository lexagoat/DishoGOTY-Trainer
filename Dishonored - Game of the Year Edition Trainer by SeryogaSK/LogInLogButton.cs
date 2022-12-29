using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000030 RID: 48
	public class LogInLogButton : Control
	{
		// Token: 0x06000314 RID: 788 RVA: 0x00003619 File Offset: 0x00001819
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000362F File Offset: 0x0000182F
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00003645 File Offset: 0x00001845
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000365B File Offset: 0x0000185B
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000318 RID: 792 RVA: 0x00014EA0 File Offset: 0x000130A0
		// (set) Token: 0x06000319 RID: 793 RVA: 0x00003671 File Offset: 0x00001871
		[Category("Colours")]
		public Color ArcColour
		{
			get
			{
				return this._ArcColour;
			}
			set
			{
				this._ArcColour = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00014EB8 File Offset: 0x000130B8
		// (set) Token: 0x0600031B RID: 795 RVA: 0x0000367A File Offset: 0x0000187A
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

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00014ED0 File Offset: 0x000130D0
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00003683 File Offset: 0x00001883
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

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00014EE8 File Offset: 0x000130E8
		// (set) Token: 0x0600031F RID: 799 RVA: 0x0000368C File Offset: 0x0000188C
		[Category("Colours")]
		public Color ArrowBorderColour
		{
			get
			{
				return this._ArrowBorderColour;
			}
			set
			{
				this._ArrowBorderColour = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00014F00 File Offset: 0x00013100
		// (set) Token: 0x06000321 RID: 801 RVA: 0x00003695 File Offset: 0x00001895
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

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00014F18 File Offset: 0x00013118
		// (set) Token: 0x06000323 RID: 803 RVA: 0x0000369E File Offset: 0x0000189E
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000324 RID: 804 RVA: 0x00014F30 File Offset: 0x00013130
		// (set) Token: 0x06000325 RID: 805 RVA: 0x000036A7 File Offset: 0x000018A7
		[Category("Colours")]
		public Color NormalColour
		{
			get
			{
				return this._NormalColour;
			}
			set
			{
				this._NormalColour = value;
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x000036B0 File Offset: 0x000018B0
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new Size(50, 50);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00014F48 File Offset: 0x00013148
		public LogInLogButton()
		{
			this.State = MouseState.None;
			this._ArcColour = Color.FromArgb(43, 43, 43);
			this._ArrowColour = Color.FromArgb(235, 233, 234);
			this._ArrowBorderColour = Color.FromArgb(170, 170, 170);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._HoverColour = Color.FromArgb(0, 130, 169);
			this._PressedColour = Color.FromArgb(0, 145, 184);
			this._NormalColour = Color.FromArgb(0, 160, 199);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(50, 50);
			this.BackColor = Color.Transparent;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00015028 File Offset: 0x00013228
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Height, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			new GraphicsPath();
			new GraphicsPath();
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			Point[] points = new Point[]
			{
				new Point(18, 22),
				new Point(28, 22),
				new Point(28, 18),
				new Point(34, 25),
				new Point(28, 32),
				new Point(28, 28),
				new Point(18, 28)
			};
			checked
			{
				switch (this.State)
				{
				case MouseState.None:
					graphics2.FillEllipse(new SolidBrush(Color.FromArgb(56, 56, 56)), new Rectangle(3, 3, base.Width - 3 - 3, base.Height - 3 - 3));
					graphics2.DrawArc(new Pen(new SolidBrush(this._ArcColour), 4f), 3, 3, base.Width - 3 - 3, base.Height - 3 - 3, -90, 360);
					graphics2.DrawEllipse(new Pen(this._BorderColour), new Rectangle(1, 1, base.Height - 3, base.Height - 3));
					graphics2.FillEllipse(new SolidBrush(this._NormalColour), new Rectangle(5, 5, base.Height - 11, base.Height - 11));
					graphics2.FillPolygon(new SolidBrush(this._ArrowColour), points);
					graphics2.DrawPolygon(new Pen(this._ArrowBorderColour), points);
					break;
				case MouseState.Over:
					graphics2.DrawArc(new Pen(new SolidBrush(this._ArcColour), 4f), 3, 3, base.Width - 3 - 3, base.Height - 3 - 3, -90, 360);
					graphics2.DrawEllipse(new Pen(this._BorderColour), new Rectangle(1, 1, base.Height - 3, base.Height - 3));
					graphics2.FillEllipse(new SolidBrush(this._HoverColour), new Rectangle(6, 6, base.Height - 13, base.Height - 13));
					graphics2.FillPolygon(new SolidBrush(this._ArrowColour), points);
					graphics2.DrawPolygon(new Pen(this._ArrowBorderColour), points);
					break;
				case MouseState.Down:
					graphics2.DrawArc(new Pen(new SolidBrush(this._ArcColour), 4f), 3, 3, base.Width - 3 - 3, base.Height - 3 - 3, -90, 360);
					graphics2.DrawEllipse(new Pen(this._BorderColour), new Rectangle(1, 1, base.Height - 3, base.Height - 3));
					graphics2.FillEllipse(new SolidBrush(this._PressedColour), new Rectangle(6, 6, base.Height - 13, base.Height - 13));
					graphics2.FillPolygon(new SolidBrush(this._ArrowColour), points);
					graphics2.DrawPolygon(new Pen(this._ArrowBorderColour), points);
					break;
				}
				base.OnPaint(e);
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001A6 RID: 422
		private MouseState State;

		// Token: 0x040001A7 RID: 423
		private Color _ArcColour;

		// Token: 0x040001A8 RID: 424
		private Color _ArrowColour;

		// Token: 0x040001A9 RID: 425
		private Color _ArrowBorderColour;

		// Token: 0x040001AA RID: 426
		private Color _BorderColour;

		// Token: 0x040001AB RID: 427
		private Color _HoverColour;

		// Token: 0x040001AC RID: 428
		private Color _PressedColour;

		// Token: 0x040001AD RID: 429
		private Color _NormalColour;
	}
}
