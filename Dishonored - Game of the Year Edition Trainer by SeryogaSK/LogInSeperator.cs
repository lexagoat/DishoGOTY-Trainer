using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000038 RID: 56
	public class LogInSeperator : Control
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060003AE RID: 942 RVA: 0x000171CC File Offset: 0x000153CC
		// (set) Token: 0x060003AF RID: 943 RVA: 0x0000399D File Offset: 0x00001B9D
		[Category("Control")]
		public float Thickness
		{
			get
			{
				return this._Thickness;
			}
			set
			{
				this._Thickness = value;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x000171E4 File Offset: 0x000153E4
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x000039A6 File Offset: 0x00001BA6
		[Category("Control")]
		public LogInSeperator.Style Alignment
		{
			get
			{
				return this._Alignment;
			}
			set
			{
				this._Alignment = value;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x000171FC File Offset: 0x000153FC
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x000039AF File Offset: 0x00001BAF
		[Category("Colours")]
		public Color SeperatorColour
		{
			get
			{
				return this._SeperatorColour;
			}
			set
			{
				this._SeperatorColour = value;
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00017214 File Offset: 0x00015414
		public LogInSeperator()
		{
			this._SeperatorColour = Color.FromArgb(35, 35, 35);
			this._Alignment = LogInSeperator.Style.Horizontal;
			this._Thickness = 1f;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.Size = new Size(20, 20);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00017278 File Offset: 0x00015478
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			checked
			{
				Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
				Graphics graphics2 = graphics;
				graphics2.SmoothingMode = SmoothingMode.HighQuality;
				graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
				LogInSeperator.Style alignment = this._Alignment;
				if (alignment != LogInSeperator.Style.Horizontal)
				{
					if (alignment == LogInSeperator.Style.Verticle)
					{
						graphics2.DrawLine(new Pen(this._SeperatorColour, this._Thickness), new Point((int)Math.Round((double)base.Width / 2.0), 0), new Point((int)Math.Round((double)base.Width / 2.0), base.Height));
					}
				}
				else
				{
					graphics2.DrawLine(new Pen(this._SeperatorColour, this._Thickness), new Point(0, (int)Math.Round((double)base.Height / 2.0)), new Point(base.Width, (int)Math.Round((double)base.Height / 2.0)));
				}
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001DF RID: 479
		private Color _SeperatorColour;

		// Token: 0x040001E0 RID: 480
		private LogInSeperator.Style _Alignment;

		// Token: 0x040001E1 RID: 481
		private float _Thickness;

		// Token: 0x02000061 RID: 97
		public enum Style
		{
			// Token: 0x04000319 RID: 793
			Horizontal,
			// Token: 0x0400031A RID: 794
			Verticle
		}
	}
}
