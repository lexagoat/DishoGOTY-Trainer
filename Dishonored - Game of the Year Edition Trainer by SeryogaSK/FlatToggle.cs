using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200000F RID: 15
	[DefaultEvent("CheckedChanged")]
	internal class FlatToggle : Control
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000061 RID: 97 RVA: 0x00006058 File Offset: 0x00004258
		// (remove) Token: 0x06000062 RID: 98 RVA: 0x00006090 File Offset: 0x00004290
		public event FlatToggle.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000060C8 File Offset: 0x000042C8
		// (set) Token: 0x06000064 RID: 100 RVA: 0x000023DB File Offset: 0x000005DB
		[Category("Options")]
		public FlatToggle._Options Options
		{
			get
			{
				return this.O;
			}
			set
			{
				this.O = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000060E0 File Offset: 0x000042E0
		// (set) Token: 0x06000066 RID: 102 RVA: 0x000023E4 File Offset: 0x000005E4
		[Category("Options")]
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000023FC File Offset: 0x000005FC
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Width = 76;
			base.Height = 33;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002415 File Offset: 0x00000615
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000242B File Offset: 0x0000062B
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002441 File Offset: 0x00000641
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002457 File Offset: 0x00000657
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000060F4 File Offset: 0x000042F4
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this._Checked = !this._Checked;
			FlatToggle.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
			if (checkedChangedEvent != null)
			{
				checkedChangedEvent(this);
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00006128 File Offset: 0x00004328
		public FlatToggle()
		{
			this._Checked = false;
			this.State = MouseState.None;
			this.BaseColor = Color.FromArgb(0, 170, 220);
			this.BaseColorRed = Color.FromArgb(0, 170, 220);
			this.BGColor = Color.FromArgb(84, 85, 86);
			this.ToggleColor = Color.FromArgb(45, 47, 49);
			this.TextColor = Color.FromArgb(243, 243, 243);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.Size = new Size(44, checked(base.Height + 1));
			this.Cursor = Cursors.Hand;
			this.Font = new Font("Segoe UI", 10f);
			base.Size = new Size(56, 13);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00006214 File Offset: 0x00004414
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				GraphicsPath path = new GraphicsPath();
				GraphicsPath graphicsPath = new GraphicsPath();
				Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
				Rectangle rectangle2 = new Rectangle(this.W / 2, 0, 38, this.H);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				switch (this.O)
				{
				case FlatToggle._Options.Style1:
					path = Helpers.RoundRec(rectangle, 6);
					graphicsPath = Helpers.RoundRec(rectangle2, 6);
					g.FillPath(new SolidBrush(this.BGColor), path);
					g.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
					g.DrawString("OFF", this.Font, new SolidBrush(this.BGColor), new Rectangle(19, 1, this.W, this.H), Helpers.CenterSF);
					if (this.Checked)
					{
						path = Helpers.RoundRec(rectangle, 6);
						graphicsPath = Helpers.RoundRec(new Rectangle(this.W / 2, 0, 38, this.H), 6);
						g.FillPath(new SolidBrush(this.ToggleColor), path);
						g.FillPath(new SolidBrush(this.BaseColor), graphicsPath);
						g.DrawString("ON", this.Font, new SolidBrush(this.BaseColor), new Rectangle(8, 7, this.W, this.H), Helpers.NearSF);
					}
					break;
				case FlatToggle._Options.Style2:
					path = Helpers.RoundRec(rectangle, 6);
					rectangle2 = new Rectangle(4, 4, 36, this.H - 8);
					graphicsPath = Helpers.RoundRec(rectangle2, 4);
					g.FillPath(new SolidBrush(this.BaseColorRed), path);
					g.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
					g.DrawLine(new Pen(this.BGColor), 18, 20, 18, 12);
					g.DrawLine(new Pen(this.BGColor), 22, 20, 22, 12);
					g.DrawLine(new Pen(this.BGColor), 26, 20, 26, 12);
					g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.TextColor), new Rectangle(19, 2, base.Width, base.Height), Helpers.CenterSF);
					if (this.Checked)
					{
						path = Helpers.RoundRec(rectangle, 6);
						rectangle2 = new Rectangle(this.W / 2 - 2, 4, 36, this.H - 8);
						graphicsPath = Helpers.RoundRec(rectangle2, 4);
						g.FillPath(new SolidBrush(this.BaseColor), path);
						g.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
						g.DrawLine(new Pen(this.BGColor), this.W / 2 + 12, 20, this.W / 2 + 12, 12);
						g.DrawLine(new Pen(this.BGColor), this.W / 2 + 16, 20, this.W / 2 + 16, 12);
						g.DrawLine(new Pen(this.BGColor), this.W / 2 + 20, 20, this.W / 2 + 20, 12);
						g.DrawString("ü", new Font("Wingdings", 14f), new SolidBrush(this.TextColor), new Rectangle(8, 7, base.Width, base.Height), Helpers.NearSF);
					}
					break;
				case FlatToggle._Options.Style3:
					path = Helpers.RoundRec(rectangle, 16);
					rectangle2 = new Rectangle(this.W - 28, 4, 22, this.H - 8);
					graphicsPath.AddEllipse(rectangle2);
					g.FillPath(new SolidBrush(this.ToggleColor), path);
					g.FillPath(new SolidBrush(this.BaseColorRed), graphicsPath);
					g.DrawString("OFF", this.Font, new SolidBrush(this.BaseColorRed), new Rectangle(-12, 2, this.W, this.H), Helpers.CenterSF);
					if (this.Checked)
					{
						path = Helpers.RoundRec(rectangle, 16);
						rectangle2 = new Rectangle(6, 4, 22, this.H - 8);
						graphicsPath.Reset();
						graphicsPath.AddEllipse(rectangle2);
						g.FillPath(new SolidBrush(this.ToggleColor), path);
						g.FillPath(new SolidBrush(this.BaseColor), graphicsPath);
						g.DrawString("ON", this.Font, new SolidBrush(this.BaseColor), new Rectangle(12, 2, this.W, this.H), Helpers.CenterSF);
					}
					break;
				case FlatToggle._Options.Style4:
					if (this.Checked)
					{
					}
					break;
				case FlatToggle._Options.Style5:
					if (!this.Checked)
					{
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

		// Token: 0x04000033 RID: 51
		private int W;

		// Token: 0x04000034 RID: 52
		private int H;

		// Token: 0x04000035 RID: 53
		private FlatToggle._Options O;

		// Token: 0x04000036 RID: 54
		private bool _Checked;

		// Token: 0x04000037 RID: 55
		private MouseState State;

		// Token: 0x04000039 RID: 57
		private Color BaseColor;

		// Token: 0x0400003A RID: 58
		private Color BaseColorRed;

		// Token: 0x0400003B RID: 59
		private Color BGColor;

		// Token: 0x0400003C RID: 60
		private Color ToggleColor;

		// Token: 0x0400003D RID: 61
		private Color TextColor;

		// Token: 0x02000052 RID: 82
		// (Invoke) Token: 0x06000682 RID: 1666
		public delegate void CheckedChangedEventHandler(object sender);

		// Token: 0x02000053 RID: 83
		[Flags]
		public enum _Options
		{
			// Token: 0x040002FB RID: 763
			Style1 = 0,
			// Token: 0x040002FC RID: 764
			Style2 = 1,
			// Token: 0x040002FD RID: 765
			Style3 = 2,
			// Token: 0x040002FE RID: 766
			Style4 = 3,
			// Token: 0x040002FF RID: 767
			Style5 = 4
		}
	}
}
