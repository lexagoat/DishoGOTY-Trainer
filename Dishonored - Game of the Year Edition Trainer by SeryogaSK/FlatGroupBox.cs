using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200000D RID: 13
	internal class FlatGroupBox : ContainerControl
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00005A5C File Offset: 0x00003C5C
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002356 File Offset: 0x00000556
		[Category("Colors")]
		public Color BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00005A74 File Offset: 0x00003C74
		// (set) Token: 0x06000052 RID: 82 RVA: 0x0000235F File Offset: 0x0000055F
		public bool ShowText
		{
			get
			{
				return this._ShowText;
			}
			set
			{
				this._ShowText = value;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00005A88 File Offset: 0x00003C88
		public FlatGroupBox()
		{
			this._ShowText = true;
			this._BaseColor = Color.FromArgb(60, 60, 60);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.Size = new Size(240, 180);
			this.Font = new Font("Segoe ui", 10f);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00005AFC File Offset: 0x00003CFC
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				GraphicsPath path = new GraphicsPath();
				GraphicsPath path2 = new GraphicsPath();
				GraphicsPath path3 = new GraphicsPath();
				Rectangle rectangle = new Rectangle(8, 8, this.W - 16, this.H - 16);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				path = Helpers.RoundRec(rectangle, 8);
				g.FillPath(new SolidBrush(this._BaseColor), path);
				path2 = Helpers.DrawArrow(28, 2, false);
				g.FillPath(new SolidBrush(this._BaseColor), path2);
				path3 = Helpers.DrawArrow(28, 8, true);
				g.FillPath(new SolidBrush(Color.FromArgb(60, 70, 73)), path3);
				if (this.ShowText)
				{
					g.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(0, 170, 220)), new Rectangle(16, 16, this.W, this.H), Helpers.NearSF);
				}
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x04000029 RID: 41
		private int W;

		// Token: 0x0400002A RID: 42
		private int H;

		// Token: 0x0400002B RID: 43
		private bool _ShowText;

		// Token: 0x0400002C RID: 44
		private Color _BaseColor;
	}
}
