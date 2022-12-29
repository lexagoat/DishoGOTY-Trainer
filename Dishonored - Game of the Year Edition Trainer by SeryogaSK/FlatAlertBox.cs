using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000014 RID: 20
	internal class FlatAlertBox : Control
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000263F File Offset: 0x0000083F
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00007E00 File Offset: 0x00006000
		private virtual Timer T
		{
			[CompilerGenerated]
			get
			{
				return this._T;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.T_Tick);
				Timer t = this._T;
				if (t != null)
				{
					t.Tick -= value2;
				}
				this._T = value;
				t = this._T;
				if (t != null)
				{
					t.Tick += value2;
				}
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00007E44 File Offset: 0x00006044
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00002647 File Offset: 0x00000847
		[Category("Options")]
		public FlatAlertBox._Kind kind
		{
			get
			{
				return this.K;
			}
			set
			{
				this.K = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00007E5C File Offset: 0x0000605C
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
				if (this._Text != null)
				{
					this._Text = value;
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00007E84 File Offset: 0x00006084
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00002650 File Offset: 0x00000850
		[Category("Options")]
		public new bool Visible
		{
			get
			{
				return !base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00002659 File Offset: 0x00000859
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 42;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000266A File Offset: 0x0000086A
		public void ShowControl(FlatAlertBox._Kind Kind, string Str, int Interval)
		{
			this.K = Kind;
			this.Text = Str;
			this.Visible = true;
			this.T = new Timer();
			this.T.Interval = Interval;
			this.T.Enabled = true;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000026A4 File Offset: 0x000008A4
		private void T_Tick(object sender, EventArgs e)
		{
			this.Visible = false;
			this.T.Enabled = false;
			this.T.Dispose();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000026C4 File Offset: 0x000008C4
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000026DA File Offset: 0x000008DA
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000026F0 File Offset: 0x000008F0
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00002706 File Offset: 0x00000906
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000271C File Offset: 0x0000091C
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.X = e.X;
			base.Invalidate();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00002737 File Offset: 0x00000937
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this.Visible = false;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00007E9C File Offset: 0x0000609C
		public FlatAlertBox()
		{
			this.State = MouseState.None;
			this.SuccessColor = Color.FromArgb(60, 85, 79);
			this.SuccessText = Color.FromArgb(35, 169, 110);
			this.ErrorColor = Color.FromArgb(87, 71, 71);
			this.ErrorText = Color.FromArgb(254, 142, 122);
			this.InfoColor = Color.FromArgb(70, 91, 94);
			this.InfoText = Color.FromArgb(97, 185, 186);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			base.Size = new Size(576, 42);
			base.Location = new Point(10, 61);
			this.Font = new Font("Segoe UI", 10f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00007F90 File Offset: 0x00006190
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
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				switch (this.K)
				{
				case FlatAlertBox._Kind.Success:
				{
					g.FillRectangle(new SolidBrush(this.SuccessColor), rect);
					g.FillEllipse(new SolidBrush(this.SuccessText), new Rectangle(8, 9, 24, 24));
					g.FillEllipse(new SolidBrush(this.SuccessColor), new Rectangle(10, 11, 20, 20));
					g.DrawString("ü", new Font("Wingdings", 22f), new SolidBrush(this.SuccessText), new Rectangle(7, 7, this.W, this.H), Helpers.NearSF);
					g.DrawString(this.Text, this.Font, new SolidBrush(this.SuccessText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
					g.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 30, this.H - 29, 17, 17));
					g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.SuccessColor), new Rectangle(this.W - 28, 16, this.W, this.H), Helpers.NearSF);
					MouseState state = this.State;
					if (state == MouseState.Over)
					{
						g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 28, 16, this.W, this.H), Helpers.NearSF);
					}
					break;
				}
				case FlatAlertBox._Kind.Error:
				{
					g.FillRectangle(new SolidBrush(this.ErrorColor), rect);
					g.FillEllipse(new SolidBrush(this.ErrorText), new Rectangle(8, 9, 24, 24));
					g.FillEllipse(new SolidBrush(this.ErrorColor), new Rectangle(10, 11, 20, 20));
					g.DrawString("r", new Font("Marlett", 16f), new SolidBrush(this.ErrorText), new Rectangle(6, 11, this.W, this.H), Helpers.NearSF);
					g.DrawString(this.Text, this.Font, new SolidBrush(this.ErrorText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
					g.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 32, this.H - 29, 17, 17));
					g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.ErrorColor), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
					MouseState state2 = this.State;
					if (state2 == MouseState.Over)
					{
						g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 30, 15, this.W, this.H), Helpers.NearSF);
					}
					break;
				}
				case FlatAlertBox._Kind.Info:
				{
					g.FillRectangle(new SolidBrush(this.InfoColor), rect);
					g.FillEllipse(new SolidBrush(this.InfoText), new Rectangle(8, 9, 24, 24));
					g.FillEllipse(new SolidBrush(this.InfoColor), new Rectangle(10, 11, 20, 20));
					g.DrawString("¡", new Font("Segoe UI", 20f, FontStyle.Bold), new SolidBrush(this.InfoText), new Rectangle(12, -4, this.W, this.H), Helpers.NearSF);
					g.DrawString(this.Text, this.Font, new SolidBrush(this.InfoText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
					g.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 32, this.H - 29, 17, 17));
					g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.InfoColor), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
					MouseState state3 = this.State;
					if (state3 == MouseState.Over)
					{
						g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
					}
					break;
				}
				}
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x04000061 RID: 97
		private int W;

		// Token: 0x04000062 RID: 98
		private int H;

		// Token: 0x04000063 RID: 99
		private FlatAlertBox._Kind K;

		// Token: 0x04000064 RID: 100
		private string _Text;

		// Token: 0x04000065 RID: 101
		private MouseState State;

		// Token: 0x04000066 RID: 102
		private int X;

		// Token: 0x04000068 RID: 104
		private Color SuccessColor;

		// Token: 0x04000069 RID: 105
		private Color SuccessText;

		// Token: 0x0400006A RID: 106
		private Color ErrorColor;

		// Token: 0x0400006B RID: 107
		private Color ErrorText;

		// Token: 0x0400006C RID: 108
		private Color InfoColor;

		// Token: 0x0400006D RID: 109
		private Color InfoText;

		// Token: 0x02000058 RID: 88
		[Flags]
		public enum _Kind
		{
			// Token: 0x04000307 RID: 775
			Success = 0,
			// Token: 0x04000308 RID: 776
			Error = 1,
			// Token: 0x04000309 RID: 777
			Info = 2
		}
	}
}
