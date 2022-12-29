using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000034 RID: 52
	[DefaultEvent("CheckedChanged")]
	public class LogInRadioButton : Control
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000371 RID: 881 RVA: 0x0001637C File Offset: 0x0001457C
		// (set) Token: 0x06000372 RID: 882 RVA: 0x0000383F File Offset: 0x00001A3F
		[Category("Colours")]
		public Color HighlightColour
		{
			get
			{
				return this._HoverColour;
			}
			set
			{
				this._HoverColour = value;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00016394 File Offset: 0x00014594
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00003848 File Offset: 0x00001A48
		[Category("Colours")]
		public Color BaseColour
		{
			get
			{
				return this._BackColour;
			}
			set
			{
				this._BackColour = value;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000375 RID: 885 RVA: 0x000163AC File Offset: 0x000145AC
		// (set) Token: 0x06000376 RID: 886 RVA: 0x00003851 File Offset: 0x00001A51
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

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000377 RID: 887 RVA: 0x000163C4 File Offset: 0x000145C4
		// (set) Token: 0x06000378 RID: 888 RVA: 0x0000385A File Offset: 0x00001A5A
		[Category("Colours")]
		public Color CheckedColour
		{
			get
			{
				return this._CheckedColour;
			}
			set
			{
				this._CheckedColour = value;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000379 RID: 889 RVA: 0x000163DC File Offset: 0x000145DC
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00003863 File Offset: 0x00001A63
		[Category("Colours")]
		public Color FontColour
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

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600037B RID: 891 RVA: 0x000163F4 File Offset: 0x000145F4
		// (remove) Token: 0x0600037C RID: 892 RVA: 0x0001642C File Offset: 0x0001462C
		public event LogInRadioButton.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600037D RID: 893 RVA: 0x00016464 File Offset: 0x00014664
		// (set) Token: 0x0600037E RID: 894 RVA: 0x00016478 File Offset: 0x00014678
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
				LogInRadioButton.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
				if (checkedChangedEvent != null)
				{
					checkedChangedEvent(this);
				}
				base.Invalidate();
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x000164AC File Offset: 0x000146AC
		protected override void OnClick(EventArgs e)
		{
			if (!this._Checked)
			{
				this.Checked = true;
			}
			base.OnClick(e);
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000164D4 File Offset: 0x000146D4
		private void InvalidateControls()
		{
			if (base.IsHandleCreated && this._Checked)
			{
				try
				{
					foreach (object obj in base.Parent.Controls)
					{
						Control control = (Control)obj;
						if (control != this && control is LogInRadioButton)
						{
							((LogInRadioButton)control).Checked = false;
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

		// Token: 0x06000381 RID: 897 RVA: 0x0000386C File Offset: 0x00001A6C
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.InvalidateControls();
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00002484 File Offset: 0x00000684
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 22;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000387A File Offset: 0x00001A7A
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00003890 File Offset: 0x00001A90
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000038A6 File Offset: 0x00001AA6
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000386 RID: 902 RVA: 0x000038BC File Offset: 0x00001ABC
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0001656C File Offset: 0x0001476C
		public LogInRadioButton()
		{
			this.State = MouseState.None;
			this._HoverColour = Color.FromArgb(50, 49, 51);
			this._CheckedColour = Color.FromArgb(173, 173, 174);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._BackColour = Color.FromArgb(42, 42, 42);
			this._TextColour = Color.FromArgb(255, 255, 255);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Cursor = Cursors.Hand;
			base.Size = new Size(100, 22);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0001661C File Offset: 0x0001481C
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			checked
			{
				Rectangle rect = new Rectangle(1, 1, base.Height - 2, base.Height - 2);
				Rectangle rect2 = new Rectangle(6, 6, base.Height - 12, base.Height - 12);
				Rectangle rectangle = new Rectangle(4, 3, 14, 14);
				Graphics graphics2 = graphics;
				graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				graphics2.SmoothingMode = SmoothingMode.HighQuality;
				graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics2.Clear(Color.Transparent);
				graphics2.FillEllipse(new SolidBrush(this._BackColour), rect);
				graphics2.DrawEllipse(new Pen(this._BorderColour, 2f), rect);
				if (this.Checked)
				{
					MouseState state = this.State;
					if (state == MouseState.Over)
					{
						graphics2.FillEllipse(new SolidBrush(this._HoverColour), new Rectangle(2, 2, base.Height - 4, base.Height - 4));
					}
					graphics2.FillEllipse(new SolidBrush(this._CheckedColour), rect2);
				}
				else
				{
					MouseState state2 = this.State;
					if (state2 == MouseState.Over)
					{
						graphics2.FillEllipse(new SolidBrush(this._HoverColour), new Rectangle(2, 2, base.Height - 4, base.Height - 4));
					}
				}
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColour), new Rectangle(24, 3, base.Width, base.Height), new StringFormat
				{
					Alignment = StringAlignment.Near,
					LineAlignment = StringAlignment.Near
				});
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001C8 RID: 456
		private bool _Checked;

		// Token: 0x040001C9 RID: 457
		private MouseState State;

		// Token: 0x040001CA RID: 458
		private Color _HoverColour;

		// Token: 0x040001CB RID: 459
		private Color _CheckedColour;

		// Token: 0x040001CC RID: 460
		private Color _BorderColour;

		// Token: 0x040001CD RID: 461
		private Color _BackColour;

		// Token: 0x040001CE RID: 462
		private Color _TextColour;

		// Token: 0x02000060 RID: 96
		// (Invoke) Token: 0x060006AD RID: 1709
		public delegate void CheckedChangedEventHandler(object sender);
	}
}
