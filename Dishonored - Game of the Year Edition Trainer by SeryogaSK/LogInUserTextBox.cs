using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200002E RID: 46
	[DefaultEvent("TextChanged")]
	public class LogInUserTextBox : Control
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x000034FF File Offset: 0x000016FF
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00003507 File Offset: 0x00001707
		private virtual TextBox TB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0001414C File Offset: 0x0001234C
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00014164 File Offset: 0x00012364
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

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00014190 File Offset: 0x00012390
		// (set) Token: 0x060002DB RID: 731 RVA: 0x000141A8 File Offset: 0x000123A8
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

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002DC RID: 732 RVA: 0x000141D4 File Offset: 0x000123D4
		// (set) Token: 0x060002DD RID: 733 RVA: 0x000141E8 File Offset: 0x000123E8
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

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00014214 File Offset: 0x00012414
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00014228 File Offset: 0x00012428
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

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00014254 File Offset: 0x00012454
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00014268 File Offset: 0x00012468
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

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x000142C0 File Offset: 0x000124C0
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

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x000142EC File Offset: 0x000124EC
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

		// Token: 0x060002E6 RID: 742 RVA: 0x0001435C File Offset: 0x0001255C
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.TB))
			{
				base.Controls.Add(this.TB);
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00003510 File Offset: 0x00001710
		private void OnBaseTextChanged(object sender, EventArgs e)
		{
			this.Text = this.TB.Text;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00014398 File Offset: 0x00012598
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

		// Token: 0x060002E9 RID: 745 RVA: 0x000143F8 File Offset: 0x000125F8
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

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00014464 File Offset: 0x00012664
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00003523 File Offset: 0x00001723
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

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002EC RID: 748 RVA: 0x0001447C File Offset: 0x0001267C
		// (set) Token: 0x060002ED RID: 749 RVA: 0x0000352C File Offset: 0x0000172C
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

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00014494 File Offset: 0x00012694
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00003535 File Offset: 0x00001735
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

		// Token: 0x060002F0 RID: 752 RVA: 0x0000353E File Offset: 0x0000173E
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00003554 File Offset: 0x00001754
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			base.Invalidate();
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00003576 File Offset: 0x00001776
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x000144AC File Offset: 0x000126AC
		public LogInUserTextBox()
		{
			this.State = MouseState.None;
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._BorderColour = Color.FromArgb(35, 35, 35);
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

		// Token: 0x060002F4 RID: 756 RVA: 0x0001464C File Offset: 0x0001284C
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
				graphics2.FillPie(new SolidBrush(base.FindForm().BackColor), new Rectangle(base.Width - 25, base.Height - 23, base.Height + 25, base.Height + 25), 180f, 90f);
				graphics2.DrawPie(new Pen(Color.FromArgb(35, 35, 35), 2f), new Rectangle(base.Width - 25, base.Height - 23, base.Height + 25, base.Height + 25), 180f, 90f);
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x04000192 RID: 402
		private MouseState State;

		// Token: 0x04000194 RID: 404
		private Color _BaseColour;

		// Token: 0x04000195 RID: 405
		private Color _TextColour;

		// Token: 0x04000196 RID: 406
		private Color _BorderColour;

		// Token: 0x04000197 RID: 407
		private HorizontalAlignment _TextAlign;

		// Token: 0x04000198 RID: 408
		private int _MaxLength;

		// Token: 0x04000199 RID: 409
		private bool _ReadOnly;

		// Token: 0x0400019A RID: 410
		private bool _UseSystemPasswordChar;

		// Token: 0x0400019B RID: 411
		private bool _Multiline;
	}
}
