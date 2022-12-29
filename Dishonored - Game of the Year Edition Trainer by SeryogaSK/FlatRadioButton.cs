using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000010 RID: 16
	[DefaultEvent("CheckedChanged")]
	internal class FlatRadioButton : Control
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000070 RID: 112 RVA: 0x0000676C File Offset: 0x0000496C
		// (remove) Token: 0x06000071 RID: 113 RVA: 0x000067A4 File Offset: 0x000049A4
		public event FlatRadioButton.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000067DC File Offset: 0x000049DC
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000067F0 File Offset: 0x000049F0
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				this.InvalidateControls();
				FlatRadioButton.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
				if (checkedChangedEvent != null)
				{
					checkedChangedEvent(this);
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00006824 File Offset: 0x00004A24
		protected override void OnClick(EventArgs e)
		{
			if (!this._Checked)
			{
				this.Checked = true;
			}
			base.OnClick(e);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000684C File Offset: 0x00004A4C
		private void InvalidateControls()
		{
			if (base.IsHandleCreated && this._Checked)
			{
				try
				{
					foreach (object obj in base.Parent.Controls)
					{
						Control control = (Control)obj;
						if (control != this && control is RadioButton)
						{
							((RadioButton)control).Checked = false;
							base.Invalidate();
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
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000246D File Offset: 0x0000066D
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.InvalidateControls();
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000068E4 File Offset: 0x00004AE4
		// (set) Token: 0x06000078 RID: 120 RVA: 0x0000247B File Offset: 0x0000067B
		[Category("Options")]
		public FlatRadioButton._Options Options
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

		// Token: 0x06000079 RID: 121 RVA: 0x00002484 File Offset: 0x00000684
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 22;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000068FC File Offset: 0x00004AFC
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00002495 File Offset: 0x00000695
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

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00006914 File Offset: 0x00004B14
		// (set) Token: 0x0600007D RID: 125 RVA: 0x0000249E File Offset: 0x0000069E
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

		// Token: 0x0600007E RID: 126 RVA: 0x000024A7 File Offset: 0x000006A7
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000024BD File Offset: 0x000006BD
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000024D3 File Offset: 0x000006D3
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000024E9 File Offset: 0x000006E9
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000692C File Offset: 0x00004B2C
		public FlatRadioButton()
		{
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(60, 60, 60);
			this._BorderColor = Color.FromArgb(0, 170, 220);
			this._TextColor = Color.FromArgb(243, 243, 243);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Cursor = Cursors.Hand;
			base.Size = new Size(100, 22);
			this.BackColor = Color.FromArgb(50, 50, 50);
			this.Font = new Font("Segoe UI", 10f);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000069DC File Offset: 0x00004BDC
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = base.Width - 1;
				this.H = base.Height - 1;
				Rectangle rect = new Rectangle(0, 2, base.Height - 5, base.Height - 5);
				Rectangle rect2 = new Rectangle(4, 6, this.H - 12, this.H - 12);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				FlatRadioButton._Options o = this.O;
				if (o != FlatRadioButton._Options.Style1)
				{
					if (o == FlatRadioButton._Options.Style2)
					{
						g.FillEllipse(new SolidBrush(this._BaseColor), rect);
						MouseState state = this.State;
						if (state != MouseState.Over)
						{
							if (state == MouseState.Down)
							{
								g.DrawEllipse(new Pen(this._BorderColor), rect);
								g.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
							}
						}
						else
						{
							g.DrawEllipse(new Pen(this._BorderColor), rect);
							g.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
						}
						if (this.Checked)
						{
							g.FillEllipse(new SolidBrush(this._BorderColor), rect2);
						}
						if (!base.Enabled)
						{
							g.FillEllipse(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
							g.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(48, 119, 91)), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
						}
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
					}
				}
				else
				{
					g.FillEllipse(new SolidBrush(this._BaseColor), rect);
					MouseState state2 = this.State;
					if (state2 != MouseState.Over)
					{
						if (state2 == MouseState.Down)
						{
							g.DrawEllipse(new Pen(this._BorderColor), rect);
						}
					}
					else
					{
						g.DrawEllipse(new Pen(this._BorderColor), rect);
					}
					if (this.Checked)
					{
						g.FillEllipse(new SolidBrush(this._BorderColor), rect2);
					}
					if (!base.Enabled)
					{
						g.FillEllipse(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
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

		// Token: 0x0400003E RID: 62
		private MouseState State;

		// Token: 0x0400003F RID: 63
		private int W;

		// Token: 0x04000040 RID: 64
		private int H;

		// Token: 0x04000041 RID: 65
		private FlatRadioButton._Options O;

		// Token: 0x04000042 RID: 66
		private bool _Checked;

		// Token: 0x04000044 RID: 68
		private Color _BaseColor;

		// Token: 0x04000045 RID: 69
		private Color _BorderColor;

		// Token: 0x04000046 RID: 70
		private Color _TextColor;

		// Token: 0x02000054 RID: 84
		// (Invoke) Token: 0x06000686 RID: 1670
		public delegate void CheckedChangedEventHandler(object sender);

		// Token: 0x02000055 RID: 85
		[Flags]
		public enum _Options
		{
			// Token: 0x04000301 RID: 769
			Style1 = 0,
			// Token: 0x04000302 RID: 770
			Style2 = 1
		}
	}
}
