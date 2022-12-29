using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000040 RID: 64
	public class LogInStatusBar : Control
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00018E84 File Offset: 0x00017084
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00003D54 File Offset: 0x00001F54
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

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00018E9C File Offset: 0x0001709C
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00003D5D File Offset: 0x00001F5D
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

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00018EB4 File Offset: 0x000170B4
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x00003D66 File Offset: 0x00001F66
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

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00018ECC File Offset: 0x000170CC
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00003D6F File Offset: 0x00001F6F
		[Category("Control")]
		public LogInStatusBar.Alignments Alignment
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

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x00018EE4 File Offset: 0x000170E4
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x00003D78 File Offset: 0x00001F78
		[Category("Control")]
		public LogInStatusBar.LinesCount LinesToShow
		{
			get
			{
				return this._LinesToShow;
			}
			set
			{
				this._LinesToShow = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00018EFC File Offset: 0x000170FC
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x00003D81 File Offset: 0x00001F81
		public bool ShowBorder
		{
			get
			{
				return this._ShowBorder;
			}
			set
			{
				this._ShowBorder = value;
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000029D1 File Offset: 0x00000BD1
		protected override void CreateHandle()
		{
			base.CreateHandle();
			this.Dock = DockStyle.Bottom;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00018F10 File Offset: 0x00017110
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00003D8A File Offset: 0x00001F8A
		[Category("Colours")]
		public Color RectangleColor
		{
			get
			{
				return this._RectColour;
			}
			set
			{
				this._RectColour = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00018F28 File Offset: 0x00017128
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00003D93 File Offset: 0x00001F93
		public bool ShowLine
		{
			get
			{
				return this._ShowLine;
			}
			set
			{
				this._ShowLine = value;
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00018F3C File Offset: 0x0001713C
		public LogInStatusBar()
		{
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._TextColour = Color.White;
			this._RectColour = Color.FromArgb(21, 117, 149);
			this._ShowLine = true;
			this._LinesToShow = LogInStatusBar.LinesCount.One;
			this._Alignment = LogInStatusBar.Alignments.Left;
			this._ShowBorder = true;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 9f);
			this.ForeColor = Color.White;
			base.Size = new Size(base.Width, 20);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00018FF4 File Offset: 0x000171F4
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BaseColour);
			graphics2.FillRectangle(new SolidBrush(this.BaseColour), rect);
			checked
			{
				if (this._ShowLine)
				{
					LogInStatusBar.LinesCount linesToShow = this._LinesToShow;
					if (linesToShow != LogInStatusBar.LinesCount.One)
					{
						if (linesToShow == LogInStatusBar.LinesCount.Two)
						{
							if (this._Alignment == LogInStatusBar.Alignments.Left)
							{
								graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(22, 2, base.Width, base.Height), new StringFormat
								{
									Alignment = StringAlignment.Near,
									LineAlignment = StringAlignment.Near
								});
							}
							else if (this._Alignment == LogInStatusBar.Alignments.Center)
							{
								graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(0, 0, base.Width, base.Height), new StringFormat
								{
									Alignment = StringAlignment.Center,
									LineAlignment = StringAlignment.Center
								});
							}
							else
							{
								graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(0, 0, base.Width - 22, base.Height), new StringFormat
								{
									Alignment = StringAlignment.Far,
									LineAlignment = StringAlignment.Center
								});
							}
							graphics2.FillRectangle(new SolidBrush(this._RectColour), new Rectangle(5, 9, 14, 3));
							graphics2.FillRectangle(new SolidBrush(this._RectColour), new Rectangle(base.Width - 20, 9, 14, 3));
						}
					}
					else
					{
						if (this._Alignment == LogInStatusBar.Alignments.Left)
						{
							graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(22, 2, base.Width, base.Height), new StringFormat
							{
								Alignment = StringAlignment.Near,
								LineAlignment = StringAlignment.Near
							});
						}
						else if (this._Alignment == LogInStatusBar.Alignments.Center)
						{
							graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(0, 0, base.Width, base.Height), new StringFormat
							{
								Alignment = StringAlignment.Center,
								LineAlignment = StringAlignment.Center
							});
						}
						else
						{
							graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(0, 0, base.Width - 5, base.Height), new StringFormat
							{
								Alignment = StringAlignment.Far,
								LineAlignment = StringAlignment.Center
							});
						}
						graphics2.FillRectangle(new SolidBrush(this._RectColour), new Rectangle(5, 9, 14, 3));
					}
				}
				else
				{
					graphics2.DrawString(this.Text, this.Font, Brushes.White, new Rectangle(5, 2, base.Width, base.Height), new StringFormat
					{
						Alignment = StringAlignment.Near,
						LineAlignment = StringAlignment.Near
					});
				}
				if (this._ShowBorder)
				{
					graphics2.DrawLine(new Pen(this._BorderColour, 2f), new Point(0, 0), new Point(base.Width, 0));
				}
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x0400020D RID: 525
		private Color _BaseColour;

		// Token: 0x0400020E RID: 526
		private Color _BorderColour;

		// Token: 0x0400020F RID: 527
		private Color _TextColour;

		// Token: 0x04000210 RID: 528
		private Color _RectColour;

		// Token: 0x04000211 RID: 529
		private bool _ShowLine;

		// Token: 0x04000212 RID: 530
		private LogInStatusBar.LinesCount _LinesToShow;

		// Token: 0x04000213 RID: 531
		private LogInStatusBar.Alignments _Alignment;

		// Token: 0x04000214 RID: 532
		private bool _ShowBorder;

		// Token: 0x02000062 RID: 98
		public enum LinesCount
		{
			// Token: 0x0400031C RID: 796
			One = 1,
			// Token: 0x0400031D RID: 797
			Two
		}

		// Token: 0x02000063 RID: 99
		public enum Alignments
		{
			// Token: 0x0400031F RID: 799
			Left,
			// Token: 0x04000320 RID: 800
			Center,
			// Token: 0x04000321 RID: 801
			Right
		}
	}
}
