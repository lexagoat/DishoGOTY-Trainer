using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000031 RID: 49
	[DefaultEvent("CheckedChanged")]
	public class LogInCheckBox : Control
	{
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000329 RID: 809 RVA: 0x000153A0 File Offset: 0x000135A0
		// (set) Token: 0x0600032A RID: 810 RVA: 0x000036C8 File Offset: 0x000018C8
		[Category("Colours")]
		public Color BaseColour
		{
			get
			{
				return this._BackColour;
			}
			set
			{
				this._BackColour = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600032B RID: 811 RVA: 0x000153B8 File Offset: 0x000135B8
		// (set) Token: 0x0600032C RID: 812 RVA: 0x000036D1 File Offset: 0x000018D1
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

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600032D RID: 813 RVA: 0x000153D0 File Offset: 0x000135D0
		// (set) Token: 0x0600032E RID: 814 RVA: 0x000036DA File Offset: 0x000018DA
		[Category("Colours")]
		public Color CheckedColour
		{
			get
			{
				return this._CheckedColour;
			}
			set
			{
				this._CheckedColour = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600032F RID: 815 RVA: 0x000153E8 File Offset: 0x000135E8
		// (set) Token: 0x06000330 RID: 816 RVA: 0x000036E3 File Offset: 0x000018E3
		[Category("Colours")]
		public Color FontColour
		{
			get
			{
				return this._TextColour;
			}
			set
			{
				this._TextColour = value;
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00015400 File Offset: 0x00013600
		// (set) Token: 0x06000333 RID: 819 RVA: 0x000036EC File Offset: 0x000018EC
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

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000334 RID: 820 RVA: 0x00015414 File Offset: 0x00013614
		// (remove) Token: 0x06000335 RID: 821 RVA: 0x0001544C File Offset: 0x0001364C
		public event LogInCheckBox.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x06000336 RID: 822 RVA: 0x00015484 File Offset: 0x00013684
		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			LogInCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
			if (checkedChangedEvent != null)
			{
				checkedChangedEvent(this);
			}
			base.OnClick(e);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00002484 File Offset: 0x00000684
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 22;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x000036FB File Offset: 0x000018FB
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00003711 File Offset: 0x00001911
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00003727 File Offset: 0x00001927
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000373D File Offset: 0x0000193D
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x000154B8 File Offset: 0x000136B8
		public LogInCheckBox()
		{
			this.State = MouseState.None;
			this._CheckedColour = Color.FromArgb(173, 173, 174);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._BackColour = Color.FromArgb(42, 42, 42);
			this._TextColour = Color.FromArgb(255, 255, 255);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Cursor = Cursors.Hand;
			base.Size = new Size(100, 22);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00015558 File Offset: 0x00013758
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, 20, 20);
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BackColour), rect);
			graphics2.DrawRectangle(new Pen(this._BorderColour), new Rectangle(1, 1, 18, 18));
			MouseState state = this.State;
			if (state == MouseState.Over)
			{
				graphics2.FillRectangle(new SolidBrush(Color.FromArgb(50, 49, 51)), rect);
				graphics2.DrawRectangle(new Pen(this._BorderColour), new Rectangle(1, 1, 18, 18));
			}
			if (this.Checked)
			{
				Point[] points = new Point[]
				{
					new Point(4, 11),
					new Point(6, 8),
					new Point(9, 12),
					new Point(15, 3),
					new Point(17, 6),
					new Point(9, 16)
				};
				graphics2.FillPolygon(new SolidBrush(this._CheckedColour), points);
			}
			graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(24, 1, base.Width, base.Height), new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near
			});
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040001AE RID: 430
		private bool _Checked;

		// Token: 0x040001AF RID: 431
		private MouseState State;

		// Token: 0x040001B0 RID: 432
		private Color _CheckedColour;

		// Token: 0x040001B1 RID: 433
		private Color _BorderColour;

		// Token: 0x040001B2 RID: 434
		private Color _BackColour;

		// Token: 0x040001B3 RID: 435
		private Color _TextColour;

		// Token: 0x0200005E RID: 94
		// (Invoke) Token: 0x060006A9 RID: 1705
		public delegate void CheckedChangedEventHandler(object sender);
	}
}
