using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000017 RID: 23
	internal class FlatStickyButton : Control
	{
		// Token: 0x060000EC RID: 236 RVA: 0x000027FA File Offset: 0x000009FA
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00002810 File Offset: 0x00000A10
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00002826 File Offset: 0x00000A26
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000283C File Offset: 0x00000A3C
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00008E54 File Offset: 0x00007054
		private bool[] GetConnectedSides()
		{
			bool[] array = new bool[4];
			try
			{
				foreach (object obj in base.Parent.Controls)
				{
					Control control = (Control)obj;
					if (control is FlatStickyButton && !(control == this | !this.Rect.IntersectsWith(this.Rect)))
					{
						double num = checked(Math.Atan2((double)(base.Left - control.Left), (double)(base.Top - control.Top))) * 2.0 / 3.141592653589793;
						checked
						{
							if ((double)((long)Math.Round(num) / 1L) == num)
							{
								array[(int)Math.Round(unchecked(num + 1.0))] = true;
							}
						}
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return array;
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00008F50 File Offset: 0x00007150
		private Rectangle Rect
		{
			get
			{
				Rectangle result = new Rectangle(base.Left, base.Top, base.Width, base.Height);
				return result;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00008F80 File Offset: 0x00007180
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00002852 File Offset: 0x00000A52
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

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00008F98 File Offset: 0x00007198
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x0000285B File Offset: 0x00000A5B
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

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00008FB0 File Offset: 0x000071B0
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00002864 File Offset: 0x00000A64
		[Category("Options")]
		public bool Rounded
		{
			get
			{
				return this._Rounded;
			}
			set
			{
				this._Rounded = value;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000286D File Offset: 0x00000A6D
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00002876 File Offset: 0x00000A76
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00008FC4 File Offset: 0x000071C4
		public FlatStickyButton()
		{
			this.State = MouseState.None;
			this._Rounded = false;
			this._BaseColor = Color.FromArgb(0, 170, 220);
			this._TextColor = Color.FromArgb(243, 243, 243);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(106, 32);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 10f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00009064 File Offset: 0x00007264
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = base.Width;
			this.H = base.Height;
			GraphicsPath path = new GraphicsPath();
			bool[] connectedSides = this.GetConnectedSides();
			GraphicsPath graphicsPath = Helpers.RoundRect(0f, 0f, (float)this.W, (float)this.H, 0.3f, !(connectedSides[2] | connectedSides[1]), !(connectedSides[1] | connectedSides[0]), !(connectedSides[3] | connectedSides[0]), !(connectedSides[3] | connectedSides[2]));
			Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			switch (this.State)
			{
			case MouseState.None:
				if (this.Rounded)
				{
					path = graphicsPath;
					g.FillPath(new SolidBrush(this._BaseColor), path);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			case MouseState.Over:
				if (this.Rounded)
				{
					path = graphicsPath;
					g.FillPath(new SolidBrush(this._BaseColor), path);
					g.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), path);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), rectangle);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			case MouseState.Down:
				if (this.Rounded)
				{
					path = graphicsPath;
					g.FillPath(new SolidBrush(this._BaseColor), path);
					g.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), path);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), rectangle);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			}
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}

		// Token: 0x0400007E RID: 126
		private int W;

		// Token: 0x0400007F RID: 127
		private int H;

		// Token: 0x04000080 RID: 128
		private MouseState State;

		// Token: 0x04000081 RID: 129
		private bool _Rounded;

		// Token: 0x04000082 RID: 130
		private Color _BaseColor;

		// Token: 0x04000083 RID: 131
		private Color _TextColor;
	}
}
