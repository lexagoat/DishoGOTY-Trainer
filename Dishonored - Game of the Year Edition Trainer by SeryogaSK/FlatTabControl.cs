using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000013 RID: 19
	internal class FlatTabControl : TabControl
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x0000261E File Offset: 0x0000081E
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Alignment = TabAlignment.Top;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00007888 File Offset: 0x00005A88
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x0000262D File Offset: 0x0000082D
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

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000078A0 File Offset: 0x00005AA0
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00002636 File Offset: 0x00000836
		[Category("Colors")]
		public Color ActiveColor
		{
			get
			{
				return this._ActiveColor;
			}
			set
			{
				this._ActiveColor = value;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000078B8 File Offset: 0x00005AB8
		public FlatTabControl()
		{
			this.BGColor = Color.FromArgb(50, 50, 50);
			this._BaseColor = Color.FromArgb(45, 47, 49);
			this._ActiveColor = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Font = new Font("Segoe UI", 10f);
			base.SizeMode = TabSizeMode.Fixed;
			base.ItemSize = new Size(120, 40);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00007954 File Offset: 0x00005B54
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				Graphics graphics = Helpers.G;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				graphics.Clear(this._BaseColor);
				try
				{
					base.SelectedTab.BackColor = this.BGColor;
				}
				catch (Exception ex)
				{
				}
				int num = base.TabCount - 1;
				for (int i = 0; i <= num; i++)
				{
					Rectangle rectangle = new Rectangle(new Point(base.GetTabRect(i).Location.X + 2, base.GetTabRect(i).Location.Y), new Size(base.GetTabRect(i).Width, base.GetTabRect(i).Height));
					Rectangle rectangle2 = new Rectangle(rectangle.Location, new Size(rectangle.Width, rectangle.Height));
					if (i == base.SelectedIndex)
					{
						graphics.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
						graphics.FillRectangle(new SolidBrush(this._ActiveColor), rectangle2);
						if (base.ImageList != null)
						{
							try
							{
								if (base.ImageList.Images[base.TabPages[i].ImageIndex] != null)
								{
									graphics.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 6));
									graphics.DrawString("      " + base.TabPages[i].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
								}
								else
								{
									graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
								}
								goto IL_40F;
							}
							catch (Exception ex2)
							{
								throw new Exception(ex2.Message);
							}
						}
						graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
					}
					else
					{
						graphics.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
						if (base.ImageList != null)
						{
							try
							{
								if (base.ImageList.Images[base.TabPages[i].ImageIndex] != null)
								{
									graphics.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 6));
									graphics.DrawString("      " + base.TabPages[i].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
								else
								{
									graphics.DrawString(base.TabPages[i].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
								goto IL_40F;
							}
							catch (Exception ex3)
							{
								throw new Exception(ex3.Message);
							}
						}
						graphics.DrawString(base.TabPages[i].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
						{
							LineAlignment = StringAlignment.Center,
							Alignment = StringAlignment.Center
						});
					}
					IL_40F:;
				}
				graphics = null;
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x0400005C RID: 92
		private int W;

		// Token: 0x0400005D RID: 93
		private int H;

		// Token: 0x0400005E RID: 94
		private Color BGColor;

		// Token: 0x0400005F RID: 95
		private Color _BaseColor;

		// Token: 0x04000060 RID: 96
		private Color _ActiveColor;
	}
}
