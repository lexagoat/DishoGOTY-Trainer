using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000011 RID: 17
	[DefaultEvent("CheckedChanged")]
	internal class FlatCheckBox : Control
	{
		// Token: 0x06000084 RID: 132 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00006D20 File Offset: 0x00004F20
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000024FF File Offset: 0x000006FF
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				base.Invalidate();
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000087 RID: 135 RVA: 0x00006D34 File Offset: 0x00004F34
		// (remove) Token: 0x06000088 RID: 136 RVA: 0x00006D6C File Offset: 0x00004F6C
		public event FlatCheckBox.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x06000089 RID: 137 RVA: 0x00006DA4 File Offset: 0x00004FA4
		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			FlatCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
			if (checkedChangedEvent != null)
			{
				checkedChangedEvent(this);
			}
			base.OnClick(e);
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00006DD8 File Offset: 0x00004FD8
		// (set) Token: 0x0600008B RID: 139 RVA: 0x0000250E File Offset: 0x0000070E
		[Category("Options")]
		public FlatCheckBox._Options Options
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

		// Token: 0x0600008C RID: 140 RVA: 0x00002484 File Offset: 0x00000684
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 22;
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00006DF0 File Offset: 0x00004FF0
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00002517 File Offset: 0x00000717
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

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00006E08 File Offset: 0x00005008
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00002520 File Offset: 0x00000720
		[Category("Colors")]
		public Color BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				this._BorderColor = value;
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00002529 File Offset: 0x00000729
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000253F File Offset: 0x0000073F
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00002555 File Offset: 0x00000755
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000256B File Offset: 0x0000076B
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006E20 File Offset: 0x00005020
		public FlatCheckBox()
		{
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(60, 60, 60);
			this._BorderColor = Color.FromArgb(0, 170, 220);
			this._TextColor = Color.FromArgb(243, 243, 243);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(50, 50, 50);
			this.Cursor = Cursors.Hand;
			this.Font = new Font("Segoe UI", 10f);
			base.Size = new Size(112, 22);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006ED0 File Offset: 0x000050D0
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				Rectangle rect = new Rectangle(0, 2, base.Height - 5, base.Height - 5);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				FlatCheckBox._Options o = this.O;
				if (o != FlatCheckBox._Options.Style1)
				{
					if (o == FlatCheckBox._Options.Style2)
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), rect);
						MouseState state = this.State;
						if (state != MouseState.Over)
						{
							if (state == MouseState.Down)
							{
								g.DrawRectangle(new Pen(this._BorderColor), rect);
								g.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
							}
						}
						else
						{
							g.DrawRectangle(new Pen(this._BorderColor), rect);
							g.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
						}
						if (this.Checked)
						{
							g.DrawString("ü", new Font("Wingdings", 18f), new SolidBrush(this._BorderColor), new Rectangle(5, 7, this.H - 9, this.H - 9), Helpers.CenterSF);
						}
						if (!base.Enabled)
						{
							g.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
							g.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(48, 119, 91)), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
						}
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
					}
				}
				else
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), rect);
					MouseState state2 = this.State;
					if (state2 != MouseState.Over)
					{
						if (state2 == MouseState.Down)
						{
							g.DrawRectangle(new Pen(this._BorderColor), rect);
						}
					}
					else
					{
						g.DrawRectangle(new Pen(this._BorderColor), rect);
					}
					if (this.Checked)
					{
						g.DrawString("ü", new Font("Wingdings", 18f), new SolidBrush(this._BorderColor), new Rectangle(5, 7, this.H - 9, this.H - 9), Helpers.CenterSF);
					}
					if (!base.Enabled)
					{
						g.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
						g.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(140, 142, 143)), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
					}
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
				}
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x04000047 RID: 71
		private int W;

		// Token: 0x04000048 RID: 72
		private int H;

		// Token: 0x04000049 RID: 73
		private MouseState State;

		// Token: 0x0400004A RID: 74
		private FlatCheckBox._Options O;

		// Token: 0x0400004B RID: 75
		private bool _Checked;

		// Token: 0x0400004D RID: 77
		private Color _BaseColor;

		// Token: 0x0400004E RID: 78
		private Color _BorderColor;

		// Token: 0x0400004F RID: 79
		private Color _TextColor;

		// Token: 0x02000056 RID: 86
		// (Invoke) Token: 0x0600068A RID: 1674
		public delegate void CheckedChangedEventHandler(object sender);

		// Token: 0x02000057 RID: 87
		[Flags]
		public enum _Options
		{
			// Token: 0x04000304 RID: 772
			Style1 = 0,
			// Token: 0x04000305 RID: 773
			Style2 = 1
		}
	}
}
