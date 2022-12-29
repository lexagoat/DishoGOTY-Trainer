using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000015 RID: 21
	internal class FlatProgressBar : Control
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00008578 File Offset: 0x00006778
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00008590 File Offset: 0x00006790
		[Category("Control")]
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
				this._Maximum = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000085C0 File Offset: 0x000067C0
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x000085E4 File Offset: 0x000067E4
		[Category("Control")]
		public int Value
		{
			get
			{
				int value = this._Value;
				int result;
				if (value != 0)
				{
					result = this._Value;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				int num = value;
				if (num > this._Maximum)
				{
					value = this._Maximum;
					base.Invalidate();
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x0000861C File Offset: 0x0000681C
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00002747 File Offset: 0x00000947
		[Category("Colors")]
		public Color ProgressColor
		{
			get
			{
				return this._ProgressColor;
			}
			set
			{
				this._ProgressColor = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00008634 File Offset: 0x00006834
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00002750 File Offset: 0x00000950
		[Category("Colors")]
		public Color DarkerProgress
		{
			get
			{
				return this._DarkerProgress;
			}
			set
			{
				this._DarkerProgress = value;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00002659 File Offset: 0x00000859
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 42;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00002759 File Offset: 0x00000959
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Height = 42;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00002769 File Offset: 0x00000969
		public void Increment(int Amount)
		{
			checked
			{
				this.Value += Amount;
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000864C File Offset: 0x0000684C
		public FlatProgressBar()
		{
			this._Value = 0;
			this._Maximum = 100;
			this._BaseColor = Color.FromArgb(60, 60, 60);
			this._ProgressColor = Color.FromArgb(0, 170, 220);
			this._DarkerProgress = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(50, 50, 50);
			base.Height = 30;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000086D8 File Offset: 0x000068D8
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				Rectangle rect = new Rectangle(0, 24, this.W, this.H);
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath path = new GraphicsPath();
				GraphicsPath path2 = new GraphicsPath();
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				int num = (int)Math.Round(unchecked((double)this._Value / (double)this._Maximum * (double)base.Width));
				int value = this.Value;
				if (value != 0)
				{
					if (value != 100)
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), rect);
						graphicsPath.AddRectangle(new Rectangle(0, 24, num - 1, this.H - 1));
						g.FillPath(new SolidBrush(this._ProgressColor), graphicsPath);
						HatchBrush brush = new HatchBrush(HatchStyle.Plaid, this._DarkerProgress, this._ProgressColor);
						g.FillRectangle(brush, new Rectangle(0, 24, num - 1, this.H - 1));
						Rectangle rectangle = new Rectangle(num - 18, 0, 34, 16);
						path = Helpers.RoundRec(rectangle, 4);
						g.FillPath(new SolidBrush(this._BaseColor), path);
						path2 = Helpers.DrawArrow(num - 9, 16, true);
						g.FillPath(new SolidBrush(this._BaseColor), path2);
						g.DrawString(Conversions.ToString(this.Value), new Font("Segoe UI", 10f), new SolidBrush(this._ProgressColor), new Rectangle(num - 11, -2, this.W, this.H), Helpers.NearSF);
					}
					else
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), rect);
						g.FillRectangle(new SolidBrush(this._ProgressColor), new Rectangle(0, 24, num - 1, this.H - 1));
					}
				}
				else
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), rect);
					g.FillRectangle(new SolidBrush(this._ProgressColor), new Rectangle(0, 24, num - 1, this.H - 1));
				}
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x0400006E RID: 110
		private int W;

		// Token: 0x0400006F RID: 111
		private int H;

		// Token: 0x04000070 RID: 112
		private int _Value;

		// Token: 0x04000071 RID: 113
		private int _Maximum;

		// Token: 0x04000072 RID: 114
		private Color _BaseColor;

		// Token: 0x04000073 RID: 115
		private Color _ProgressColor;

		// Token: 0x04000074 RID: 116
		private Color _DarkerProgress;
	}
}
