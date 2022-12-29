using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000037 RID: 55
	public class LogInGroupBox : ContainerControl
	{
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00016E5C File Offset: 0x0001505C
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00003979 File Offset: 0x00001B79
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

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00016E74 File Offset: 0x00015074
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00003982 File Offset: 0x00001B82
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

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x00016E8C File Offset: 0x0001508C
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x0000398B File Offset: 0x00001B8B
		[Category("Colours")]
		public Color HeaderColour
		{
			get
			{
				return this._HeaderColour;
			}
			set
			{
				this._HeaderColour = value;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00016EA4 File Offset: 0x000150A4
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00003994 File Offset: 0x00001B94
		[Category("Colours")]
		public Color MainColour
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

		// Token: 0x060003AC RID: 940 RVA: 0x00016EBC File Offset: 0x000150BC
		public LogInGroupBox()
		{
			this._MainColour = Color.FromArgb(47, 47, 47);
			this._HeaderColour = Color.FromArgb(42, 42, 42);
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(160, 110);
			this.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00016F58 File Offset: 0x00015158
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			checked
			{
				Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
				Rectangle rectangle2 = new Rectangle(8, 8, 10, 10);
				Graphics graphics2 = graphics;
				graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				graphics2.SmoothingMode = SmoothingMode.HighQuality;
				graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics2.Clear(this.BackColor);
				graphics2.FillRectangle(new SolidBrush(this._MainColour), new Rectangle(0, 28, base.Width, base.Height));
				graphics2.FillRectangle(new SolidBrush(this._HeaderColour), new Rectangle(0, 0, (int)Math.Round((double)(unchecked(graphics2.MeasureString(this.Text, this.Font).Width + 7f))), 28));
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Point(5, 5));
				Point[] points = new Point[]
				{
					new Point(0, 0),
					new Point((int)Math.Round((double)(unchecked(graphics2.MeasureString(this.Text, this.Font).Width + 7f))), 0),
					new Point((int)Math.Round((double)(unchecked(graphics2.MeasureString(this.Text, this.Font).Width + 7f))), 28),
					new Point(base.Width - 1, 28),
					new Point(base.Width - 1, base.Height - 1),
					new Point(1, base.Height - 1),
					new Point(1, 1)
				};
				graphics2.DrawLines(new Pen(this._BorderColour), points);
				graphics2.DrawLine(new Pen(this._BorderColour, 2f), new Point(0, 28), new Point((int)Math.Round((double)(unchecked(graphics2.MeasureString(this.Text, this.Font).Width + 7f))), 28));
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001DB RID: 475
		private Color _MainColour;

		// Token: 0x040001DC RID: 476
		private Color _HeaderColour;

		// Token: 0x040001DD RID: 477
		private Color _TextColour;

		// Token: 0x040001DE RID: 478
		private Color _BorderColour;
	}
}
