using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000044 RID: 68
	public class LogInTrackBar : Control
	{
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x0001A5B0 File Offset: 0x000187B0
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x00003EAF File Offset: 0x000020AF
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

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x0001A5C8 File Offset: 0x000187C8
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x00003EB8 File Offset: 0x000020B8
		[Category("Colours")]
		public Color BarBaseColour
		{
			get
			{
				return this._BarBaseColour;
			}
			set
			{
				this._BarBaseColour = value;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0001A5E0 File Offset: 0x000187E0
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x00003EC1 File Offset: 0x000020C1
		[Category("Colours")]
		public Color StripColour
		{
			get
			{
				return this._StripColour;
			}
			set
			{
				this._StripColour = value;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x0001A5F8 File Offset: 0x000187F8
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x00003ECA File Offset: 0x000020CA
		[Category("Colours")]
		public Color TextColour
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

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0001A610 File Offset: 0x00018810
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x00003ED3 File Offset: 0x000020D3
		[Category("Colours")]
		public Color StripAmountColour
		{
			get
			{
				return this._StripAmountColour;
			}
			set
			{
				this._StripAmountColour = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0001A628 File Offset: 0x00018828
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x0001A640 File Offset: 0x00018840
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value > 0)
				{
					this._Maximum = value;
				}
				if (value < this._Value)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000499 RID: 1177 RVA: 0x0001A674 File Offset: 0x00018874
		// (remove) Token: 0x0600049A RID: 1178 RVA: 0x0001A6AC File Offset: 0x000188AC
		public event LogInTrackBar.ValueChangedEventHandler ValueChanged;

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0001A6E4 File Offset: 0x000188E4
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x0001A6FC File Offset: 0x000188FC
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
					if (value < 0)
					{
						this._Value = 0;
					}
					else if (value > this._Maximum)
					{
						this._Value = this._Maximum;
					}
					else
					{
						this._Value = value;
					}
					base.Invalidate();
					LogInTrackBar.ValueChangedEventHandler valueChangedEvent = this.ValueChangedEvent;
					if (valueChangedEvent != null)
					{
						valueChangedEvent();
					}
				}
			}
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00003EDC File Offset: 0x000020DC
		protected override void OnHandleCreated(EventArgs e)
		{
			this.BackColor = Color.Transparent;
			base.OnHandleCreated(e);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0001A75C File Offset: 0x0001895C
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			Rectangle rect = new Rectangle(new Point(e.Location.X, e.Location.Y), new Size(1, 1));
			checked
			{
				Rectangle rectangle = new Rectangle(10, 10, base.Width - 21, base.Height - 21);
				if (new Rectangle(new Point(rectangle.X + (int)Math.Round(unchecked((double)rectangle.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round(unchecked((double)this.Track.Width / 2.0 - 1.0)), 0), new Size(this.Track.Width, base.Height)).IntersectsWith(rect))
				{
					this.CaptureMovement = true;
				}
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00003EF0 File Offset: 0x000020F0
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.CaptureMovement = false;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0001A840 File Offset: 0x00018A40
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			checked
			{
				if (this.CaptureMovement)
				{
					Point point = new Point(e.X, e.Y);
					Rectangle rectangle = new Rectangle(10, 10, base.Width - 21, base.Height - 21);
					this.Value = (int)Math.Round(unchecked((double)this.Maximum * ((double)(checked(point.X - rectangle.X)) / (double)rectangle.Width)));
				}
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00003F00 File Offset: 0x00002100
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.CaptureMovement = false;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0001A8BC File Offset: 0x00018ABC
		public LogInTrackBar()
		{
			this._Maximum = 10;
			this._Value = 0;
			this.CaptureMovement = false;
			this.Bar = checked(new Rectangle(0, 10, base.Width - 21, base.Height - 21));
			this.Track = new Size(25, 14);
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._BarBaseColour = Color.FromArgb(47, 47, 47);
			this._StripColour = Color.FromArgb(42, 42, 42);
			this._StripAmountColour = Color.FromArgb(23, 119, 151);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0001A988 File Offset: 0x00018B88
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			checked
			{
				this.Bar = new Rectangle(13, 11, base.Width - 27, base.Height - 21);
				graphics2.Clear(base.Parent.FindForm().BackColor);
				graphics2.SmoothingMode = SmoothingMode.AntiAlias;
				graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				graphics2.FillRectangle(new SolidBrush(this._StripColour), new Rectangle(3, (int)Math.Round(unchecked((double)base.Height / 2.0 - 4.0)), base.Width - 5, 8));
				graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), new Rectangle(4, (int)Math.Round(unchecked((double)base.Height / 2.0 - 4.0)), base.Width - 5, 8));
				graphics2.FillRectangle(new SolidBrush(this._StripAmountColour), new Rectangle(4, (int)Math.Round(unchecked((double)base.Height / 2.0 - 4.0)), (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.Value / (double)this.Maximum))) + (int)Math.Round((double)this.Track.Width / 2.0), 8));
				graphics2.FillRectangle(new SolidBrush(this._BarBaseColour), this.Bar.X + (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.Track.Width / 2.0), this.Bar.Y + (int)Math.Round((double)this.Bar.Height / 2.0) - (int)Math.Round((double)this.Track.Height / 2.0), this.Track.Width, this.Track.Height);
				graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), this.Bar.X + (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.Track.Width / 2.0), this.Bar.Y + (int)Math.Round((double)this.Bar.Height / 2.0) - (int)Math.Round((double)this.Track.Height / 2.0), this.Track.Width, this.Track.Height);
				graphics2.DrawString(Conversions.ToString(this._Value), new Font("Segoe UI", 6.5f, FontStyle.Regular), new SolidBrush(this._TextColour), new Rectangle(this.Bar.X + (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.Track.Width / 2.0), this.Bar.Y + (int)Math.Round((double)this.Bar.Height / 2.0) - (int)Math.Round((double)this.Track.Height / 2.0), this.Track.Width - 1, this.Track.Height), new StringFormat
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				});
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x0400022F RID: 559
		private int _Maximum;

		// Token: 0x04000230 RID: 560
		private int _Value;

		// Token: 0x04000231 RID: 561
		private bool CaptureMovement;

		// Token: 0x04000232 RID: 562
		private Rectangle Bar;

		// Token: 0x04000233 RID: 563
		private Size Track;

		// Token: 0x04000234 RID: 564
		private Color _TextColour;

		// Token: 0x04000235 RID: 565
		private Color _BorderColour;

		// Token: 0x04000236 RID: 566
		private Color _BarBaseColour;

		// Token: 0x04000237 RID: 567
		private Color _StripColour;

		// Token: 0x04000238 RID: 568
		private Color _StripAmountColour;

		// Token: 0x02000066 RID: 102
		// (Invoke) Token: 0x060006B5 RID: 1717
		public delegate void ValueChangedEventHandler();
	}
}
