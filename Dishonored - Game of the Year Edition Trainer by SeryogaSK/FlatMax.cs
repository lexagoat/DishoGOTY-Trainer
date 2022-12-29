using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200000B RID: 11
	internal class FlatMax : Control
	{
		// Token: 0x06000035 RID: 53 RVA: 0x0000224C File Offset: 0x0000044C
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002262 File Offset: 0x00000462
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002278 File Offset: 0x00000478
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000228E File Offset: 0x0000048E
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000022A4 File Offset: 0x000004A4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.X;
			base.Invalidate();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000055B8 File Offset: 0x000037B8
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			FormWindowState windowState = base.FindForm().WindowState;
			if (windowState != FormWindowState.Normal)
			{
				if (windowState == FormWindowState.Maximized)
				{
					base.FindForm().WindowState = FormWindowState.Normal;
				}
			}
			else
			{
				base.FindForm().WindowState = FormWindowState.Maximized;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000055FC File Offset: 0x000037FC
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000022BF File Offset: 0x000004BF
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

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00005614 File Offset: 0x00003814
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000022C8 File Offset: 0x000004C8
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

		// Token: 0x0600003F RID: 63 RVA: 0x00002222 File Offset: 0x00000422
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new Size(18, 18);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000562C File Offset: 0x0000382C
		public FlatMax()
		{
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(50, 50, 50);
			this._TextColor = Color.FromArgb(243, 243, 243);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			base.Size = new Size(18, 18);
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 12f);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000056BC File Offset: 0x000038BC
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			if (base.FindForm().WindowState == FormWindowState.Maximized)
			{
				graphics2.DrawString("1", this.Font, new SolidBrush(this.TextColor), new Rectangle(1, 1, base.Width, base.Height), Helpers.CenterSF);
			}
			else if (base.FindForm().WindowState == FormWindowState.Normal)
			{
				graphics2.DrawString("2", this.Font, new SolidBrush(this.TextColor), new Rectangle(1, 1, base.Width, base.Height), Helpers.CenterSF);
			}
			MouseState state = this.State;
			if (state != MouseState.Over)
			{
				if (state == MouseState.Down)
				{
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
				}
			}
			else
			{
				graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x04000021 RID: 33
		private MouseState State;

		// Token: 0x04000022 RID: 34
		private int x;

		// Token: 0x04000023 RID: 35
		private Color _BaseColor;

		// Token: 0x04000024 RID: 36
		private Color _TextColor;
	}
}
