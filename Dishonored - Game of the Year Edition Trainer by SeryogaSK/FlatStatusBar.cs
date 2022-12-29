using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x0200001C RID: 28
	internal class FlatStatusBar : Control
	{
		// Token: 0x06000136 RID: 310 RVA: 0x000029D1 File Offset: 0x00000BD1
		protected override void CreateHandle()
		{
			base.CreateHandle();
			this.Dock = DockStyle.Bottom;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000138 RID: 312 RVA: 0x0000A470 File Offset: 0x00008670
		// (set) Token: 0x06000139 RID: 313 RVA: 0x000029E0 File Offset: 0x00000BE0
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600013A RID: 314 RVA: 0x0000A488 File Offset: 0x00008688
		// (set) Token: 0x0600013B RID: 315 RVA: 0x000029E9 File Offset: 0x00000BE9
		[Category("Colors")]
		public Color TextColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600013C RID: 316 RVA: 0x0000A4A0 File Offset: 0x000086A0
		// (set) Token: 0x0600013D RID: 317 RVA: 0x000029F2 File Offset: 0x00000BF2
		[Category("Colors")]
		public Color RectColor
		{
			get
			{
				return this._RectColor;
			}
			set
			{
				this._RectColor = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600013E RID: 318 RVA: 0x0000A4B8 File Offset: 0x000086B8
		// (set) Token: 0x0600013F RID: 319 RVA: 0x000029FB File Offset: 0x00000BFB
		public bool ShowTimeDate
		{
			get
			{
				return this._ShowTimeDate;
			}
			set
			{
				this._ShowTimeDate = value;
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000A4CC File Offset: 0x000086CC
		public string GetTimeDate()
		{
			return string.Concat(new string[]
			{
				Conversions.ToString(DateTime.Now.Date),
				" ",
				Conversions.ToString(DateTime.Now.Hour),
				":",
				Conversions.ToString(DateTime.Now.Minute)
			});
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000A538 File Offset: 0x00008738
		public FlatStatusBar()
		{
			this._ShowTimeDate = false;
			this._BaseColor = Color.FromArgb(50, 50, 50);
			this._TextColor = Color.White;
			this._RectColor = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = Color.White;
			base.Size = new Size(base.Width, 20);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000A5CC File Offset: 0x000087CC
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BaseColor);
			g.FillRectangle(new SolidBrush(this.BaseColor), rect);
			g.DrawString(this.Text, this.Font, Brushes.White, new Rectangle(10, 4, this.W, this.H), Helpers.NearSF);
			g.FillRectangle(new SolidBrush(this._RectColor), new Rectangle(4, 4, 4, 14));
			if (this.ShowTimeDate)
			{
				g.DrawString(this.GetTimeDate(), this.Font, new SolidBrush(this._TextColor), new Rectangle(-4, 2, this.W, this.H), new StringFormat
				{
					Alignment = StringAlignment.Far,
					LineAlignment = StringAlignment.Center
				});
			}
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}

		// Token: 0x040000A3 RID: 163
		private int W;

		// Token: 0x040000A4 RID: 164
		private int H;

		// Token: 0x040000A5 RID: 165
		private bool _ShowTimeDate;

		// Token: 0x040000A6 RID: 166
		private Color _BaseColor;

		// Token: 0x040000A7 RID: 167
		private Color _TextColor;

		// Token: 0x040000A8 RID: 168
		private Color _RectColor;
	}
}
