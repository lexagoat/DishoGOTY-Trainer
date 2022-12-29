using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000012 RID: 18
	[DefaultEvent("TextChanged")]
	internal class FlatTextBox : Control
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002581 File Offset: 0x00000781
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00002589 File Offset: 0x00000789
		private virtual TextBox TB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00007260 File Offset: 0x00005460
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00007278 File Offset: 0x00005478
		[Category("Options")]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return this._TextAlign;
			}
			set
			{
				this._TextAlign = value;
				if (this.TB != null)
				{
					this.TB.TextAlign = value;
				}
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000072A4 File Offset: 0x000054A4
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000072BC File Offset: 0x000054BC
		[Category("Options")]
		public int MaxLength
		{
			get
			{
				return this._MaxLength;
			}
			set
			{
				this._MaxLength = value;
				if (this.TB != null)
				{
					this.TB.MaxLength = value;
				}
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000072E8 File Offset: 0x000054E8
		// (set) Token: 0x0600009E RID: 158 RVA: 0x000072FC File Offset: 0x000054FC
		[Category("Options")]
		public bool ReadOnly
		{
			get
			{
				return this._ReadOnly;
			}
			set
			{
				this._ReadOnly = value;
				if (this.TB != null)
				{
					this.TB.ReadOnly = value;
				}
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00007328 File Offset: 0x00005528
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x0000733C File Offset: 0x0000553C
		[Category("Options")]
		public bool UseSystemPasswordChar
		{
			get
			{
				return this._UseSystemPasswordChar;
			}
			set
			{
				this._UseSystemPasswordChar = value;
				if (this.TB != null)
				{
					this.TB.UseSystemPasswordChar = value;
				}
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00007368 File Offset: 0x00005568
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000737C File Offset: 0x0000557C
		[Category("Options")]
		public bool Multiline
		{
			get
			{
				return this._Multiline;
			}
			set
			{
				this._Multiline = value;
				checked
				{
					if (this.TB != null)
					{
						this.TB.Multiline = value;
						if (value)
						{
							this.TB.Height = base.Height - 11;
						}
						else
						{
							base.Height = this.TB.Height + 11;
						}
					}
				}
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x000073EC File Offset: 0x000055EC
		[Category("Options")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (this.TB != null)
				{
					this.TB.Text = value;
				}
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00007430 File Offset: 0x00005630
		[Category("Options")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				checked
				{
					if (this.TB != null)
					{
						this.TB.Font = value;
						this.TB.Location = new Point(3, 5);
						this.TB.Width = base.Width - 6;
						if (!this._Multiline)
						{
							base.Height = this.TB.Height + 11;
						}
					}
				}
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000074A0 File Offset: 0x000056A0
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.TB))
			{
				base.Controls.Add(this.TB);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002592 File Offset: 0x00000792
		private void OnBaseTextChanged(object sender, EventArgs e)
		{
			this.Text = this.TB.Text;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000074DC File Offset: 0x000056DC
		private void OnBaseKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				this.TB.SelectAll();
				e.SuppressKeyPress = true;
			}
			if (e.Control && e.KeyCode == Keys.C)
			{
				this.TB.Copy();
				e.SuppressKeyPress = true;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000753C File Offset: 0x0000573C
		protected override void OnResize(EventArgs e)
		{
			this.TB.Location = new Point(5, 5);
			checked
			{
				this.TB.Width = base.Width - 10;
				if (this._Multiline)
				{
					this.TB.Height = base.Height - 11;
				}
				else
				{
					base.Height = this.TB.Height + 11;
				}
				base.OnResize(e);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000AB RID: 171 RVA: 0x000075A8 File Offset: 0x000057A8
		// (set) Token: 0x060000AC RID: 172 RVA: 0x000025A5 File Offset: 0x000007A5
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

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000075A8 File Offset: 0x000057A8
		// (set) Token: 0x060000AE RID: 174 RVA: 0x000025A5 File Offset: 0x000007A5
		public override Color ForeColor
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

		// Token: 0x060000AF RID: 175 RVA: 0x000025AE File Offset: 0x000007AE
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000025C4 File Offset: 0x000007C4
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			base.Invalidate();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000025E6 File Offset: 0x000007E6
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			base.Invalidate();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002608 File Offset: 0x00000808
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000075C0 File Offset: 0x000057C0
		public FlatTextBox()
		{
			this.State = MouseState.None;
			this._TextAlign = HorizontalAlignment.Left;
			this._MaxLength = 32767;
			this._BaseColor = Color.FromArgb(60, 60, 60);
			this._TextColor = Color.FromArgb(192, 192, 192);
			this._BorderColor = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			this.TB = new TextBox();
			this.TB.Font = new Font("Segoe UI", 10f);
			this.TB.Text = this.Text;
			this.TB.BackColor = this._BaseColor;
			this.TB.ForeColor = this._TextColor;
			this.TB.MaxLength = this._MaxLength;
			this.TB.Multiline = this._Multiline;
			this.TB.ReadOnly = this._ReadOnly;
			this.TB.UseSystemPasswordChar = this._UseSystemPasswordChar;
			this.TB.BorderStyle = BorderStyle.None;
			this.TB.Location = new Point(5, 5);
			checked
			{
				this.TB.Width = base.Width - 10;
				this.TB.Cursor = Cursors.IBeam;
				if (this._Multiline)
				{
					this.TB.Height = base.Height - 11;
				}
				else
				{
					base.Height = this.TB.Height + 11;
				}
				this.TB.TextChanged += this.OnBaseTextChanged;
				this.TB.KeyDown += this.OnBaseKeyDown;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000778C File Offset: 0x0000598C
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				Rectangle rect = new Rectangle(0, 0, this.W, this.H);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				this.TB.BackColor = this._BaseColor;
				this.TB.ForeColor = this._TextColor;
				g.FillRectangle(new SolidBrush(this._BaseColor), rect);
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x04000050 RID: 80
		private int W;

		// Token: 0x04000051 RID: 81
		private int H;

		// Token: 0x04000052 RID: 82
		private MouseState State;

		// Token: 0x04000054 RID: 84
		private HorizontalAlignment _TextAlign;

		// Token: 0x04000055 RID: 85
		private int _MaxLength;

		// Token: 0x04000056 RID: 86
		private bool _ReadOnly;

		// Token: 0x04000057 RID: 87
		private bool _UseSystemPasswordChar;

		// Token: 0x04000058 RID: 88
		private bool _Multiline;

		// Token: 0x04000059 RID: 89
		private Color _BaseColor;

		// Token: 0x0400005A RID: 90
		private Color _TextColor;

		// Token: 0x0400005B RID: 91
		private Color _BorderColor;
	}
}
