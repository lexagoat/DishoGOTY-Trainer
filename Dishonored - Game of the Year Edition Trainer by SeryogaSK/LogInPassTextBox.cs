using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200002F RID: 47
	[DefaultEvent("TextChanged")]
	public class LogInPassTextBox : Control
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000358C File Offset: 0x0000178C
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x00003594 File Offset: 0x00001794
		private virtual TextBox TB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x000147F0 File Offset: 0x000129F0
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x00014808 File Offset: 0x00012A08
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

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00014834 File Offset: 0x00012A34
		// (set) Token: 0x060002FA RID: 762 RVA: 0x0001484C File Offset: 0x00012A4C
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

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00014878 File Offset: 0x00012A78
		// (set) Token: 0x060002FC RID: 764 RVA: 0x0001488C File Offset: 0x00012A8C
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

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060002FD RID: 765 RVA: 0x000148B8 File Offset: 0x00012AB8
		// (set) Token: 0x060002FE RID: 766 RVA: 0x000148CC File Offset: 0x00012ACC
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

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060002FF RID: 767 RVA: 0x000148F8 File Offset: 0x00012AF8
		// (set) Token: 0x06000300 RID: 768 RVA: 0x0001490C File Offset: 0x00012B0C
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

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000301 RID: 769 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00014964 File Offset: 0x00012B64
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

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x06000304 RID: 772 RVA: 0x00014990 File Offset: 0x00012B90
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
						this.TB.Width = base.Width - 35;
						if (!this._Multiline)
						{
							base.Height = this.TB.Height + 11;
						}
					}
				}
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00014A00 File Offset: 0x00012C00
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.TB))
			{
				base.Controls.Add(this.TB);
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000359D File Offset: 0x0000179D
		private void OnBaseTextChanged(object sender, EventArgs e)
		{
			this.Text = this.TB.Text;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00014A3C File Offset: 0x00012C3C
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

		// Token: 0x06000308 RID: 776 RVA: 0x00014A9C File Offset: 0x00012C9C
		protected override void OnResize(EventArgs e)
		{
			this.TB.Location = new Point(5, 5);
			checked
			{
				this.TB.Width = base.Width - 35;
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

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00014B08 File Offset: 0x00012D08
		// (set) Token: 0x0600030A RID: 778 RVA: 0x000035B0 File Offset: 0x000017B0
		[Category("Colours")]
		public Color BackgroundColour
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

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00014B20 File Offset: 0x00012D20
		// (set) Token: 0x0600030C RID: 780 RVA: 0x000035B9 File Offset: 0x000017B9
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

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00014B38 File Offset: 0x00012D38
		// (set) Token: 0x0600030E RID: 782 RVA: 0x000035C2 File Offset: 0x000017C2
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

		// Token: 0x0600030F RID: 783 RVA: 0x000035CB File Offset: 0x000017CB
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000035E1 File Offset: 0x000017E1
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			base.Invalidate();
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00003603 File Offset: 0x00001803
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00014B50 File Offset: 0x00012D50
		public LogInPassTextBox()
		{
			this.State = MouseState.None;
			this._BaseColour = Color.FromArgb(255, 255, 255);
			this._TextColour = Color.FromArgb(50, 50, 50);
			this._BorderColour = Color.FromArgb(180, 187, 205);
			this._TextAlign = HorizontalAlignment.Left;
			this._MaxLength = 32767;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			this.TB = new TextBox();
			this.TB.Height = 190;
			this.TB.Font = new Font("Segoe UI", 10f);
			this.TB.Text = this.Text;
			this.TB.BackColor = Color.FromArgb(42, 42, 42);
			this.TB.ForeColor = Color.FromArgb(255, 255, 255);
			this.TB.MaxLength = this._MaxLength;
			this.TB.Multiline = false;
			this.TB.ReadOnly = this._ReadOnly;
			this.TB.UseSystemPasswordChar = this._UseSystemPasswordChar;
			this.TB.BorderStyle = BorderStyle.None;
			this.TB.Location = new Point(5, 5);
			this.TB.Width = checked(base.Width - 35);
			this.TB.TextChanged += this.OnBaseTextChanged;
			this.TB.KeyDown += this.OnBaseKeyDown;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00014CFC File Offset: 0x00012EFC
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			this.TB.BackColor = Color.FromArgb(42, 42, 42);
			this.TB.ForeColor = Color.FromArgb(255, 255, 255);
			GraphicsPath path = DrawHelpers.RoundRectangle(rectangle, 6);
			graphics2.FillPath(new SolidBrush(Color.FromArgb(42, 42, 42)), path);
			graphics2.DrawPath(new Pen(new SolidBrush(Color.FromArgb(35, 35, 35)), 2f), path);
			checked
			{
				graphics2.FillPie(new SolidBrush(base.FindForm().BackColor), new Rectangle(base.Width - 25, base.Height - 60, base.Height + 25, base.Height + 25), 90f, 90f);
				graphics2.DrawPie(new Pen(Color.FromArgb(35, 35, 35), 2f), new Rectangle(base.Width - 25, base.Height - 60, base.Height + 25, base.Height + 25), 90f, 90f);
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x0400019C RID: 412
		private MouseState State;

		// Token: 0x0400019E RID: 414
		private Color _BaseColour;

		// Token: 0x0400019F RID: 415
		private Color _TextColour;

		// Token: 0x040001A0 RID: 416
		private Color _BorderColour;

		// Token: 0x040001A1 RID: 417
		private HorizontalAlignment _TextAlign;

		// Token: 0x040001A2 RID: 418
		private int _MaxLength;

		// Token: 0x040001A3 RID: 419
		private bool _ReadOnly;

		// Token: 0x040001A4 RID: 420
		private bool _UseSystemPasswordChar;

		// Token: 0x040001A5 RID: 421
		private bool _Multiline;
	}
}
