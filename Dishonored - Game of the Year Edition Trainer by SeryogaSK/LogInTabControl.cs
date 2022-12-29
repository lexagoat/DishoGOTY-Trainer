using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000043 RID: 67
	public class LogInTabControl : TabControl
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x0001A0CC File Offset: 0x000182CC
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x00003E70 File Offset: 0x00002070
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

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x0001A0E4 File Offset: 0x000182E4
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x00003E79 File Offset: 0x00002079
		[Category("Colours")]
		public Color UpLineColour
		{
			get
			{
				return this._UpLineColour;
			}
			set
			{
				this._UpLineColour = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001A0FC File Offset: 0x000182FC
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x00003E82 File Offset: 0x00002082
		[Category("Colours")]
		public Color HorizontalLineColour
		{
			get
			{
				return this._HorizLineColour;
			}
			set
			{
				this._HorizLineColour = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0001A114 File Offset: 0x00018314
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x00003E8B File Offset: 0x0000208B
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

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0001A12C File Offset: 0x0001832C
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00003E94 File Offset: 0x00002094
		[Category("Colours")]
		public Color BackTabColour
		{
			get
			{
				return this._BackTabColour;
			}
			set
			{
				this._BackTabColour = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x0001A144 File Offset: 0x00018344
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x00003E9D File Offset: 0x0000209D
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

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0001A15C File Offset: 0x0001835C
		// (set) Token: 0x06000489 RID: 1161 RVA: 0x00003EA6 File Offset: 0x000020A6
		[Category("Colours")]
		public Color ActiveColour
		{
			get
			{
				return this._ActiveColour;
			}
			set
			{
				this._ActiveColour = value;
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000261E File Offset: 0x0000081E
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Alignment = TabAlignment.Top;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0001A174 File Offset: 0x00018374
		public LogInTabControl()
		{
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._BackTabColour = Color.FromArgb(54, 54, 54);
			this._BaseColour = Color.FromArgb(35, 35, 35);
			this._ActiveColour = Color.FromArgb(47, 47, 47);
			this._BorderColour = Color.FromArgb(30, 30, 30);
			this._UpLineColour = Color.FromArgb(0, 160, 199);
			this._HorizLineColour = Color.FromArgb(23, 119, 151);
			this.CenterSF = new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 10f);
			base.SizeMode = TabSizeMode.Normal;
			base.ItemSize = new Size(240, 32);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001A26C File Offset: 0x0001846C
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this._BaseColour);
			try
			{
				base.SelectedTab.BackColor = this._BackTabColour;
			}
			catch (Exception ex)
			{
			}
			try
			{
				base.SelectedTab.BorderStyle = BorderStyle.FixedSingle;
			}
			catch (Exception ex2)
			{
			}
			graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), new Rectangle(0, 0, base.Width, base.Height));
			checked
			{
				int num = base.TabCount - 1;
				for (int i = 0; i <= num; i++)
				{
					Rectangle rectangle = new Rectangle(new Point(base.GetTabRect(i).Location.X, base.GetTabRect(i).Location.Y), new Size(base.GetTabRect(i).Width, base.GetTabRect(i).Height));
					Rectangle rectangle2 = new Rectangle(rectangle.Location, new Size(rectangle.Width, rectangle.Height));
					if (i == base.SelectedIndex)
					{
						graphics2.FillRectangle(new SolidBrush(this._BaseColour), rectangle2);
						graphics2.FillRectangle(new SolidBrush(this._ActiveColour), new Rectangle(rectangle.X + 1, rectangle.Y - 3, rectangle.Width, rectangle.Height + 5));
						graphics2.DrawString(base.TabPages[i].Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(rectangle.X + 7, rectangle.Y, rectangle.Width - 3, rectangle.Height), this.CenterSF);
						graphics2.DrawLine(new Pen(this._HorizLineColour, 2f), new Point(rectangle.X + 3, (int)Math.Round(unchecked((double)rectangle.Height / 2.0 + 2.0))), new Point(rectangle.X + 9, (int)Math.Round(unchecked((double)rectangle.Height / 2.0 + 2.0))));
						graphics2.DrawLine(new Pen(this._UpLineColour, 2f), new Point(rectangle.X + 3, rectangle.Y - 3), new Point(rectangle.X + 3, rectangle.Height + 5));
					}
					else
					{
						graphics2.DrawString(base.TabPages[i].Text, this.Font, new SolidBrush(this._TextColour), rectangle2, this.CenterSF);
					}
				}
				graphics2 = null;
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x04000227 RID: 551
		private Color _TextColour;

		// Token: 0x04000228 RID: 552
		private Color _BackTabColour;

		// Token: 0x04000229 RID: 553
		private Color _BaseColour;

		// Token: 0x0400022A RID: 554
		private Color _ActiveColour;

		// Token: 0x0400022B RID: 555
		private Color _BorderColour;

		// Token: 0x0400022C RID: 556
		private Color _UpLineColour;

		// Token: 0x0400022D RID: 557
		private Color _HorizLineColour;

		// Token: 0x0400022E RID: 558
		private StringFormat CenterSF;
	}
}
