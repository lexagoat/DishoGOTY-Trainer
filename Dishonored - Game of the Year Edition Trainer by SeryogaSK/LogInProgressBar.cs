using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200003E RID: 62
	public class LogInProgressBar : Control
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x00018744 File Offset: 0x00016944
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x00003C0D File Offset: 0x00001E0D
		public Color SecondColour
		{
			get
			{
				return this._SecondColour;
			}
			set
			{
				this._SecondColour = value;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x0001875C File Offset: 0x0001695C
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x00003C16 File Offset: 0x00001E16
		[Category("Control")]
		public bool TwoColour
		{
			get
			{
				return this._TwoColour;
			}
			set
			{
				this._TwoColour = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x00018770 File Offset: 0x00016970
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x00018788 File Offset: 0x00016988
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

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x000187B8 File Offset: 0x000169B8
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x000187DC File Offset: 0x000169DC
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

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00018814 File Offset: 0x00016A14
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x00003C1F File Offset: 0x00001E1F
		[Category("Colours")]
		public Color ProgressColour
		{
			get
			{
				return this._ProgressColour;
			}
			set
			{
				this._ProgressColour = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x0001882C File Offset: 0x00016A2C
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x00003C28 File Offset: 0x00001E28
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

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x00018844 File Offset: 0x00016A44
		// (set) Token: 0x06000423 RID: 1059 RVA: 0x00003C31 File Offset: 0x00001E31
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

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0001885C File Offset: 0x00016A5C
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x00003C3A File Offset: 0x00001E3A
		[Category("Colours")]
		public Color FontColour
		{
			get
			{
				return this._FontColour;
			}
			set
			{
				this._FontColour = value;
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00003C43 File Offset: 0x00001E43
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 25;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00003C54 File Offset: 0x00001E54
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Height = 25;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00003C64 File Offset: 0x00001E64
		public void Increment(int Amount)
		{
			checked
			{
				this.Value += Amount;
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00018874 File Offset: 0x00016A74
		public LogInProgressBar()
		{
			this._ProgressColour = Color.FromArgb(0, 160, 199);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._FontColour = Color.FromArgb(50, 50, 50);
			this._SecondColour = Color.FromArgb(0, 145, 184);
			this._Value = 0;
			this._Maximum = 100;
			this._TwoColour = true;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00018910 File Offset: 0x00016B10
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			checked
			{
				int num = (int)Math.Round(unchecked((double)this._Value / (double)this._Maximum * (double)base.Width));
				int value = this.Value;
				if (value == 0)
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColour), rect);
					graphics2.FillRectangle(new SolidBrush(this._ProgressColour), new Rectangle(0, 0, num - 1, base.Height));
					graphics2.DrawRectangle(new Pen(this._BorderColour, 3f), rect);
				}
				else if (value == this._Maximum)
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColour), rect);
					graphics2.FillRectangle(new SolidBrush(this._ProgressColour), new Rectangle(0, 0, num - 1, base.Height));
					if (this._TwoColour)
					{
						graphics2.SetClip(new Rectangle(0, 0, (int)Math.Round(unchecked((double)(checked(base.Width * this._Value)) / (double)this._Maximum - 1.0)), base.Height - 1));
						double num2 = (double)((base.Width - 1) * this._Maximum) / (double)this._Value;
						for (double num3 = 0.0; num3 <= num2; num3 = unchecked(num3 + 25.0))
						{
							graphics2.DrawLine(new Pen(new SolidBrush(this._SecondColour), 7f), new Point((int)Math.Round(num3), 0), new Point((int)Math.Round(unchecked(num3 - 10.0)), base.Height));
						}
						graphics2.ResetClip();
					}
					graphics2.DrawRectangle(new Pen(this._BorderColour, 3f), rect);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColour), rect);
					graphics2.FillRectangle(new SolidBrush(this._ProgressColour), new Rectangle(0, 0, num - 1, base.Height));
					if (this._TwoColour)
					{
						graphics2.SetClip(new Rectangle(0, 0, (int)Math.Round(unchecked((double)(checked(base.Width * this._Value)) / (double)this._Maximum - 1.0)), base.Height - 1));
						double num4 = (double)((base.Width - 1) * this._Maximum) / (double)this._Value;
						for (double num5 = 0.0; num5 <= num4; num5 = unchecked(num5 + 25.0))
						{
							graphics2.DrawLine(new Pen(new SolidBrush(this._SecondColour), 7f), new Point((int)Math.Round(num5), 0), new Point((int)Math.Round(unchecked(num5 - 10.0)), base.Height));
						}
						graphics2.ResetClip();
					}
					graphics2.DrawRectangle(new Pen(this._BorderColour, 3f), rect);
				}
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x04000201 RID: 513
		private Color _ProgressColour;

		// Token: 0x04000202 RID: 514
		private Color _BorderColour;

		// Token: 0x04000203 RID: 515
		private Color _BaseColour;

		// Token: 0x04000204 RID: 516
		private Color _FontColour;

		// Token: 0x04000205 RID: 517
		private Color _SecondColour;

		// Token: 0x04000206 RID: 518
		private int _Value;

		// Token: 0x04000207 RID: 519
		private int _Maximum;

		// Token: 0x04000208 RID: 520
		private bool _TwoColour;
	}
}
