using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000041 RID: 65
	public class LogInOnOffSwitch : Control
	{
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00019380 File Offset: 0x00017580
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x00003D9C File Offset: 0x00001F9C
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

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00019398 File Offset: 0x00017598
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x00003DA5 File Offset: 0x00001FA5
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

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x000193B0 File Offset: 0x000175B0
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x00003DAE File Offset: 0x00001FAE
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

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x000193C8 File Offset: 0x000175C8
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x00003DB7 File Offset: 0x00001FB7
		[Category("Colours")]
		public Color NonToggledTextColourderColour
		{
			get
			{
				return this._NonToggledTextColour;
			}
			set
			{
				this._NonToggledTextColour = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x000193E0 File Offset: 0x000175E0
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x00003DC0 File Offset: 0x00001FC0
		[Category("Colours")]
		public Color ToggledColour
		{
			get
			{
				return this._ToggledColour;
			}
			set
			{
				this._ToggledColour = value;
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600045B RID: 1115 RVA: 0x000193F8 File Offset: 0x000175F8
		// (remove) Token: 0x0600045C RID: 1116 RVA: 0x00019430 File Offset: 0x00017630
		public event LogInOnOffSwitch.ToggledChangedEventHandler ToggledChanged;

		// Token: 0x0600045D RID: 1117 RVA: 0x00019468 File Offset: 0x00017668
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.MouseXLoc = e.Location.X;
			base.Invalidate();
			if (e.X < checked(base.Width - 40) && e.X > 40)
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Arrow;
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x000194D0 File Offset: 0x000176D0
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (this.MouseXLoc > checked(base.Width - 39))
			{
				this._Toggled = LogInOnOffSwitch.Toggles.Toggled;
				this.ToggledValue();
			}
			else if (this.MouseXLoc < 39)
			{
				this._Toggled = LogInOnOffSwitch.Toggles.NotToggled;
				this.ToggledValue();
			}
			base.Invalidate();
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x00019528 File Offset: 0x00017728
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x00003DC9 File Offset: 0x00001FC9
		public LogInOnOffSwitch.Toggles Toggled
		{
			get
			{
				return this._Toggled;
			}
			set
			{
				this._Toggled = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00019540 File Offset: 0x00017740
		private void ToggledValue()
		{
			checked
			{
				if (this._Toggled > LogInOnOffSwitch.Toggles.Toggled)
				{
					if (this.ToggleLocation < 100)
					{
						ref int ptr = ref this.ToggleLocation;
						this.ToggleLocation = ptr + 10;
					}
				}
				else if (this.ToggleLocation > 0)
				{
					ref int ptr = ref this.ToggleLocation;
					this.ToggleLocation = ptr - 10;
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00019594 File Offset: 0x00017794
		public LogInOnOffSwitch()
		{
			this._Toggled = LogInOnOffSwitch.Toggles.NotToggled;
			this.ToggleLocation = 0;
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._NonToggledTextColour = Color.FromArgb(155, 155, 155);
			this._ToggledColour = Color.FromArgb(23, 119, 151);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0001962C File Offset: 0x0001782C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(base.Parent.FindForm().BackColor);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.FillRectangle(new SolidBrush(this._BaseColour), new Rectangle(0, 0, 39, base.Height));
			checked
			{
				graphics.FillRectangle(new SolidBrush(this._BaseColour), new Rectangle(base.Width - 40, 0, base.Width, base.Height));
				graphics.FillRectangle(new SolidBrush(this._BaseColour), new Rectangle(38, 9, base.Width - 40, 5));
				Point[] points = new Point[]
				{
					new Point(0, 0),
					new Point(39, 0),
					new Point(39, 9),
					new Point(base.Width - 40, 9),
					new Point(base.Width - 40, 0),
					new Point(base.Width - 2, 0),
					new Point(base.Width - 2, base.Height - 1),
					new Point(base.Width - 40, base.Height - 1),
					new Point(base.Width - 40, 14),
					new Point(39, 14),
					new Point(39, base.Height - 1),
					new Point(0, base.Height - 1),
					default(Point)
				};
				graphics.DrawLines(new Pen(this._BorderColour, 2f), points);
				if (this._Toggled == LogInOnOffSwitch.Toggles.Toggled)
				{
					graphics.FillRectangle(new SolidBrush(this._ToggledColour), new Rectangle((int)Math.Round((double)base.Width / 2.0), 10, (int)Math.Round(unchecked((double)base.Width / 2.0 - 38.0)), 3));
					graphics.FillRectangle(new SolidBrush(this._ToggledColour), new Rectangle(base.Width - 39, 2, 36, base.Height - 5));
				}
				if (this._Toggled == LogInOnOffSwitch.Toggles.Toggled)
				{
					graphics.DrawString("ON", new Font("Microsoft Sans Serif", 7f, FontStyle.Bold), new SolidBrush(this._TextColour), new Rectangle(2, -1, (int)Math.Round(unchecked((double)(checked(base.Width - 20)) + 6.666666666666667)), base.Height), new StringFormat
					{
						Alignment = StringAlignment.Far,
						LineAlignment = StringAlignment.Center
					});
					graphics.DrawString("OFF", new Font("Microsoft Sans Serif", 7f, FontStyle.Bold), new SolidBrush(this._NonToggledTextColour), new Rectangle(7, -1, (int)Math.Round(unchecked((double)(checked(base.Width - 20)) + 6.666666666666667)), base.Height), new StringFormat
					{
						Alignment = StringAlignment.Near,
						LineAlignment = StringAlignment.Center
					});
				}
				else if (this._Toggled == LogInOnOffSwitch.Toggles.NotToggled)
				{
					graphics.DrawString("OFF", new Font("Microsoft Sans Serif", 7f, FontStyle.Bold), new SolidBrush(this._TextColour), new Rectangle(7, -1, (int)Math.Round(unchecked((double)(checked(base.Width - 20)) + 6.666666666666667)), base.Height), new StringFormat
					{
						Alignment = StringAlignment.Near,
						LineAlignment = StringAlignment.Center
					});
					graphics.DrawString("ON", new Font("Microsoft Sans Serif", 7f, FontStyle.Bold), new SolidBrush(this._NonToggledTextColour), new Rectangle(2, -1, (int)Math.Round(unchecked((double)(checked(base.Width - 20)) + 6.666666666666667)), base.Height), new StringFormat
					{
						Alignment = StringAlignment.Far,
						LineAlignment = StringAlignment.Center
					});
				}
				graphics.DrawLine(new Pen(this._BorderColour, 2f), new Point((int)Math.Round((double)base.Width / 2.0), 0), new Point((int)Math.Round((double)base.Width / 2.0), base.Height));
			}
		}

		// Token: 0x04000215 RID: 533
		private LogInOnOffSwitch.Toggles _Toggled;

		// Token: 0x04000216 RID: 534
		private int MouseXLoc;

		// Token: 0x04000217 RID: 535
		private int ToggleLocation;

		// Token: 0x04000218 RID: 536
		private Color _BaseColour;

		// Token: 0x04000219 RID: 537
		private Color _BorderColour;

		// Token: 0x0400021A RID: 538
		private Color _TextColour;

		// Token: 0x0400021B RID: 539
		private Color _NonToggledTextColour;

		// Token: 0x0400021C RID: 540
		private Color _ToggledColour;

		// Token: 0x02000064 RID: 100
		public enum Toggles
		{
			// Token: 0x04000323 RID: 803
			Toggled,
			// Token: 0x04000324 RID: 804
			NotToggled
		}

		// Token: 0x02000065 RID: 101
		// (Invoke) Token: 0x060006B1 RID: 1713
		public delegate void ToggledChangedEventHandler();
	}
}
