using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000042 RID: 66
	public class LogInComboBox : ComboBox
	{
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x00019A94 File Offset: 0x00017C94
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x00003DD8 File Offset: 0x00001FD8
		[Category("Colours")]
		public Color LineColour
		{
			get
			{
				return this._LineColour;
			}
			set
			{
				this._LineColour = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x00019AAC File Offset: 0x00017CAC
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x00003DE1 File Offset: 0x00001FE1
		[Category("Colours")]
		public Color SqaureColour
		{
			get
			{
				return this._SqaureColour;
			}
			set
			{
				this._SqaureColour = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x00019AC4 File Offset: 0x00017CC4
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x00003DEA File Offset: 0x00001FEA
		[Category("Colours")]
		public Color ArrowColour
		{
			get
			{
				return this._ArrowColour;
			}
			set
			{
				this._ArrowColour = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x00019ADC File Offset: 0x00017CDC
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x00003DF3 File Offset: 0x00001FF3
		[Category("Colours")]
		public Color SqaureHoverColour
		{
			get
			{
				return this._SqaureHoverColour;
			}
			set
			{
				this._SqaureHoverColour = value;
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00003DFC File Offset: 0x00001FFC
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00003E12 File Offset: 0x00002012
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x00019AF4 File Offset: 0x00017CF4
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00003E28 File Offset: 0x00002028
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

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00019B0C File Offset: 0x00017D0C
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x00003E31 File Offset: 0x00002031
		[Category("Colours")]
		public Color BaseColour
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

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00019B24 File Offset: 0x00017D24
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00003E3A File Offset: 0x0000203A
		[Category("Colours")]
		public Color FontColour
		{
			get
			{
				return this._FontColour;
			}
			set
			{
				this._FontColour = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00019B3C File Offset: 0x00017D3C
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x00019B54 File Offset: 0x00017D54
		public int StartIndex
		{
			get
			{
				return this._StartIndex;
			}
			set
			{
				this._StartIndex = value;
				try
				{
					base.SelectedIndex = value;
				}
				catch (Exception ex)
				{
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00003E43 File Offset: 0x00002043
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00003E52 File Offset: 0x00002052
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.Invalidate();
			base.OnMouseClick(e);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00003E61 File Offset: 0x00002061
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00019B94 File Offset: 0x00017D94
		public void ReplaceItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			checked
			{
				Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 1, e.Bounds.Height + 1);
				try
				{
					Graphics graphics = e.Graphics;
					if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
					{
						graphics.FillRectangle(new SolidBrush(this._SqaureColour), rect);
						graphics.DrawString(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), this.Font, new SolidBrush(this._FontColour), 1f, (float)(e.Bounds.Top + 2));
					}
					else
					{
						graphics.FillRectangle(new SolidBrush(this._BaseColour), rect);
						graphics.DrawString(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), this.Font, new SolidBrush(this._FontColour), 1f, (float)(e.Bounds.Top + 2));
					}
				}
				catch (Exception ex)
				{
				}
				e.DrawFocusRectangle();
				base.Invalidate();
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00019CF0 File Offset: 0x00017EF0
		public LogInComboBox()
		{
			base.DrawItem += this.ReplaceItem;
			this._StartIndex = 0;
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._FontColour = Color.FromArgb(255, 255, 255);
			this._LineColour = Color.FromArgb(23, 119, 151);
			this._SqaureColour = Color.FromArgb(47, 47, 47);
			this._ArrowColour = Color.FromArgb(30, 30, 30);
			this._SqaureHoverColour = Color.FromArgb(52, 52, 52);
			this.State = MouseState.None;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			base.Width = 163;
			this.Font = new Font("Segoe UI", 10f);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00019DF4 File Offset: 0x00017FF4
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			checked
			{
				try
				{
					Rectangle rect = new Rectangle(base.Width - 25, 0, base.Width, base.Height);
					graphics2.FillRectangle(new SolidBrush(this._BaseColour), new Rectangle(0, 0, base.Width - 25, base.Height));
					MouseState state = this.State;
					if (state != MouseState.None)
					{
						if (state == MouseState.Over)
						{
							graphics2.FillRectangle(new SolidBrush(this._SqaureHoverColour), rect);
						}
					}
					else
					{
						graphics2.FillRectangle(new SolidBrush(this._SqaureColour), rect);
					}
					graphics2.DrawLine(new Pen(this._LineColour, 2f), new Point(base.Width - 26, 1), new Point(base.Width - 26, base.Height - 1));
					try
					{
						graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._FontColour), new Rectangle(3, 0, base.Width - 20, base.Height), new StringFormat
						{
							LineAlignment = StringAlignment.Center,
							Alignment = StringAlignment.Near
						});
					}
					catch (Exception ex)
					{
					}
					graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), new Rectangle(0, 0, base.Width, base.Height));
					Point[] points = new Point[]
					{
						new Point(base.Width - 17, 11),
						new Point(base.Width - 13, 5),
						new Point(base.Width - 9, 11)
					};
					graphics2.FillPolygon(new SolidBrush(this._BorderColour), points);
					graphics2.DrawPolygon(new Pen(this._ArrowColour), points);
					Point[] points2 = new Point[]
					{
						new Point(base.Width - 17, 15),
						new Point(base.Width - 13, 21),
						new Point(base.Width - 9, 15)
					};
					graphics2.FillPolygon(new SolidBrush(this._BorderColour), points2);
					graphics2.DrawPolygon(new Pen(this._ArrowColour), points2);
				}
				catch (Exception ex2)
				{
				}
				graphics2 = null;
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x0400021E RID: 542
		private int _StartIndex;

		// Token: 0x0400021F RID: 543
		private Color _BorderColour;

		// Token: 0x04000220 RID: 544
		private Color _BaseColour;

		// Token: 0x04000221 RID: 545
		private Color _FontColour;

		// Token: 0x04000222 RID: 546
		private Color _LineColour;

		// Token: 0x04000223 RID: 547
		private Color _SqaureColour;

		// Token: 0x04000224 RID: 548
		private Color _ArrowColour;

		// Token: 0x04000225 RID: 549
		private Color _SqaureHoverColour;

		// Token: 0x04000226 RID: 550
		private MouseState State;
	}
}
