using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200000E RID: 14
	internal class FlatButton : Control
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00005C88 File Offset: 0x00003E88
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002368 File Offset: 0x00000568
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

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00005CA0 File Offset: 0x00003EA0
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002371 File Offset: 0x00000571
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

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00005CB8 File Offset: 0x00003EB8
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000237A File Offset: 0x0000057A
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

		// Token: 0x0600005B RID: 91 RVA: 0x00002383 File Offset: 0x00000583
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002399 File Offset: 0x00000599
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000023AF File Offset: 0x000005AF
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000023C5 File Offset: 0x000005C5
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005CCC File Offset: 0x00003ECC
		public FlatButton()
		{
			this._Rounded = false;
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(0, 170, 220);
			this._TextColor = Color.FromArgb(243, 243, 243);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(106, 32);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 10f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005D6C File Offset: 0x00003F6C
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				GraphicsPath path = new GraphicsPath();
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
						path = Helpers.RoundRec(rectangle, 6);
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
						path = Helpers.RoundRec(rectangle, 6);
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
						path = Helpers.RoundRec(rectangle, 6);
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
		}

		// Token: 0x0400002D RID: 45
		private int W;

		// Token: 0x0400002E RID: 46
		private int H;

		// Token: 0x0400002F RID: 47
		private bool _Rounded;

		// Token: 0x04000030 RID: 48
		private MouseState State;

		// Token: 0x04000031 RID: 49
		private Color _BaseColor;

		// Token: 0x04000032 RID: 50
		private Color _TextColor;
	}
}
