using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000033 RID: 51
	public class LogInRadialProgressBar : Control
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00015DB8 File Offset: 0x00013FB8
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00015DD0 File Offset: 0x00013FD0
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

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00015E00 File Offset: 0x00014000
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00015E24 File Offset: 0x00014024
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

		// Token: 0x06000364 RID: 868 RVA: 0x00003802 File Offset: 0x00001A02
		public void Increment(int Amount)
		{
			checked
			{
				this.Value += Amount;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00015E5C File Offset: 0x0001405C
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00003812 File Offset: 0x00001A12
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

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00015E74 File Offset: 0x00014074
		// (set) Token: 0x06000368 RID: 872 RVA: 0x0000381B File Offset: 0x00001A1B
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

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00015E8C File Offset: 0x0001408C
		// (set) Token: 0x0600036A RID: 874 RVA: 0x00003824 File Offset: 0x00001A24
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

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00015EA4 File Offset: 0x000140A4
		// (set) Token: 0x0600036C RID: 876 RVA: 0x0000382D File Offset: 0x00001A2D
		[Category("Control")]
		public int StartingAngle
		{
			get
			{
				return this._StartingAngle;
			}
			set
			{
				this._StartingAngle = value;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00015EBC File Offset: 0x000140BC
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00003836 File Offset: 0x00001A36
		[Category("Control")]
		public int RotationAngle
		{
			get
			{
				return this._RotationAngle;
			}
			set
			{
				this._RotationAngle = value;
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00015ED4 File Offset: 0x000140D4
		public LogInRadialProgressBar()
		{
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._ProgressColour = Color.FromArgb(0, 160, 199);
			this._Value = 0;
			this._Maximum = 100;
			this._StartingAngle = 110;
			this._RotationAngle = 255;
			this._Font = new Font("Segoe UI", 20f);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(78, 78);
			this.BackColor = Color.Transparent;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00015F84 File Offset: 0x00014184
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			int value = this._Value;
			checked
			{
				if (value == 0)
				{
					graphics2.DrawArc(new Pen(new SolidBrush(this._BorderColour), 6f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle - 3, this._RotationAngle + 5);
					graphics2.DrawArc(new Pen(new SolidBrush(this._BaseColour), 4f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle, this._RotationAngle);
					graphics2.DrawString(Conversions.ToString(this._Value), this._Font, Brushes.White, new Point((int)Math.Round((double)base.Width / 2.0), (int)Math.Round(unchecked((double)base.Height / 2.0 - 1.0))), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
				}
				else if (value == this._Maximum)
				{
					graphics2.DrawArc(new Pen(new SolidBrush(this._BorderColour), 6f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle - 3, this._RotationAngle + 5);
					graphics2.DrawArc(new Pen(new SolidBrush(this._BaseColour), 4f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle, this._RotationAngle);
					graphics2.DrawArc(new Pen(new SolidBrush(this._ProgressColour), 4f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle, this._RotationAngle);
					graphics2.DrawString(Conversions.ToString(this._Value), this._Font, Brushes.White, new Point((int)Math.Round((double)base.Width / 2.0), (int)Math.Round(unchecked((double)base.Height / 2.0 - 1.0))), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
				}
				else
				{
					graphics2.DrawArc(new Pen(new SolidBrush(this._BorderColour), 6f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle - 3, this._RotationAngle + 5);
					graphics2.DrawArc(new Pen(new SolidBrush(this._BaseColour), 4f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle, this._RotationAngle);
					graphics2.DrawArc(new Pen(new SolidBrush(this._ProgressColour), 4f), 3, 3, base.Width - 3 - 4, base.Height - 3 - 3, this._StartingAngle, (int)Math.Round(unchecked((double)this._RotationAngle / (double)this._Maximum * (double)this._Value)));
					graphics2.DrawString(Conversions.ToString(this._Value), this._Font, Brushes.White, new Point((int)Math.Round((double)base.Width / 2.0), (int)Math.Round(unchecked((double)base.Height / 2.0 - 1.0))), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
				}
				base.OnPaint(e);
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001C0 RID: 448
		private Color _BorderColour;

		// Token: 0x040001C1 RID: 449
		private Color _BaseColour;

		// Token: 0x040001C2 RID: 450
		private Color _ProgressColour;

		// Token: 0x040001C3 RID: 451
		private int _Value;

		// Token: 0x040001C4 RID: 452
		private int _Maximum;

		// Token: 0x040001C5 RID: 453
		private int _StartingAngle;

		// Token: 0x040001C6 RID: 454
		private int _RotationAngle;

		// Token: 0x040001C7 RID: 455
		private Font _Font;
	}
}
