using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000032 RID: 50
	public class LogInNormalTextBox : Control
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00003753 File Offset: 0x00001953
		// (set) Token: 0x0600033F RID: 831 RVA: 0x0000375B File Offset: 0x0000195B
		private virtual TextBox TB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x06000340 RID: 832 RVA: 0x00003764 File Offset: 0x00001964
		public void SelectAll()
		{
			this.TB.Focus();
			this.TB.SelectAll();
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000341 RID: 833 RVA: 0x00015714 File Offset: 0x00013914
		// (set) Token: 0x06000342 RID: 834 RVA: 0x0001572C File Offset: 0x0001392C
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

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000343 RID: 835 RVA: 0x00015758 File Offset: 0x00013958
		// (set) Token: 0x06000344 RID: 836 RVA: 0x00015770 File Offset: 0x00013970
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

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000345 RID: 837 RVA: 0x0001579C File Offset: 0x0001399C
		// (set) Token: 0x06000346 RID: 838 RVA: 0x000157B0 File Offset: 0x000139B0
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

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000347 RID: 839 RVA: 0x000157DC File Offset: 0x000139DC
		// (set) Token: 0x06000348 RID: 840 RVA: 0x000157F0 File Offset: 0x000139F0
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

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000349 RID: 841 RVA: 0x0001581C File Offset: 0x00013A1C
		// (set) Token: 0x0600034A RID: 842 RVA: 0x00015830 File Offset: 0x00013A30
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

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600034B RID: 843 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x0600034C RID: 844 RVA: 0x00015888 File Offset: 0x00013A88
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

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x0600034E RID: 846 RVA: 0x000158B4 File Offset: 0x00013AB4
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

		// Token: 0x0600034F RID: 847 RVA: 0x00015924 File Offset: 0x00013B24
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.TB))
			{
				base.Controls.Add(this.TB);
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000377D File Offset: 0x0000197D
		private void OnBaseTextChanged(object sender, EventArgs e)
		{
			this.Text = this.TB.Text;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00015960 File Offset: 0x00013B60
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

		// Token: 0x06000352 RID: 850 RVA: 0x000159C0 File Offset: 0x00013BC0
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

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00015A2C File Offset: 0x00013C2C
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00003790 File Offset: 0x00001990
		public LogInNormalTextBox.Styles Style
		{
			get
			{
				return this._Style;
			}
			set
			{
				this._Style = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00015A44 File Offset: 0x00013C44
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00003799 File Offset: 0x00001999
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

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00015A5C File Offset: 0x00013C5C
		// (set) Token: 0x06000358 RID: 856 RVA: 0x000037A2 File Offset: 0x000019A2
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

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00015A74 File Offset: 0x00013C74
		// (set) Token: 0x0600035A RID: 858 RVA: 0x000037AB File Offset: 0x000019AB
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

		// Token: 0x0600035B RID: 859 RVA: 0x000037B4 File Offset: 0x000019B4
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000037CA File Offset: 0x000019CA
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			base.Invalidate();
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000037EC File Offset: 0x000019EC
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00015A8C File Offset: 0x00013C8C
		public LogInNormalTextBox()
		{
			this.State = MouseState.None;
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._Style = LogInNormalTextBox.Styles.NotRounded;
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

		// Token: 0x0600035F RID: 863 RVA: 0x00015C34 File Offset: 0x00013E34
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
			LogInNormalTextBox.Styles style = this._Style;
			if (style != LogInNormalTextBox.Styles.Rounded)
			{
				if (style == LogInNormalTextBox.Styles.NotRounded)
				{
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(42, 42, 42)), checked(new Rectangle(0, 0, base.Width - 1, base.Height - 1)));
					graphics2.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(35, 35, 35)), 2f), new Rectangle(0, 0, base.Width, base.Height));
				}
			}
			else
			{
				GraphicsPath path = DrawHelpers.RoundRectangle(rectangle, 6);
				graphics2.FillPath(new SolidBrush(Color.FromArgb(42, 42, 42)), path);
				graphics2.DrawPath(new Pen(new SolidBrush(Color.FromArgb(35, 35, 35)), 2f), path);
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040001B5 RID: 437
		private MouseState State;

		// Token: 0x040001B7 RID: 439
		private Color _BaseColour;

		// Token: 0x040001B8 RID: 440
		private Color _TextColour;

		// Token: 0x040001B9 RID: 441
		private Color _BorderColour;

		// Token: 0x040001BA RID: 442
		private LogInNormalTextBox.Styles _Style;

		// Token: 0x040001BB RID: 443
		private HorizontalAlignment _TextAlign;

		// Token: 0x040001BC RID: 444
		private int _MaxLength;

		// Token: 0x040001BD RID: 445
		private bool _ReadOnly;

		// Token: 0x040001BE RID: 446
		private bool _UseSystemPasswordChar;

		// Token: 0x040001BF RID: 447
		private bool _Multiline;

		// Token: 0x0200005F RID: 95
		public enum Styles
		{
			// Token: 0x04000316 RID: 790
			Rounded,
			// Token: 0x04000317 RID: 791
			NotRounded
		}
	}
}
