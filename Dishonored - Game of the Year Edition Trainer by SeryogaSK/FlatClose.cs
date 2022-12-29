using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200000A RID: 10
	internal class FlatClose : Control
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000021A0 File Offset: 0x000003A0
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000021B6 File Offset: 0x000003B6
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000021CC File Offset: 0x000003CC
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000021E2 File Offset: 0x000003E2
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021F8 File Offset: 0x000003F8
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.X;
			base.Invalidate();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002213 File Offset: 0x00000413
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			Environment.Exit(0);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002222 File Offset: 0x00000422
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new Size(18, 18);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000053D8 File Offset: 0x000035D8
		// (set) Token: 0x06000030 RID: 48 RVA: 0x0000223A File Offset: 0x0000043A
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

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000053F0 File Offset: 0x000035F0
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002243 File Offset: 0x00000443
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

		// Token: 0x06000033 RID: 51 RVA: 0x00005408 File Offset: 0x00003608
		public FlatClose()
		{
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(50, 50, 50);
			this._TextColor = Color.FromArgb(220, 220, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			base.Size = new Size(18, 18);
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 12f);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00005498 File Offset: 0x00003698
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
			graphics2.DrawString("r", this.Font, new SolidBrush(this.TextColor), new Rectangle(0, 0, base.Width, base.Height), Helpers.CenterSF);
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

		// Token: 0x0400001D RID: 29
		private MouseState State;

		// Token: 0x0400001E RID: 30
		private int x;

		// Token: 0x0400001F RID: 31
		private Color _BaseColor;

		// Token: 0x04000020 RID: 32
		private Color _TextColor;
	}
}
